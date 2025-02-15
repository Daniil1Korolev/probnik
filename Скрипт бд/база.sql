USE [ribalka]
GO
/****** Object:  Table [dbo].[Active]    Script Date: 13.06.2024 15:12:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Active](
	[ID_Active] [int] IDENTITY(1,1) NOT NULL,
	[Number] [int] NOT NULL,
	[DateAdd] [date] NOT NULL,
	[NameActive] [varchar](50) NOT NULL,
	[Category] [varchar](50) NOT NULL,
	[Price] [float] NOT NULL,
	[Count] [int] NOT NULL,
	[Description] [varchar](250) NOT NULL,
	[NameFish] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Active] PRIMARY KEY CLUSTERED 
(
	[ID_Active] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Feeding]    Script Date: 13.06.2024 15:12:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Feeding](
	[ID_Feeding] [int] IDENTITY(1,1) NOT NULL,
	[FeederName] [varchar](50) NOT NULL,
	[Active_ID] [int] NOT NULL,
 CONSTRAINT [PK_Feeding] PRIMARY KEY CLUSTERED 
(
	[ID_Feeding] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Fishing]    Script Date: 13.06.2024 15:12:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Fishing](
	[ID_Fishing] [int] IDENTITY(1,1) NOT NULL,
	[DateFishingStart] [datetime] NOT NULL,
	[InstructorName] [varchar](50) NOT NULL,
	[TouristName] [varchar](50) NOT NULL,
	[DateFishingEnd] [datetime] NOT NULL,
	[Active_ID] [int] NOT NULL,
 CONSTRAINT [PK_Fishing] PRIMARY KEY CLUSTERED 
(
	[ID_Fishing] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FishResult]    Script Date: 13.06.2024 15:12:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FishResult](
	[ID_FishResult] [int] IDENTITY(1,1) NOT NULL,
	[CountFish] [int] NOT NULL,
	[Fishing_ID] [int] NOT NULL,
 CONSTRAINT [PK_FishResult] PRIMARY KEY CLUSTERED 
(
	[ID_FishResult] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 13.06.2024 15:12:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[ID_User] [int] IDENTITY(1,1) NOT NULL,
	[Login] [varchar](50) NOT NULL,
	[Password] [varchar](50) NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[ID_User] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Feeding]  WITH CHECK ADD  CONSTRAINT [FK_Feeding_Active] FOREIGN KEY([ID_Feeding])
REFERENCES [dbo].[Active] ([ID_Active])
GO
ALTER TABLE [dbo].[Feeding] CHECK CONSTRAINT [FK_Feeding_Active]
GO
ALTER TABLE [dbo].[Fishing]  WITH CHECK ADD  CONSTRAINT [FK_Fishing_Active] FOREIGN KEY([Active_ID])
REFERENCES [dbo].[Active] ([ID_Active])
GO
ALTER TABLE [dbo].[Fishing] CHECK CONSTRAINT [FK_Fishing_Active]
GO
ALTER TABLE [dbo].[FishResult]  WITH CHECK ADD  CONSTRAINT [FK_FishResult_Fishing] FOREIGN KEY([Fishing_ID])
REFERENCES [dbo].[Fishing] ([ID_Fishing])
GO
ALTER TABLE [dbo].[FishResult] CHECK CONSTRAINT [FK_FishResult_Fishing]
GO
