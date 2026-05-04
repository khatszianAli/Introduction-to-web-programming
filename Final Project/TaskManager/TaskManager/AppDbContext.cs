using Microsoft.EntityFrameworkCore;
using TaskManager.Models;

public class AppDbContext : DbContext
{
    public DbSet<TaskItem> Tasks { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }
    public DbSet<User> Users { get; set; }
    public DbSet<Group> Groups { get; set; }
    public DbSet<GroupMember> GroupMembers { get; set; }
    public DbSet<TaskComment> TaskComments { get; set; }
    public DbSet<CommentReaction> CommentReactions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<GroupMember>(entity =>
        {
            entity.ToTable("GroupUser");
            entity.HasKey(gm => new { gm.GroupsId, gm.UsersId });

            entity.HasOne(gm => gm.Group)
                .WithMany(g => g.Members)
                .HasForeignKey(gm => gm.GroupsId);

            entity.HasOne(gm => gm.User)
                .WithMany(u => u.GroupMemberships)
                .HasForeignKey(gm => gm.UsersId);
        });

        modelBuilder.Entity<Group>()
            .HasOne(g => g.CreatedByUser)
            .WithMany(u => u.CreatedGroups)
            .HasForeignKey(g => g.CreatedByUserId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Group>()
            .HasIndex(g => g.GroupUsername)
            .IsUnique();

        modelBuilder.Entity<TaskItem>()
            .HasOne(t => t.Group)
            .WithMany(g => g.Tasks)
            .HasForeignKey(t => t.GroupId)
            .OnDelete(DeleteBehavior.SetNull);

        modelBuilder.Entity<TaskComment>()
            .HasOne(c => c.ParentComment)
            .WithMany(c => c.Replies)
            .HasForeignKey(c => c.ParentCommentId)
            .OnDelete(DeleteBehavior.Restrict);
        
        modelBuilder.Entity<TaskComment>()
            .HasOne(c => c.User)
            .WithMany(u => u.Comments)
            .HasForeignKey(c => c.UserId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<CommentReaction>()
            .HasOne(r => r.User)
            .WithMany(u => u.Reactions)
            .HasForeignKey(r => r.UserId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<CommentReaction>()
            .HasIndex(r => new { r.TaskCommentId, r.UserId, r.Emoji })
            .IsUnique();
    }
}