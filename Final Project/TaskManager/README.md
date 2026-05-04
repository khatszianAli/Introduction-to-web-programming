# TaskManager

A full-featured collaborative task management web application built with **ASP.NET Core Blazor** and **SQL Server**. TaskManager enables users to create, manage, and organize tasks individually or within collaborative groups with real-time commenting and emoji reactions.

## 🌟 Features

### Core Task Management
- **Create, Read, Update, Delete (CRUD)** tasks with full task lifecycle management
- **Task Status Tracking**: Tasks support multiple statuses (todo, in-progress, done, etc.)
- **Group-Based Organization**: Organize tasks into collaborative groups
- **User Authentication**: Secure login and registration with hashed passwords
- **Cookie-Based Sessions**: 7-day persistent authentication

### Collaboration Features
- **Group Management**: Create and manage collaborative task groups
- **Group Members**: Add members to groups for shared task management
- **Task Comments**: Comment on tasks with nested reply support
- **Emoji Reactions**: React to comments with emoji (👍, ❤️, 😂, etc.)
- **User Identification**: Track task and comment ownership

### Technical Highlights
- **Real-time UI**: Interactive Blazor Server components
- **Database Migrations**: Automated schema management with Entity Framework Core
- **Password Security**: BCrypt-style hashing with legacy password support for migrations
- **Authorization**: ASP.NET Core Identity-based authentication

## 🛠️ Tech Stack

| Technology | Version | Purpose |
|-----------|---------|---------|
| **ASP.NET Core** | 10.0 | Web framework & runtime |
| **Blazor Server** | 10.0 | Interactive UI components |
| **Entity Framework Core** | 10.0.7 | ORM & database access |
| **SQL Server** | Latest | Data persistence |
| **C#** | 12+ | Primary language |

## 📁 Project Structure

```
TaskManager/
├── Components/                 # Blazor components & pages
│   ├── Pages/                 # Page-level components
│   ├── Layout/                # Layout components
│   ├── App.razor              # Root component
│   ├── Routes.razor           # Routing configuration
│   ├── TaskForm.razor         # Task creation/editing form
│   └── _Imports.razor         # Global imports
├── Models/                     # Data models
│   ├── User.cs                # User entity
│   ├── TaskItem.cs            # Task entity
│   ├── Group.cs               # Group entity
│   ├── GroupMember.cs         # Group membership (junction table)
│   ├── TaskComment.cs         # Task comments with nesting
│   ├── CommentReaction.cs     # Emoji reactions
│   └── TaskStatuses.cs        # Task status constants
├── Services/                   # Business logic
│   └── CurrentUserService.cs  # User context service
├── AppDbContext.cs            # Entity Framework context
├── Program.cs                 # Application configuration & endpoints
├── TaskManager.csproj         # Project file
└── appsettings.json           # Configuration

```

## 🗄️ Database Schema

### Core Tables
- **Users**: User accounts with credentials
- **Tasks**: Individual task items with status
- **Groups**: Collaborative group containers
- **GroupUser** (GroupMembers): Many-to-many relationship between users and groups
- **TaskComments**: Nested comments on tasks with parent-child relationships
- **CommentReactions**: Emoji reactions linked to comments

### Key Relationships
- Users → Tasks (one-to-many, optional via Group)
- Users → Groups (many-to-many via GroupMembers)
- Groups → Tasks (one-to-many, optional)
- Users → Comments (one-to-many)
- Comments → Comments (self-referencing for nesting)
- Users → Reactions (one-to-many)

## 🚀 Getting Started

### Prerequisites
- .NET 10.0 SDK or later
- SQL Server (local or remote)
- Visual Studio 2024 / VS Code with C# extension

### Installation

1. **Clone the repository**
   ```bash
   git clone https://github.com/khatszianAli/Introduction-to-web-programming.git
   cd Introduction-to-web-programming/Final\ Project/TaskManager
   ```

2. **Configure the database connection**
   
   Edit `appsettings.json`:
   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "Server=YOUR_SERVER;Database=TaskManagerDb;Trusted_Connection=true;"
     }
   }
   ```

3. **Install dependencies**
   ```bash
   dotnet restore
   ```

4. **Apply database migrations**
   ```bash
   dotnet ef database update
   ```

5. **Run the application**
   ```bash
   dotnet run
   ```
   
   The app will start at `https://localhost:7000` (or specified port)

## 📝 API Endpoints

### Authentication
- **POST** `/auth/login` - User login via username/email and password
- **POST** `/auth/register` - User registration with username, email, and password
- **GET** `/logout` - Logout and clear authentication cookie

### Pages (Blazor Components)
- **GET** `/` - Dashboard/home page
- **GET** `/login` - Login form
- **GET** `/register` - Registration form
- **GET** `/tasks` - Task listing
- **GET** `/groups` - Group management
- **GET** `/not-found` - 404 error page

## 🔐 Security Features

### Authentication & Authorization
- **Cookie-based authentication** with 7-day expiration
- **CSRF protection** via Antiforgery tokens
- **Password hashing** with BCrypt-style hashing
- **Legacy password migration** supporting plain-text to hashed conversion

### Database Security
- **Foreign key constraints** for referential integrity
- **Unique constraints** on critical fields (GroupUsername)
- **Cascading delete rules** for task comments
- **No Action deletes** for user-referenced data (comments, reactions)

## 🔄 Migrations & Schema Bootstrap

The application automatically:
1. Runs pending Entity Framework migrations on startup
2. Creates missing database columns and tables
3. Establishes indexes for performance optimization
4. Configures foreign key relationships
5. Migrates legacy passwords on first login

## 🛣️ User Workflows

### Creating a Task
1. Register/Login to your account
2. Navigate to "New Task"
3. Fill in task details and optional group assignment
4. Task appears in dashboard with status "todo"

### Collaborating in Groups
1. Create a new group
2. Add group members via their username
3. Create tasks within the group
4. All group members can view and edit shared tasks

### Commenting & Reactions
1. Open a task detail view
2. Add a comment (supports nesting by replying to comments)
3. React to comments with emoji
4. View all reactions and comments in real-time

## 📊 Entity Relationships Diagram

```
User (1) ──→ (M) Task
User (1) ──→ (M) Group (created_by)
User (M) ←──→ (M) Group (members) [via GroupMember]
Group (1) ──→ (M) Task
Task (1) ──→ (M) TaskComment
TaskComment (1) ──→ (M) TaskComment (nested replies)
TaskComment (1) ──→ (M) CommentReaction
User (1) ──→ (M) CommentReaction
```

## 🎯 Future Enhancements

- Task filtering and searching
- Task priority levels and due dates
- Real-time notifications
- Task assignment to group members
- Drag-and-drop task organization
- Task templates and recurring tasks
- Activity logging and audit trails
- File attachments on tasks
- Mobile-responsive design improvements
- Dark mode theme

## 🤝 Contributing

Contributions are welcome! Please:
1. Fork the repository
2. Create a feature branch (`git checkout -b feature/amazing-feature`)
3. Commit changes (`git commit -m 'Add amazing feature'`)
4. Push to the branch (`git push origin feature/amazing-feature`)
5. Open a Pull Request

## 📄 License

This project is part of the "Introduction to Web Programming" course final project.

## 👨‍💻 Author

**Khatszian Ali**  
[GitHub Profile](https://github.com/khatszianAli)

## 📞 Support

For issues, questions, or suggestions:
- Open a GitHub Issue
- Contact the project author

---

**Last Updated**: May 2026  
**Project Status**: ✅ Active Development