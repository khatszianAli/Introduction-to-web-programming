using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskManager.Migrations
{
    /// <inheritdoc />
    public partial class AddCompletedBy : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // ── Tasks columns ─────────────────────────────────────────────────
            migrationBuilder.Sql("""
                IF NOT EXISTS (
                    SELECT 1 FROM sys.columns
                    WHERE object_id = OBJECT_ID(N'[Tasks]') AND name = 'CompletedByUserId'
                )
                BEGIN
                    ALTER TABLE [Tasks] ADD [CompletedByUserId] int NULL;
                END
                """);

            migrationBuilder.Sql("""
                IF NOT EXISTS (
                    SELECT 1 FROM sys.columns
                    WHERE object_id = OBJECT_ID(N'[Tasks]') AND name = 'GroupId'
                )
                BEGIN
                    ALTER TABLE [Tasks] ADD [GroupId] int NULL;
                END
                """);

            migrationBuilder.Sql("""
                IF NOT EXISTS (
                    SELECT 1 FROM sys.columns
                    WHERE object_id = OBJECT_ID(N'[Tasks]') AND name = 'Status'
                )
                BEGIN
                    ALTER TABLE [Tasks] ADD [Status] nvarchar(max) NOT NULL DEFAULT N'';
                END
                """);

            // ── Groups columns ────────────────────────────────────────────────
            migrationBuilder.Sql("""
                IF NOT EXISTS (
                    SELECT 1 FROM sys.columns
                    WHERE object_id = OBJECT_ID(N'[Groups]') AND name = 'CreatedAt'
                )
                BEGIN
                    ALTER TABLE [Groups] ADD [CreatedAt] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.000';
                END
                """);

            migrationBuilder.Sql("""
                IF NOT EXISTS (
                    SELECT 1 FROM sys.columns
                    WHERE object_id = OBJECT_ID(N'[Groups]') AND name = 'CreatedByUserId'
                )
                BEGIN
                    ALTER TABLE [Groups] ADD [CreatedByUserId] int NULL;
                END
                """);

            migrationBuilder.Sql("""
                IF NOT EXISTS (
                    SELECT 1 FROM sys.columns
                    WHERE object_id = OBJECT_ID(N'[Groups]') AND name = 'Description'
                )
                BEGIN
                    ALTER TABLE [Groups] ADD [Description] nvarchar(max) NOT NULL DEFAULT N'';
                END
                """);

            migrationBuilder.Sql("""
                IF NOT EXISTS (
                    SELECT 1 FROM sys.columns
                    WHERE object_id = OBJECT_ID(N'[Groups]') AND name = 'GroupUsername'
                )
                BEGIN
                    ALTER TABLE [Groups] ADD [GroupUsername] nvarchar(450) NOT NULL DEFAULT N'';
                END
                """);

            // ── TaskComments table ────────────────────────────────────────────
            migrationBuilder.Sql("""
                IF OBJECT_ID(N'[TaskComments]') IS NULL
                BEGIN
                    CREATE TABLE [TaskComments] (
                        [Id]              int            NOT NULL IDENTITY(1,1),
                        [TaskItemId]      int            NOT NULL,
                        [UserId]          int            NOT NULL,
                        [ParentCommentId] int            NULL,
                        [Content]         nvarchar(max)  NOT NULL,
                        [CreatedAt]       datetime2      NOT NULL,
                        CONSTRAINT [PK_TaskComments] PRIMARY KEY ([Id]),
                        CONSTRAINT [FK_TaskComments_Tasks_TaskItemId]
                            FOREIGN KEY ([TaskItemId]) REFERENCES [Tasks] ([Id]) ON DELETE CASCADE,
                        CONSTRAINT [FK_TaskComments_Users_UserId]
                            FOREIGN KEY ([UserId]) REFERENCES [Users] ([Id]),
                        CONSTRAINT [FK_TaskComments_TaskComments_ParentCommentId]
                            FOREIGN KEY ([ParentCommentId]) REFERENCES [TaskComments] ([Id]) ON DELETE NO ACTION
                    );
                END
                """);

            // ── CommentReactions table ────────────────────────────────────────
            migrationBuilder.Sql("""
                IF OBJECT_ID(N'[CommentReactions]') IS NULL
                BEGIN
                    CREATE TABLE [CommentReactions] (
                        [Id]             int            NOT NULL IDENTITY(1,1),
                        [TaskCommentId]  int            NOT NULL,
                        [UserId]         int            NOT NULL,
                        [Emoji]          nvarchar(16)   NOT NULL,
                        [CreatedAt]      datetime2      NOT NULL,
                        CONSTRAINT [PK_CommentReactions] PRIMARY KEY ([Id]),
                        CONSTRAINT [FK_CommentReactions_TaskComments_TaskCommentId]
                            FOREIGN KEY ([TaskCommentId]) REFERENCES [TaskComments] ([Id]) ON DELETE CASCADE,
                        CONSTRAINT [FK_CommentReactions_Users_UserId]
                            FOREIGN KEY ([UserId]) REFERENCES [Users] ([Id])
                    );
                END
                """);

            // ── Indexes ───────────────────────────────────────────────────────
            migrationBuilder.Sql("""
                IF NOT EXISTS (
                    SELECT 1 FROM sys.indexes
                    WHERE object_id = OBJECT_ID(N'[Tasks]') AND name = 'IX_Tasks_CompletedByUserId'
                )
                BEGIN
                    CREATE INDEX [IX_Tasks_CompletedByUserId] ON [Tasks] ([CompletedByUserId]);
                END
                """);

            migrationBuilder.Sql("""
                IF NOT EXISTS (
                    SELECT 1 FROM sys.indexes
                    WHERE object_id = OBJECT_ID(N'[Tasks]') AND name = 'IX_Tasks_GroupId'
                )
                BEGIN
                    CREATE INDEX [IX_Tasks_GroupId] ON [Tasks] ([GroupId]);
                END
                """);

            migrationBuilder.Sql("""
                IF NOT EXISTS (
                    SELECT 1 FROM sys.indexes
                    WHERE object_id = OBJECT_ID(N'[Groups]') AND name = 'IX_Groups_CreatedByUserId'
                )
                BEGIN
                    CREATE INDEX [IX_Groups_CreatedByUserId] ON [Groups] ([CreatedByUserId]);
                END
                """);

            migrationBuilder.Sql("""
                IF NOT EXISTS (
                    SELECT 1 FROM sys.indexes
                    WHERE object_id = OBJECT_ID(N'[Groups]') AND name = 'IX_Groups_GroupUsername'
                )
                BEGIN
                    CREATE UNIQUE INDEX [IX_Groups_GroupUsername] ON [Groups] ([GroupUsername]);
                END
                """);

            migrationBuilder.Sql("""
                IF NOT EXISTS (
                    SELECT 1 FROM sys.indexes
                    WHERE object_id = OBJECT_ID(N'[CommentReactions]') AND name = 'IX_CommentReactions_TaskCommentId_UserId_Emoji'
                )
                BEGIN
                    CREATE UNIQUE INDEX [IX_CommentReactions_TaskCommentId_UserId_Emoji]
                        ON [CommentReactions] ([TaskCommentId], [UserId], [Emoji]);
                END
                """);

            migrationBuilder.Sql("""
                IF NOT EXISTS (
                    SELECT 1 FROM sys.indexes
                    WHERE object_id = OBJECT_ID(N'[CommentReactions]') AND name = 'IX_CommentReactions_UserId'
                )
                BEGIN
                    CREATE INDEX [IX_CommentReactions_UserId] ON [CommentReactions] ([UserId]);
                END
                """);

            migrationBuilder.Sql("""
                IF NOT EXISTS (
                    SELECT 1 FROM sys.indexes
                    WHERE object_id = OBJECT_ID(N'[TaskComments]') AND name = 'IX_TaskComments_ParentCommentId'
                )
                BEGIN
                    CREATE INDEX [IX_TaskComments_ParentCommentId] ON [TaskComments] ([ParentCommentId]);
                END
                """);

            migrationBuilder.Sql("""
                IF NOT EXISTS (
                    SELECT 1 FROM sys.indexes
                    WHERE object_id = OBJECT_ID(N'[TaskComments]') AND name = 'IX_TaskComments_TaskItemId'
                )
                BEGIN
                    CREATE INDEX [IX_TaskComments_TaskItemId] ON [TaskComments] ([TaskItemId]);
                END
                """);

            migrationBuilder.Sql("""
                IF NOT EXISTS (
                    SELECT 1 FROM sys.indexes
                    WHERE object_id = OBJECT_ID(N'[TaskComments]') AND name = 'IX_TaskComments_UserId'
                )
                BEGIN
                    CREATE INDEX [IX_TaskComments_UserId] ON [TaskComments] ([UserId]);
                END
                """);

            // ── Foreign keys ──────────────────────────────────────────────────
            migrationBuilder.Sql("""
                IF NOT EXISTS (
                    SELECT 1 FROM sys.foreign_keys
                    WHERE name = 'FK_Groups_Users_CreatedByUserId'
                )
                BEGIN
                    ALTER TABLE [Groups]
                        ADD CONSTRAINT [FK_Groups_Users_CreatedByUserId]
                        FOREIGN KEY ([CreatedByUserId]) REFERENCES [Users] ([Id]) ON DELETE NO ACTION;
                END
                """);

            migrationBuilder.Sql("""
                IF NOT EXISTS (
                    SELECT 1 FROM sys.foreign_keys
                    WHERE name = 'FK_Tasks_Groups_GroupId'
                )
                BEGIN
                    ALTER TABLE [Tasks]
                        ADD CONSTRAINT [FK_Tasks_Groups_GroupId]
                        FOREIGN KEY ([GroupId]) REFERENCES [Groups] ([Id]) ON DELETE SET NULL;
                END
                """);

            migrationBuilder.Sql("""
                IF NOT EXISTS (
                    SELECT 1 FROM sys.foreign_keys
                    WHERE name = 'FK_Tasks_Users_CompletedByUserId'
                )
                BEGIN
                    ALTER TABLE [Tasks]
                        ADD CONSTRAINT [FK_Tasks_Users_CompletedByUserId]
                        FOREIGN KEY ([CompletedByUserId]) REFERENCES [Users] ([Id]) ON DELETE NO ACTION;
                END
                """);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Groups_Users_CreatedByUserId",
                table: "Groups");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Groups_GroupId",
                table: "Tasks");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Users_CompletedByUserId",
                table: "Tasks");

            migrationBuilder.DropTable(
                name: "CommentReactions");

            migrationBuilder.DropTable(
                name: "TaskComments");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_CompletedByUserId",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_GroupId",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Groups_CreatedByUserId",
                table: "Groups");

            migrationBuilder.DropIndex(
                name: "IX_Groups_GroupUsername",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "CompletedByUserId",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "GroupId",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "GroupUsername",
                table: "Groups");
        }
    }
}
