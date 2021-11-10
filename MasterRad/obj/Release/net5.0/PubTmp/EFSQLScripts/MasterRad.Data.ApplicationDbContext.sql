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

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210828181857_Initial-migration')
BEGIN
    CREATE TABLE [Sectors] (
        [Id] int NOT NULL IDENTITY,
        [Sector_name] nvarchar(max) NULL,
        CONSTRAINT [PK_Sectors] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210828181857_Initial-migration')
BEGIN
    CREATE TABLE [Warehouses] (
        [Id] int NOT NULL IDENTITY,
        [Warehouse_name] nvarchar(max) NULL,
        CONSTRAINT [PK_Warehouses] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210828181857_Initial-migration')
BEGIN
    CREATE TABLE [Borders] (
        [Id] int NOT NULL IDENTITY,
        [MaxTemperature] real NOT NULL,
        [MinTemperature] real NOT NULL,
        [MaxHumidity] real NOT NULL,
        [MinHumidity] real NOT NULL,
        [SectorsId] int NOT NULL,
        [WarehousesId] int NOT NULL,
        CONSTRAINT [PK_Borders] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Borders_Sectors_SectorsId] FOREIGN KEY ([SectorsId]) REFERENCES [Sectors] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_Borders_Warehouses_WarehousesId] FOREIGN KEY ([WarehousesId]) REFERENCES [Warehouses] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210828181857_Initial-migration')
BEGIN
    CREATE TABLE [Measurements] (
        [Id] int NOT NULL IDENTITY,
        [Temperature] real NOT NULL,
        [Humidity] real NOT NULL,
        [Timestamp] datetime2 NOT NULL,
        [BorderId] int NOT NULL,
        CONSTRAINT [PK_Measurements] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Measurements_Borders_BorderId] FOREIGN KEY ([BorderId]) REFERENCES [Borders] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210828181857_Initial-migration')
BEGIN
    CREATE INDEX [IX_Borders_SectorsId] ON [Borders] ([SectorsId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210828181857_Initial-migration')
BEGIN
    CREATE INDEX [IX_Borders_WarehousesId] ON [Borders] ([WarehousesId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210828181857_Initial-migration')
BEGIN
    CREATE INDEX [IX_Measurements_BorderId] ON [Measurements] ([BorderId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210828181857_Initial-migration')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210828181857_Initial-migration', N'5.0.8');
END;
GO

COMMIT;
GO

