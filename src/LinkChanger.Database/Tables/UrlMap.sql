﻿CREATE TABLE [dbo].[UrlMap]
(
	[Id] INT IDENTITY(1, 1) NOT NULL,
	[SourceUrl]	NVARCHAR(MAX) NOT NULL,
	[TargetUrlMap] NVARCHAR(MAX) NOT NULL,
	[SourceUrlMapHash] INT NOT NULL,
	[TargetUrlMapHash] INT NOT NULL,
	[Created] DATETIME2 NOT NULL DEFAULT GETUTCDATE(),
	[LastAccessed] DATETIME2 NOT NULL DEFAULT '1753-1-1',
	CONSTRAINT PK_UrlMap_Id PRIMARY KEY CLUSTERED (Id)
)
GO

CREATE UNIQUE INDEX UX_UrlMap_SourceUrlMapHash ON [dbo].[UrlMap] (SourceUrlMapHash)
GO

CREATE UNIQUE INDEX UX_UrlMap_TargetUrlMapHash ON [dbo].[UrlMap] (TargetUrlMapHash)
GO