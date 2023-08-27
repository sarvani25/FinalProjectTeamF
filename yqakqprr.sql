IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Authors] (
    [Id] nvarchar(450) NOT NULL,
    [Name] nvarchar(max) NOT NULL,
    [Biography] nvarchar(2000) NOT NULL,
    [Photo] nvarchar(max) NOT NULL,
    [Email] nvarchar(max) NULL,
    CONSTRAINT [PK_Authors] PRIMARY KEY ([Id])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230825142347_author_table_added', N'7.0.10');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Books] (
    [Id] nvarchar(450) NOT NULL,
    [Title] nvarchar(max) NOT NULL,
    [Description] nvarchar(2000) NOT NULL,
    [AuthorId] nvarchar(max) NOT NULL,
    [CoverPhoto] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Books] PRIMARY KEY ([Id])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230825142548_book_table_added', N'7.0.10');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Books]') AND [c].[name] = N'AuthorId');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Books] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [Books] ALTER COLUMN [AuthorId] nvarchar(450) NOT NULL;
GO

CREATE INDEX [IX_Books_AuthorId] ON [Books] ([AuthorId]);
GO

ALTER TABLE [Books] ADD CONSTRAINT [FK_Books_Authors_AuthorId] FOREIGN KEY ([AuthorId]) REFERENCES [Authors] ([Id]) ON DELETE CASCADE;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230825151854_book_list_added_in_author', N'7.0.10');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Users] (
    [Email] nvarchar(450) NOT NULL,
    [Password] nvarchar(max) NOT NULL,
    [Name] nvarchar(max) NOT NULL,
    [PhotoUrl] nvarchar(max) NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY ([Email])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230825165542_user_table_added', N'7.0.10');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Reviews] (
    [Id] int NOT NULL IDENTITY,
    [UserEmail] nvarchar(max) NOT NULL,
    [bookId] nvarchar(max) NOT NULL,
    [Rating] nvarchar(max) NOT NULL,
    [Title] nvarchar(max) NULL,
    [Details] nvarchar(max) NULL,
    CONSTRAINT [PK_Reviews] PRIMARY KEY ([Id])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230826083743_review-table-added', N'7.0.10');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

DECLARE @var1 sysname;
SELECT @var1 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Reviews]') AND [c].[name] = N'bookId');
IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [Reviews] DROP CONSTRAINT [' + @var1 + '];');
ALTER TABLE [Reviews] ALTER COLUMN [bookId] nvarchar(450) NOT NULL;
GO

CREATE INDEX [IX_Reviews_bookId] ON [Reviews] ([bookId]);
GO

ALTER TABLE [Reviews] ADD CONSTRAINT [FK_Reviews_Books_bookId] FOREIGN KEY ([bookId]) REFERENCES [Books] ([Id]) ON DELETE CASCADE;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230826084848_bookId_migration_added_to_Review', N'7.0.10');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

DECLARE @var2 sysname;
SELECT @var2 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Reviews]') AND [c].[name] = N'UserEmail');
IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [Reviews] DROP CONSTRAINT [' + @var2 + '];');
ALTER TABLE [Reviews] ALTER COLUMN [UserEmail] nvarchar(450) NOT NULL;
GO

CREATE INDEX [IX_Reviews_UserEmail] ON [Reviews] ([UserEmail]);
GO

ALTER TABLE [Reviews] ADD CONSTRAINT [FK_Reviews_Users_UserEmail] FOREIGN KEY ([UserEmail]) REFERENCES [Users] ([Email]) ON DELETE CASCADE;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230826085001_UserEmail_foreingKey_AddedTo_Review', N'7.0.10');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

DECLARE @var3 sysname;
SELECT @var3 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Reviews]') AND [c].[name] = N'Rating');
IF @var3 IS NOT NULL EXEC(N'ALTER TABLE [Reviews] DROP CONSTRAINT [' + @var3 + '];');
ALTER TABLE [Reviews] ALTER COLUMN [Rating] int NOT NULL;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230826110403_Rating_Type_Update_in_Review', N'7.0.10');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Favorites] (
    [Id] int NOT NULL IDENTITY,
    [UserEmail] nvarchar(max) NOT NULL,
    [BookId] nvarchar(max) NOT NULL,
    [Status] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Favorites] PRIMARY KEY ([Id])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230826111141_Favorites_table_added', N'7.0.10');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

DECLARE @var4 sysname;
SELECT @var4 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Favorites]') AND [c].[name] = N'UserEmail');
IF @var4 IS NOT NULL EXEC(N'ALTER TABLE [Favorites] DROP CONSTRAINT [' + @var4 + '];');
ALTER TABLE [Favorites] ALTER COLUMN [UserEmail] nvarchar(450) NOT NULL;
GO

CREATE INDEX [IX_Favorites_UserEmail] ON [Favorites] ([UserEmail]);
GO

ALTER TABLE [Favorites] ADD CONSTRAINT [FK_Favorites_Users_UserEmail] FOREIGN KEY ([UserEmail]) REFERENCES [Users] ([Email]) ON DELETE CASCADE;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230826132002_UserEmail_Foreign_key_AddedTo_Favorites', N'7.0.10');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

DECLARE @var5 sysname;
SELECT @var5 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Favorites]') AND [c].[name] = N'BookId');
IF @var5 IS NOT NULL EXEC(N'ALTER TABLE [Favorites] DROP CONSTRAINT [' + @var5 + '];');
ALTER TABLE [Favorites] ALTER COLUMN [BookId] nvarchar(450) NOT NULL;
GO

CREATE INDEX [IX_Favorites_BookId] ON [Favorites] ([BookId]);
GO

ALTER TABLE [Favorites] ADD CONSTRAINT [FK_Favorites_Books_BookId] FOREIGN KEY ([BookId]) REFERENCES [Books] ([Id]) ON DELETE CASCADE;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230826132232_BookId_foreignKey_AddedTo_Favorites', N'7.0.10');
GO

COMMIT;
GO

