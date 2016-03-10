USE [SmartFood]
GO

/****** Object:  Table [dbo].[User]    Script Date: 24/02/2016 21:21:56 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Client](
	Id int NOT NULL PRIMARY KEY IDENTITY (1, 1),
	CreatedDate datetime NOT NULL,
	FullName varchar(100) NOT NULL,
	BirthDate datetime NULL,
	PhoneNumber varchar(15) NOT NULL,
	CellNumber varchar(15) NULL,
	LocationId INT NOT NULL,
	FOREIGN KEY (LocationId) REFERENCES Location
)

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].Client ADD  CONSTRAINT [DF_Client_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO