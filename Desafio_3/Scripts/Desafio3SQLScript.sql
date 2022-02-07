
/*****CREAR DATABASE******/

USE [master]
GO

CREATE DATABASE [Desafio3Usuarios]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Desafio3Usuarios', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Desafio3Usuarios.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Desafio3Usuarios_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Desafio3Usuarios_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Desafio3Usuarios].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [Desafio3Usuarios] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [Desafio3Usuarios] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [Desafio3Usuarios] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [Desafio3Usuarios] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [Desafio3Usuarios] SET ARITHABORT OFF 
GO

ALTER DATABASE [Desafio3Usuarios] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [Desafio3Usuarios] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [Desafio3Usuarios] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [Desafio3Usuarios] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [Desafio3Usuarios] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [Desafio3Usuarios] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [Desafio3Usuarios] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [Desafio3Usuarios] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [Desafio3Usuarios] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [Desafio3Usuarios] SET  DISABLE_BROKER 
GO

ALTER DATABASE [Desafio3Usuarios] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [Desafio3Usuarios] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [Desafio3Usuarios] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [Desafio3Usuarios] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [Desafio3Usuarios] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [Desafio3Usuarios] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [Desafio3Usuarios] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [Desafio3Usuarios] SET RECOVERY SIMPLE 
GO

ALTER DATABASE [Desafio3Usuarios] SET  MULTI_USER 
GO

ALTER DATABASE [Desafio3Usuarios] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [Desafio3Usuarios] SET DB_CHAINING OFF 
GO

ALTER DATABASE [Desafio3Usuarios] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [Desafio3Usuarios] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO

ALTER DATABASE [Desafio3Usuarios] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [Desafio3Usuarios] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO

ALTER DATABASE [Desafio3Usuarios] SET QUERY_STORE = OFF
GO

ALTER DATABASE [Desafio3Usuarios] SET  READ_WRITE 
GO

/*****CREAR TABLA 'USERS'******/

USE [Desafio3Usuarios]
GO

/****** Object:  Table [dbo].[Users]    Script Date: 5/2/2022 12:10:51 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[LastName] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
	[Password] [nvarchar](max) NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

/******POPULATE******/

DELETE FROM [dbo].[Users]

DBCC CHECKIDENT ('[dbo].[Users]', RESEED, 0);
GO

INSERT INTO [dbo].[Users] ([Name],[LastName],[Email],[Password])
VALUES 
	('Damaris','San Juan','damaris@test.com','d4m4ri5'),
	('Eugenia','Prieto','eugenia@test.com','3ug3ni4'),
	('Monica','Mari','monica@test.com','m0n1c4'),
	('Nora','Sastre','nora@test.com','n0r4'),
	('Lucio','Godoy','lucio@test.com','luc10'),
	('Cesar','Sancho','cesar@test.com','c3s4r'),
	('Eloy','Jimeno','eloy@test.com','3l0y'),
	('Alvaro','Navarro','alvaro@test.com','4lv4r0'),
	('Rogelio','Lujan','rogelio@test.com','r0g3l10'),
	('Cristobal','Freire','cristobal@test.com','cr15t0b4l')

