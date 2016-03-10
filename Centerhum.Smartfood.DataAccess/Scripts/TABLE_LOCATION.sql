USE [SmartFood]
GO

/****** Object:  Table [dbo].[User]    Script Date: 24/02/2016 21:21:56 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Location](
	Id int NOT NULL PRIMARY KEY IDENTITY (1, 1),
	CreatedDate datetime NOT NULL,
	Street varchar(80) NOT NULL,
	Number int NOT NULL,
	Block varchar(80) NULL,
	ApNumber int NULL,
	Complement varchar(120) NOT NULL
)

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].Location ADD  CONSTRAINT [DF_Location_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO