CREATE TABLE [dbo].[Dat_Company] (
	[CompanyID] [int] NOT NULL ,
	[UserID] [int] NULL ,
	[CompanyName] [char] (64) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[Address1] [char] (128) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[Address2] [char] (128) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[City] [char] (64) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[State] [char] (3) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[Zipcode] [char] (10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[Country] [char] (32) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[CreateDate] [datetime] NULL 
) ON [PRIMARY]
GO



CREATE TABLE [dbo].[Dat_Issue] (
	[IssueID] [int] NOT NULL ,
	[TypeID] [int] NULL ,
	[UserID] [int] NULL ,
	[EntryDate] [datetime] NULL ,
	[StatusID] [int] NULL ,
	[Summary] [char] (128) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[Description] [text] COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[PriorityID] [int] NULL,
	[ModifiedDate] [datetime] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO



CREATE TABLE [dbo].[Dat_User] (
	[UserID] [int] NOT NULL ,
	[Password] [char] (16) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[Firstname] [char] (32) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[Lastname] [char] (64) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[EmailAddress] [char] (256) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[UserType] [int] NULL ,
	[CreateDate] [datetime] NULL 
) ON [PRIMARY]
GO



CREATE TABLE [dbo].[Val_IssueType] (
	[TypeID]  [int]  NOT NULL ,
	[TypeLabel] [char] (32) COLLATE SQL_Latin1_General_CP1_CI_AS NULL 
) ON [PRIMARY]
GO



CREATE TABLE [dbo].[Val_MailMessage] (
	[MailMessageID] [int] NOT NULL ,
	[Format] [int] NULL ,
	[Priority] [int] NULL ,
	[Subject] [char] (128) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[Body] [text] COLLATE SQL_Latin1_General_CP1_CI_AS NULL 
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO



CREATE TABLE [dbo].[Val_Priority] (
	[PriorityID]  [int]  NOT NULL ,
	[PriorityLabel] [char] (32) COLLATE SQL_Latin1_General_CP1_CI_AS NULL 
) ON [PRIMARY]
GO



CREATE TABLE [dbo].[Val_Reports] (
	[ReportID] [int] NOT NULL ,
	[ReportLabel] [char] (32) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[ReportFilePath] [char] (256) COLLATE SQL_Latin1_General_CP1_CI_AS NULL 
) ON [PRIMARY]
GO



CREATE TABLE [dbo].[Val_Status] (
	[StatusID]  [int] NOT NULL ,
	[StatusLabel] [char] (32) COLLATE SQL_Latin1_General_CP1_CI_AS NULL 
) ON [PRIMARY]
GO
