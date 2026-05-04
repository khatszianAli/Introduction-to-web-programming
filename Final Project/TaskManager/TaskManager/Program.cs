using Microsoft.EntityFrameworkCore;
using TaskManager.Components;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using TaskManager.Models;
using TaskManager.Services;
using Microsoft.EntityFrameworkCore.Diagnostics;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAntiforgery(); 
// Включаем систему авторизации через Cookie
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.Cookie.Name = "TaskManagerAuth";
        options.LoginPath = "/login"; // Куда отправлять неавторизованных
        options.Cookie.MaxAge = TimeSpan.FromDays(7); 
    });
builder.Services.AddAuthorization();
builder.Services.AddCascadingAuthenticationState(); 
builder.Services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();
builder.Services.AddScoped<CurrentUserService>();
// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddDbContext<AppDbContext>(options =>
    options
        .UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
        .ConfigureWarnings(w => w.Ignore(RelationalEventId.PendingModelChangesWarning)),
    contextLifetime: ServiceLifetime.Transient,
    optionsLifetime: ServiceLifetime.Singleton);
builder.Services.AddDbContextFactory<AppDbContext>(options =>
    options
        .UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
        .ConfigureWarnings(w => w.Ignore(RelationalEventId.PendingModelChangesWarning)));
var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.Migrate();

    // Lightweight schema bootstrap for collaborative group features.
    db.Database.ExecuteSqlRaw("""
        IF COL_LENGTH('Tasks', 'GroupId') IS NULL
            ALTER TABLE [Tasks] ADD [GroupId] int NULL;
        IF COL_LENGTH('Tasks', 'Status') IS NULL
            ALTER TABLE [Tasks] ADD [Status] nvarchar(32) NOT NULL CONSTRAINT [DF_Tasks_Status] DEFAULT N'todo';
        IF COL_LENGTH('Groups', 'Description') IS NULL
            ALTER TABLE [Groups] ADD [Description] nvarchar(max) NOT NULL CONSTRAINT [DF_Groups_Description] DEFAULT N'';
        IF COL_LENGTH('Groups', 'GroupUsername') IS NULL
            ALTER TABLE [Groups] ADD [GroupUsername] nvarchar(64) NULL;
        IF COL_LENGTH('Groups', 'CreatedByUserId') IS NULL
            ALTER TABLE [Groups] ADD [CreatedByUserId] int NULL;
        IF COL_LENGTH('Groups', 'CreatedAt') IS NULL
            ALTER TABLE [Groups] ADD [CreatedAt] datetime2 NOT NULL CONSTRAINT [DF_Groups_CreatedAt] DEFAULT SYSUTCDATETIME();
        IF COL_LENGTH('Groups', 'GroupUsername') IS NOT NULL
            EXEC(N'UPDATE [Groups] SET [GroupUsername] = CONCAT(N''group_'', [Id]) WHERE [GroupUsername] IS NULL OR LTRIM(RTRIM([GroupUsername])) = N'''';');
        IF COL_LENGTH('Groups', 'GroupUsername') IS NOT NULL
            EXEC(N'ALTER TABLE [Groups] ALTER COLUMN [GroupUsername] nvarchar(64) NOT NULL;');
        IF COL_LENGTH('Tasks', 'Status') IS NOT NULL
            EXEC(N'UPDATE [Tasks] SET [Status] = N''todo'' WHERE [Status] IS NULL OR [Status] = N'''';');

        IF NOT EXISTS (SELECT 1 FROM sys.foreign_keys WHERE name = 'FK_Tasks_Groups_GroupId')
            ALTER TABLE [Tasks] ADD CONSTRAINT [FK_Tasks_Groups_GroupId] FOREIGN KEY ([GroupId]) REFERENCES [Groups]([Id]) ON DELETE SET NULL;
        IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = 'IX_Tasks_GroupId')
            CREATE INDEX [IX_Tasks_GroupId] ON [Tasks]([GroupId]);
        IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = 'IX_Groups_CreatedByUserId')
            CREATE INDEX [IX_Groups_CreatedByUserId] ON [Groups]([CreatedByUserId]);
        IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = 'IX_Groups_GroupUsername')
            CREATE UNIQUE INDEX [IX_Groups_GroupUsername] ON [Groups]([GroupUsername]);
        IF NOT EXISTS (SELECT 1 FROM sys.foreign_keys WHERE name = 'FK_Groups_Users_CreatedByUserId')
            ALTER TABLE [Groups] ADD CONSTRAINT [FK_Groups_Users_CreatedByUserId] FOREIGN KEY ([CreatedByUserId]) REFERENCES [Users]([Id]);

        IF OBJECT_ID(N'[TaskComments]', N'U') IS NULL
            CREATE TABLE [TaskComments](
                [Id] int IDENTITY(1,1) NOT NULL CONSTRAINT [PK_TaskComments] PRIMARY KEY,
                [TaskItemId] int NOT NULL,
                [UserId] int NOT NULL,
                [ParentCommentId] int NULL,
                [Content] nvarchar(max) NOT NULL,
                [CreatedAt] datetime2 NOT NULL
            );
        IF OBJECT_ID(N'[CommentReactions]', N'U') IS NULL
            CREATE TABLE [CommentReactions](
                [Id] int IDENTITY(1,1) NOT NULL CONSTRAINT [PK_CommentReactions] PRIMARY KEY,
                [TaskCommentId] int NOT NULL,
                [UserId] int NOT NULL,
                [Emoji] nvarchar(16) NOT NULL,
                [CreatedAt] datetime2 NOT NULL
            );

        IF NOT EXISTS (SELECT 1 FROM sys.foreign_keys WHERE name = 'FK_TaskComments_Tasks_TaskItemId')
            ALTER TABLE [TaskComments] ADD CONSTRAINT [FK_TaskComments_Tasks_TaskItemId] FOREIGN KEY ([TaskItemId]) REFERENCES [Tasks]([Id]) ON DELETE CASCADE;
        IF NOT EXISTS (SELECT 1 FROM sys.foreign_keys WHERE name = 'FK_TaskComments_Users_UserId')
            ALTER TABLE [TaskComments] ADD CONSTRAINT [FK_TaskComments_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [Users]([Id]) ON DELETE NO ACTION;
        IF NOT EXISTS (SELECT 1 FROM sys.foreign_keys WHERE name = 'FK_TaskComments_TaskComments_ParentCommentId')
            ALTER TABLE [TaskComments] ADD CONSTRAINT [FK_TaskComments_TaskComments_ParentCommentId] FOREIGN KEY ([ParentCommentId]) REFERENCES [TaskComments]([Id]) ON DELETE NO ACTION;
        IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = 'IX_TaskComments_TaskItemId')
            CREATE INDEX [IX_TaskComments_TaskItemId] ON [TaskComments]([TaskItemId]);
        IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = 'IX_TaskComments_UserId')
            CREATE INDEX [IX_TaskComments_UserId] ON [TaskComments]([UserId]);
        IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = 'IX_TaskComments_ParentCommentId')
            CREATE INDEX [IX_TaskComments_ParentCommentId] ON [TaskComments]([ParentCommentId]);

        IF NOT EXISTS (SELECT 1 FROM sys.foreign_keys WHERE name = 'FK_CommentReactions_TaskComments_TaskCommentId')
            ALTER TABLE [CommentReactions] ADD CONSTRAINT [FK_CommentReactions_TaskComments_TaskCommentId] FOREIGN KEY ([TaskCommentId]) REFERENCES [TaskComments]([Id]) ON DELETE CASCADE;
        IF NOT EXISTS (SELECT 1 FROM sys.foreign_keys WHERE name = 'FK_CommentReactions_Users_UserId')
            ALTER TABLE [CommentReactions] ADD CONSTRAINT [FK_CommentReactions_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [Users]([Id]) ON DELETE NO ACTION;
        IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = 'IX_CommentReactions_TaskCommentId_UserId_Emoji')
            CREATE UNIQUE INDEX [IX_CommentReactions_TaskCommentId_UserId_Emoji] ON [CommentReactions]([TaskCommentId], [UserId], [Emoji]);
        IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = 'IX_CommentReactions_UserId')
            CREATE INDEX [IX_CommentReactions_UserId] ON [CommentReactions]([UserId]);
    """);
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthentication(); 
app.UseAuthorization();
app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();
app.MapPost("/auth/login", async (HttpContext context, AppDbContext db, IPasswordHasher<User> passwordHasher) =>
{
    var form = await context.Request.ReadFormAsync();
    var login = form["login"].ToString();
    var password = form["password"].ToString();

    var user = await db.Users.FirstOrDefaultAsync(u =>
        (u.Username == login || u.Email == login));

    if (user is null)
    {
        return Results.Redirect("/login?error=invalid");
    }
    
    PasswordVerificationResult verificationResult;
    try
    {
        verificationResult = passwordHasher.VerifyHashedPassword(user, user.Password, password);
    }
    catch (FormatException)
    {
        // Legacy plain-text password value: treat as failed hash verification
        // and rely on plain-text fallback check below for one-time migration.
        verificationResult = PasswordVerificationResult.Failed;
    }
    var isLegacyPlainTextMatch = user.Password == password;
    var isPasswordValid = verificationResult == PasswordVerificationResult.Success ||
                          verificationResult == PasswordVerificationResult.SuccessRehashNeeded ||
                          isLegacyPlainTextMatch;

    if (!isPasswordValid)
    {
        return Results.Redirect("/login?error=invalid");
    }

    if (verificationResult == PasswordVerificationResult.SuccessRehashNeeded || isLegacyPlainTextMatch)
    {
        user.Password = passwordHasher.HashPassword(user, password);
        await db.SaveChangesAsync();
    }

    var claims = new List<Claim>
    {
        new Claim(ClaimTypes.Name, user.Username),
        new Claim(ClaimTypes.Email, user.Email)
    };

    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
    var principal = new ClaimsPrincipal(identity);

    await context.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

    return Results.Redirect("/");
}).DisableAntiforgery();
app.MapPost("/auth/register", async (HttpContext context, AppDbContext db, IPasswordHasher<User> passwordHasher) =>
{
    var form = await context.Request.ReadFormAsync();
    var username = form["username"].ToString().Trim();
    var email = form["email"].ToString().Trim();
    var password = form["password"].ToString();

    if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
    {
        return Results.Redirect("/register");
    }

    var userExists = await db.Users.AnyAsync(u => u.Username == username || u.Email == email);
    if (userExists)
    {
        return Results.Redirect("/register?error=exists");
    }

    var newUser = new User
    {
        Username = username,
        Email = email,
        Password = string.Empty
    };
    newUser.Password = passwordHasher.HashPassword(newUser, password);

    db.Users.Add(newUser);
    await db.SaveChangesAsync();

    var claims = new List<Claim>
    {
        new Claim(ClaimTypes.Name, newUser.Username),
        new Claim(ClaimTypes.Email, newUser.Email)
    };

    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
    var principal = new ClaimsPrincipal(identity);

    await context.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

    return Results.Redirect("/");
}).DisableAntiforgery();
app.MapGet("/logout", async (HttpContext context) =>
{
    // Удаляем куки авторизации
    await Microsoft.AspNetCore.Authentication.AuthenticationHttpContextExtensions.SignOutAsync(
        context,
        Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationDefaults.AuthenticationScheme);

    // Перенаправляем пользователя обратно на главную
    return Results.Redirect("/");
});
app.Run();