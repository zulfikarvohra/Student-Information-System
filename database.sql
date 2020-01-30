

-- ----------------------------
-- Table structure for Files
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[Files]') AND type IN ('U'))
	DROP TABLE [dbo].[Files]
GO

CREATE TABLE [dbo].[Files] (
  [Id] bigint  IDENTITY(1,1) NOT NULL,
  [StudentId] bigint  NOT NULL,
  [FileName] nvarchar(500) COLLATE SQL_Latin1_General_CP1_CI_AS  NOT NULL,
  [FileSize] nvarchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS  NOT NULL
)
GO

ALTER TABLE [dbo].[Files] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of Files
-- ----------------------------
SET IDENTITY_INSERT [dbo].[Files] ON
GO

INSERT INTO [dbo].[Files] ([Id], [StudentId], [FileName], [FileSize]) VALUES (N'1', N'1', N'paper1.jpg', N'2221')
GO

INSERT INTO [dbo].[Files] ([Id], [StudentId], [FileName], [FileSize]) VALUES (N'2', N'1', N'paper2.jpg', N'21799')
GO

INSERT INTO [dbo].[Files] ([Id], [StudentId], [FileName], [FileSize]) VALUES (N'7', N'4', N'paper3.jpg', N'4432')
GO

INSERT INTO [dbo].[Files] ([Id], [StudentId], [FileName], [FileSize]) VALUES (N'8', N'5', N'paper1.jpg', N'2332')
GO

INSERT INTO [dbo].[Files] ([Id], [StudentId], [FileName], [FileSize]) VALUES (N'9', N'5', N'paper3.jpg', N'3223')
GO

SET IDENTITY_INSERT [dbo].[Files] OFF
GO


-- ----------------------------
-- Table structure for StudentMaster
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[StudentMaster]') AND type IN ('U'))
	DROP TABLE [dbo].[StudentMaster]
GO

CREATE TABLE [dbo].[StudentMaster] (
  [Id] bigint  IDENTITY(1,1) NOT NULL,
  [StudentName] nvarchar(200) COLLATE SQL_Latin1_General_CP1_CI_AS  NOT NULL,
  [Grade] int  NOT NULL,
  [DateOfBirth] date  NOT NULL,
  [Address] nvarchar(1000) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL
)
GO

ALTER TABLE [dbo].[StudentMaster] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of StudentMaster
-- ----------------------------
SET IDENTITY_INSERT [dbo].[StudentMaster] ON
GO

INSERT INTO [dbo].[StudentMaster] ([Id], [StudentName], [Grade], [DateOfBirth], [Address]) VALUES (N'1', N'Ahmed Fathallah', N'2', N'2010-01-10', N'Salmiya')
GO

INSERT INTO [dbo].[StudentMaster] ([Id], [StudentName], [Grade], [DateOfBirth], [Address]) VALUES (N'4', N'Arif Shabbir', N'4', N'2010-11-11', N'Hawalli')
GO

INSERT INTO [dbo].[StudentMaster] ([Id], [StudentName], [Grade], [DateOfBirth], [Address]) VALUES (N'5', N'Fahmeen Syed', N'6', N'2007-04-11', N'Khaitan')
GO

SET IDENTITY_INSERT [dbo].[StudentMaster] OFF
GO


-- ----------------------------
-- Auto increment value for Files
-- ----------------------------
DBCC CHECKIDENT ('[dbo].[Files]', RESEED, 9)
GO


-- ----------------------------
-- Primary Key structure for table Files
-- ----------------------------
ALTER TABLE [dbo].[Files] ADD CONSTRAINT [PK_Files] PRIMARY KEY CLUSTERED ([Id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Auto increment value for StudentMaster
-- ----------------------------
DBCC CHECKIDENT ('[dbo].[StudentMaster]', RESEED, 5)
GO


-- ----------------------------
-- Primary Key structure for table StudentMaster
-- ----------------------------
ALTER TABLE [dbo].[StudentMaster] ADD CONSTRAINT [PK_StudentMaster] PRIMARY KEY CLUSTERED ([Id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Foreign Keys structure for table Files
-- ----------------------------
ALTER TABLE [dbo].[Files] ADD CONSTRAINT [FK_Files_StudentMaster] FOREIGN KEY ([StudentId]) REFERENCES [dbo].[StudentMaster] ([Id]) ON DELETE CASCADE ON UPDATE NO ACTION
GO

