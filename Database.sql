/****** Object:  Table [dbo].[doctors]    Script Date: 20/02/2025 14:15:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[doctors](
	[id_doc] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[surname] [nvarchar](50) NOT NULL,
	[specialization] [nvarchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_doc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[labTests]    Script Date: 20/02/2025 14:15:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[labTests](
	[id_tes] [int] IDENTITY(1,1) NOT NULL,
	[patients_id_pat] [int] NOT NULL,
	[name] [nvarchar](255) NOT NULL,
	[tes_ok] [bit] NULL,
	[result] [nvarchar](500) NULL,
	[tes_dat] [date] NULL,
	[notes] [nvarchar](500) NULL,
PRIMARY KEY CLUSTERED 
(
	[id_tes] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[patients]    Script Date: 20/02/2025 14:15:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[patients](
	[id_pat] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[surname] [nvarchar](50) NOT NULL,
	[birth_dat] [date] NOT NULL,
	[birth_num] [nvarchar](11) NOT NULL,
	[contact] [nvarchar](100) NOT NULL,
	[height] [decimal](5, 2) NULL,
	[weight] [decimal](5, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[id_pat] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[reports]    Script Date: 20/02/2025 14:15:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[reports](
	[id_rep] [int] IDENTITY(1,1) NOT NULL,
	[visits_id_vis] [int] NOT NULL,
	[symptoms] [nvarchar](500) NOT NULL,
	[diagnosis] [nvarchar](500) NULL,
	[recommendation] [nvarchar](500) NULL,
	[treatment] [nvarchar](500) NULL,
	[conclusion] [nvarchar](500) NOT NULL,
	[rep_dat] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_rep] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[visits]    Script Date: 20/02/2025 14:15:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[visits](
	[id_vis] [int] IDENTITY(1,1) NOT NULL,
	[patients_id_pat] [int] NOT NULL,
	[doctors_id_doc] [int] NOT NULL,
	[vis_reason] [nvarchar](255) NOT NULL,
	[vis_dat] [datetime] NOT NULL,
	[vis_price] [decimal](8, 2) NOT NULL,
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
SET IDENTITY_INSERT [dbo].[labTests] ON 
GO
INSERT [dbo].[labTests] ([id_tes], [patients_id_pat], [name], [tes_ok], [result], [tes_dat], [notes]) VALUES (1, 2, N'MRI', 1, N'', CAST(N'2024-02-28' AS Date), NULL)
GO
SET IDENTITY_INSERT [dbo].[labTests] OFF
GO
SET IDENTITY_INSERT [dbo].[patients] ON 
GO
INSERT [dbo].[patients] ([id_pat], [name], [surname], [birth_dat], [birth_num], [contact], [height], [weight]) VALUES (1, N'Jan', N'Novák', CAST(N'1985-06-15' AS Date), N'850615/1234', N'jan.novak@email.com', CAST(180.50 AS Decimal(5, 2)), CAST(75.20 AS Decimal(5, 2)))
GO
INSERT [dbo].[patients] ([id_pat], [name], [surname], [birth_dat], [birth_num], [contact], [height], [weight]) VALUES (2, N'Petra', N'Svobodová', CAST(N'1992-12-03' AS Date), N'921203/5678', N'petra.svobodova@email.com', NULL, CAST(68.40 AS Decimal(5, 2)))
GO
INSERT [dbo].[patients] ([id_pat], [name], [surname], [birth_dat], [birth_num], [contact], [height], [weight]) VALUES (3, N'Tomáš', N'Dvorák', CAST(N'1978-09-27' AS Date), N'780927/4321', N'tomas.dvorak@email.com', CAST(175.00 AS Decimal(5, 2)), NULL)
GO
INSERT [dbo].[patients] ([id_pat], [name], [surname], [birth_dat], [birth_num], [contact], [height], [weight]) VALUES (4, N'Eliska', N'Novotná', CAST(N'2004-05-12' AS Date), N'045512/6789', N'eliska.novotna@email.com', CAST(166.00 AS Decimal(5, 2)), CAST(58.00 AS Decimal(5, 2)))
GO
SET IDENTITY_INSERT [dbo].[patients] OFF
GO
SET IDENTITY_INSERT [dbo].[reports] ON 
GO
INSERT [dbo].[reports] ([id_rep], [visits_id_vis], [symptoms], [diagnosis], [recommendation], [treatment], [conclusion], [rep_dat]) VALUES (1, 1, N'Routine cardiology check-up', NULL, NULL, NULL, N'No significant changes, patient is stable', CAST(N'2024-02-18T11:00:00.000' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[reports] OFF
GO
SET IDENTITY_INSERT [dbo].[visits] ON 
GO
INSERT [dbo].[visits] ([id_vis], [patients_id_pat], [doctors_id_doc], [vis_reason], [vis_dat], [vis_price]) VALUES (1, 1, 1, N'Routine check-up', CAST(N'2024-02-18T10:30:00.000' AS DateTime), CAST(0.00 AS Decimal(8, 2)))
GO
INSERT [dbo].[visits] ([id_vis], [patients_id_pat], [doctors_id_doc], [vis_reason], [vis_dat], [vis_price]) VALUES (2, 2, 2, N'Headaches', CAST(N'2024-02-20T00:00:00.000' AS DateTime), CAST(0.00 AS Decimal(8, 2)))
GO
INSERT [dbo].[visits] ([id_vis], [patients_id_pat], [doctors_id_doc], [vis_reason], [vis_dat], [vis_price]) VALUES (3, 4, 7, N'Routine eye check-up', CAST(N'2025-02-18T10:30:00.000' AS DateTime), CAST(0.00 AS Decimal(8, 2)))
GO
SET IDENTITY_INSERT [dbo].[visits] OFF
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
