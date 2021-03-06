USE [master]
GO
/****** Object:  Database [AspNews]    Script Date: 29/7/19 09:13:08 ب.ظ ******/
CREATE DATABASE [AspNews]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'AspNews', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\AspNews.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'AspNews_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\AspNews_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [AspNews] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [AspNews].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [AspNews] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [AspNews] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [AspNews] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [AspNews] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [AspNews] SET ARITHABORT OFF 
GO
ALTER DATABASE [AspNews] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [AspNews] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [AspNews] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [AspNews] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [AspNews] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [AspNews] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [AspNews] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [AspNews] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [AspNews] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [AspNews] SET  DISABLE_BROKER 
GO
ALTER DATABASE [AspNews] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [AspNews] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [AspNews] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [AspNews] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [AspNews] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [AspNews] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [AspNews] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [AspNews] SET RECOVERY FULL 
GO
ALTER DATABASE [AspNews] SET  MULTI_USER 
GO
ALTER DATABASE [AspNews] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [AspNews] SET DB_CHAINING OFF 
GO
ALTER DATABASE [AspNews] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [AspNews] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [AspNews] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'AspNews', N'ON'
GO
USE [AspNews]
GO
/****** Object:  Table [dbo].[Audios]    Script Date: 29/7/19 09:13:08 ب.ظ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Audios](
	[Id] [int] NOT NULL,
	[Title] [nvarchar](255) NOT NULL,
	[Lead] [nvarchar](1000) NULL,
	[Body] [nvarchar](max) NULL,
	[SlideShow] [bit] NULL,
	[Type] [nvarchar](50) NOT NULL,
	[UserId] [int] NOT NULL,
	[CreatedAt] [smalldatetime] NOT NULL,
	[UpdatedAt] [smalldatetime] NOT NULL,
 CONSTRAINT [PK_Audios] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Categories]    Script Date: 29/7/19 09:13:08 ب.ظ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[Id] [int] NOT NULL,
	[Title] [nvarchar](100) NOT NULL,
	[CreatedAt] [smalldatetime] NOT NULL,
	[UpdatedAt] [smalldatetime] NOT NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CategoryAudio]    Script Date: 29/7/19 09:13:08 ب.ظ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CategoryAudio](
	[Id] [int] NOT NULL,
	[CategoryId] [int] NOT NULL,
	[AudioId] [int] NOT NULL,
 CONSTRAINT [PK_CategoryAudio] PRIMARY KEY CLUSTERED 
(
	[Id] ASC,
	[CategoryId] ASC,
	[AudioId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CategoryMatter]    Script Date: 29/7/19 09:13:08 ب.ظ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CategoryMatter](
	[Id] [int] NOT NULL,
	[CategoryId] [int] NOT NULL,
	[MatterId] [int] NOT NULL,
 CONSTRAINT [PK_CategoryMatter] PRIMARY KEY CLUSTERED 
(
	[Id] ASC,
	[CategoryId] ASC,
	[MatterId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CategoryPhoto]    Script Date: 29/7/19 09:13:08 ب.ظ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CategoryPhoto](
	[Id] [int] NOT NULL,
	[CategoryId] [int] NOT NULL,
	[PhotoId] [int] NOT NULL,
 CONSTRAINT [PK_CategoryPhoto] PRIMARY KEY CLUSTERED 
(
	[Id] ASC,
	[CategoryId] ASC,
	[PhotoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CategoryVideo]    Script Date: 29/7/19 09:13:08 ب.ظ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CategoryVideo](
	[Id] [int] NOT NULL,
	[CategoryId] [int] NOT NULL,
	[VideoId] [int] NOT NULL,
 CONSTRAINT [PK_CategoryVideo] PRIMARY KEY CLUSTERED 
(
	[Id] ASC,
	[CategoryId] ASC,
	[VideoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Files]    Script Date: 29/7/19 09:13:08 ب.ظ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Files](
	[Id] [int] NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
	[Uri] [nvarchar](255) NOT NULL,
	[Mime] [nvarchar](255) NOT NULL,
	[Size] [bigint] NOT NULL,
	[Type] [nvarchar](255) NOT NULL,
	[CreatedAt] [smalldatetime] NOT NULL,
	[UpdatedAt] [smalldatetime] NOT NULL,
	[UserID] [int] NOT NULL,
	[MatterId] [int] NULL,
	[PhotoId] [int] NULL,
	[VideoId] [int] NULL,
	[AudioId] [int] NULL,
 CONSTRAINT [PK_Files] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Matters]    Script Date: 29/7/19 09:13:08 ب.ظ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Matters](
	[Id] [int] NOT NULL,
	[TopTitle] [nvarchar](100) NULL,
	[Title] [nvarchar](255) NOT NULL,
	[Lead] [nvarchar](1000) NULL,
	[Body] [nvarchar](max) NULL,
	[SlideShow] [bit] NULL,
	[Type] [nvarchar](50) NOT NULL,
	[UserId] [int] NOT NULL,
	[CreatedAt] [smalldatetime] NOT NULL,
	[UpdatedAt] [smalldatetime] NOT NULL,
 CONSTRAINT [PK_Matters] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Photos]    Script Date: 29/7/19 09:13:08 ب.ظ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Photos](
	[Id] [int] NOT NULL,
	[Title] [nvarchar](255) NOT NULL,
	[Lead] [nvarchar](1000) NULL,
	[Body] [nvarchar](max) NULL,
	[SlideShow] [bit] NULL,
	[Type] [nvarchar](50) NOT NULL,
	[UserId] [int] NOT NULL,
	[CreatedAt] [smalldatetime] NOT NULL,
	[UpdatedAt] [smalldatetime] NOT NULL,
 CONSTRAINT [PK_Photos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TagAudio]    Script Date: 29/7/19 09:13:08 ب.ظ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TagAudio](
	[Id] [int] NOT NULL,
	[TagId] [int] NOT NULL,
	[AudioId] [int] NOT NULL,
 CONSTRAINT [PK_TagAudio] PRIMARY KEY CLUSTERED 
(
	[Id] ASC,
	[TagId] ASC,
	[AudioId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TagMatter]    Script Date: 29/7/19 09:13:08 ب.ظ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TagMatter](
	[Id] [int] NOT NULL,
	[TagId] [int] NOT NULL,
	[MatterId] [int] NOT NULL,
 CONSTRAINT [PK_TagMatter] PRIMARY KEY CLUSTERED 
(
	[Id] ASC,
	[TagId] ASC,
	[MatterId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TagPhoto]    Script Date: 29/7/19 09:13:08 ب.ظ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TagPhoto](
	[Id] [int] NOT NULL,
	[TagId] [int] NOT NULL,
	[PhotoId] [int] NOT NULL,
 CONSTRAINT [PK_TagPhoto] PRIMARY KEY CLUSTERED 
(
	[Id] ASC,
	[TagId] ASC,
	[PhotoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Tags]    Script Date: 29/7/19 09:13:08 ب.ظ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tags](
	[Id] [int] NOT NULL,
	[Title] [nvarchar](100) NOT NULL,
	[CreatedAt] [smalldatetime] NOT NULL,
	[UpdatedAt] [smalldatetime] NOT NULL,
 CONSTRAINT [PK_Tags] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TagVideo]    Script Date: 29/7/19 09:13:08 ب.ظ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TagVideo](
	[Id] [int] NOT NULL,
	[TagId] [int] NOT NULL,
	[VideoId] [int] NOT NULL,
 CONSTRAINT [PK_TagVideo] PRIMARY KEY CLUSTERED 
(
	[Id] ASC,
	[TagId] ASC,
	[VideoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Users]    Script Date: 29/7/19 09:13:08 ب.ظ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Mobile] [bigint] NOT NULL,
	[Email] [nvarchar](255) NULL,
	[Passwod] [nvarchar](255) NOT NULL,
	[CreatedAt] [smalldatetime] NULL,
	[UpdatedAt] [smalldatetime] NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Videos]    Script Date: 29/7/19 09:13:08 ب.ظ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Videos](
	[Id] [int] NOT NULL,
	[Title] [nvarchar](255) NOT NULL,
	[Lead] [nvarchar](1000) NULL,
	[Body] [nvarchar](max) NULL,
	[SlideShow] [bit] NULL,
	[Type] [nvarchar](50) NOT NULL,
	[UserId] [int] NOT NULL,
	[CreatedAt] [smalldatetime] NOT NULL,
	[UpdatedAt] [smalldatetime] NOT NULL,
 CONSTRAINT [PK_Videos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
ALTER TABLE [dbo].[Audios]  WITH CHECK ADD  CONSTRAINT [FK_Audios_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Audios] CHECK CONSTRAINT [FK_Audios_Users]
GO
ALTER TABLE [dbo].[CategoryAudio]  WITH CHECK ADD  CONSTRAINT [FK_CategoryAudio_Audios] FOREIGN KEY([AudioId])
REFERENCES [dbo].[Audios] ([Id])
GO
ALTER TABLE [dbo].[CategoryAudio] CHECK CONSTRAINT [FK_CategoryAudio_Audios]
GO
ALTER TABLE [dbo].[CategoryAudio]  WITH CHECK ADD  CONSTRAINT [FK_CategoryAudio_Categories] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Categories] ([Id])
GO
ALTER TABLE [dbo].[CategoryAudio] CHECK CONSTRAINT [FK_CategoryAudio_Categories]
GO
ALTER TABLE [dbo].[CategoryMatter]  WITH CHECK ADD  CONSTRAINT [FK_CategoryMatter_Categories] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Categories] ([Id])
GO
ALTER TABLE [dbo].[CategoryMatter] CHECK CONSTRAINT [FK_CategoryMatter_Categories]
GO
ALTER TABLE [dbo].[CategoryMatter]  WITH CHECK ADD  CONSTRAINT [FK_CategoryMatter_Matters] FOREIGN KEY([MatterId])
REFERENCES [dbo].[Matters] ([Id])
GO
ALTER TABLE [dbo].[CategoryMatter] CHECK CONSTRAINT [FK_CategoryMatter_Matters]
GO
ALTER TABLE [dbo].[CategoryPhoto]  WITH CHECK ADD  CONSTRAINT [FK_CategoryPhoto_Categories] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Categories] ([Id])
GO
ALTER TABLE [dbo].[CategoryPhoto] CHECK CONSTRAINT [FK_CategoryPhoto_Categories]
GO
ALTER TABLE [dbo].[CategoryPhoto]  WITH CHECK ADD  CONSTRAINT [FK_CategoryPhoto_Photos] FOREIGN KEY([PhotoId])
REFERENCES [dbo].[Photos] ([Id])
GO
ALTER TABLE [dbo].[CategoryPhoto] CHECK CONSTRAINT [FK_CategoryPhoto_Photos]
GO
ALTER TABLE [dbo].[CategoryVideo]  WITH CHECK ADD  CONSTRAINT [FK_CategoryVideo_Categories] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Categories] ([Id])
GO
ALTER TABLE [dbo].[CategoryVideo] CHECK CONSTRAINT [FK_CategoryVideo_Categories]
GO
ALTER TABLE [dbo].[CategoryVideo]  WITH CHECK ADD  CONSTRAINT [FK_CategoryVideo_Videos] FOREIGN KEY([VideoId])
REFERENCES [dbo].[Videos] ([Id])
GO
ALTER TABLE [dbo].[CategoryVideo] CHECK CONSTRAINT [FK_CategoryVideo_Videos]
GO
ALTER TABLE [dbo].[Files]  WITH CHECK ADD  CONSTRAINT [FK_Files_Audios] FOREIGN KEY([AudioId])
REFERENCES [dbo].[Audios] ([Id])
GO
ALTER TABLE [dbo].[Files] CHECK CONSTRAINT [FK_Files_Audios]
GO
ALTER TABLE [dbo].[Files]  WITH CHECK ADD  CONSTRAINT [FK_Files_Matters] FOREIGN KEY([MatterId])
REFERENCES [dbo].[Matters] ([Id])
GO
ALTER TABLE [dbo].[Files] CHECK CONSTRAINT [FK_Files_Matters]
GO
ALTER TABLE [dbo].[Files]  WITH CHECK ADD  CONSTRAINT [FK_Files_Photos] FOREIGN KEY([PhotoId])
REFERENCES [dbo].[Photos] ([Id])
GO
ALTER TABLE [dbo].[Files] CHECK CONSTRAINT [FK_Files_Photos]
GO
ALTER TABLE [dbo].[Files]  WITH CHECK ADD  CONSTRAINT [FK_Files_Users] FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Files] CHECK CONSTRAINT [FK_Files_Users]
GO
ALTER TABLE [dbo].[Files]  WITH CHECK ADD  CONSTRAINT [FK_Files_Videos] FOREIGN KEY([VideoId])
REFERENCES [dbo].[Videos] ([Id])
GO
ALTER TABLE [dbo].[Files] CHECK CONSTRAINT [FK_Files_Videos]
GO
ALTER TABLE [dbo].[Matters]  WITH CHECK ADD  CONSTRAINT [FK_Matters_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Matters] CHECK CONSTRAINT [FK_Matters_Users]
GO
ALTER TABLE [dbo].[Photos]  WITH CHECK ADD  CONSTRAINT [FK_Photos_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Photos] CHECK CONSTRAINT [FK_Photos_Users]
GO
ALTER TABLE [dbo].[TagAudio]  WITH CHECK ADD  CONSTRAINT [FK_TagAudio_Audios] FOREIGN KEY([AudioId])
REFERENCES [dbo].[Audios] ([Id])
GO
ALTER TABLE [dbo].[TagAudio] CHECK CONSTRAINT [FK_TagAudio_Audios]
GO
ALTER TABLE [dbo].[TagAudio]  WITH CHECK ADD  CONSTRAINT [FK_TagAudio_Tags] FOREIGN KEY([TagId])
REFERENCES [dbo].[Tags] ([Id])
GO
ALTER TABLE [dbo].[TagAudio] CHECK CONSTRAINT [FK_TagAudio_Tags]
GO
ALTER TABLE [dbo].[TagMatter]  WITH CHECK ADD  CONSTRAINT [FK_TagMatter_Matters] FOREIGN KEY([MatterId])
REFERENCES [dbo].[Matters] ([Id])
GO
ALTER TABLE [dbo].[TagMatter] CHECK CONSTRAINT [FK_TagMatter_Matters]
GO
ALTER TABLE [dbo].[TagMatter]  WITH CHECK ADD  CONSTRAINT [FK_TagMatter_Tags] FOREIGN KEY([TagId])
REFERENCES [dbo].[Tags] ([Id])
GO
ALTER TABLE [dbo].[TagMatter] CHECK CONSTRAINT [FK_TagMatter_Tags]
GO
ALTER TABLE [dbo].[TagPhoto]  WITH CHECK ADD  CONSTRAINT [FK_TagPhoto_Photos] FOREIGN KEY([PhotoId])
REFERENCES [dbo].[Photos] ([Id])
GO
ALTER TABLE [dbo].[TagPhoto] CHECK CONSTRAINT [FK_TagPhoto_Photos]
GO
ALTER TABLE [dbo].[TagPhoto]  WITH CHECK ADD  CONSTRAINT [FK_TagPhoto_Tags] FOREIGN KEY([TagId])
REFERENCES [dbo].[Tags] ([Id])
GO
ALTER TABLE [dbo].[TagPhoto] CHECK CONSTRAINT [FK_TagPhoto_Tags]
GO
ALTER TABLE [dbo].[TagVideo]  WITH CHECK ADD  CONSTRAINT [FK_TagVideo_Tags] FOREIGN KEY([TagId])
REFERENCES [dbo].[Tags] ([Id])
GO
ALTER TABLE [dbo].[TagVideo] CHECK CONSTRAINT [FK_TagVideo_Tags]
GO
ALTER TABLE [dbo].[TagVideo]  WITH CHECK ADD  CONSTRAINT [FK_TagVideo_Videos] FOREIGN KEY([VideoId])
REFERENCES [dbo].[Videos] ([Id])
GO
ALTER TABLE [dbo].[TagVideo] CHECK CONSTRAINT [FK_TagVideo_Videos]
GO
ALTER TABLE [dbo].[Videos]  WITH CHECK ADD  CONSTRAINT [FK_Videos_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Videos] CHECK CONSTRAINT [FK_Videos_Users]
GO
USE [master]
GO
ALTER DATABASE [AspNews] SET  READ_WRITE 
GO
