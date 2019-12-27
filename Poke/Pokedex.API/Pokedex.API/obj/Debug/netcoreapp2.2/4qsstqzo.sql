IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [POKEDEXINFO] (
    [Id] int NOT NULL IDENTITY,
    [Numero] int NOT NULL,
    [Name] nvarchar(max) NULL,
    [Type_1] nvarchar(max) NULL,
    [Type_2] nvarchar(max) NULL,
    [Total] int NOT NULL,
    [HP] int NOT NULL,
    [Attack] int NOT NULL,
    [Defense] int NOT NULL,
    [SP_Atk] int NOT NULL,
    [SP_Def] int NOT NULL,
    [Speed] int NOT NULL,
    [Generation] int NOT NULL,
    [Legendary] nvarchar(max) NULL,
    CONSTRAINT [PK_POKEDEXINFO] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [TRAINER] (
    [Id] int NOT NULL IDENTITY,
    [Nome] nvarchar(30) NOT NULL,
    [Email] nvarchar(30) NOT NULL,
    [Liga] nvarchar(20) NULL,
    CONSTRAINT [PK_TRAINER] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [ENDERECO] (
    [Id] int NOT NULL IDENTITY,
    [Bairro] nvarchar(50) NULL,
    [Estado] nvarchar(2) NULL,
    [Pais] nvarchar(20) NULL,
    [Id_Trainer] int NOT NULL,
    CONSTRAINT [PK_ENDERECO] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_ENDERECO_TRAINER_Id_Trainer] FOREIGN KEY ([Id_Trainer]) REFERENCES [TRAINER] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [POKEMON] (
    [Id] int NOT NULL IDENTITY,
    [Name_Custom] nvarchar(max) NULL,
    [Nivel] int NOT NULL,
    [Id_Trainer] int NOT NULL,
    [Id_Pokedex] int NOT NULL,
    CONSTRAINT [PK_POKEMON] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_POKEMON_POKEDEXINFO_Id_Pokedex] FOREIGN KEY ([Id_Pokedex]) REFERENCES [POKEDEXINFO] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_POKEMON_TRAINER_Id_Trainer] FOREIGN KEY ([Id_Trainer]) REFERENCES [TRAINER] ([Id]) ON DELETE CASCADE
);

GO

CREATE INDEX [IX_ENDERECO_Id_Trainer] ON [ENDERECO] ([Id_Trainer]);

GO

CREATE INDEX [IX_POKEMON_Id_Pokedex] ON [POKEMON] ([Id_Pokedex]);

GO

CREATE INDEX [IX_POKEMON_Id_Trainer] ON [POKEMON] ([Id_Trainer]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20191219183633_Pokedex.API', N'2.2.0-rtm-35687');

GO

