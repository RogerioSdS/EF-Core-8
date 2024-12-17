CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" TEXT NOT NULL CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY,
    "ProductVersion" TEXT NOT NULL
);

BEGIN TRANSACTION;

CREATE TABLE "Diretores" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_Diretores" PRIMARY KEY AUTOINCREMENT,
    "Name" TEXT NOT NULL
);

CREATE TABLE "Filmes" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_Filmes" PRIMARY KEY AUTOINCREMENT,
    "Titulo" TEXT NOT NULL,
    "Ano" INTEGER NULL,
    "DiretorId" INTEGER NOT NULL,
    CONSTRAINT "FK_Filmes_Diretores_DiretorId" FOREIGN KEY ("DiretorId") REFERENCES "Diretores" ("Id") ON DELETE CASCADE
);

CREATE INDEX "IX_Filmes_DiretorId" ON "Filmes" ("DiretorId");

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20241217134610_inicial', '8.0.4');

COMMIT;

BEGIN TRANSACTION;

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20241217183421_RequiredDiretorId', '8.0.4');

COMMIT;