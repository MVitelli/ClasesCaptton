USE [master]
GO
/****** Object:  Database [Empleados]    Script Date: 13/07/2017 05:37:32 p.m. ******/
CREATE DATABASE [Empleados]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Empleados', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\Empleados.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Empleados_log', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\Empleados_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Empleados] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Empleados].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Empleados] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Empleados] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Empleados] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Empleados] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Empleados] SET ARITHABORT OFF 
GO
ALTER DATABASE [Empleados] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Empleados] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [Empleados] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Empleados] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Empleados] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Empleados] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Empleados] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Empleados] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Empleados] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Empleados] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Empleados] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Empleados] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Empleados] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Empleados] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Empleados] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Empleados] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Empleados] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Empleados] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Empleados] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Empleados] SET  MULTI_USER 
GO
ALTER DATABASE [Empleados] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Empleados] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Empleados] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Empleados] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [Empleados]
GO
/****** Object:  Table [dbo].[Empleado]    Script Date: 13/07/2017 05:37:32 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Empleado](
	[idEmpleado] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[apellido] [varchar](50) NOT NULL,
	[idSector] [int] NOT NULL,
 CONSTRAINT [PK_Empleado] PRIMARY KEY CLUSTERED 
(
	[idEmpleado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[EmpleadoReunion]    Script Date: 13/07/2017 05:37:32 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmpleadoReunion](
	[idEmpleado] [int] NOT NULL,
	[idReunion] [int] NOT NULL,
 CONSTRAINT [PK_EmpleadoReunion] PRIMARY KEY CLUSTERED 
(
	[idEmpleado] ASC,
	[idReunion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Reunion]    Script Date: 13/07/2017 05:37:32 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Reunion](
	[idReunion] [int] IDENTITY(1,1) NOT NULL,
	[tema] [varchar](150) NOT NULL,
	[fecha] [date] NOT NULL,
 CONSTRAINT [PK_Reunion] PRIMARY KEY CLUSTERED 
(
	[idReunion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Sector]    Script Date: 13/07/2017 05:37:32 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Sector](
	[idSector] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Sector] PRIMARY KEY CLUSTERED 
(
	[idSector] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Empleado] ON 

INSERT [dbo].[Empleado] ([idEmpleado], [nombre], [apellido], [idSector]) VALUES (1, N'gabi', N'digruttola', 6)
INSERT [dbo].[Empleado] ([idEmpleado], [nombre], [apellido], [idSector]) VALUES (5, N'brian', N'sarmiento', 3)
SET IDENTITY_INSERT [dbo].[Empleado] OFF
SET IDENTITY_INSERT [dbo].[Sector] ON 

INSERT [dbo].[Sector] ([idSector], [nombre]) VALUES (1, N'Contabilidad')
INSERT [dbo].[Sector] ([idSector], [nombre]) VALUES (2, N'IT')
INSERT [dbo].[Sector] ([idSector], [nombre]) VALUES (3, N'RR.PP.')
INSERT [dbo].[Sector] ([idSector], [nombre]) VALUES (4, N'RR.HH.')
INSERT [dbo].[Sector] ([idSector], [nombre]) VALUES (5, N'Ventas')
INSERT [dbo].[Sector] ([idSector], [nombre]) VALUES (6, N'Compras')
SET IDENTITY_INSERT [dbo].[Sector] OFF
ALTER TABLE [dbo].[Empleado]  WITH CHECK ADD  CONSTRAINT [FK_Empleado_Sector] FOREIGN KEY([idSector])
REFERENCES [dbo].[Sector] ([idSector])
GO
ALTER TABLE [dbo].[Empleado] CHECK CONSTRAINT [FK_Empleado_Sector]
GO
ALTER TABLE [dbo].[EmpleadoReunion]  WITH CHECK ADD  CONSTRAINT [FK_EmpleadoReunion_Empleado] FOREIGN KEY([idEmpleado])
REFERENCES [dbo].[Empleado] ([idEmpleado])
GO
ALTER TABLE [dbo].[EmpleadoReunion] CHECK CONSTRAINT [FK_EmpleadoReunion_Empleado]
GO
ALTER TABLE [dbo].[EmpleadoReunion]  WITH CHECK ADD  CONSTRAINT [FK_EmpleadoReunion_Reunion] FOREIGN KEY([idReunion])
REFERENCES [dbo].[Reunion] ([idReunion])
GO
ALTER TABLE [dbo].[EmpleadoReunion] CHECK CONSTRAINT [FK_EmpleadoReunion_Reunion]
GO
USE [master]
GO
ALTER DATABASE [Empleados] SET  READ_WRITE 
GO
