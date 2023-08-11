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

CREATE TABLE [Artist] (
    [ArtistId] int NOT NULL IDENTITY,
    [Name] nvarchar(50) NOT NULL,
    [DateOfBirth] datetime NOT NULL,
    [Phone] nvarchar(20) NULL,
    [Email] nvarchar(50) NULL,
    [InstagramUrl] nvarchar(255) NULL,
    CONSTRAINT [PK_Artist] PRIMARY KEY ([ArtistId])
);
GO

CREATE TABLE [Genre] (
    [GenreId] int NOT NULL IDENTITY,
    [Title] nvarchar(70) NOT NULL,
    CONSTRAINT [PK_Genre] PRIMARY KEY ([GenreId])
);
GO

CREATE TABLE [Song] (
    [SongId] integer NOT NULL IDENTITY,
    [Title] nvarchar(100) NOT NULL,
    [Duration] nvarchar(100) NOT NULL,
    [ReleasedDate] datetime NOT NULL,
    [GenreId] int NOT NULL,
    CONSTRAINT [PK_Song] PRIMARY KEY ([SongId]),
    CONSTRAINT [FK_Song_Genre_GenreId] FOREIGN KEY ([GenreId]) REFERENCES [Genre] ([GenreId]) ON DELETE CASCADE
);
GO

CREATE TABLE [ArtistSong] (
    [ArtistSongId] int NOT NULL IDENTITY,
    [ArtistId] int NOT NULL,
    [SongId] int NOT NULL,
    CONSTRAINT [PK_ArtistSong] PRIMARY KEY ([ArtistSongId]),
    CONSTRAINT [FK_ArtistSong_Artist_ArtistId] FOREIGN KEY ([ArtistId]) REFERENCES [Artist] ([ArtistId]) ON DELETE CASCADE,
    CONSTRAINT [FK_ArtistSong_Song_SongId] FOREIGN KEY ([SongId]) REFERENCES [Song] ([SongId]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_ArtistSong_ArtistId] ON [ArtistSong] ([ArtistId]);
GO

CREATE INDEX [IX_ArtistSong_SongId] ON [ArtistSong] ([SongId]);
GO

CREATE INDEX [IX_Song_GenreId] ON [Song] ([GenreId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230809190143_InitialCreate', N'7.0.10');
GO

COMMIT;
GO

