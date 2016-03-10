USE [SmartFood]
GO

/****** Object:  Table [dbo].[User]    Script Date: 24/02/2016 21:21:56 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Ingredient](
	Id int NOT NULL PRIMARY KEY IDENTITY (1, 1),
	CreatedDate datetime NOT NULL,
	Name varchar(80) NOT NULL
)

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].Ingredient ADD  CONSTRAINT [DF_Ingredient_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO