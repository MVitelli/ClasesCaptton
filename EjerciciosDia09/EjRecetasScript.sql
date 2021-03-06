USE [master]
GO
/****** Object:  Database [Recetas]    Script Date: 13/07/2017 05:38:16 p.m. ******/
CREATE DATABASE [Recetas]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Recetas', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\Recetas.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Recetas_log', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\Recetas_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Recetas] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Recetas].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Recetas] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Recetas] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Recetas] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Recetas] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Recetas] SET ARITHABORT OFF 
GO
ALTER DATABASE [Recetas] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Recetas] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [Recetas] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Recetas] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Recetas] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Recetas] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Recetas] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Recetas] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Recetas] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Recetas] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Recetas] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Recetas] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Recetas] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Recetas] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Recetas] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Recetas] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Recetas] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Recetas] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Recetas] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Recetas] SET  MULTI_USER 
GO
ALTER DATABASE [Recetas] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Recetas] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Recetas] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Recetas] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [Recetas]
GO
/****** Object:  Table [dbo].[Ingrediente]    Script Date: 13/07/2017 05:38:16 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Ingrediente](
	[idIngrediente] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Ingrediente] PRIMARY KEY CLUSTERED 
(
	[idIngrediente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Receta]    Script Date: 13/07/2017 05:38:16 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Receta](
	[idReceta] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[instrucciones] [varchar](150) NOT NULL,
 CONSTRAINT [PK_Receta] PRIMARY KEY CLUSTERED 
(
	[idReceta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[RecetaIngrediente]    Script Date: 13/07/2017 05:38:16 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RecetaIngrediente](
	[idReceta] [int] NOT NULL,
	[idIngrediente] [int] NOT NULL,
	[cantidad] [int] NOT NULL,
	[unidadDeMedida] [varchar](50) NOT NULL,
 CONSTRAINT [PK_RecetaIngrediente] PRIMARY KEY CLUSTERED 
(
	[idReceta] ASC,
	[idIngrediente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Ingrediente] ON 

INSERT [dbo].[Ingrediente] ([idIngrediente], [nombre]) VALUES (1, N'Queso')
INSERT [dbo].[Ingrediente] ([idIngrediente], [nombre]) VALUES (2, N'Harina')
INSERT [dbo].[Ingrediente] ([idIngrediente], [nombre]) VALUES (3, N'Huevo')
INSERT [dbo].[Ingrediente] ([idIngrediente], [nombre]) VALUES (4, N'Manteca')
SET IDENTITY_INSERT [dbo].[Ingrediente] OFF
SET IDENTITY_INSERT [dbo].[Receta] ON 

INSERT [dbo].[Receta] ([idReceta], [nombre], [instrucciones]) VALUES (5, N'Pan', N'Poner en un recipiente')
INSERT [dbo].[Receta] ([idReceta], [nombre], [instrucciones]) VALUES (6, N'Omelette', N'Cortar en cuadrados')
SET IDENTITY_INSERT [dbo].[Receta] OFF
INSERT [dbo].[RecetaIngrediente] ([idReceta], [idIngrediente], [cantidad], [unidadDeMedida]) VALUES (5, 2, 500, N'gramos')
INSERT [dbo].[RecetaIngrediente] ([idReceta], [idIngrediente], [cantidad], [unidadDeMedida]) VALUES (6, 1, 200, N'gramos')
INSERT [dbo].[RecetaIngrediente] ([idReceta], [idIngrediente], [cantidad], [unidadDeMedida]) VALUES (6, 2, 400, N'gramos')
USE [master]
GO
ALTER DATABASE [Recetas] SET  READ_WRITE 
GO
