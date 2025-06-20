USE [master]
GO
/****** Object:  Database [OfficeSpaces]    Script Date: 04/06/2025 15:34:49 ******/
CREATE DATABASE [OfficeSpaces]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'OfficeSpaces', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\OfficeSpaces.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'OfficeSpaces_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\OfficeSpaces_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [OfficeSpaces] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [OfficeSpaces].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [OfficeSpaces] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [OfficeSpaces] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [OfficeSpaces] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [OfficeSpaces] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [OfficeSpaces] SET ARITHABORT OFF 
GO
ALTER DATABASE [OfficeSpaces] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [OfficeSpaces] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [OfficeSpaces] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [OfficeSpaces] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [OfficeSpaces] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [OfficeSpaces] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [OfficeSpaces] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [OfficeSpaces] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [OfficeSpaces] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [OfficeSpaces] SET  ENABLE_BROKER 
GO
ALTER DATABASE [OfficeSpaces] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [OfficeSpaces] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [OfficeSpaces] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [OfficeSpaces] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [OfficeSpaces] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [OfficeSpaces] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [OfficeSpaces] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [OfficeSpaces] SET RECOVERY FULL 
GO
ALTER DATABASE [OfficeSpaces] SET  MULTI_USER 
GO
ALTER DATABASE [OfficeSpaces] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [OfficeSpaces] SET DB_CHAINING OFF 
GO
ALTER DATABASE [OfficeSpaces] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [OfficeSpaces] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [OfficeSpaces] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [OfficeSpaces] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'OfficeSpaces', N'ON'
GO
ALTER DATABASE [OfficeSpaces] SET QUERY_STORE = ON
GO
ALTER DATABASE [OfficeSpaces] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [OfficeSpaces]
GO
/****** Object:  Table [dbo].[favoriteSpaces]    Script Date: 04/06/2025 15:34:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[favoriteSpaces](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[userId] [int] NULL,
	[spaceId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Reservations]    Script Date: 04/06/2025 15:34:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reservations](
	[reservationId] [int] IDENTITY(1,1) NOT NULL,
	[reservationDate] [datetime] NOT NULL,
	[reservedSpaceId] [int] NOT NULL,
	[userId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[reservationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 04/06/2025 15:34:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[userId] [int] IDENTITY(1,1) NOT NULL,
	[email] [varchar](50) NOT NULL,
	[username] [varchar](50) NOT NULL,
	[password] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[userId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[WorkSpaces]    Script Date: 04/06/2025 15:34:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WorkSpaces](
	[spaceId] [int] IDENTITY(1,1) NOT NULL,
	[spaceLocationFloor] [int] NOT NULL,
	[spacelocationZone] [varchar](50) NOT NULL,
	[hasMonitor] [bit] NOT NULL,
	[hasDockStation] [bit] NOT NULL,
	[hasWindow] [bit] NOT NULL,
	[hasPrinter] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[spaceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[favoriteSpaces] ON 

INSERT [dbo].[favoriteSpaces] ([id], [userId], [spaceId]) VALUES (2, 1, 1)
INSERT [dbo].[favoriteSpaces] ([id], [userId], [spaceId]) VALUES (3, 3, 1)
INSERT [dbo].[favoriteSpaces] ([id], [userId], [spaceId]) VALUES (5, 3, 3)
INSERT [dbo].[favoriteSpaces] ([id], [userId], [spaceId]) VALUES (6, 3, 2)
SET IDENTITY_INSERT [dbo].[favoriteSpaces] OFF
GO
SET IDENTITY_INSERT [dbo].[Reservations] ON 

INSERT [dbo].[Reservations] ([reservationId], [reservationDate], [reservedSpaceId], [userId]) VALUES (1, CAST(N'2025-06-04T00:00:00.000' AS DateTime), 1, 1)
INSERT [dbo].[Reservations] ([reservationId], [reservationDate], [reservedSpaceId], [userId]) VALUES (2, CAST(N'2025-06-05T14:32:59.667' AS DateTime), 3, 3)
INSERT [dbo].[Reservations] ([reservationId], [reservationDate], [reservedSpaceId], [userId]) VALUES (4, CAST(N'2025-06-08T00:00:00.000' AS DateTime), 1, 3)
INSERT [dbo].[Reservations] ([reservationId], [reservationDate], [reservedSpaceId], [userId]) VALUES (5, CAST(N'2025-06-05T00:00:00.000' AS DateTime), 1, 1)
SET IDENTITY_INSERT [dbo].[Reservations] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([userId], [email], [username], [password]) VALUES (1, N'ge', N'htrhr', N'hrthrt')
INSERT [dbo].[Users] ([userId], [email], [username], [password]) VALUES (2, N'bhrth', N'se', N'jyt')
INSERT [dbo].[Users] ([userId], [email], [username], [password]) VALUES (3, N'123', N'123', N'123')
INSERT [dbo].[Users] ([userId], [email], [username], [password]) VALUES (4, N'222', N'222', N'222')
INSERT [dbo].[Users] ([userId], [email], [username], [password]) VALUES (5, N'333', N'333', N'333')
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
SET IDENTITY_INSERT [dbo].[WorkSpaces] ON 

INSERT [dbo].[WorkSpaces] ([spaceId], [spaceLocationFloor], [spacelocationZone], [hasMonitor], [hasDockStation], [hasWindow], [hasPrinter]) VALUES (1, 1, N'ger', 1, 1, 1, 1)
INSERT [dbo].[WorkSpaces] ([spaceId], [spaceLocationFloor], [spacelocationZone], [hasMonitor], [hasDockStation], [hasWindow], [hasPrinter]) VALUES (2, 1, N'qeghh', 1, 1, 1, 1)
INSERT [dbo].[WorkSpaces] ([spaceId], [spaceLocationFloor], [spacelocationZone], [hasMonitor], [hasDockStation], [hasWindow], [hasPrinter]) VALUES (3, 2, N'ger', 1, 1, 1, 1)
INSERT [dbo].[WorkSpaces] ([spaceId], [spaceLocationFloor], [spacelocationZone], [hasMonitor], [hasDockStation], [hasWindow], [hasPrinter]) VALUES (4, 1, N'window', 0, 1, 0, 1)
SET IDENTITY_INSERT [dbo].[WorkSpaces] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Users__AB6E616467D89332]    Script Date: 04/06/2025 15:34:49 ******/
ALTER TABLE [dbo].[Users] ADD UNIQUE NONCLUSTERED 
(
	[email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Users__F3DBC5721C6F5FA0]    Script Date: 04/06/2025 15:34:49 ******/
ALTER TABLE [dbo].[Users] ADD UNIQUE NONCLUSTERED 
(
	[username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__WorkSpac__775A59B207E56954]    Script Date: 04/06/2025 15:34:49 ******/
ALTER TABLE [dbo].[WorkSpaces] ADD UNIQUE NONCLUSTERED 
(
	[spaceLocationFloor] ASC,
	[spacelocationZone] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[WorkSpaces] ADD  DEFAULT ((0)) FOR [hasMonitor]
GO
ALTER TABLE [dbo].[WorkSpaces] ADD  DEFAULT ((0)) FOR [hasDockStation]
GO
ALTER TABLE [dbo].[WorkSpaces] ADD  DEFAULT ((0)) FOR [hasWindow]
GO
ALTER TABLE [dbo].[WorkSpaces] ADD  DEFAULT ((0)) FOR [hasPrinter]
GO
ALTER TABLE [dbo].[favoriteSpaces]  WITH CHECK ADD FOREIGN KEY([spaceId])
REFERENCES [dbo].[WorkSpaces] ([spaceId])
GO
ALTER TABLE [dbo].[favoriteSpaces]  WITH CHECK ADD FOREIGN KEY([userId])
REFERENCES [dbo].[Users] ([userId])
GO
ALTER TABLE [dbo].[Reservations]  WITH CHECK ADD FOREIGN KEY([reservedSpaceId])
REFERENCES [dbo].[WorkSpaces] ([spaceId])
GO
ALTER TABLE [dbo].[Reservations]  WITH CHECK ADD FOREIGN KEY([userId])
REFERENCES [dbo].[Users] ([userId])
GO
USE [master]
GO
ALTER DATABASE [OfficeSpaces] SET  READ_WRITE 
GO
