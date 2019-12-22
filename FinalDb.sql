USE [master]
GO
/****** Object:  Database [UVDbFinal]    Script Date: 12/23/2019 5:30:36 AM ******/
CREATE DATABASE [UVDbFinal]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'UVDbFinal', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\UVDbFinal.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'UVDbFinal_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\UVDbFinal_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [UVDbFinal] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [UVDbFinal].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [UVDbFinal] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [UVDbFinal] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [UVDbFinal] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [UVDbFinal] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [UVDbFinal] SET ARITHABORT OFF 
GO
ALTER DATABASE [UVDbFinal] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [UVDbFinal] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [UVDbFinal] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [UVDbFinal] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [UVDbFinal] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [UVDbFinal] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [UVDbFinal] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [UVDbFinal] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [UVDbFinal] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [UVDbFinal] SET  ENABLE_BROKER 
GO
ALTER DATABASE [UVDbFinal] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [UVDbFinal] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [UVDbFinal] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [UVDbFinal] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [UVDbFinal] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [UVDbFinal] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [UVDbFinal] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [UVDbFinal] SET RECOVERY FULL 
GO
ALTER DATABASE [UVDbFinal] SET  MULTI_USER 
GO
ALTER DATABASE [UVDbFinal] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [UVDbFinal] SET DB_CHAINING OFF 
GO
ALTER DATABASE [UVDbFinal] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [UVDbFinal] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [UVDbFinal] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'UVDbFinal', N'ON'
GO
ALTER DATABASE [UVDbFinal] SET QUERY_STORE = OFF
GO
USE [UVDbFinal]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 12/23/2019 5:30:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Allocations]    Script Date: 12/23/2019 5:30:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Allocations](
	[AllocationId] [int] IDENTITY(1,1) NOT NULL,
	[DepartmentId] [int] NOT NULL,
	[CourseId] [int] NOT NULL,
	[RoomId] [int] NOT NULL,
	[DayId] [int] NOT NULL,
	[FromTime] [nvarchar](max) NULL,
	[ToTime] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Allocations] PRIMARY KEY CLUSTERED 
(
	[AllocationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AssignCourses]    Script Date: 12/23/2019 5:30:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AssignCourses](
	[AssignId] [int] IDENTITY(1,1) NOT NULL,
	[DepartmentId] [int] NOT NULL,
	[TeacherId] [int] NOT NULL,
	[CourseId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.AssignCourses] PRIMARY KEY CLUSTERED 
(
	[AssignId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Courses]    Script Date: 12/23/2019 5:30:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Courses](
	[CourseId] [int] IDENTITY(1,1) NOT NULL,
	[CourseCode] [varchar](8000) NOT NULL,
	[CourseName] [varchar](8000) NOT NULL,
	[Credit] [real] NOT NULL,
	[Description] [nvarchar](max) NULL,
	[DepartmentId] [int] NOT NULL,
	[SemesterId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Courses] PRIMARY KEY CLUSTERED 
(
	[CourseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Days]    Script Date: 12/23/2019 5:30:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Days](
	[DayId] [int] IDENTITY(1,1) NOT NULL,
	[DayName] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Days] PRIMARY KEY CLUSTERED 
(
	[DayId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Departments]    Script Date: 12/23/2019 5:30:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Departments](
	[DepartmentId] [int] IDENTITY(1,1) NOT NULL,
	[DepartmentCode] [varchar](7) NOT NULL,
	[DepartmentName] [varchar](50) NOT NULL,
 CONSTRAINT [PK_dbo.Departments] PRIMARY KEY CLUSTERED 
(
	[DepartmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Designations]    Script Date: 12/23/2019 5:30:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Designations](
	[DesignationId] [int] IDENTITY(1,1) NOT NULL,
	[DesignationInfo] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Designations] PRIMARY KEY CLUSTERED 
(
	[DesignationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Enrolls]    Script Date: 12/23/2019 5:30:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Enrolls](
	[EnrollId] [int] IDENTITY(1,1) NOT NULL,
	[StudentId] [int] NOT NULL,
	[StudentName] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
	[Department] [nvarchar](max) NULL,
	[CourseId] [int] NOT NULL,
	[Date] [datetime] NOT NULL,
	[Result_ResultId] [int] NULL,
 CONSTRAINT [PK_dbo.Enrolls] PRIMARY KEY CLUSTERED 
(
	[EnrollId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Grades]    Script Date: 12/23/2019 5:30:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Grades](
	[GradeId] [int] IDENTITY(1,1) NOT NULL,
	[GradeLetter] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Grades] PRIMARY KEY CLUSTERED 
(
	[GradeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Results]    Script Date: 12/23/2019 5:30:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Results](
	[ResultId] [int] IDENTITY(1,1) NOT NULL,
	[StudentId] [int] NOT NULL,
	[CourseId] [int] NOT NULL,
	[GradeId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Results] PRIMARY KEY CLUSTERED 
(
	[ResultId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rooms]    Script Date: 12/23/2019 5:30:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rooms](
	[RoomId] [int] IDENTITY(1,1) NOT NULL,
	[RoomNo] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Rooms] PRIMARY KEY CLUSTERED 
(
	[RoomId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Semesters]    Script Date: 12/23/2019 5:30:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Semesters](
	[SemesterId] [int] IDENTITY(1,1) NOT NULL,
	[SemesterNo] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Semesters] PRIMARY KEY CLUSTERED 
(
	[SemesterId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Students]    Script Date: 12/23/2019 5:30:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Students](
	[StudentId] [int] IDENTITY(1,1) NOT NULL,
	[StudentName] [varchar](50) NOT NULL,
	[Email] [varchar](8000) NOT NULL,
	[ContactNo] [nvarchar](max) NOT NULL,
	[RegistrationDate] [datetime] NOT NULL,
	[Address] [nvarchar](max) NULL,
	[DepartmentId] [int] NOT NULL,
	[RegNo] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Students] PRIMARY KEY CLUSTERED 
(
	[StudentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Teachers]    Script Date: 12/23/2019 5:30:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Teachers](
	[TeacherId] [int] IDENTITY(1,1) NOT NULL,
	[TeacherName] [nvarchar](50) NOT NULL,
	[Address] [nvarchar](max) NULL,
	[Email] [varchar](8000) NOT NULL,
	[ContactNo] [nvarchar](max) NOT NULL,
	[DesignationId] [int] NOT NULL,
	[DepartmentId] [int] NOT NULL,
	[CreditToBeTaken] [real] NOT NULL,
 CONSTRAINT [PK_dbo.Teachers] PRIMARY KEY CLUSTERED 
(
	[TeacherId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Index [IX_CourseId]    Script Date: 12/23/2019 5:30:37 AM ******/
CREATE NONCLUSTERED INDEX [IX_CourseId] ON [dbo].[Allocations]
(
	[CourseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_DayId]    Script Date: 12/23/2019 5:30:37 AM ******/
CREATE NONCLUSTERED INDEX [IX_DayId] ON [dbo].[Allocations]
(
	[DayId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_DepartmentId]    Script Date: 12/23/2019 5:30:37 AM ******/
CREATE NONCLUSTERED INDEX [IX_DepartmentId] ON [dbo].[Allocations]
(
	[DepartmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_RoomId]    Script Date: 12/23/2019 5:30:37 AM ******/
CREATE NONCLUSTERED INDEX [IX_RoomId] ON [dbo].[Allocations]
(
	[RoomId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_CourseId]    Script Date: 12/23/2019 5:30:37 AM ******/
CREATE NONCLUSTERED INDEX [IX_CourseId] ON [dbo].[AssignCourses]
(
	[CourseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_DepartmentId]    Script Date: 12/23/2019 5:30:37 AM ******/
CREATE NONCLUSTERED INDEX [IX_DepartmentId] ON [dbo].[AssignCourses]
(
	[DepartmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_TeacherId]    Script Date: 12/23/2019 5:30:37 AM ******/
CREATE NONCLUSTERED INDEX [IX_TeacherId] ON [dbo].[AssignCourses]
(
	[TeacherId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_DepartmentId]    Script Date: 12/23/2019 5:30:37 AM ******/
CREATE NONCLUSTERED INDEX [IX_DepartmentId] ON [dbo].[Courses]
(
	[DepartmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_SemesterId]    Script Date: 12/23/2019 5:30:37 AM ******/
CREATE NONCLUSTERED INDEX [IX_SemesterId] ON [dbo].[Courses]
(
	[SemesterId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_CourseId]    Script Date: 12/23/2019 5:30:37 AM ******/
CREATE NONCLUSTERED INDEX [IX_CourseId] ON [dbo].[Enrolls]
(
	[CourseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Result_ResultId]    Script Date: 12/23/2019 5:30:37 AM ******/
CREATE NONCLUSTERED INDEX [IX_Result_ResultId] ON [dbo].[Enrolls]
(
	[Result_ResultId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_StudentId]    Script Date: 12/23/2019 5:30:37 AM ******/
CREATE NONCLUSTERED INDEX [IX_StudentId] ON [dbo].[Enrolls]
(
	[StudentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_CourseId]    Script Date: 12/23/2019 5:30:37 AM ******/
CREATE NONCLUSTERED INDEX [IX_CourseId] ON [dbo].[Results]
(
	[CourseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_GradeId]    Script Date: 12/23/2019 5:30:37 AM ******/
CREATE NONCLUSTERED INDEX [IX_GradeId] ON [dbo].[Results]
(
	[GradeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_StudentId]    Script Date: 12/23/2019 5:30:37 AM ******/
CREATE NONCLUSTERED INDEX [IX_StudentId] ON [dbo].[Results]
(
	[StudentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_DepartmentId]    Script Date: 12/23/2019 5:30:37 AM ******/
CREATE NONCLUSTERED INDEX [IX_DepartmentId] ON [dbo].[Students]
(
	[DepartmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_DepartmentId]    Script Date: 12/23/2019 5:30:37 AM ******/
CREATE NONCLUSTERED INDEX [IX_DepartmentId] ON [dbo].[Teachers]
(
	[DepartmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_DesignationId]    Script Date: 12/23/2019 5:30:37 AM ******/
CREATE NONCLUSTERED INDEX [IX_DesignationId] ON [dbo].[Teachers]
(
	[DesignationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Allocations]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Allocations_dbo.Courses_CourseId] FOREIGN KEY([CourseId])
REFERENCES [dbo].[Courses] ([CourseId])
GO
ALTER TABLE [dbo].[Allocations] CHECK CONSTRAINT [FK_dbo.Allocations_dbo.Courses_CourseId]
GO
ALTER TABLE [dbo].[Allocations]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Allocations_dbo.Days_DayId] FOREIGN KEY([DayId])
REFERENCES [dbo].[Days] ([DayId])
GO
ALTER TABLE [dbo].[Allocations] CHECK CONSTRAINT [FK_dbo.Allocations_dbo.Days_DayId]
GO
ALTER TABLE [dbo].[Allocations]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Allocations_dbo.Departments_DepartmentId] FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[Departments] ([DepartmentId])
GO
ALTER TABLE [dbo].[Allocations] CHECK CONSTRAINT [FK_dbo.Allocations_dbo.Departments_DepartmentId]
GO
ALTER TABLE [dbo].[Allocations]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Allocations_dbo.Rooms_RoomId] FOREIGN KEY([RoomId])
REFERENCES [dbo].[Rooms] ([RoomId])
GO
ALTER TABLE [dbo].[Allocations] CHECK CONSTRAINT [FK_dbo.Allocations_dbo.Rooms_RoomId]
GO
ALTER TABLE [dbo].[AssignCourses]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AssignCourses_dbo.Courses_CourseId] FOREIGN KEY([CourseId])
REFERENCES [dbo].[Courses] ([CourseId])
GO
ALTER TABLE [dbo].[AssignCourses] CHECK CONSTRAINT [FK_dbo.AssignCourses_dbo.Courses_CourseId]
GO
ALTER TABLE [dbo].[AssignCourses]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AssignCourses_dbo.Departments_DepartmentId] FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[Departments] ([DepartmentId])
GO
ALTER TABLE [dbo].[AssignCourses] CHECK CONSTRAINT [FK_dbo.AssignCourses_dbo.Departments_DepartmentId]
GO
ALTER TABLE [dbo].[AssignCourses]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AssignCourses_dbo.Teachers_TeacherId] FOREIGN KEY([TeacherId])
REFERENCES [dbo].[Teachers] ([TeacherId])
GO
ALTER TABLE [dbo].[AssignCourses] CHECK CONSTRAINT [FK_dbo.AssignCourses_dbo.Teachers_TeacherId]
GO
ALTER TABLE [dbo].[Courses]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Courses_dbo.Departments_DepartmentId] FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[Departments] ([DepartmentId])
GO
ALTER TABLE [dbo].[Courses] CHECK CONSTRAINT [FK_dbo.Courses_dbo.Departments_DepartmentId]
GO
ALTER TABLE [dbo].[Courses]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Courses_dbo.Semesters_SemesterId] FOREIGN KEY([SemesterId])
REFERENCES [dbo].[Semesters] ([SemesterId])
GO
ALTER TABLE [dbo].[Courses] CHECK CONSTRAINT [FK_dbo.Courses_dbo.Semesters_SemesterId]
GO
ALTER TABLE [dbo].[Enrolls]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Enrolls_dbo.Courses_CourseId] FOREIGN KEY([CourseId])
REFERENCES [dbo].[Courses] ([CourseId])
GO
ALTER TABLE [dbo].[Enrolls] CHECK CONSTRAINT [FK_dbo.Enrolls_dbo.Courses_CourseId]
GO
ALTER TABLE [dbo].[Enrolls]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Enrolls_dbo.Results_Result_ResultId] FOREIGN KEY([Result_ResultId])
REFERENCES [dbo].[Results] ([ResultId])
GO
ALTER TABLE [dbo].[Enrolls] CHECK CONSTRAINT [FK_dbo.Enrolls_dbo.Results_Result_ResultId]
GO
ALTER TABLE [dbo].[Enrolls]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Enrolls_dbo.Students_StudentId] FOREIGN KEY([StudentId])
REFERENCES [dbo].[Students] ([StudentId])
GO
ALTER TABLE [dbo].[Enrolls] CHECK CONSTRAINT [FK_dbo.Enrolls_dbo.Students_StudentId]
GO
ALTER TABLE [dbo].[Results]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Results_dbo.Courses_CourseId] FOREIGN KEY([CourseId])
REFERENCES [dbo].[Courses] ([CourseId])
GO
ALTER TABLE [dbo].[Results] CHECK CONSTRAINT [FK_dbo.Results_dbo.Courses_CourseId]
GO
ALTER TABLE [dbo].[Results]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Results_dbo.Grades_GradeId] FOREIGN KEY([GradeId])
REFERENCES [dbo].[Grades] ([GradeId])
GO
ALTER TABLE [dbo].[Results] CHECK CONSTRAINT [FK_dbo.Results_dbo.Grades_GradeId]
GO
ALTER TABLE [dbo].[Results]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Results_dbo.Students_StudentId] FOREIGN KEY([StudentId])
REFERENCES [dbo].[Students] ([StudentId])
GO
ALTER TABLE [dbo].[Results] CHECK CONSTRAINT [FK_dbo.Results_dbo.Students_StudentId]
GO
ALTER TABLE [dbo].[Students]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Students_dbo.Departments_DepartmentId] FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[Departments] ([DepartmentId])
GO
ALTER TABLE [dbo].[Students] CHECK CONSTRAINT [FK_dbo.Students_dbo.Departments_DepartmentId]
GO
ALTER TABLE [dbo].[Teachers]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Teachers_dbo.Departments_DepartmentId] FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[Departments] ([DepartmentId])
GO
ALTER TABLE [dbo].[Teachers] CHECK CONSTRAINT [FK_dbo.Teachers_dbo.Departments_DepartmentId]
GO
ALTER TABLE [dbo].[Teachers]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Teachers_dbo.Designations_DesignationId] FOREIGN KEY([DesignationId])
REFERENCES [dbo].[Designations] ([DesignationId])
GO
ALTER TABLE [dbo].[Teachers] CHECK CONSTRAINT [FK_dbo.Teachers_dbo.Designations_DesignationId]
GO
USE [master]
GO
ALTER DATABASE [UVDbFinal] SET  READ_WRITE 
GO
