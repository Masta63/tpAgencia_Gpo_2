USE [Sistema_Viajes]
GO
/****** Object:  Table [dbo].[Ciudad]    Script Date: 17/10/2023 00:17:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ciudad](
	[idCiudad] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nchar](50) NULL,
	[idCiudadVuelo] [int] NULL,
	[idCiudadHotel] [int] NULL,
 CONSTRAINT [PK_Ciudad] PRIMARY KEY CLUSTERED 
(
	[idCiudad] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CiudadHotel]    Script Date: 17/10/2023 00:17:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CiudadHotel](
	[idCiudadHotel] [int] IDENTITY(1,1) NOT NULL,
	[idHotel] [int] NULL,
	[idCiudad] [int] NULL,
 CONSTRAINT [PK_CiudadHotel] PRIMARY KEY CLUSTERED 
(
	[idCiudadHotel] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CiudadVuelos]    Script Date: 17/10/2023 00:17:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CiudadVuelos](
	[idCiudadVuelos] [int] IDENTITY(1,1) NOT NULL,
	[idVuelos] [int] NULL,
	[idCiudad] [int] NULL,
 CONSTRAINT [PK_CiudadVuelos] PRIMARY KEY CLUSTERED 
(
	[idCiudadVuelos] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Hotel]    Script Date: 17/10/2023 00:17:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Hotel](
	[idHotel] [int] IDENTITY(1,1) NOT NULL,
	[ubicacion] [int] NULL,
	[capacidad] [int] NULL,
	[costo] [numeric](18, 0) NULL,
	[nombre] [nchar](50) NULL,
	[idMisReservas] [int] NULL,
 CONSTRAINT [PK_Hotel] PRIMARY KEY CLUSTERED 
(
	[idHotel] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Hotel_Usuario]    Script Date: 17/10/2023 00:17:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Hotel_Usuario](
	[idHotel] [int] NOT NULL,
	[idUsuario] [int] NOT NULL,
	[cantidad] [int] NULL,
 CONSTRAINT [PK_Hotel_Usuario] PRIMARY KEY CLUSTERED 
(
	[idHotel] ASC,
	[idUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HotelesVisitadosUsuario]    Script Date: 17/10/2023 00:17:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HotelesVisitadosUsuario](
	[idHotelUsuario] [int] IDENTITY(1,1) NOT NULL,
	[idHotel] [int] NULL,
	[idUsuario] [int] NULL,
 CONSTRAINT [PK_HotelesVisitadosUsuario] PRIMARY KEY CLUSTERED 
(
	[idHotelUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MisReservasHotel]    Script Date: 17/10/2023 00:17:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MisReservasHotel](
	[idMisReservas] [int] NOT NULL,
	[idHotel] [int] NULL,
	[idReservaHotel] [int] NULL,
 CONSTRAINT [PK_MisReservas] PRIMARY KEY CLUSTERED 
(
	[idMisReservas] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MisReservasHotelesUsuario]    Script Date: 17/10/2023 00:17:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MisReservasHotelesUsuario](
	[idReservaHotelUsuario] [int] IDENTITY(1,1) NOT NULL,
	[idReservaHotel] [int] NULL,
	[idUsuario] [int] NULL,
 CONSTRAINT [PK_MisReservasHotelesUsuario] PRIMARY KEY CLUSTERED 
(
	[idReservaHotelUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MisReservasVuelo]    Script Date: 17/10/2023 00:17:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MisReservasVuelo](
	[idMisReservasVuelo] [int] IDENTITY(1,1) NOT NULL,
	[idVuelo] [int] NULL,
	[idReservaVuelo] [int] NULL,
 CONSTRAINT [PK_MisReservasVuelo] PRIMARY KEY CLUSTERED 
(
	[idMisReservasVuelo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MisReservaVuelosUsuario]    Script Date: 17/10/2023 00:17:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MisReservaVuelosUsuario](
	[idMisReservasVuelosUsuarios] [int] IDENTITY(1,1) NOT NULL,
	[idReservaVuelo] [int] NULL,
	[idUsuario] [int] NULL,
 CONSTRAINT [PK_MisReservaVuelosUsuario] PRIMARY KEY CLUSTERED 
(
	[idMisReservasVuelosUsuarios] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ReservaHotel]    Script Date: 17/10/2023 00:17:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReservaHotel](
	[idReservaHotel] [int] IDENTITY(1,1) NOT NULL,
	[idUsuario] [int] NULL,
	[fechaDesde] [datetime] NULL,
	[fechaHasta] [datetime] NULL,
	[pagado] [numeric](18, 0) NULL,
	[idHotel] [int] NULL,
 CONSTRAINT [PK_ReservaHotel] PRIMARY KEY CLUSTERED 
(
	[idReservaHotel] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ReservaVuelo]    Script Date: 17/10/2023 00:17:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReservaVuelo](
	[idReservaVuelo] [int] IDENTITY(1,1) NOT NULL,
	[idVuelo] [int] NULL,
	[idUsuario] [int] NULL,
	[pagado] [decimal](18, 0) NULL,
 CONSTRAINT [PK_ReservaVuelo] PRIMARY KEY CLUSTERED 
(
	[idReservaVuelo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 17/10/2023 00:17:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[idUsuario] [int] IDENTITY(1,1) NOT NULL,
	[dni] [int] NULL,
	[nombre] [nchar](50) NULL,
	[apellido] [nchar](50) NULL,
	[mail] [nchar](50) NULL,
	[password] [nchar](50) NULL,
	[intentosFallidos] [int] NULL,
	[bloqueado] [bit] NULL,
	[credito] [decimal](18, 0) NULL,
	[esAdmin] [bit] NULL,
	[idMisReservasHotelesUsuario] [int] NULL,
	[idMisReservasVuelosUsuarios] [int] NULL,
	[idHotelesVisitadosUsuario] [int] NULL,
	[idVuelosTomadoUsuario] [int] NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[idUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Vuelo]    Script Date: 17/10/2023 00:17:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Vuelo](
	[idVuelo] [int] IDENTITY(1,1) NOT NULL,
	[idOrigen] [int] NULL,
	[idDestino] [int] NULL,
	[capacidad] [int] NULL,
	[vendido] [int] NULL,
	[costo] [decimal](18, 0) NULL,
	[fecha] [datetime] NULL,
	[aerolinea] [nvarchar](50) NULL,
	[avion] [nvarchar](50) NULL,
	[idMisReservasVuelo] [int] NULL,
 CONSTRAINT [PK_Vuelo] PRIMARY KEY CLUSTERED 
(
	[idVuelo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Vuelo_Usuario]    Script Date: 17/10/2023 00:17:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Vuelo_Usuario](
	[idVuelo] [int] NOT NULL,
	[idUsuario] [int] NOT NULL,
	[cantidad] [int] NULL,
 CONSTRAINT [PK_Vuelo_Usuario] PRIMARY KEY CLUSTERED 
(
	[idVuelo] ASC,
	[idUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VuelosTomadosUsuario]    Script Date: 17/10/2023 00:17:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VuelosTomadosUsuario](
	[idVueloTomado] [int] IDENTITY(1,1) NOT NULL,
	[idUsuario] [int] NULL,
	[idVuelo] [int] NULL,
 CONSTRAINT [PK_VuelosTomadosUsuario] PRIMARY KEY CLUSTERED 
(
	[idVueloTomado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Ciudad]  WITH CHECK ADD  CONSTRAINT [FK_Ciudad_CiudadHotel] FOREIGN KEY([idCiudadHotel])
REFERENCES [dbo].[CiudadHotel] ([idCiudadHotel])
GO
ALTER TABLE [dbo].[Ciudad] CHECK CONSTRAINT [FK_Ciudad_CiudadHotel]
GO
ALTER TABLE [dbo].[Ciudad]  WITH CHECK ADD  CONSTRAINT [FK_Ciudad_CiudadVuelos] FOREIGN KEY([idCiudadVuelo])
REFERENCES [dbo].[CiudadVuelos] ([idCiudadVuelos])
GO
ALTER TABLE [dbo].[Ciudad] CHECK CONSTRAINT [FK_Ciudad_CiudadVuelos]
GO
ALTER TABLE [dbo].[Hotel]  WITH CHECK ADD  CONSTRAINT [FK_Hotel_Ciudad] FOREIGN KEY([ubicacion])
REFERENCES [dbo].[Ciudad] ([idCiudad])
GO
ALTER TABLE [dbo].[Hotel] CHECK CONSTRAINT [FK_Hotel_Ciudad]
GO
ALTER TABLE [dbo].[Hotel]  WITH CHECK ADD  CONSTRAINT [FK_Hotel_MisReservas] FOREIGN KEY([idMisReservas])
REFERENCES [dbo].[MisReservasHotel] ([idMisReservas])
GO
ALTER TABLE [dbo].[Hotel] CHECK CONSTRAINT [FK_Hotel_MisReservas]
GO
ALTER TABLE [dbo].[Hotel_Usuario]  WITH CHECK ADD  CONSTRAINT [FK_Hotel_Usuario_Hotel] FOREIGN KEY([idHotel])
REFERENCES [dbo].[Hotel] ([idHotel])
GO
ALTER TABLE [dbo].[Hotel_Usuario] CHECK CONSTRAINT [FK_Hotel_Usuario_Hotel]
GO
ALTER TABLE [dbo].[Hotel_Usuario]  WITH CHECK ADD  CONSTRAINT [FK_Hotel_Usuario_Hotel_Usuario] FOREIGN KEY([idUsuario])
REFERENCES [dbo].[Usuario] ([idUsuario])
GO
ALTER TABLE [dbo].[Hotel_Usuario] CHECK CONSTRAINT [FK_Hotel_Usuario_Hotel_Usuario]
GO
ALTER TABLE [dbo].[ReservaHotel]  WITH CHECK ADD  CONSTRAINT [FK_ReservaHotel_Hotel] FOREIGN KEY([idHotel])
REFERENCES [dbo].[Hotel] ([idHotel])
GO
ALTER TABLE [dbo].[ReservaHotel] CHECK CONSTRAINT [FK_ReservaHotel_Hotel]
GO
ALTER TABLE [dbo].[ReservaHotel]  WITH CHECK ADD  CONSTRAINT [FK_ReservaHotel_Usuario] FOREIGN KEY([idUsuario])
REFERENCES [dbo].[Usuario] ([idUsuario])
GO
ALTER TABLE [dbo].[ReservaHotel] CHECK CONSTRAINT [FK_ReservaHotel_Usuario]
GO
ALTER TABLE [dbo].[ReservaVuelo]  WITH CHECK ADD  CONSTRAINT [FK_ReservaVuelo_Usuario] FOREIGN KEY([idUsuario])
REFERENCES [dbo].[Usuario] ([idUsuario])
GO
ALTER TABLE [dbo].[ReservaVuelo] CHECK CONSTRAINT [FK_ReservaVuelo_Usuario]
GO
ALTER TABLE [dbo].[ReservaVuelo]  WITH CHECK ADD  CONSTRAINT [FK_ReservaVuelo_Vuelo] FOREIGN KEY([idVuelo])
REFERENCES [dbo].[Vuelo] ([idVuelo])
GO
ALTER TABLE [dbo].[ReservaVuelo] CHECK CONSTRAINT [FK_ReservaVuelo_Vuelo]
GO
ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD  CONSTRAINT [FK_Usuario_HotelesVisitadosUsuario] FOREIGN KEY([idHotelesVisitadosUsuario])
REFERENCES [dbo].[HotelesVisitadosUsuario] ([idHotelUsuario])
GO
ALTER TABLE [dbo].[Usuario] CHECK CONSTRAINT [FK_Usuario_HotelesVisitadosUsuario]
GO
ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD  CONSTRAINT [FK_Usuario_MisReservasHotelesUsuario] FOREIGN KEY([idMisReservasHotelesUsuario])
REFERENCES [dbo].[MisReservasHotelesUsuario] ([idReservaHotelUsuario])
GO
ALTER TABLE [dbo].[Usuario] CHECK CONSTRAINT [FK_Usuario_MisReservasHotelesUsuario]
GO
ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD  CONSTRAINT [FK_Usuario_MisReservaVuelosUsuario] FOREIGN KEY([idMisReservasVuelosUsuarios])
REFERENCES [dbo].[MisReservaVuelosUsuario] ([idMisReservasVuelosUsuarios])
GO
ALTER TABLE [dbo].[Usuario] CHECK CONSTRAINT [FK_Usuario_MisReservaVuelosUsuario]
GO
ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD  CONSTRAINT [FK_Usuario_VuelosTomadosUsuario] FOREIGN KEY([idVuelosTomadoUsuario])
REFERENCES [dbo].[VuelosTomadosUsuario] ([idVueloTomado])
GO
ALTER TABLE [dbo].[Usuario] CHECK CONSTRAINT [FK_Usuario_VuelosTomadosUsuario]
GO
ALTER TABLE [dbo].[Vuelo]  WITH CHECK ADD  CONSTRAINT [FK_Vuelo_Ciudad] FOREIGN KEY([idOrigen])
REFERENCES [dbo].[Ciudad] ([idCiudad])
GO
ALTER TABLE [dbo].[Vuelo] CHECK CONSTRAINT [FK_Vuelo_Ciudad]
GO
ALTER TABLE [dbo].[Vuelo]  WITH CHECK ADD  CONSTRAINT [FK_Vuelo_Ciudad1] FOREIGN KEY([idDestino])
REFERENCES [dbo].[Ciudad] ([idCiudad])
GO
ALTER TABLE [dbo].[Vuelo] CHECK CONSTRAINT [FK_Vuelo_Ciudad1]
GO
ALTER TABLE [dbo].[Vuelo]  WITH CHECK ADD  CONSTRAINT [FK_Vuelo_MisReservasVuelo] FOREIGN KEY([idMisReservasVuelo])
REFERENCES [dbo].[MisReservasVuelo] ([idMisReservasVuelo])
GO
ALTER TABLE [dbo].[Vuelo] CHECK CONSTRAINT [FK_Vuelo_MisReservasVuelo]
GO
ALTER TABLE [dbo].[Vuelo_Usuario]  WITH CHECK ADD  CONSTRAINT [FK_Vuelo_Usuario_Usuario] FOREIGN KEY([idUsuario])
REFERENCES [dbo].[Usuario] ([idUsuario])
GO
ALTER TABLE [dbo].[Vuelo_Usuario] CHECK CONSTRAINT [FK_Vuelo_Usuario_Usuario]
GO
ALTER TABLE [dbo].[Vuelo_Usuario]  WITH CHECK ADD  CONSTRAINT [FK_Vuelo_Usuario_Vuelo] FOREIGN KEY([idVuelo])
REFERENCES [dbo].[Vuelo] ([idVuelo])
GO
ALTER TABLE [dbo].[Vuelo_Usuario] CHECK CONSTRAINT [FK_Vuelo_Usuario_Vuelo]
GO
