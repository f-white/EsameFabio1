USE [master]
GO
/****** Object:  Database [EsameFabio1]    Script Date: 09/07/2023 09:57:33 ******/
CREATE DATABASE [EsameFabio1]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'AspNetIdentityDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\AspNetIdentityDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'AspNetIdentityDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\AspNetIdentityDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [EsameFabio1] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [EsameFabio1].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [EsameFabio1] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [EsameFabio1] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [EsameFabio1] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [EsameFabio1] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [EsameFabio1] SET ARITHABORT OFF 
GO
ALTER DATABASE [EsameFabio1] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [EsameFabio1] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [EsameFabio1] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [EsameFabio1] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [EsameFabio1] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [EsameFabio1] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [EsameFabio1] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [EsameFabio1] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [EsameFabio1] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [EsameFabio1] SET  DISABLE_BROKER 
GO
ALTER DATABASE [EsameFabio1] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [EsameFabio1] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [EsameFabio1] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [EsameFabio1] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [EsameFabio1] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [EsameFabio1] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [EsameFabio1] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [EsameFabio1] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [EsameFabio1] SET  MULTI_USER 
GO
ALTER DATABASE [EsameFabio1] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [EsameFabio1] SET DB_CHAINING OFF 
GO
ALTER DATABASE [EsameFabio1] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [EsameFabio1] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [EsameFabio1] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [EsameFabio1] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [EsameFabio1] SET QUERY_STORE = ON
GO
ALTER DATABASE [EsameFabio1] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [EsameFabio1]
GO
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 09/07/2023 09:57:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoleClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
	[RoleId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 09/07/2023 09:57:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](450) NOT NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[Name] [nvarchar](256) NULL,
	[NormalizedName] [nvarchar](256) NULL,
 CONSTRAINT [PK_AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 09/07/2023 09:57:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
	[UserId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 09/07/2023 09:57:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](450) NOT NULL,
	[ProviderKey] [nvarchar](450) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 09/07/2023 09:57:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](450) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 09/07/2023 09:57:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](450) NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[Email] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[NormalizedEmail] [nvarchar](256) NULL,
	[NormalizedUserName] [nvarchar](256) NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[UserName] [nvarchar](256) NULL,
	[FirstName] [nvarchar](max) NULL,
	[LastName] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 09/07/2023 09:57:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserTokens](
	[UserId] [nvarchar](450) NOT NULL,
	[LoginProvider] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](450) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Attivita]    Script Date: 09/07/2023 09:57:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Attivita](
	[IdAttivita] [uniqueidentifier] NOT NULL,
	[NomeAttivita] [nvarchar](50) NOT NULL,
	[DescrizioneAttivita] [varchar](max) NOT NULL,
	[DataInizio] [datetime] NOT NULL,
	[DataFine] [datetime] NOT NULL,
	[NumeroPosti] [int] NOT NULL,
	[PrezzoAttivita] [decimal](18, 2) NOT NULL,
	[ImgAtt] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdAttivita] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Prenotazioni]    Script Date: 09/07/2023 09:57:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Prenotazioni](
	[IdPrenotazioneAttivita] [uniqueidentifier] NOT NULL,
	[IdUtente] [nvarchar](450) NOT NULL,
	[IdAttivita] [uniqueidentifier] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdPrenotazioneAttivita] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[AspNetRoles] ([Id], [ConcurrencyStamp], [Name], [NormalizedName]) VALUES (N'b5dad443-fd55-408a-8039-771d684dffd3', N'52ea3c72-81db-43fe-9f18-a2c0fadc22b8', N'Admin', N'ADMIN')
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'07ead05e-6ce7-4dd5-adc6-2360392928fe', N'b5dad443-fd55-408a-8039-771d684dffd3')
GO
INSERT [dbo].[AspNetUsers] ([Id], [AccessFailedCount], [ConcurrencyStamp], [Email], [EmailConfirmed], [LockoutEnabled], [LockoutEnd], [NormalizedEmail], [NormalizedUserName], [PasswordHash], [PhoneNumber], [PhoneNumberConfirmed], [SecurityStamp], [TwoFactorEnabled], [UserName], [FirstName], [LastName]) VALUES (N'07ead05e-6ce7-4dd5-adc6-2360392928fe', 0, N'eff9cfdf-253c-4f98-a272-6b5ccc5dcd4a', N'admin@admin.it', 0, 1, NULL, N'ADMIN@ADMIN.IT', N'ADMIN', N'AQAAAAEAACcQAAAAEDJgc519+N8b4EA82qZ8qhSKFnipgc4oz6FJraoBs4PrUPe5BfVHZtOQwtE+9Gjd3g==', NULL, 0, N'AB47ZNRBRBBLEFXJMESBDADC5O4AZF5J', 0, N'Admin', NULL, NULL)
INSERT [dbo].[AspNetUsers] ([Id], [AccessFailedCount], [ConcurrencyStamp], [Email], [EmailConfirmed], [LockoutEnabled], [LockoutEnd], [NormalizedEmail], [NormalizedUserName], [PasswordHash], [PhoneNumber], [PhoneNumberConfirmed], [SecurityStamp], [TwoFactorEnabled], [UserName], [FirstName], [LastName]) VALUES (N'8fcfe8e4-1d97-4ced-aae6-3d56a2b1969b', 0, N'229b9d99-60c8-480b-9f00-e720e0d0f239', N'bianco.fabio@gmail.com', 0, 1, NULL, N'BIANCO.FABIO@GMAIL.COM', N'FABIO', N'AQAAAAEAACcQAAAAEBgtXKDD1mltW1+D4/Z0uYPdyMinU5KChPrw57VUNLzfN8ANQNfWkK5b4oOQbnx6Hw==', NULL, 0, N'JRXZMW4EBOT2IIAMAQIIY53J3L5EVTRB', 0, N'Fabio', N'Fabio', N'Bianco')
INSERT [dbo].[AspNetUsers] ([Id], [AccessFailedCount], [ConcurrencyStamp], [Email], [EmailConfirmed], [LockoutEnabled], [LockoutEnd], [NormalizedEmail], [NormalizedUserName], [PasswordHash], [PhoneNumber], [PhoneNumberConfirmed], [SecurityStamp], [TwoFactorEnabled], [UserName], [FirstName], [LastName]) VALUES (N'a9f82c8d-d514-49f9-8d96-69e2725ad821', 0, N'c8694381-f43c-468e-b148-b9b8fd1cb7fb', N'baudo@gmail.com', 0, 1, NULL, N'BAUDO@GMAIL.COM', N'PIPPO', N'AQAAAAEAACcQAAAAEKG562wsiz+PjXxgeia73UhaI2PhvZR4m83SCUDAZSOqahAAmDGyABWFFqryk7nC0w==', NULL, 0, N'EEVQHMRFLGAMKVQESMFMNFASHNTDODVE', 0, N'pippo', N'pippo', N'baudo')
GO
INSERT [dbo].[Attivita] ([IdAttivita], [NomeAttivita], [DescrizioneAttivita], [DataInizio], [DataFine], [NumeroPosti], [PrezzoAttivita], [ImgAtt]) VALUES (N'2dd4e384-d4d9-4122-b4af-02280b22fc7e', N'Pilates', N'Lezioni di Pilates con la nostra insegnante Ornella', CAST(N'2023-07-07T00:00:00.000' AS DateTime), CAST(N'2023-07-13T00:00:00.000' AS DateTime), 5, CAST(10.00 AS Decimal(18, 2)), N'https://liltpalermo.it/wp-content/uploads/2020/02/pilates.jpg.webp')
INSERT [dbo].[Attivita] ([IdAttivita], [NomeAttivita], [DescrizioneAttivita], [DataInizio], [DataFine], [NumeroPosti], [PrezzoAttivita], [ImgAtt]) VALUES (N'e29604e5-8fbd-4ccc-af8d-03e34867cc0f', N'Relax', N'Bellissima cosa da fare', CAST(N'2023-07-15T10:30:00.000' AS DateTime), CAST(N'2023-07-20T12:00:00.000' AS DateTime), 10, CAST(42.50 AS Decimal(18, 2)), N'https://img.freepik.com/free-photo/relax-written-sand_23-2148330675.jpg?t=st=1688734545~exp=1688735145~hmac=015182a307ce7c5166a5c8e21e222d9452b02b8619e5f8501b269bebae0ff6f8')
INSERT [dbo].[Attivita] ([IdAttivita], [NomeAttivita], [DescrizioneAttivita], [DataInizio], [DataFine], [NumeroPosti], [PrezzoAttivita], [ImgAtt]) VALUES (N'2cae3b87-efcb-4d50-9d88-32fe41e8487a', N'Fun', N'Divertimento assicurato', CAST(N'2023-12-31T21:30:00.000' AS DateTime), CAST(N'2024-01-01T12:00:00.000' AS DateTime), 40, CAST(15.90 AS Decimal(18, 2)), N'https://www.crescita-personale.org/wp-content/uploads/2013/05/il-potere-del-divertimento1.jpg')
INSERT [dbo].[Attivita] ([IdAttivita], [NomeAttivita], [DescrizioneAttivita], [DataInizio], [DataFine], [NumeroPosti], [PrezzoAttivita], [ImgAtt]) VALUES (N'ba396633-1d52-4139-9df9-f1842924790e', N'Brivido', N'Provate la paura di essere arrestati', CAST(N'2023-07-07T00:00:00.000' AS DateTime), CAST(N'2023-07-07T00:00:00.000' AS DateTime), 3, CAST(40.00 AS Decimal(18, 2)), N'https://www.istitutopsicoterapie.com/wp-content/uploads/2023/04/alcatraz-2161656_1280.jpeg')
GO
INSERT [dbo].[Prenotazioni] ([IdPrenotazioneAttivita], [IdUtente], [IdAttivita]) VALUES (N'6398774c-5042-496b-877d-b3536c13e97e', N'8fcfe8e4-1d97-4ced-aae6-3d56a2b1969b', N'ba396633-1d52-4139-9df9-f1842924790e')
GO
ALTER TABLE [dbo].[AspNetRoleClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetRoleClaims] CHECK CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[Prenotazioni]  WITH CHECK ADD  CONSTRAINT [FK__Prenotazi__IdAtt__4BAC3F29] FOREIGN KEY([IdAttivita])
REFERENCES [dbo].[Attivita] ([IdAttivita])
GO
ALTER TABLE [dbo].[Prenotazioni] CHECK CONSTRAINT [FK__Prenotazi__IdAtt__4BAC3F29]
GO
ALTER TABLE [dbo].[Prenotazioni]  WITH CHECK ADD FOREIGN KEY([IdUtente])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
USE [master]
GO
ALTER DATABASE [EsameFabio1] SET  READ_WRITE 
GO
