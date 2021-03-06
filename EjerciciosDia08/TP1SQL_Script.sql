USE [master]
GO
/****** Object:  Database [Nomina]    Script Date: 12/07/2017 12:12:20 p.m. ******/
CREATE DATABASE [Nomina]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Nomina', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\Nomina.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Nomina_log', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\Nomina_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Nomina] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Nomina].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Nomina] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Nomina] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Nomina] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Nomina] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Nomina] SET ARITHABORT OFF 
GO
ALTER DATABASE [Nomina] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Nomina] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [Nomina] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Nomina] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Nomina] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Nomina] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Nomina] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Nomina] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Nomina] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Nomina] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Nomina] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Nomina] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Nomina] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Nomina] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Nomina] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Nomina] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Nomina] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Nomina] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Nomina] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Nomina] SET  MULTI_USER 
GO
ALTER DATABASE [Nomina] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Nomina] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Nomina] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Nomina] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [Nomina]
GO
/****** Object:  Table [dbo].[Empleados]    Script Date: 12/07/2017 12:12:20 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Empleados](
	[idEmpleado] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[dirección] [varchar](50) NOT NULL,
	[teléfono] [varchar](20) NOT NULL,
	[fechaNacimiento] [date] NOT NULL,
	[sueldo] [float] NULL,
	[localidad] [int] NOT NULL,
 CONSTRAINT [PK_Empleados] PRIMARY KEY CLUSTERED 
(
	[idEmpleado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Localidades]    Script Date: 12/07/2017 12:12:20 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Localidades](
	[codigoLocalidad] [int] IDENTITY(1,1) NOT NULL,
	[localidad] [varchar](30) NOT NULL,
 CONSTRAINT [PK_Localidades] PRIMARY KEY CLUSTERED 
(
	[codigoLocalidad] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Empleados] ON 

INSERT [dbo].[Empleados] ([idEmpleado], [nombre], [dirección], [teléfono], [fechaNacimiento], [sueldo], [localidad]) VALUES (1, N'Roberto Pérez', N'Av. Mitre 750', N'0112234223', CAST(0xEF130B00 AS Date), 20000, 1)
INSERT [dbo].[Empleados] ([idEmpleado], [nombre], [dirección], [teléfono], [fechaNacimiento], [sueldo], [localidad]) VALUES (5, N'Rosa Gómez', N'Olivera 393 ', N'02224452678', CAST(0x3C040B00 AS Date), 16920, 1)
INSERT [dbo].[Empleados] ([idEmpleado], [nombre], [dirección], [teléfono], [fechaNacimiento], [sueldo], [localidad]) VALUES (6, N'José Luis Perales', N'Calle 483 entre 41 y 43', N'0111588339280', CAST(0xF7F90A00 AS Date), 19000, 1)
INSERT [dbo].[Empleados] ([idEmpleado], [nombre], [dirección], [teléfono], [fechaNacimiento], [sueldo], [localidad]) VALUES (9, N'Julio Pérez', N'Calle falsa 123', N'011334567', CAST(0x3A140B00 AS Date), 20000, 2)
SET IDENTITY_INSERT [dbo].[Empleados] OFF
SET IDENTITY_INSERT [dbo].[Localidades] ON 

INSERT [dbo].[Localidades] ([codigoLocalidad], [localidad]) VALUES (1, N'Avellaneda')
INSERT [dbo].[Localidades] ([codigoLocalidad], [localidad]) VALUES (2, N'Lanús')
INSERT [dbo].[Localidades] ([codigoLocalidad], [localidad]) VALUES (3, N'Presidente Perón')
SET IDENTITY_INSERT [dbo].[Localidades] OFF
USE [master]
GO
ALTER DATABASE [Nomina] SET  READ_WRITE 
GO
