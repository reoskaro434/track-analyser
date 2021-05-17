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

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210419205907_InitializeDb')
BEGIN
    CREATE TABLE [Artists] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NULL,
        CONSTRAINT [PK_Artists] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210419205907_InitializeDb')
BEGIN
    CREATE TABLE [AspNetRoles] (
        [Id] nvarchar(450) NOT NULL,
        [Name] nvarchar(256) NULL,
        [NormalizedName] nvarchar(256) NULL,
        [ConcurrencyStamp] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetRoles] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210419205907_InitializeDb')
BEGIN
    CREATE TABLE [AspNetUsers] (
        [Id] nvarchar(450) NOT NULL,
        [UserName] nvarchar(256) NULL,
        [NormalizedUserName] nvarchar(256) NULL,
        [Email] nvarchar(256) NULL,
        [NormalizedEmail] nvarchar(256) NULL,
        [EmailConfirmed] bit NOT NULL,
        [PasswordHash] nvarchar(max) NULL,
        [SecurityStamp] nvarchar(max) NULL,
        [ConcurrencyStamp] nvarchar(max) NULL,
        [PhoneNumber] nvarchar(max) NULL,
        [PhoneNumberConfirmed] bit NOT NULL,
        [TwoFactorEnabled] bit NOT NULL,
        [LockoutEnd] datetimeoffset NULL,
        [LockoutEnabled] bit NOT NULL,
        [AccessFailedCount] int NOT NULL,
        CONSTRAINT [PK_AspNetUsers] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210419205907_InitializeDb')
BEGIN
    CREATE TABLE [Canals] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NULL,
        CONSTRAINT [PK_Canals] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210419205907_InitializeDb')
BEGIN
    CREATE TABLE [Tracks] (
        [Id] int NOT NULL IDENTITY,
        [Title] nvarchar(max) NULL,
        [ArtistId] int NULL,
        [Duration] datetime2 NOT NULL,
        [Version] nvarchar(max) NULL,
        [Description] nvarchar(max) NULL,
        [CoverPicturePath] nvarchar(max) NULL,
        CONSTRAINT [PK_Tracks] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Tracks_Artists_ArtistId] FOREIGN KEY ([ArtistId]) REFERENCES [Artists] ([Id]) ON DELETE NO ACTION
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210419205907_InitializeDb')
BEGIN
    CREATE TABLE [AspNetRoleClaims] (
        [Id] int NOT NULL IDENTITY,
        [RoleId] nvarchar(450) NOT NULL,
        [ClaimType] nvarchar(max) NULL,
        [ClaimValue] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210419205907_InitializeDb')
BEGIN
    CREATE TABLE [AspNetUserClaims] (
        [Id] int NOT NULL IDENTITY,
        [UserId] nvarchar(450) NOT NULL,
        [ClaimType] nvarchar(max) NULL,
        [ClaimValue] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210419205907_InitializeDb')
BEGIN
    CREATE TABLE [AspNetUserLogins] (
        [LoginProvider] nvarchar(450) NOT NULL,
        [ProviderKey] nvarchar(450) NOT NULL,
        [ProviderDisplayName] nvarchar(max) NULL,
        [UserId] nvarchar(450) NOT NULL,
        CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY ([LoginProvider], [ProviderKey]),
        CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210419205907_InitializeDb')
BEGIN
    CREATE TABLE [AspNetUserRoles] (
        [UserId] nvarchar(450) NOT NULL,
        [RoleId] nvarchar(450) NOT NULL,
        CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY ([UserId], [RoleId]),
        CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210419205907_InitializeDb')
BEGIN
    CREATE TABLE [AspNetUserTokens] (
        [UserId] nvarchar(450) NOT NULL,
        [LoginProvider] nvarchar(450) NOT NULL,
        [Name] nvarchar(450) NOT NULL,
        [Value] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY ([UserId], [LoginProvider], [Name]),
        CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210419205907_InitializeDb')
BEGIN
    CREATE TABLE [TrackEmissions] (
        [Id] int NOT NULL IDENTITY,
        [BeginDateTime] datetime2 NOT NULL,
        [EmissionTime] datetime2 NOT NULL,
        [CanalId] int NULL,
        CONSTRAINT [PK_TrackEmissions] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_TrackEmissions_Canals_CanalId] FOREIGN KEY ([CanalId]) REFERENCES [Canals] ([Id]) ON DELETE NO ACTION
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210419205907_InitializeDb')
BEGIN
    CREATE TABLE [TrackStatistics] (
        [Id] int NOT NULL IDENTITY,
        [TrackId] int NULL,
        [PlayedTimes] int NOT NULL,
        [CanalId] int NULL,
        CONSTRAINT [PK_TrackStatistics] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_TrackStatistics_Canals_CanalId] FOREIGN KEY ([CanalId]) REFERENCES [Canals] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_TrackStatistics_Tracks_TrackId] FOREIGN KEY ([TrackId]) REFERENCES [Tracks] ([Id]) ON DELETE NO ACTION
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210419205907_InitializeDb')
BEGIN
    CREATE INDEX [IX_AspNetRoleClaims_RoleId] ON [AspNetRoleClaims] ([RoleId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210419205907_InitializeDb')
BEGIN
    EXEC(N'CREATE UNIQUE INDEX [RoleNameIndex] ON [AspNetRoles] ([NormalizedName]) WHERE [NormalizedName] IS NOT NULL');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210419205907_InitializeDb')
BEGIN
    CREATE INDEX [IX_AspNetUserClaims_UserId] ON [AspNetUserClaims] ([UserId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210419205907_InitializeDb')
BEGIN
    CREATE INDEX [IX_AspNetUserLogins_UserId] ON [AspNetUserLogins] ([UserId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210419205907_InitializeDb')
BEGIN
    CREATE INDEX [IX_AspNetUserRoles_RoleId] ON [AspNetUserRoles] ([RoleId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210419205907_InitializeDb')
BEGIN
    CREATE INDEX [EmailIndex] ON [AspNetUsers] ([NormalizedEmail]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210419205907_InitializeDb')
BEGIN
    EXEC(N'CREATE UNIQUE INDEX [UserNameIndex] ON [AspNetUsers] ([NormalizedUserName]) WHERE [NormalizedUserName] IS NOT NULL');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210419205907_InitializeDb')
BEGIN
    CREATE INDEX [IX_TrackEmissions_CanalId] ON [TrackEmissions] ([CanalId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210419205907_InitializeDb')
BEGIN
    CREATE INDEX [IX_Tracks_ArtistId] ON [Tracks] ([ArtistId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210419205907_InitializeDb')
BEGIN
    CREATE INDEX [IX_TrackStatistics_CanalId] ON [TrackStatistics] ([CanalId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210419205907_InitializeDb')
BEGIN
    CREATE INDEX [IX_TrackStatistics_TrackId] ON [TrackStatistics] ([TrackId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210419205907_InitializeDb')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210419205907_InitializeDb', N'5.0.5');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210422150353_AddTrackToTrackEmission')
BEGIN
    ALTER TABLE [TrackEmissions] ADD [TrackId] int NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210422150353_AddTrackToTrackEmission')
BEGIN
    CREATE INDEX [IX_TrackEmissions_TrackId] ON [TrackEmissions] ([TrackId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210422150353_AddTrackToTrackEmission')
BEGIN
    ALTER TABLE [TrackEmissions] ADD CONSTRAINT [FK_TrackEmissions_Tracks_TrackId] FOREIGN KEY ([TrackId]) REFERENCES [Tracks] ([Id]) ON DELETE NO ACTION;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210422150353_AddTrackToTrackEmission')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210422150353_AddTrackToTrackEmission', N'5.0.5');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210423165017_CreateDayStatistic')
BEGIN
    DECLARE @var0 sysname;
    SELECT @var0 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[TrackStatistics]') AND [c].[name] = N'PlayedTimes');
    IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [TrackStatistics] DROP CONSTRAINT [' + @var0 + '];');
    ALTER TABLE [TrackStatistics] DROP COLUMN [PlayedTimes];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210423165017_CreateDayStatistic')
BEGIN
    CREATE TABLE [DayStatistics] (
        [Id] int NOT NULL IDENTITY,
        [Day] datetime2 NOT NULL,
        [PlayedTimes] int NOT NULL,
        [TrackStatisticId] int NULL,
        CONSTRAINT [PK_DayStatistics] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_DayStatistics_TrackStatistics_TrackStatisticId] FOREIGN KEY ([TrackStatisticId]) REFERENCES [TrackStatistics] ([Id]) ON DELETE NO ACTION
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210423165017_CreateDayStatistic')
BEGIN
    CREATE INDEX [IX_DayStatistics_TrackStatisticId] ON [DayStatistics] ([TrackStatisticId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210423165017_CreateDayStatistic')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210423165017_CreateDayStatistic', N'5.0.5');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210424110247_UpdateForeignKeysForTables')
BEGIN
    ALTER TABLE [DayStatistics] DROP CONSTRAINT [FK_DayStatistics_TrackStatistics_TrackStatisticId];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210424110247_UpdateForeignKeysForTables')
BEGIN
    ALTER TABLE [TrackEmissions] DROP CONSTRAINT [FK_TrackEmissions_Canals_CanalId];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210424110247_UpdateForeignKeysForTables')
BEGIN
    ALTER TABLE [TrackEmissions] DROP CONSTRAINT [FK_TrackEmissions_Tracks_TrackId];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210424110247_UpdateForeignKeysForTables')
BEGIN
    ALTER TABLE [Tracks] DROP CONSTRAINT [FK_Tracks_Artists_ArtistId];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210424110247_UpdateForeignKeysForTables')
BEGIN
    ALTER TABLE [TrackStatistics] DROP CONSTRAINT [FK_TrackStatistics_Canals_CanalId];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210424110247_UpdateForeignKeysForTables')
BEGIN
    ALTER TABLE [TrackStatistics] DROP CONSTRAINT [FK_TrackStatistics_Tracks_TrackId];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210424110247_UpdateForeignKeysForTables')
BEGIN
    DROP INDEX [IX_TrackStatistics_TrackId] ON [TrackStatistics];
    DECLARE @var1 sysname;
    SELECT @var1 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[TrackStatistics]') AND [c].[name] = N'TrackId');
    IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [TrackStatistics] DROP CONSTRAINT [' + @var1 + '];');
    ALTER TABLE [TrackStatistics] ALTER COLUMN [TrackId] int NOT NULL;
    ALTER TABLE [TrackStatistics] ADD DEFAULT 0 FOR [TrackId];
    CREATE INDEX [IX_TrackStatistics_TrackId] ON [TrackStatistics] ([TrackId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210424110247_UpdateForeignKeysForTables')
BEGIN
    DROP INDEX [IX_TrackStatistics_CanalId] ON [TrackStatistics];
    DECLARE @var2 sysname;
    SELECT @var2 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[TrackStatistics]') AND [c].[name] = N'CanalId');
    IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [TrackStatistics] DROP CONSTRAINT [' + @var2 + '];');
    ALTER TABLE [TrackStatistics] ALTER COLUMN [CanalId] int NOT NULL;
    ALTER TABLE [TrackStatistics] ADD DEFAULT 0 FOR [CanalId];
    CREATE INDEX [IX_TrackStatistics_CanalId] ON [TrackStatistics] ([CanalId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210424110247_UpdateForeignKeysForTables')
BEGIN
    DROP INDEX [IX_Tracks_ArtistId] ON [Tracks];
    DECLARE @var3 sysname;
    SELECT @var3 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Tracks]') AND [c].[name] = N'ArtistId');
    IF @var3 IS NOT NULL EXEC(N'ALTER TABLE [Tracks] DROP CONSTRAINT [' + @var3 + '];');
    ALTER TABLE [Tracks] ALTER COLUMN [ArtistId] int NOT NULL;
    ALTER TABLE [Tracks] ADD DEFAULT 0 FOR [ArtistId];
    CREATE INDEX [IX_Tracks_ArtistId] ON [Tracks] ([ArtistId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210424110247_UpdateForeignKeysForTables')
BEGIN
    DROP INDEX [IX_TrackEmissions_TrackId] ON [TrackEmissions];
    DECLARE @var4 sysname;
    SELECT @var4 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[TrackEmissions]') AND [c].[name] = N'TrackId');
    IF @var4 IS NOT NULL EXEC(N'ALTER TABLE [TrackEmissions] DROP CONSTRAINT [' + @var4 + '];');
    ALTER TABLE [TrackEmissions] ALTER COLUMN [TrackId] int NOT NULL;
    ALTER TABLE [TrackEmissions] ADD DEFAULT 0 FOR [TrackId];
    CREATE INDEX [IX_TrackEmissions_TrackId] ON [TrackEmissions] ([TrackId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210424110247_UpdateForeignKeysForTables')
BEGIN
    DROP INDEX [IX_TrackEmissions_CanalId] ON [TrackEmissions];
    DECLARE @var5 sysname;
    SELECT @var5 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[TrackEmissions]') AND [c].[name] = N'CanalId');
    IF @var5 IS NOT NULL EXEC(N'ALTER TABLE [TrackEmissions] DROP CONSTRAINT [' + @var5 + '];');
    ALTER TABLE [TrackEmissions] ALTER COLUMN [CanalId] int NOT NULL;
    ALTER TABLE [TrackEmissions] ADD DEFAULT 0 FOR [CanalId];
    CREATE INDEX [IX_TrackEmissions_CanalId] ON [TrackEmissions] ([CanalId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210424110247_UpdateForeignKeysForTables')
BEGIN
    DROP INDEX [IX_DayStatistics_TrackStatisticId] ON [DayStatistics];
    DECLARE @var6 sysname;
    SELECT @var6 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DayStatistics]') AND [c].[name] = N'TrackStatisticId');
    IF @var6 IS NOT NULL EXEC(N'ALTER TABLE [DayStatistics] DROP CONSTRAINT [' + @var6 + '];');
    ALTER TABLE [DayStatistics] ALTER COLUMN [TrackStatisticId] int NOT NULL;
    ALTER TABLE [DayStatistics] ADD DEFAULT 0 FOR [TrackStatisticId];
    CREATE INDEX [IX_DayStatistics_TrackStatisticId] ON [DayStatistics] ([TrackStatisticId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210424110247_UpdateForeignKeysForTables')
BEGIN
    ALTER TABLE [DayStatistics] ADD CONSTRAINT [FK_DayStatistics_TrackStatistics_TrackStatisticId] FOREIGN KEY ([TrackStatisticId]) REFERENCES [TrackStatistics] ([Id]) ON DELETE CASCADE;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210424110247_UpdateForeignKeysForTables')
BEGIN
    ALTER TABLE [TrackEmissions] ADD CONSTRAINT [FK_TrackEmissions_Canals_CanalId] FOREIGN KEY ([CanalId]) REFERENCES [Canals] ([Id]) ON DELETE CASCADE;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210424110247_UpdateForeignKeysForTables')
BEGIN
    ALTER TABLE [TrackEmissions] ADD CONSTRAINT [FK_TrackEmissions_Tracks_TrackId] FOREIGN KEY ([TrackId]) REFERENCES [Tracks] ([Id]) ON DELETE CASCADE;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210424110247_UpdateForeignKeysForTables')
BEGIN
    ALTER TABLE [Tracks] ADD CONSTRAINT [FK_Tracks_Artists_ArtistId] FOREIGN KEY ([ArtistId]) REFERENCES [Artists] ([Id]) ON DELETE CASCADE;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210424110247_UpdateForeignKeysForTables')
BEGIN
    ALTER TABLE [TrackStatistics] ADD CONSTRAINT [FK_TrackStatistics_Canals_CanalId] FOREIGN KEY ([CanalId]) REFERENCES [Canals] ([Id]) ON DELETE CASCADE;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210424110247_UpdateForeignKeysForTables')
BEGIN
    ALTER TABLE [TrackStatistics] ADD CONSTRAINT [FK_TrackStatistics_Tracks_TrackId] FOREIGN KEY ([TrackId]) REFERENCES [Tracks] ([Id]) ON DELETE CASCADE;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210424110247_UpdateForeignKeysForTables')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210424110247_UpdateForeignKeysForTables', N'5.0.5');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210424203751_AddCanalTrackToDb')
BEGIN
    CREATE TABLE [CanalTracks] (
        [CanalId] int NOT NULL,
        [TrackId] int NOT NULL,
        CONSTRAINT [PK_CanalTracks] PRIMARY KEY ([CanalId], [TrackId]),
        CONSTRAINT [FK_CanalTracks_Canals_CanalId] FOREIGN KEY ([CanalId]) REFERENCES [Canals] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_CanalTracks_Tracks_TrackId] FOREIGN KEY ([TrackId]) REFERENCES [Tracks] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210424203751_AddCanalTrackToDb')
BEGIN
    CREATE INDEX [IX_CanalTracks_TrackId] ON [CanalTracks] ([TrackId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210424203751_AddCanalTrackToDb')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210424203751_AddCanalTrackToDb', N'5.0.5');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210505153541_AddApplicationUserToDb')
BEGIN
    ALTER TABLE [AspNetUsers] ADD [Discriminator] nvarchar(max) NOT NULL DEFAULT N'';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210505153541_AddApplicationUserToDb')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210505153541_AddApplicationUserToDb', N'5.0.5');
END;
GO

COMMIT;
GO

