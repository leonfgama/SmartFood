USE [SmartFood]
GO

/****** Object:  Table [dbo].[User]    Script Date: 24/02/2016 21:21:56 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[ProductIngredients](
	Id int NOT NULL PRIMARY KEY IDENTITY (1, 1),
	CreatedDate datetime NOT NULL,
	ProductId INT NOT NULL,
	IngredientsId INT NOT NULL,
	FOREIGN KEY (ProductId) REFERENCES Product,
	FOREIGN KEY (IngredientsId) REFERENCES Ingredient
)

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[ProductIngredients] ADD  CONSTRAINT [DF_ProductIngredients_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO