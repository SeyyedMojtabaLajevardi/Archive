USE [Archive]
GO
/****** Object:  Schema [Base]    Script Date: 12/26/2024 6:45:18 PM ******/
CREATE SCHEMA [Base]
GO
/****** Object:  Table [Base].[Category]    Script Date: 12/26/2024 6:45:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Base].[Category](
	[CategoryId] [int] IDENTITY(1,1) NOT NULL,
	[CategoryTitle] [nvarchar](100) NULL,
	[ParentId] [int] NULL,
	[LevelNo] [int] NULL,
	[ChildCount] [int] NULL,
	[ChildOrder] [int] NULL,
	[CategoryEnglishTitle] [nvarchar](100) NULL,
 CONSTRAINT [PK_MainCategory] PRIMARY KEY CLUSTERED 
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Base].[CodeRange]    Script Date: 12/26/2024 6:45:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Base].[CodeRange](
	[CodeRangeId] [int] IDENTITY(1,1) NOT NULL,
	[MinCode] [int] NULL,
	[MaxCode] [int] NULL,
	[CategoryId] [int] NULL,
 CONSTRAINT [PK_CodeRangeI] PRIMARY KEY CLUSTERED 
(
	[CodeRangeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Base].[Collection]    Script Date: 12/26/2024 6:45:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Base].[Collection](
	[CollectionId] [int] IDENTITY(1,1) NOT NULL,
	[CollectionTitle] [nvarchar](150) NULL,
 CONSTRAINT [PK_Collection] PRIMARY KEY CLUSTERED 
(
	[CollectionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Base].[Comment]    Script Date: 12/26/2024 6:45:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Base].[Comment](
	[CommentId] [int] IDENTITY(1,1) NOT NULL,
	[CommentTitle] [nvarchar](250) NULL,
	[CommentText] [nvarchar](max) NOT NULL,
	[SenderUserId] [int] NOT NULL,
	[ReceiverUserId] [int] NOT NULL,
	[SendDate] [nvarchar](50) NOT NULL,
	[ReceiveDate] [nvarchar](50) NULL,
 CONSTRAINT [PK_Comment] PRIMARY KEY CLUSTERED 
(
	[CommentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [Base].[ContentType]    Script Date: 12/26/2024 6:45:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Base].[ContentType](
	[ContentTypeId] [int] IDENTITY(1,1) NOT NULL,
	[ContentTypeTitle] [nvarchar](50) NULL,
	[ContentTypeTitlePersian] [nvarchar](50) NULL,
 CONSTRAINT [PK_ContentType] PRIMARY KEY CLUSTERED 
(
	[ContentTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Base].[Editor]    Script Date: 12/26/2024 6:45:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Base].[Editor](
	[EditorId] [int] NOT NULL,
	[EditorName] [nvarchar](150) NULL,
	[SampleEditorName] [nvarchar](150) NULL,
 CONSTRAINT [PK_Editor] PRIMARY KEY CLUSTERED 
(
	[EditorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Base].[FileType]    Script Date: 12/26/2024 6:45:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Base].[FileType](
	[FileTypeId] [int] IDENTITY(1,1) NOT NULL,
	[FileTypeTitle] [nvarchar](50) NULL,
	[ContentTypeId] [int] NULL,
	[IsBook] [bit] NULL,
	[FileTypeTitlePersian] [nvarchar](50) NULL,
 CONSTRAINT [PK_FileType] PRIMARY KEY CLUSTERED 
(
	[FileTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Base].[Language]    Script Date: 12/26/2024 6:45:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Base].[Language](
	[LanguageId] [int] IDENTITY(1,1) NOT NULL,
	[LanguageTitle] [nvarchar](50) NULL,
	[BriefLangyageTitle] [nvarchar](10) NULL,
	[LanguageTitlePersian] [nvarchar](50) NULL,
 CONSTRAINT [PK_Language] PRIMARY KEY CLUSTERED 
(
	[LanguageId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Base].[PadidAvar]    Script Date: 12/26/2024 6:45:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Base].[PadidAvar](
	[PadidAvarId] [int] IDENTITY(1,1) NOT NULL,
	[PadidAvarTitle] [nvarchar](250) NULL,
	[BirthDate] [nvarchar](50) NULL,
	[DeathDate] [nvarchar](50) NULL,
	[SamplePadidAvarTitle] [nvarchar](250) NULL,
 CONSTRAINT [PK_Creator] PRIMARY KEY CLUSTERED 
(
	[PadidAvarId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Base].[PermissionState]    Script Date: 12/26/2024 6:45:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Base].[PermissionState](
	[PermissionStateId] [int] IDENTITY(1,1) NOT NULL,
	[PermissionStateTitle] [nvarchar](50) NULL,
 CONSTRAINT [PK_PermissionLevel] PRIMARY KEY CLUSTERED 
(
	[PermissionStateId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Base].[PermissionType]    Script Date: 12/26/2024 6:45:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Base].[PermissionType](
	[PermissionTypeId] [int] IDENTITY(1,1) NOT NULL,
	[PermissionTypeTitle] [nvarchar](100) NULL,
	[SamplePermissionTypeTitle] [nvarchar](100) NULL,
 CONSTRAINT [PK_PermissionType] PRIMARY KEY CLUSTERED 
(
	[PermissionTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Base].[PublishState]    Script Date: 12/26/2024 6:45:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Base].[PublishState](
	[PublishStateId] [int] IDENTITY(1,1) NOT NULL,
	[PublishStateTitle] [nvarchar](200) NULL,
 CONSTRAINT [PK_Base.PublishState] PRIMARY KEY CLUSTERED 
(
	[PublishStateId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Base].[Subject]    Script Date: 12/26/2024 6:45:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Base].[Subject](
	[SubjectId] [int] IDENTITY(1,1) NOT NULL,
	[SubjectTitle] [nvarchar](250) NULL,
 CONSTRAINT [PK_Subject] PRIMARY KEY CLUSTERED 
(
	[SubjectId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Base].[UserInfo]    Script Date: 12/26/2024 6:45:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Base].[UserInfo](
	[UsreId] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](100) NULL,
	[LastName] [nvarchar](100) NULL,
	[UserName] [nvarchar](50) NOT NULL,
	[PassWord] [nvarchar](50) NOT NULL,
	[PermissionTypeId] [int] NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[UsreId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Base].[View]    Script Date: 12/26/2024 6:45:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Base].[View](
	[ViewId] [int] IDENTITY(1,1) NOT NULL,
	[ViewTitle] [nvarchar](250) NULL,
	[ViewText] [nvarchar](max) NULL,
	[SenderUserId] [int] NOT NULL,
	[ReceiverUserId] [int] NOT NULL,
	[SendDate] [nvarchar](50) NOT NULL,
	[ReceiveDate] [nvarchar](50) NULL,
 CONSTRAINT [PK_View] PRIMARY KEY CLUSTERED 
(
	[ViewId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [Base].[WorkFlowState]    Script Date: 12/26/2024 6:45:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Base].[WorkFlowState](
	[WorkFlowStateId] [int] IDENTITY(1,1) NOT NULL,
	[WorkFlowTitle] [nvarchar](100) NULL,
 CONSTRAINT [PK_WorkFlowState] PRIMARY KEY CLUSTERED 
(
	[WorkFlowStateId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Content]    Script Date: 12/26/2024 6:45:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Content](
	[ContentId] [int] NOT NULL,
	[ContentTypeId] [int] NULL,
	[DocumentId] [int] NULL,
	[Code] [nvarchar](50) NULL,
	[Description] [nvarchar](max) NULL,
 CONSTRAINT [PK_Content] PRIMARY KEY CLUSTERED 
(
	[ContentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ContentEditorRelation_NotUsed Probably]    Script Date: 12/26/2024 6:45:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ContentEditorRelation_NotUsed Probably](
	[ContentEditorRelationId] [int] IDENTITY(1,1) NOT NULL,
	[ContentId] [int] NULL,
	[EditorId] [int] NULL,
 CONSTRAINT [PK_ContentEditorRelation] PRIMARY KEY CLUSTERED 
(
	[ContentEditorRelationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Document]    Script Date: 12/26/2024 6:45:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Document](
	[DocumentId] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NULL,
	[DocumentCode] [nvarchar](50) NULL,
	[CreatedDate] [datetime] NULL,
	[SiteCode] [nvarchar](50) NULL,
	[OldTitle] [nvarchar](250) NULL,
	[NewTitle] [nvarchar](250) NULL,
	[SubTitle] [nvarchar](250) NULL,
	[PublishStateId] [int] NULL,
	[PermissionStateId] [int] NULL,
	[CreatorUserId] [int] NULL,
	[PadidAvarId] [int] NULL,
	[LanguageId] [int] NULL,
	[Comment] [nvarchar](max) NULL,
	[CollectionId] [int] NULL,
	[SessionNumber] [int] NULL,
	[SessionCount] [int] NULL,
	[SessionPlace] [nvarchar](250) NULL,
	[SessionDate] [datetime] NULL,
	[RelatedLink] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
	[MainCategoryId] [int] NULL,
	[ContentTypeId] [int] NULL,
	[PublishYear] [int] NULL,
	[PublishPlace] [nvarchar](50) NULL,
	[BookPublisher] [nvarchar](250) NULL,
	[BookVolumeNumber] [int] NULL,
	[BookPageNumber] [int] NULL,
	[BookVolumeCount] [int] NULL,
	[FipaCode] [nvarchar](max) NULL,
	[TranslateLanguageId] [int] NULL,
	[Translator] [nvarchar](150) NULL,
	[Narrator] [nvarchar](150) NULL,
	[SecondCategoryId] [int] NULL,
	[FirstCategoryId] [int] NULL,
 CONSTRAINT [PK_Document] PRIMARY KEY CLUSTERED 
(
	[DocumentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DocumentResourceRelation]    Script Date: 12/26/2024 6:45:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DocumentResourceRelation](
	[DocumentResourceRelationId] [int] IDENTITY(1,1) NOT NULL,
	[DocumentId] [int] NULL,
	[ResourceId] [int] NULL,
 CONSTRAINT [PK_DocumentResourceRelation] PRIMARY KEY CLUSTERED 
(
	[DocumentResourceRelationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DocumentSubjectRelation]    Script Date: 12/26/2024 6:45:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DocumentSubjectRelation](
	[DocumentSubjectRelationId] [int] IDENTITY(1,1) NOT NULL,
	[DocumentId] [int] NULL,
	[SubjectId] [int] NULL,
 CONSTRAINT [PK_DocumentSubjectRelation] PRIMARY KEY CLUSTERED 
(
	[DocumentSubjectRelationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[File]    Script Date: 12/26/2024 6:45:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[File](
	[FileId] [int] IDENTITY(1,1) NOT NULL,
	[ContentId] [int] NOT NULL,
	[FileTypeId] [int] NOT NULL,
	[FileNumber] [int] NULL,
	[ResourceId] [int] NULL,
	[DeletionDescription] [nvarchar](max) NULL,
	[Comment] [nvarchar](max) NULL,
	[Text] [nvarchar](max) NULL,
	[FileName] [nvarchar](200) NULL,
	[EditorId] [int] NOT NULL,
 CONSTRAINT [PK_File] PRIMARY KEY CLUSTERED 
(
	[FileId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Resource]    Script Date: 12/26/2024 6:45:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Resource](
	[ResourceId] [int] IDENTITY(1,1) NOT NULL,
	[ResourceTitle] [nvarchar](250) NULL,
 CONSTRAINT [PK_Resource] PRIMARY KEY CLUSTERED 
(
	[ResourceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [Base].[Category] ON 

INSERT [Base].[Category] ([CategoryId], [CategoryTitle], [ParentId], [LevelNo], [ChildCount], [ChildOrder], [CategoryEnglishTitle]) VALUES (1, N'سخنرانی', NULL, 1, 2, NULL, N'Speach')
INSERT [Base].[Category] ([CategoryId], [CategoryTitle], [ParentId], [LevelNo], [ChildCount], [ChildOrder], [CategoryEnglishTitle]) VALUES (2, N'عنوان بصری', 1, 2, NULL, NULL, NULL)
INSERT [Base].[Category] ([CategoryId], [CategoryTitle], [ParentId], [LevelNo], [ChildCount], [ChildOrder], [CategoryEnglishTitle]) VALUES (3, N'سلوک خانواده', 1, 2, 2, NULL, NULL)
INSERT [Base].[Category] ([CategoryId], [CategoryTitle], [ParentId], [LevelNo], [ChildCount], [ChildOrder], [CategoryEnglishTitle]) VALUES (4, N'قم', 3, 3, NULL, 0, NULL)
INSERT [Base].[Category] ([CategoryId], [CategoryTitle], [ParentId], [LevelNo], [ChildCount], [ChildOrder], [CategoryEnglishTitle]) VALUES (5, N'طهران', 3, 3, NULL, 1, NULL)
INSERT [Base].[Category] ([CategoryId], [CategoryTitle], [ParentId], [LevelNo], [ChildCount], [ChildOrder], [CategoryEnglishTitle]) VALUES (6, N'طرح مبانی اسلام', 1, 2, 2, NULL, NULL)
INSERT [Base].[Category] ([CategoryId], [CategoryTitle], [ParentId], [LevelNo], [ChildCount], [ChildOrder], [CategoryEnglishTitle]) VALUES (8, N'جایگاه اهل علم', 6, 2, NULL, 0, NULL)
INSERT [Base].[Category] ([CategoryId], [CategoryTitle], [ParentId], [LevelNo], [ChildCount], [ChildOrder], [CategoryEnglishTitle]) VALUES (9, N'عید غدیر', 6, 2, NULL, 1, NULL)
INSERT [Base].[Category] ([CategoryId], [CategoryTitle], [ParentId], [LevelNo], [ChildCount], [ChildOrder], [CategoryEnglishTitle]) VALUES (10, N'دروس', NULL, 1, 2, NULL, N'Lesson')
INSERT [Base].[Category] ([CategoryId], [CategoryTitle], [ParentId], [LevelNo], [ChildCount], [ChildOrder], [CategoryEnglishTitle]) VALUES (11, N'اسفار', 10, 2, NULL, 0, NULL)
INSERT [Base].[Category] ([CategoryId], [CategoryTitle], [ParentId], [LevelNo], [ChildCount], [ChildOrder], [CategoryEnglishTitle]) VALUES (12, N'منظومه', 10, 2, NULL, 1, NULL)
INSERT [Base].[Category] ([CategoryId], [CategoryTitle], [ParentId], [LevelNo], [ChildCount], [ChildOrder], [CategoryEnglishTitle]) VALUES (13, N'کتب', NULL, 1, NULL, NULL, N'Book')
INSERT [Base].[Category] ([CategoryId], [CategoryTitle], [ParentId], [LevelNo], [ChildCount], [ChildOrder], [CategoryEnglishTitle]) VALUES (14, N'پرسش و پاسخ', NULL, 1, NULL, NULL, N'QA')
INSERT [Base].[Category] ([CategoryId], [CategoryTitle], [ParentId], [LevelNo], [ChildCount], [ChildOrder], [CategoryEnglishTitle]) VALUES (15, N'عرفا (نام عارف)', NULL, 1, 8, NULL, N'Aref')
INSERT [Base].[Category] ([CategoryId], [CategoryTitle], [ParentId], [LevelNo], [ChildCount], [ChildOrder], [CategoryEnglishTitle]) VALUES (16, N'تصویر', 15, 2, NULL, 0, NULL)
INSERT [Base].[Category] ([CategoryId], [CategoryTitle], [ParentId], [LevelNo], [ChildCount], [ChildOrder], [CategoryEnglishTitle]) VALUES (17, N'رحلت', 15, 2, NULL, 1, NULL)
INSERT [Base].[Category] ([CategoryId], [CategoryTitle], [ParentId], [LevelNo], [ChildCount], [ChildOrder], [CategoryEnglishTitle]) VALUES (18, N'ادعیه', 15, 2, NULL, 2, NULL)
INSERT [Base].[Category] ([CategoryId], [CategoryTitle], [ParentId], [LevelNo], [ChildCount], [ChildOrder], [CategoryEnglishTitle]) VALUES (19, N'صدای بزرگان', 15, 2, NULL, 3, NULL)
INSERT [Base].[Category] ([CategoryId], [CategoryTitle], [ParentId], [LevelNo], [ChildCount], [ChildOrder], [CategoryEnglishTitle]) VALUES (20, N'اماکن', 15, 2, NULL, 4, NULL)
INSERT [Base].[Category] ([CategoryId], [CategoryTitle], [ParentId], [LevelNo], [ChildCount], [ChildOrder], [CategoryEnglishTitle]) VALUES (21, N'نامه‌ها', 15, 2, NULL, 5, NULL)
INSERT [Base].[Category] ([CategoryId], [CategoryTitle], [ParentId], [LevelNo], [ChildCount], [ChildOrder], [CategoryEnglishTitle]) VALUES (22, N'دستخط', 15, 2, NULL, 6, NULL)
INSERT [Base].[Category] ([CategoryId], [CategoryTitle], [ParentId], [LevelNo], [ChildCount], [ChildOrder], [CategoryEnglishTitle]) VALUES (23, N'دیگر', 15, 2, NULL, 7, NULL)
INSERT [Base].[Category] ([CategoryId], [CategoryTitle], [ParentId], [LevelNo], [ChildCount], [ChildOrder], [CategoryEnglishTitle]) VALUES (24, N'سایر اسناد', NULL, 1, NULL, NULL, N'OtherDocument')
SET IDENTITY_INSERT [Base].[Category] OFF
GO
SET IDENTITY_INSERT [Base].[ContentType] ON 

INSERT [Base].[ContentType] ([ContentTypeId], [ContentTypeTitle], [ContentTypeTitlePersian]) VALUES (1, N'Text', N'متن')
INSERT [Base].[ContentType] ([ContentTypeId], [ContentTypeTitle], [ContentTypeTitlePersian]) VALUES (2, N'Sound', N'صوت')
INSERT [Base].[ContentType] ([ContentTypeId], [ContentTypeTitle], [ContentTypeTitlePersian]) VALUES (3, N'Image', N'تصویر')
INSERT [Base].[ContentType] ([ContentTypeId], [ContentTypeTitle], [ContentTypeTitlePersian]) VALUES (4, N'Video', N'ویدئو')
SET IDENTITY_INSERT [Base].[ContentType] OFF
GO
SET IDENTITY_INSERT [Base].[FileType] ON 

INSERT [Base].[FileType] ([FileTypeId], [FileTypeTitle], [ContentTypeId], [IsBook], [FileTypeTitlePersian]) VALUES (1, N'M1', 1, NULL, NULL)
INSERT [Base].[FileType] ([FileTypeId], [FileTypeTitle], [ContentTypeId], [IsBook], [FileTypeTitlePersian]) VALUES (2, N'M2', 1, NULL, NULL)
INSERT [Base].[FileType] ([FileTypeId], [FileTypeTitle], [ContentTypeId], [IsBook], [FileTypeTitlePersian]) VALUES (3, N'M3', 1, NULL, NULL)
INSERT [Base].[FileType] ([FileTypeId], [FileTypeTitle], [ContentTypeId], [IsBook], [FileTypeTitlePersian]) VALUES (4, N'ORG', 2, NULL, N'اورجینال')
INSERT [Base].[FileType] ([FileTypeId], [FileTypeTitle], [ContentTypeId], [IsBook], [FileTypeTitlePersian]) VALUES (5, N'H', 2, NULL, N'هواگیری')
INSERT [Base].[FileType] ([FileTypeId], [FileTypeTitle], [ContentTypeId], [IsBook], [FileTypeTitlePersian]) VALUES (6, N'HS', 2, NULL, N'هواگیری-سانسور')
INSERT [Base].[FileType] ([FileTypeId], [FileTypeTitle], [ContentTypeId], [IsBook], [FileTypeTitlePersian]) VALUES (7, N'Final', 2, NULL, N'نهایی')
INSERT [Base].[FileType] ([FileTypeId], [FileTypeTitle], [ContentTypeId], [IsBook], [FileTypeTitlePersian]) VALUES (8, N'N0', 1, NULL, N'تایپ')
INSERT [Base].[FileType] ([FileTypeId], [FileTypeTitle], [ContentTypeId], [IsBook], [FileTypeTitlePersian]) VALUES (9, N'N1', 1, NULL, N'استایل')
INSERT [Base].[FileType] ([FileTypeId], [FileTypeTitle], [ContentTypeId], [IsBook], [FileTypeTitlePersian]) VALUES (10, N'N2', 1, NULL, N'مقابله صوتی')
INSERT [Base].[FileType] ([FileTypeId], [FileTypeTitle], [ContentTypeId], [IsBook], [FileTypeTitlePersian]) VALUES (11, N'N3', 1, NULL, N'مصدر')
INSERT [Base].[FileType] ([FileTypeId], [FileTypeTitle], [ContentTypeId], [IsBook], [FileTypeTitlePersian]) VALUES (12, N'N4', 1, NULL, N'استایل مصدر')
INSERT [Base].[FileType] ([FileTypeId], [FileTypeTitle], [ContentTypeId], [IsBook], [FileTypeTitlePersian]) VALUES (13, N'N5', 1, NULL, N'ویرایش')
SET IDENTITY_INSERT [Base].[FileType] OFF
GO
SET IDENTITY_INSERT [Base].[Language] ON 

INSERT [Base].[Language] ([LanguageId], [LanguageTitle], [BriefLangyageTitle], [LanguageTitlePersian]) VALUES (1, N'انگلیسی', N'en', N'English')
INSERT [Base].[Language] ([LanguageId], [LanguageTitle], [BriefLangyageTitle], [LanguageTitlePersian]) VALUES (2, N'فارسی', N'fa', N'Persian')
INSERT [Base].[Language] ([LanguageId], [LanguageTitle], [BriefLangyageTitle], [LanguageTitlePersian]) VALUES (3, N'عربی', N'ar', N'Arabic')
SET IDENTITY_INSERT [Base].[Language] OFF
GO
SET IDENTITY_INSERT [Base].[PadidAvar] ON 

INSERT [Base].[PadidAvar] ([PadidAvarId], [PadidAvarTitle], [BirthDate], [DeathDate], [SamplePadidAvarTitle]) VALUES (1, N'علامه طهرانی', NULL, NULL, NULL)
INSERT [Base].[PadidAvar] ([PadidAvarId], [PadidAvarTitle], [BirthDate], [DeathDate], [SamplePadidAvarTitle]) VALUES (2, N'آیت الله طهرانی', NULL, NULL, NULL)
SET IDENTITY_INSERT [Base].[PadidAvar] OFF
GO
SET IDENTITY_INSERT [Base].[PermissionState] ON 

INSERT [Base].[PermissionState] ([PermissionStateId], [PermissionStateTitle]) VALUES (1, N'عمومی')
INSERT [Base].[PermissionState] ([PermissionStateId], [PermissionStateTitle]) VALUES (2, N'خصوصی')
SET IDENTITY_INSERT [Base].[PermissionState] OFF
GO
SET IDENTITY_INSERT [Base].[PermissionType] ON 

INSERT [Base].[PermissionType] ([PermissionTypeId], [PermissionTypeTitle], [SamplePermissionTypeTitle]) VALUES (1, N'مدیر کل', NULL)
INSERT [Base].[PermissionType] ([PermissionTypeId], [PermissionTypeTitle], [SamplePermissionTypeTitle]) VALUES (2, N'مدیر پروژه', NULL)
INSERT [Base].[PermissionType] ([PermissionTypeId], [PermissionTypeTitle], [SamplePermissionTypeTitle]) VALUES (3, N'ادمین', NULL)
INSERT [Base].[PermissionType] ([PermissionTypeId], [PermissionTypeTitle], [SamplePermissionTypeTitle]) VALUES (4, N'بازبین', NULL)
INSERT [Base].[PermissionType] ([PermissionTypeId], [PermissionTypeTitle], [SamplePermissionTypeTitle]) VALUES (5, N'کلاینت', NULL)
INSERT [Base].[PermissionType] ([PermissionTypeId], [PermissionTypeTitle], [SamplePermissionTypeTitle]) VALUES (6, N'توسعه دهند فنی', NULL)
SET IDENTITY_INSERT [Base].[PermissionType] OFF
GO
SET IDENTITY_INSERT [Base].[PublishState] ON 

INSERT [Base].[PublishState] ([PublishStateId], [PublishStateTitle]) VALUES (1, N'منتشر شده')
INSERT [Base].[PublishState] ([PublishStateId], [PublishStateTitle]) VALUES (2, N'منتشر نشده')
INSERT [Base].[PublishState] ([PublishStateId], [PublishStateTitle]) VALUES (3, N'عدم انتشار')
SET IDENTITY_INSERT [Base].[PublishState] OFF
GO
SET IDENTITY_INSERT [dbo].[Document] ON 

INSERT [dbo].[Document] ([DocumentId], [UserId], [DocumentCode], [CreatedDate], [SiteCode], [OldTitle], [NewTitle], [SubTitle], [PublishStateId], [PermissionStateId], [CreatorUserId], [PadidAvarId], [LanguageId], [Comment], [CollectionId], [SessionNumber], [SessionCount], [SessionPlace], [SessionDate], [RelatedLink], [Description], [MainCategoryId], [ContentTypeId], [PublishYear], [PublishPlace], [BookPublisher], [BookVolumeNumber], [BookPageNumber], [BookVolumeCount], [FipaCode], [TranslateLanguageId], [Translator], [Narrator], [SecondCategoryId], [FirstCategoryId]) VALUES (2, NULL, NULL, CAST(N'2024-12-26T16:49:01.803' AS DateTime), N'10', N'قدیم', N'جدید', N'زیر', 2, 2, NULL, 1, 1, N'شرح', NULL, 1, 10, N'', NULL, N'مرتبط', NULL, 12, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Document] OFF
GO
ALTER TABLE [Base].[CodeRange]  WITH CHECK ADD  CONSTRAINT [FK_CodeRange_Category] FOREIGN KEY([CategoryId])
REFERENCES [Base].[Category] ([CategoryId])
GO
ALTER TABLE [Base].[CodeRange] CHECK CONSTRAINT [FK_CodeRange_Category]
GO
ALTER TABLE [Base].[Comment]  WITH CHECK ADD  CONSTRAINT [FK_Comment_User] FOREIGN KEY([SenderUserId])
REFERENCES [Base].[UserInfo] ([UsreId])
GO
ALTER TABLE [Base].[Comment] CHECK CONSTRAINT [FK_Comment_User]
GO
ALTER TABLE [Base].[Comment]  WITH CHECK ADD  CONSTRAINT [FK_Comment_User1] FOREIGN KEY([ReceiverUserId])
REFERENCES [Base].[UserInfo] ([UsreId])
GO
ALTER TABLE [Base].[Comment] CHECK CONSTRAINT [FK_Comment_User1]
GO
ALTER TABLE [Base].[UserInfo]  WITH CHECK ADD  CONSTRAINT [FK_User_PermissionType] FOREIGN KEY([PermissionTypeId])
REFERENCES [Base].[PermissionType] ([PermissionTypeId])
GO
ALTER TABLE [Base].[UserInfo] CHECK CONSTRAINT [FK_User_PermissionType]
GO
ALTER TABLE [Base].[View]  WITH CHECK ADD  CONSTRAINT [FK_View_User] FOREIGN KEY([SenderUserId])
REFERENCES [Base].[UserInfo] ([UsreId])
GO
ALTER TABLE [Base].[View] CHECK CONSTRAINT [FK_View_User]
GO
ALTER TABLE [Base].[View]  WITH CHECK ADD  CONSTRAINT [FK_View_User1] FOREIGN KEY([ReceiverUserId])
REFERENCES [Base].[UserInfo] ([UsreId])
GO
ALTER TABLE [Base].[View] CHECK CONSTRAINT [FK_View_User1]
GO
ALTER TABLE [dbo].[Content]  WITH CHECK ADD  CONSTRAINT [FK_Content_ContentType] FOREIGN KEY([ContentTypeId])
REFERENCES [Base].[ContentType] ([ContentTypeId])
GO
ALTER TABLE [dbo].[Content] CHECK CONSTRAINT [FK_Content_ContentType]
GO
ALTER TABLE [dbo].[Content]  WITH CHECK ADD  CONSTRAINT [FK_Content_Document] FOREIGN KEY([DocumentId])
REFERENCES [dbo].[Document] ([DocumentId])
GO
ALTER TABLE [dbo].[Content] CHECK CONSTRAINT [FK_Content_Document]
GO
ALTER TABLE [dbo].[Document]  WITH CHECK ADD  CONSTRAINT [FK_Document_Category] FOREIGN KEY([MainCategoryId])
REFERENCES [Base].[Category] ([CategoryId])
GO
ALTER TABLE [dbo].[Document] CHECK CONSTRAINT [FK_Document_Category]
GO
ALTER TABLE [dbo].[Document]  WITH CHECK ADD  CONSTRAINT [FK_Document_Collection] FOREIGN KEY([CollectionId])
REFERENCES [Base].[Collection] ([CollectionId])
GO
ALTER TABLE [dbo].[Document] CHECK CONSTRAINT [FK_Document_Collection]
GO
ALTER TABLE [dbo].[Document]  WITH CHECK ADD  CONSTRAINT [FK_Document_Language] FOREIGN KEY([LanguageId])
REFERENCES [Base].[Language] ([LanguageId])
GO
ALTER TABLE [dbo].[Document] CHECK CONSTRAINT [FK_Document_Language]
GO
ALTER TABLE [dbo].[Document]  WITH CHECK ADD  CONSTRAINT [FK_Document_PadidAvar] FOREIGN KEY([PadidAvarId])
REFERENCES [Base].[PadidAvar] ([PadidAvarId])
GO
ALTER TABLE [dbo].[Document] CHECK CONSTRAINT [FK_Document_PadidAvar]
GO
ALTER TABLE [dbo].[Document]  WITH CHECK ADD  CONSTRAINT [FK_Document_PermissionLevel] FOREIGN KEY([PermissionStateId])
REFERENCES [Base].[PermissionState] ([PermissionStateId])
GO
ALTER TABLE [dbo].[Document] CHECK CONSTRAINT [FK_Document_PermissionLevel]
GO
ALTER TABLE [dbo].[Document]  WITH CHECK ADD  CONSTRAINT [FK_Document_PublishState] FOREIGN KEY([PublishStateId])
REFERENCES [Base].[PublishState] ([PublishStateId])
GO
ALTER TABLE [dbo].[Document] CHECK CONSTRAINT [FK_Document_PublishState]
GO
ALTER TABLE [dbo].[Document]  WITH CHECK ADD  CONSTRAINT [FK_Document_User] FOREIGN KEY([CreatorUserId])
REFERENCES [Base].[UserInfo] ([UsreId])
GO
ALTER TABLE [dbo].[Document] CHECK CONSTRAINT [FK_Document_User]
GO
ALTER TABLE [dbo].[DocumentResourceRelation]  WITH CHECK ADD  CONSTRAINT [FK_DocumentResourceRelation_Document] FOREIGN KEY([DocumentId])
REFERENCES [dbo].[Document] ([DocumentId])
GO
ALTER TABLE [dbo].[DocumentResourceRelation] CHECK CONSTRAINT [FK_DocumentResourceRelation_Document]
GO
ALTER TABLE [dbo].[DocumentResourceRelation]  WITH CHECK ADD  CONSTRAINT [FK_DocumentResourceRelation_Resource] FOREIGN KEY([ResourceId])
REFERENCES [dbo].[Resource] ([ResourceId])
GO
ALTER TABLE [dbo].[DocumentResourceRelation] CHECK CONSTRAINT [FK_DocumentResourceRelation_Resource]
GO
ALTER TABLE [dbo].[DocumentSubjectRelation]  WITH CHECK ADD  CONSTRAINT [FK_DocumentSubjectRelation_Document] FOREIGN KEY([DocumentId])
REFERENCES [dbo].[Document] ([DocumentId])
GO
ALTER TABLE [dbo].[DocumentSubjectRelation] CHECK CONSTRAINT [FK_DocumentSubjectRelation_Document]
GO
ALTER TABLE [dbo].[DocumentSubjectRelation]  WITH CHECK ADD  CONSTRAINT [FK_DocumentSubjectRelation_Subject] FOREIGN KEY([SubjectId])
REFERENCES [Base].[Subject] ([SubjectId])
GO
ALTER TABLE [dbo].[DocumentSubjectRelation] CHECK CONSTRAINT [FK_DocumentSubjectRelation_Subject]
GO
ALTER TABLE [dbo].[File]  WITH CHECK ADD  CONSTRAINT [FK_File_Content] FOREIGN KEY([ContentId])
REFERENCES [dbo].[Content] ([ContentId])
GO
ALTER TABLE [dbo].[File] CHECK CONSTRAINT [FK_File_Content]
GO
ALTER TABLE [dbo].[File]  WITH CHECK ADD  CONSTRAINT [FK_File_Editor] FOREIGN KEY([EditorId])
REFERENCES [Base].[Editor] ([EditorId])
GO
ALTER TABLE [dbo].[File] CHECK CONSTRAINT [FK_File_Editor]
GO
ALTER TABLE [dbo].[File]  WITH CHECK ADD  CONSTRAINT [FK_File_FileType] FOREIGN KEY([FileTypeId])
REFERENCES [Base].[FileType] ([FileTypeId])
GO
ALTER TABLE [dbo].[File] CHECK CONSTRAINT [FK_File_FileType]
GO
ALTER TABLE [dbo].[File]  WITH CHECK ADD  CONSTRAINT [FK_File_Resource] FOREIGN KEY([ResourceId])
REFERENCES [dbo].[Resource] ([ResourceId])
GO
ALTER TABLE [dbo].[File] CHECK CONSTRAINT [FK_File_Resource]
GO
/****** Object:  StoredProcedure [dbo].[GetAllContent]    Script Date: 12/26/2024 6:45:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetAllContent] 
AS
BEGIN
	SELECT TOP (1000) [ContentId]
		  ,c.ContentTypeId
		  ,c.FileTypeId
		  ,c.ResourceId
		  ,DocumentId
		  ,Code
		  ,Description
		  ,FileNumber
		  ,DeletionDescription
		  ,Comment
		  ,Text
		  ,FileName
	FROM Content c
	join base.FileType f on c.FileTypeId = f.FileTypeId
	join base.ContentType ct on c.ContentTypeId = ct.ContentTypeId
	join Resource r on c.ResourceId = r.ResourceId
END
GO
/****** Object:  StoredProcedure [dbo].[GetContentByDocumentId]    Script Date: 12/26/2024 6:45:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetContentByDocumentId]
	@DocumentId int
AS
BEGIN
	SELECT TOP (1000) 
		   c.ContentId
		  ,ct.ContentTypeTitle
		  ,ft.FileTypeTitle
		  ,FileNumber
		  ,r.ResourceTitle
		  ,DocumentId
		  ,Code
		  ,Description
		  ,DeletionDescription
		  ,Comment
		  ,Text
		  ,FileName
	FROM [File] f join Content c on f.ContentId = c.ContentId
	join base.FileType ft on f.FileTypeId = ft.FileTypeId
	join base.ContentType ct on c.ContentTypeId = ct.ContentTypeId
	join Resource r on f.ResourceId = r.ResourceId
	where c.DocumentId = @DocumentId
END
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'شناسه' , @level0type=N'SCHEMA',@level0name=N'Base', @level1type=N'TABLE',@level1name=N'Category', @level2type=N'COLUMN',@level2name=N'CategoryId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'عنوان دسته' , @level0type=N'SCHEMA',@level0name=N'Base', @level1type=N'TABLE',@level1name=N'Category', @level2type=N'COLUMN',@level2name=N'CategoryTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'شناسه پدر' , @level0type=N'SCHEMA',@level0name=N'Base', @level1type=N'TABLE',@level1name=N'Category', @level2type=N'COLUMN',@level2name=N'ParentId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'سطح درخت' , @level0type=N'SCHEMA',@level0name=N'Base', @level1type=N'TABLE',@level1name=N'Category', @level2type=N'COLUMN',@level2name=N'LevelNo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'تعداد فرزندان' , @level0type=N'SCHEMA',@level0name=N'Base', @level1type=N'TABLE',@level1name=N'Category', @level2type=N'COLUMN',@level2name=N'ChildCount'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ترتیب فرزندان' , @level0type=N'SCHEMA',@level0name=N'Base', @level1type=N'TABLE',@level1name=N'Category', @level2type=N'COLUMN',@level2name=N'ChildOrder'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'درخت دسته بندی' , @level0type=N'SCHEMA',@level0name=N'Base', @level1type=N'TABLE',@level1name=N'Category'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'شناسه' , @level0type=N'SCHEMA',@level0name=N'Base', @level1type=N'TABLE',@level1name=N'CodeRange', @level2type=N'COLUMN',@level2name=N'CodeRangeId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'کد ابتدایی' , @level0type=N'SCHEMA',@level0name=N'Base', @level1type=N'TABLE',@level1name=N'CodeRange', @level2type=N'COLUMN',@level2name=N'MinCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'کد انتهایی' , @level0type=N'SCHEMA',@level0name=N'Base', @level1type=N'TABLE',@level1name=N'CodeRange', @level2type=N'COLUMN',@level2name=N'MaxCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'شناسه دسته (سخنرانی - کتب - ....)' , @level0type=N'SCHEMA',@level0name=N'Base', @level1type=N'TABLE',@level1name=N'CodeRange', @level2type=N'COLUMN',@level2name=N'CategoryId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'محدوده کدهای قبلی' , @level0type=N'SCHEMA',@level0name=N'Base', @level1type=N'TABLE',@level1name=N'CodeRange'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'شناسه' , @level0type=N'SCHEMA',@level0name=N'Base', @level1type=N'TABLE',@level1name=N'Comment', @level2type=N'COLUMN',@level2name=N'CommentId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'عنوان کامنت' , @level0type=N'SCHEMA',@level0name=N'Base', @level1type=N'TABLE',@level1name=N'Comment', @level2type=N'COLUMN',@level2name=N'CommentTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'متن کامنت' , @level0type=N'SCHEMA',@level0name=N'Base', @level1type=N'TABLE',@level1name=N'Comment', @level2type=N'COLUMN',@level2name=N'CommentText'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'شناسه فرستنده' , @level0type=N'SCHEMA',@level0name=N'Base', @level1type=N'TABLE',@level1name=N'Comment', @level2type=N'COLUMN',@level2name=N'SenderUserId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'شناسه گیرنده' , @level0type=N'SCHEMA',@level0name=N'Base', @level1type=N'TABLE',@level1name=N'Comment', @level2type=N'COLUMN',@level2name=N'ReceiverUserId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'تاریخ ارسال' , @level0type=N'SCHEMA',@level0name=N'Base', @level1type=N'TABLE',@level1name=N'Comment', @level2type=N'COLUMN',@level2name=N'SendDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'تاریخ دریافت' , @level0type=N'SCHEMA',@level0name=N'Base', @level1type=N'TABLE',@level1name=N'Comment', @level2type=N'COLUMN',@level2name=N'ReceiveDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'کامنت' , @level0type=N'SCHEMA',@level0name=N'Base', @level1type=N'TABLE',@level1name=N'Comment'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'شناسه نوع محتوا' , @level0type=N'SCHEMA',@level0name=N'Base', @level1type=N'TABLE',@level1name=N'ContentType', @level2type=N'COLUMN',@level2name=N'ContentTypeId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'نوع محتوا' , @level0type=N'SCHEMA',@level0name=N'Base', @level1type=N'TABLE',@level1name=N'ContentType', @level2type=N'COLUMN',@level2name=N'ContentTypeTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'نوع محتوا' , @level0type=N'SCHEMA',@level0name=N'Base', @level1type=N'TABLE',@level1name=N'ContentType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'شناسه' , @level0type=N'SCHEMA',@level0name=N'Base', @level1type=N'TABLE',@level1name=N'Editor', @level2type=N'COLUMN',@level2name=N'EditorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'نام ویرایش کننده' , @level0type=N'SCHEMA',@level0name=N'Base', @level1type=N'TABLE',@level1name=N'Editor', @level2type=N'COLUMN',@level2name=N'EditorName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'شناسه' , @level0type=N'SCHEMA',@level0name=N'Base', @level1type=N'TABLE',@level1name=N'FileType', @level2type=N'COLUMN',@level2name=N'FileTypeId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'عنوان نوع فایل' , @level0type=N'SCHEMA',@level0name=N'Base', @level1type=N'TABLE',@level1name=N'FileType', @level2type=N'COLUMN',@level2name=N'FileTypeTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'شناسه نوع محتوا (کلید خارجی)' , @level0type=N'SCHEMA',@level0name=N'Base', @level1type=N'TABLE',@level1name=N'FileType', @level2type=N'COLUMN',@level2name=N'ContentTypeId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'مربوط به دسته بندی کتاب است:1 (مهم است چون مثلا نوع فایل یا تنوع سند متن در اسناد غیرکتاب با اسناد کتاب متفاوت است)' , @level0type=N'SCHEMA',@level0name=N'Base', @level1type=N'TABLE',@level1name=N'FileType', @level2type=N'COLUMN',@level2name=N'IsBook'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'نوع فایل (تنوع سند)' , @level0type=N'SCHEMA',@level0name=N'Base', @level1type=N'TABLE',@level1name=N'FileType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'شناسه' , @level0type=N'SCHEMA',@level0name=N'Base', @level1type=N'TABLE',@level1name=N'Language', @level2type=N'COLUMN',@level2name=N'LanguageId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'زبان' , @level0type=N'SCHEMA',@level0name=N'Base', @level1type=N'TABLE',@level1name=N'Language', @level2type=N'COLUMN',@level2name=N'LanguageTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'علامت اختصاری زبان' , @level0type=N'SCHEMA',@level0name=N'Base', @level1type=N'TABLE',@level1name=N'Language', @level2type=N'COLUMN',@level2name=N'BriefLangyageTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'شناسه پدیدآور' , @level0type=N'SCHEMA',@level0name=N'Base', @level1type=N'TABLE',@level1name=N'PadidAvar', @level2type=N'COLUMN',@level2name=N'PadidAvarId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'نام پدیدآور' , @level0type=N'SCHEMA',@level0name=N'Base', @level1type=N'TABLE',@level1name=N'PadidAvar', @level2type=N'COLUMN',@level2name=N'PadidAvarTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'تاریخ تولد' , @level0type=N'SCHEMA',@level0name=N'Base', @level1type=N'TABLE',@level1name=N'PadidAvar', @level2type=N'COLUMN',@level2name=N'BirthDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'تاریخ وفات' , @level0type=N'SCHEMA',@level0name=N'Base', @level1type=N'TABLE',@level1name=N'PadidAvar', @level2type=N'COLUMN',@level2name=N'DeathDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'پدیدآور' , @level0type=N'SCHEMA',@level0name=N'Base', @level1type=N'TABLE',@level1name=N'PadidAvar'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'شناسه' , @level0type=N'SCHEMA',@level0name=N'Base', @level1type=N'TABLE',@level1name=N'PermissionState', @level2type=N'COLUMN',@level2name=N'PermissionStateId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'عنوان وضعیت دسترسی' , @level0type=N'SCHEMA',@level0name=N'Base', @level1type=N'TABLE',@level1name=N'PermissionState', @level2type=N'COLUMN',@level2name=N'PermissionStateTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'وضعیت دسترسی' , @level0type=N'SCHEMA',@level0name=N'Base', @level1type=N'TABLE',@level1name=N'PermissionState'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'شناسه' , @level0type=N'SCHEMA',@level0name=N'Base', @level1type=N'TABLE',@level1name=N'PermissionType', @level2type=N'COLUMN',@level2name=N'PermissionTypeId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'نوع دسترسی' , @level0type=N'SCHEMA',@level0name=N'Base', @level1type=N'TABLE',@level1name=N'PermissionType', @level2type=N'COLUMN',@level2name=N'PermissionTypeTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'نوع دسترسی' , @level0type=N'SCHEMA',@level0name=N'Base', @level1type=N'TABLE',@level1name=N'PermissionType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'شناسه' , @level0type=N'SCHEMA',@level0name=N'Base', @level1type=N'TABLE',@level1name=N'PublishState', @level2type=N'COLUMN',@level2name=N'PublishStateId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'عنوان وضعیت انتشار' , @level0type=N'SCHEMA',@level0name=N'Base', @level1type=N'TABLE',@level1name=N'PublishState', @level2type=N'COLUMN',@level2name=N'PublishStateTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'وضعیت انتشار' , @level0type=N'SCHEMA',@level0name=N'Base', @level1type=N'TABLE',@level1name=N'PublishState'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'شناسه' , @level0type=N'SCHEMA',@level0name=N'Base', @level1type=N'TABLE',@level1name=N'Subject', @level2type=N'COLUMN',@level2name=N'SubjectId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'موضوع' , @level0type=N'SCHEMA',@level0name=N'Base', @level1type=N'TABLE',@level1name=N'Subject', @level2type=N'COLUMN',@level2name=N'SubjectTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'موضوع' , @level0type=N'SCHEMA',@level0name=N'Base', @level1type=N'TABLE',@level1name=N'Subject'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'شناسه' , @level0type=N'SCHEMA',@level0name=N'Base', @level1type=N'TABLE',@level1name=N'UserInfo', @level2type=N'COLUMN',@level2name=N'UsreId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'نام' , @level0type=N'SCHEMA',@level0name=N'Base', @level1type=N'TABLE',@level1name=N'UserInfo', @level2type=N'COLUMN',@level2name=N'FirstName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'نام خانوادگی' , @level0type=N'SCHEMA',@level0name=N'Base', @level1type=N'TABLE',@level1name=N'UserInfo', @level2type=N'COLUMN',@level2name=N'LastName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'نام کاربری' , @level0type=N'SCHEMA',@level0name=N'Base', @level1type=N'TABLE',@level1name=N'UserInfo', @level2type=N'COLUMN',@level2name=N'UserName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'رمز عبور' , @level0type=N'SCHEMA',@level0name=N'Base', @level1type=N'TABLE',@level1name=N'UserInfo', @level2type=N'COLUMN',@level2name=N'PassWord'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'شناسه نوع دسترسی (کلید خارجی)' , @level0type=N'SCHEMA',@level0name=N'Base', @level1type=N'TABLE',@level1name=N'UserInfo', @level2type=N'COLUMN',@level2name=N'PermissionTypeId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'کاربران' , @level0type=N'SCHEMA',@level0name=N'Base', @level1type=N'TABLE',@level1name=N'UserInfo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'عنوان نظر' , @level0type=N'SCHEMA',@level0name=N'Base', @level1type=N'TABLE',@level1name=N'View', @level2type=N'COLUMN',@level2name=N'ViewTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'متن نظر' , @level0type=N'SCHEMA',@level0name=N'Base', @level1type=N'TABLE',@level1name=N'View', @level2type=N'COLUMN',@level2name=N'ViewText'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'شناسه فرستنده' , @level0type=N'SCHEMA',@level0name=N'Base', @level1type=N'TABLE',@level1name=N'View', @level2type=N'COLUMN',@level2name=N'SenderUserId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'شناسه گیرنده' , @level0type=N'SCHEMA',@level0name=N'Base', @level1type=N'TABLE',@level1name=N'View', @level2type=N'COLUMN',@level2name=N'ReceiverUserId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'تاریخ ارسال' , @level0type=N'SCHEMA',@level0name=N'Base', @level1type=N'TABLE',@level1name=N'View', @level2type=N'COLUMN',@level2name=N'SendDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'تاریخ دریافت' , @level0type=N'SCHEMA',@level0name=N'Base', @level1type=N'TABLE',@level1name=N'View', @level2type=N'COLUMN',@level2name=N'ReceiveDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'نظرات' , @level0type=N'SCHEMA',@level0name=N'Base', @level1type=N'TABLE',@level1name=N'View'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'شناسه' , @level0type=N'SCHEMA',@level0name=N'Base', @level1type=N'TABLE',@level1name=N'WorkFlowState', @level2type=N'COLUMN',@level2name=N'WorkFlowStateId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ایستگاه‌های چرخه کاری' , @level0type=N'SCHEMA',@level0name=N'Base', @level1type=N'TABLE',@level1name=N'WorkFlowState'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'شناسه نوع محتوا' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Content', @level2type=N'COLUMN',@level2name=N'ContentTypeId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'شناسه سند' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Content', @level2type=N'COLUMN',@level2name=N'DocumentId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'کد' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Content', @level2type=N'COLUMN',@level2name=N'Code'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'توضیحات' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Content', @level2type=N'COLUMN',@level2name=N'Description'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'شناسه کاربر' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Document', @level2type=N'COLUMN',@level2name=N'UserId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'کد سایت' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Document', @level2type=N'COLUMN',@level2name=N'SiteCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'عنوان قدیم' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Document', @level2type=N'COLUMN',@level2name=N'OldTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'عنوان جدید' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Document', @level2type=N'COLUMN',@level2name=N'NewTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'زیر عنوان' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Document', @level2type=N'COLUMN',@level2name=N'SubTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'شناسه وضعیت انتشار' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Document', @level2type=N'COLUMN',@level2name=N'PublishStateId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'شناسه وضعیت دسترسی' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Document', @level2type=N'COLUMN',@level2name=N'PermissionStateId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'شناسه کاربر ایجاد کننده' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Document', @level2type=N'COLUMN',@level2name=N'CreatorUserId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'شناسه پدیدآور' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Document', @level2type=N'COLUMN',@level2name=N'PadidAvarId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'شناسه زبان' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Document', @level2type=N'COLUMN',@level2name=N'LanguageId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'توضیحات' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Document', @level2type=N'COLUMN',@level2name=N'Comment'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'شناسه مجموعه (کلید خارجی)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Document', @level2type=N'COLUMN',@level2name=N'CollectionId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'شماره جلسه' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Document', @level2type=N'COLUMN',@level2name=N'SessionNumber'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'تعداد جلسه' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Document', @level2type=N'COLUMN',@level2name=N'SessionCount'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'مکان جلسه' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Document', @level2type=N'COLUMN',@level2name=N'SessionPlace'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'تاریخ جلسه' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Document', @level2type=N'COLUMN',@level2name=N'SessionDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'لینک سند مرتبط' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Document', @level2type=N'COLUMN',@level2name=N'RelatedLink'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'شرح سند' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Document', @level2type=N'COLUMN',@level2name=N'Description'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'شناسه دسته‌بندی' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Document', @level2type=N'COLUMN',@level2name=N'MainCategoryId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'شناسه نوع محتوا' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Document', @level2type=N'COLUMN',@level2name=N'ContentTypeId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'سال نشر (مختص کتاب)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Document', @level2type=N'COLUMN',@level2name=N'PublishYear'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'محل نشر (مختص کتاب)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Document', @level2type=N'COLUMN',@level2name=N'PublishPlace'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ناشر (مختص کتاب)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Document', @level2type=N'COLUMN',@level2name=N'BookPublisher'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'شماره جلد (مختص کتاب)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Document', @level2type=N'COLUMN',@level2name=N'BookVolumeNumber'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'شماره صفحه (مختص کتاب)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Document', @level2type=N'COLUMN',@level2name=N'BookPageNumber'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'تعداد جلد (مختص کتاب)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Document', @level2type=N'COLUMN',@level2name=N'BookVolumeCount'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'کد فیپا (مختص کتاب)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Document', @level2type=N'COLUMN',@level2name=N'FipaCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'شناسه زبان (کلید خارجی)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Document', @level2type=N'COLUMN',@level2name=N'TranslateLanguageId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'مترجم' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Document', @level2type=N'COLUMN',@level2name=N'Translator'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'گوینده' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Document', @level2type=N'COLUMN',@level2name=N'Narrator'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'سند' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Document'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'شناسه' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DocumentResourceRelation', @level2type=N'COLUMN',@level2name=N'DocumentResourceRelationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'شناسه سند' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DocumentResourceRelation', @level2type=N'COLUMN',@level2name=N'DocumentId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'شناسه منبع' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DocumentResourceRelation', @level2type=N'COLUMN',@level2name=N'ResourceId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'جدول ارتباطی سند و منبع' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DocumentResourceRelation'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'جدول ارتباطی سند و موضوع' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DocumentSubjectRelation'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'شناسه فایل' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'File', @level2type=N'COLUMN',@level2name=N'FileId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'شناسه محتوا' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'File', @level2type=N'COLUMN',@level2name=N'ContentId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'شناسه نوع فایل (تنوع اسناد)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'File', @level2type=N'COLUMN',@level2name=N'FileTypeId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'شماره فایل' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'File', @level2type=N'COLUMN',@level2name=N'FileNumber'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'شناسه منبع' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'File', @level2type=N'COLUMN',@level2name=N'ResourceId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'توضیحات حذفیات' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'File', @level2type=N'COLUMN',@level2name=N'DeletionDescription'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'کامنت' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'File', @level2type=N'COLUMN',@level2name=N'Comment'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'متن برای نوع فایل تکست' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'File', @level2type=N'COLUMN',@level2name=N'Text'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'نام فایل فیزیکی' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'File', @level2type=N'COLUMN',@level2name=N'FileName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'شناسه ویرایشگر' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'File', @level2type=N'COLUMN',@level2name=N'EditorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'شناسه' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Resource', @level2type=N'COLUMN',@level2name=N'ResourceId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'عنوان منبع' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Resource', @level2type=N'COLUMN',@level2name=N'ResourceTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'منبع' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Resource'
GO
