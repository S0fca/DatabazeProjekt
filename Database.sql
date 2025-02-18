USE [clinic]
GO
/****** Object:  Table [dbo].[doctors]    Script Date: 18/02/2025 20:59:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[doctors](
	[id_doc] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NOT NULL,
	[surname] [varchar](50) NOT NULL,
	[specialization] [varchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_doc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[labTests]    Script Date: 18/02/2025 20:59:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[labTests](
	[id_tes] [int] IDENTITY(1,1) NOT NULL,
	[patients_id_pat] [int] NOT NULL,
	[name] [varchar](255) NOT NULL,
	[tes_ok] [bit] NOT NULL,
	[result] [varchar](500) NULL,
	[tes_dat] [date] NOT NULL,
	[notes] [varchar](500) NULL,
PRIMARY KEY CLUSTERED 
(
	[id_tes] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[patients]    Script Date: 18/02/2025 20:59:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[patients](
	[id_pat] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NOT NULL,
	[surname] [varchar](50) NOT NULL,
	[birth_dat] [date] NOT NULL,
	[birth_num] [varchar](11) NOT NULL,
	[contact] [varchar](100) NULL,
	[height] [decimal](5, 2) NULL,
	[weight] [decimal](5, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[id_pat] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[reports]    Script Date: 18/02/2025 20:59:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[reports](
	[id_rep] [int] IDENTITY(1,1) NOT NULL,
	[visits_id_vis] [int] NOT NULL,
	[symptoms] [varchar](500) NOT NULL,
	[diagnosis] [varchar](500) NULL,
	[recommendation] [varchar](500) NULL,
	[treatment] [varchar](500) NULL,
	[conclusion] [varchar](500) NOT NULL,
	[rep_dat] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_rep] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[visits]    Script Date: 18/02/2025 20:59:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[visits](
	[id_vis] [int] IDENTITY(1,1) NOT NULL,
	[patients_id_pat] [int] NOT NULL,
	[doctors_id_doc] [int] NOT NULL,
	[vis_reason] [varchar](255) NOT NULL,
	[vis_dat] [datetime] NOT NULL,
	[vis_price] [decimal](8, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[id_vis] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[doctors] ON 
GO
INSERT [dbo].[doctors] ([id_doc], [name], [surname], [specialization]) VALUES (1, N'Jan', N'Novák', N'Cardiology')
GO
INSERT [dbo].[doctors] ([id_doc], [name], [surname], [specialization]) VALUES (2, N'Petr', N'Svoboda', N'Neurology')
GO
INSERT [dbo].[doctors] ([id_doc], [name], [surname], [specialization]) VALUES (3, N'Lucie', N'Dvoráková', N'Pediatrics')
GO
INSERT [dbo].[doctors] ([id_doc], [name], [surname], [specialization]) VALUES (4, N'Martin', N'Král', N'Orthopedics')
GO
INSERT [dbo].[doctors] ([id_doc], [name], [surname], [specialization]) VALUES (5, N'Eva', N'Veselá', N'Dermatology')
GO
INSERT [dbo].[doctors] ([id_doc], [name], [surname], [specialization]) VALUES (6, N'Tomáš', N'Kovár', N'General Medicine')
GO
INSERT [dbo].[doctors] ([id_doc], [name], [surname], [specialization]) VALUES (7, N'Anna', N'Malá', N'Ophthalmology')
GO
INSERT [dbo].[doctors] ([id_doc], [name], [surname], [specialization]) VALUES (8, N'David', N'Ružicka', N'Psychiatry')
GO
SET IDENTITY_INSERT [dbo].[doctors] OFF
GO
SET IDENTITY_INSERT [dbo].[patients] ON 
GO
INSERT [dbo].[patients] ([id_pat], [name], [surname], [birth_dat], [birth_num], [contact], [height], [weight]) VALUES (1, N'name', N'surname', CAST(N'2001-01-01' AS Date), N'111111/1111', N'contact', CAST(172.00 AS Decimal(5, 2)), CAST(65.00 AS Decimal(5, 2)))
GO
SET IDENTITY_INSERT [dbo].[patients] OFF
GO
ALTER TABLE [dbo].[labTests] ADD  DEFAULT ((1)) FOR [tes_ok]
GO
ALTER TABLE [dbo].[labTests]  WITH CHECK ADD FOREIGN KEY([patients_id_pat])
REFERENCES [dbo].[patients] ([id_pat])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[reports]  WITH CHECK ADD FOREIGN KEY([visits_id_vis])
REFERENCES [dbo].[visits] ([id_vis])
GO
ALTER TABLE [dbo].[visits]  WITH CHECK ADD FOREIGN KEY([doctors_id_doc])
REFERENCES [dbo].[doctors] ([id_doc])
GO
ALTER TABLE [dbo].[visits]  WITH CHECK ADD FOREIGN KEY([patients_id_pat])
REFERENCES [dbo].[patients] ([id_pat])
GO
ALTER TABLE [dbo].[patients]  WITH CHECK ADD CHECK  (([birth_dat]<=getdate()))
GO
ALTER TABLE [dbo].[patients]  WITH CHECK ADD CHECK  (([birth_num] like '[0-9][0-9][0-9][0-9][0-9][0-9]/[0-9][0-9][0-9][0-9]'))
GO
