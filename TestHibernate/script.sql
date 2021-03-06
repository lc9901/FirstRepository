USE [master]
GO

/****** Object:  Database [TestNHibernate]    Script Date: 11/04/2017 17:44:03 ******/
IF  EXISTS (SELECT name FROM sys.databases WHERE name = N'TestNHibernate')
DROP DATABASE [TestNHibernate]
GO

USE [master]
GO

/****** Object:  Database [TestNHibernate]    Script Date: 11/04/2017 17:44:03 ******/
CREATE DATABASE [TestNHibernate] ON  PRIMARY 
( NAME = N'TestNHibernate', FILENAME = N'D:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\TestNHibernate.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'TestNHibernate_log', FILENAME = N'D:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\TestNHibernate_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO

ALTER DATABASE [TestNHibernate] SET COMPATIBILITY_LEVEL = 100
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TestNHibernate].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO


USE [TestNHibernate]
GO
/****** Object:  Table [dbo].[personal]    Script Date: 11/04/2017 17:42:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF  EXISTS (SELECT name FROM sys.tables WHERE name = N'personal')
DROP DATABASE [dbo].[personal]

CREATE TABLE [dbo].[personal](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NULL,
	[tel] [nvarchar](50) NULL,
	[email] [nvarchar](50) NULL,
	[birthday] [nvarchar](50) NULL,
 CONSTRAINT [PK_personal] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
