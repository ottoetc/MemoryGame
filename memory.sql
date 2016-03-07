USE [master]
GO
/****** Object:  Database [memory]    Script Date: 3/7/2016 1:26:07 PM ******/
CREATE DATABASE [memory]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'memory', FILENAME = N'C:\Users\ottoe\memory.mdf' , SIZE = 3264KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'memory_log', FILENAME = N'C:\Users\ottoe\memory_log.ldf' , SIZE = 560KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [memory] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [memory].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [memory] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [memory] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [memory] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [memory] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [memory] SET ARITHABORT OFF 
GO
ALTER DATABASE [memory] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [memory] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [memory] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [memory] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [memory] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [memory] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [memory] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [memory] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [memory] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [memory] SET  ENABLE_BROKER 
GO
ALTER DATABASE [memory] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [memory] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [memory] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [memory] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [memory] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [memory] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [memory] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [memory] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [memory] SET  MULTI_USER 
GO
ALTER DATABASE [memory] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [memory] SET DB_CHAINING OFF 
GO
ALTER DATABASE [memory] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [memory] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [memory] SET DELAYED_DURABILITY = DISABLED 
GO
USE [memory]
GO
/****** Object:  Table [dbo].[cards]    Script Date: 3/7/2016 1:26:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cards](
	[id] [int] IDENTITY(1,1) NOT NULL
) ON [PRIMARY]

GO
USE [master]
GO
ALTER DATABASE [memory] SET  READ_WRITE 
GO
