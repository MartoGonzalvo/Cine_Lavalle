USE [20171C_TP]
GO
/****** Object:  Table [dbo].[Calificaciones]    Script Date: 16/06/2017 15:44:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Calificaciones](
	[IdCalificacion] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Calificaciones] PRIMARY KEY CLUSTERED 
(
	[IdCalificacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Carteleras]    Script Date: 16/06/2017 15:44:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Carteleras](
	[IdCartelera] [int] IDENTITY(1,1) NOT NULL,
	[IdSede] [int] NOT NULL,
	[IdPelicula] [int] NOT NULL,
	[HoraInicio] [int] NOT NULL,
	[FechaInicio] [datetime] NOT NULL,
	[FechaFin] [datetime] NOT NULL,
	[NumeroSala] [int] NOT NULL,
	[IdVersion] [int] NOT NULL,
	[Lunes] [bit] NOT NULL,
	[Martes] [bit] NOT NULL,
	[Miercoles] [bit] NOT NULL,
	[Jueves] [bit] NOT NULL,
	[Viernes] [bit] NOT NULL,
	[Sabado] [bit] NOT NULL,
	[Domingo] [bit] NOT NULL,
	[FechaCarga] [datetime] NOT NULL,
 CONSTRAINT [PK_Carteleras] PRIMARY KEY CLUSTERED 
(
	[IdCartelera] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Generos]    Script Date: 16/06/2017 15:44:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Generos](
	[IdGenero] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Generos] PRIMARY KEY CLUSTERED 
(
	[IdGenero] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Peliculas]    Script Date: 16/06/2017 15:44:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Peliculas](
	[IdPelicula] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
	[Descripcion] [nvarchar](750) NOT NULL,
	[Imagen] [nvarchar](300) NOT NULL,
	[IdCalificacion] [int] NOT NULL,
	[IdGenero] [int] NOT NULL,
	[Duracion] [int] NOT NULL,
	[FechaCarga] [datetime] NOT NULL,
 CONSTRAINT [PK_Peliculas] PRIMARY KEY CLUSTERED 
(
	[IdPelicula] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Reservas]    Script Date: 16/06/2017 15:44:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reservas](
	[IdReserva] [int] IDENTITY(1,1) NOT NULL,
	[IdSede] [int] NOT NULL,
	[IdVersion] [int] NOT NULL,
	[IdPelicula] [int] NOT NULL,
	[FechaHoraInicio] [datetime] NOT NULL,
	[Email] [nvarchar](250) NOT NULL,
	[IdTipoDocumento] [int] NOT NULL,
	[NumeroDocumento] [nvarchar](50) NOT NULL,
	[CantidadEntradas] [int] NOT NULL,
	[FechaCarga] [datetime] NOT NULL,
 CONSTRAINT [PK_Reservas] PRIMARY KEY CLUSTERED 
(
	[IdReserva] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Sedes]    Script Date: 16/06/2017 15:44:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sedes](
	[IdSede] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](100) NOT NULL,
	[Direccion] [nvarchar](300) NOT NULL,
	[PrecioGeneral] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_Sedes] PRIMARY KEY CLUSTERED 
(
	[IdSede] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TiposDocumentos]    Script Date: 16/06/2017 15:44:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TiposDocumentos](
	[IdTipoDocumento] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [nvarchar](200) NOT NULL,
 CONSTRAINT [PK_TiposDocumentos] PRIMARY KEY CLUSTERED 
(
	[IdTipoDocumento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 16/06/2017 15:44:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[IdUsuario] [int] IDENTITY(1,1) NOT NULL,
	[NombreUsuario] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Usuarios] PRIMARY KEY CLUSTERED 
(
	[IdUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Versiones]    Script Date: 16/06/2017 15:44:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Versiones](
	[IdVersion] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Versiones] PRIMARY KEY CLUSTERED 
(
	[IdVersion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Calificaciones] ON 

INSERT [dbo].[Calificaciones] ([IdCalificacion], [Nombre]) VALUES (1, N'ATP')
INSERT [dbo].[Calificaciones] ([IdCalificacion], [Nombre]) VALUES (2, N'+13')
INSERT [dbo].[Calificaciones] ([IdCalificacion], [Nombre]) VALUES (3, N'+13R')
INSERT [dbo].[Calificaciones] ([IdCalificacion], [Nombre]) VALUES (4, N'+16')
INSERT [dbo].[Calificaciones] ([IdCalificacion], [Nombre]) VALUES (5, N'+16R')
SET IDENTITY_INSERT [dbo].[Calificaciones] OFF
SET IDENTITY_INSERT [dbo].[Carteleras] ON 

INSERT [dbo].[Carteleras] ([IdCartelera], [IdSede], [IdPelicula], [HoraInicio], [FechaInicio], [FechaFin], [NumeroSala], [IdVersion], [Lunes], [Martes], [Miercoles], [Jueves], [Viernes], [Sabado], [Domingo], [FechaCarga]) VALUES (3, 1, 4, 14, CAST(N'2017-01-01 00:00:00.000' AS DateTime), CAST(N'2017-01-30 00:00:00.000' AS DateTime), 1, 1, 1, 1, 1, 0, 0, 0, 0, CAST(N'2017-06-14 19:55:05.230' AS DateTime))
INSERT [dbo].[Carteleras] ([IdCartelera], [IdSede], [IdPelicula], [HoraInicio], [FechaInicio], [FechaFin], [NumeroSala], [IdVersion], [Lunes], [Martes], [Miercoles], [Jueves], [Viernes], [Sabado], [Domingo], [FechaCarga]) VALUES (4, 1, 4, 14, CAST(N'2017-01-01 00:00:00.000' AS DateTime), CAST(N'2017-01-30 00:00:00.000' AS DateTime), 1, 2, 0, 0, 0, 0, 0, 1, 1, CAST(N'2017-06-14 19:57:53.280' AS DateTime))
SET IDENTITY_INSERT [dbo].[Carteleras] OFF
SET IDENTITY_INSERT [dbo].[Generos] ON 

INSERT [dbo].[Generos] ([IdGenero], [Nombre]) VALUES (1, N'Comedia')
INSERT [dbo].[Generos] ([IdGenero], [Nombre]) VALUES (2, N'Terror')
INSERT [dbo].[Generos] ([IdGenero], [Nombre]) VALUES (3, N'Fantasia')
INSERT [dbo].[Generos] ([IdGenero], [Nombre]) VALUES (4, N'Ficcion')
SET IDENTITY_INSERT [dbo].[Generos] OFF
SET IDENTITY_INSERT [dbo].[Peliculas] ON 

INSERT [dbo].[Peliculas] ([IdPelicula], [Nombre], [Descripcion], [Imagen], [IdCalificacion], [IdGenero], [Duracion], [FechaCarga]) VALUES (4, N'Volver al Futuro', N'Gran Pelii!!!', N'img/btf', 1, 4, 120, CAST(N'2017-06-11 15:25:14.177' AS DateTime))
INSERT [dbo].[Peliculas] ([IdPelicula], [Nombre], [Descripcion], [Imagen], [IdCalificacion], [IdGenero], [Duracion], [FechaCarga]) VALUES (5, N'Volver al futuro 2', N'asdasda', N'dasda', 1, 4, 180, CAST(N'2017-06-11 00:00:00.000' AS DateTime))
INSERT [dbo].[Peliculas] ([IdPelicula], [Nombre], [Descripcion], [Imagen], [IdCalificacion], [IdGenero], [Duracion], [FechaCarga]) VALUES (9, N'Volver al futuro 3', N'peli grosa 3', N'addas', 1, 4, 150, CAST(N'2017-06-11 00:00:00.000' AS DateTime))
INSERT [dbo].[Peliculas] ([IdPelicula], [Nombre], [Descripcion], [Imagen], [IdCalificacion], [IdGenero], [Duracion], [FechaCarga]) VALUES (10, N'iuoiui', N'kjhkjhk', N'kjhkjhk', 1, 1, 90, CAST(N'2017-06-11 00:00:00.000' AS DateTime))
INSERT [dbo].[Peliculas] ([IdPelicula], [Nombre], [Descripcion], [Imagen], [IdCalificacion], [IdGenero], [Duracion], [FechaCarga]) VALUES (11, N'pelicula prueba', N'pelicula prueba', N'jasj', 2, 3, 80, CAST(N'2017-06-13 00:00:00.000' AS DateTime))
INSERT [dbo].[Peliculas] ([IdPelicula], [Nombre], [Descripcion], [Imagen], [IdCalificacion], [IdGenero], [Duracion], [FechaCarga]) VALUES (12, N'happy feet', N'pelicula de pinguinos', N'addas', 1, 3, 90, CAST(N'2017-06-13 00:00:00.000' AS DateTime))
INSERT [dbo].[Peliculas] ([IdPelicula], [Nombre], [Descripcion], [Imagen], [IdCalificacion], [IdGenero], [Duracion], [FechaCarga]) VALUES (13, N'iuoiui', N'oiuyouyiu', N'dasda', 1, 3, 90, CAST(N'2017-06-14 00:00:00.000' AS DateTime))
INSERT [dbo].[Peliculas] ([IdPelicula], [Nombre], [Descripcion], [Imagen], [IdCalificacion], [IdGenero], [Duracion], [FechaCarga]) VALUES (14, N'happy feet', N'pelicula de pinguinos', N'/Content/imgPenguins.jpg', 1, 3, 90, CAST(N'2017-06-16 00:00:00.000' AS DateTime))
INSERT [dbo].[Peliculas] ([IdPelicula], [Nombre], [Descripcion], [Imagen], [IdCalificacion], [IdGenero], [Duracion], [FechaCarga]) VALUES (15, N'medusa asesina', N'medusa asesina que mata gente', N'/Content/imgJellyfish.jpg', 2, 2, 120, CAST(N'2017-06-16 00:00:00.000' AS DateTime))
INSERT [dbo].[Peliculas] ([IdPelicula], [Nombre], [Descripcion], [Imagen], [IdCalificacion], [IdGenero], [Duracion], [FechaCarga]) VALUES (16, N'jurasic park', N'pelicula de dinosaurios comiendo gente', N'/Content/imgDesert.jpg', 2, 3, 180, CAST(N'2017-06-16 00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[Peliculas] OFF
SET IDENTITY_INSERT [dbo].[Sedes] ON 

INSERT [dbo].[Sedes] ([IdSede], [Nombre], [Direccion], [PrecioGeneral]) VALUES (1, N'caballito', N'riv 123', CAST(150.00 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[Sedes] OFF
SET IDENTITY_INSERT [dbo].[Usuarios] ON 

INSERT [dbo].[Usuarios] ([IdUsuario], [NombreUsuario], [Password]) VALUES (3, N'admin', N'123')
SET IDENTITY_INSERT [dbo].[Usuarios] OFF
SET IDENTITY_INSERT [dbo].[Versiones] ON 

INSERT [dbo].[Versiones] ([IdVersion], [Nombre]) VALUES (1, N'Subtitulada')
INSERT [dbo].[Versiones] ([IdVersion], [Nombre]) VALUES (2, N'Doblada al Español')
SET IDENTITY_INSERT [dbo].[Versiones] OFF
ALTER TABLE [dbo].[Carteleras]  WITH CHECK ADD  CONSTRAINT [FK_Carteleras_Peliculas] FOREIGN KEY([IdPelicula])
REFERENCES [dbo].[Peliculas] ([IdPelicula])
GO
ALTER TABLE [dbo].[Carteleras] CHECK CONSTRAINT [FK_Carteleras_Peliculas]
GO
ALTER TABLE [dbo].[Carteleras]  WITH CHECK ADD  CONSTRAINT [FK_Carteleras_Sedes] FOREIGN KEY([IdSede])
REFERENCES [dbo].[Sedes] ([IdSede])
GO
ALTER TABLE [dbo].[Carteleras] CHECK CONSTRAINT [FK_Carteleras_Sedes]
GO
ALTER TABLE [dbo].[Carteleras]  WITH CHECK ADD  CONSTRAINT [FK_Carteleras_Versiones] FOREIGN KEY([IdVersion])
REFERENCES [dbo].[Versiones] ([IdVersion])
GO
ALTER TABLE [dbo].[Carteleras] CHECK CONSTRAINT [FK_Carteleras_Versiones]
GO
ALTER TABLE [dbo].[Peliculas]  WITH CHECK ADD  CONSTRAINT [FK_Peliculas_Calificaciones] FOREIGN KEY([IdCalificacion])
REFERENCES [dbo].[Calificaciones] ([IdCalificacion])
GO
ALTER TABLE [dbo].[Peliculas] CHECK CONSTRAINT [FK_Peliculas_Calificaciones]
GO
ALTER TABLE [dbo].[Peliculas]  WITH CHECK ADD  CONSTRAINT [FK_Peliculas_Generos] FOREIGN KEY([IdGenero])
REFERENCES [dbo].[Generos] ([IdGenero])
GO
ALTER TABLE [dbo].[Peliculas] CHECK CONSTRAINT [FK_Peliculas_Generos]
GO
ALTER TABLE [dbo].[Reservas]  WITH CHECK ADD  CONSTRAINT [FK_Reservas_Peliculas] FOREIGN KEY([IdPelicula])
REFERENCES [dbo].[Peliculas] ([IdPelicula])
GO
ALTER TABLE [dbo].[Reservas] CHECK CONSTRAINT [FK_Reservas_Peliculas]
GO
ALTER TABLE [dbo].[Reservas]  WITH CHECK ADD  CONSTRAINT [FK_Reservas_Sedes] FOREIGN KEY([IdSede])
REFERENCES [dbo].[Sedes] ([IdSede])
GO
ALTER TABLE [dbo].[Reservas] CHECK CONSTRAINT [FK_Reservas_Sedes]
GO
ALTER TABLE [dbo].[Reservas]  WITH CHECK ADD  CONSTRAINT [FK_Reservas_TiposDocumentos] FOREIGN KEY([IdTipoDocumento])
REFERENCES [dbo].[TiposDocumentos] ([IdTipoDocumento])
GO
ALTER TABLE [dbo].[Reservas] CHECK CONSTRAINT [FK_Reservas_TiposDocumentos]
GO
ALTER TABLE [dbo].[Reservas]  WITH CHECK ADD  CONSTRAINT [FK_Reservas_Versiones] FOREIGN KEY([IdVersion])
REFERENCES [dbo].[Versiones] ([IdVersion])
GO
ALTER TABLE [dbo].[Reservas] CHECK CONSTRAINT [FK_Reservas_Versiones]
GO
