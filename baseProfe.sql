USE [sistema]
GO
/****** Object:  Table [dbo].[Ciudad]    Script Date: 26/10/2023 18:32:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ciudad](
	[idCiudad] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nchar](50) NULL,
 CONSTRAINT [PK_Ciudad] PRIMARY KEY CLUSTERED 
(
	[idCiudad] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Hotel]    Script Date: 26/10/2023 18:32:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Hotel](
	[idHotel] [int] IDENTITY(1,1) NOT NULL,
	[ubicacion] [int] NULL,
	[capacidad] [int] NULL,
	[costo] [float] NULL,
	[nombre] [nchar](50) NULL,
 CONSTRAINT [PK_Hotel] PRIMARY KEY CLUSTERED 
(
	[idHotel] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Hotel_Usuario]    Script Date: 26/10/2023 18:32:32 ******/
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
/****** Object:  Table [dbo].[ReservaHotel]    Script Date: 26/10/2023 18:32:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReservaHotel](
	[idReservaHotel] [int] IDENTITY(1,1) NOT NULL,
	[idUsuario] [int] NULL,
	[fechaDesde] [datetime] NULL,
	[fechaHasta] [datetime] NULL,
	[pagado] [float] NULL,
	[idHotel] [int] NULL,
 CONSTRAINT [PK_ReservaHotel] PRIMARY KEY CLUSTERED 
(
	[idReservaHotel] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ReservaVuelo]    Script Date: 26/10/2023 18:32:32 ******/
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
/****** Object:  Table [dbo].[Usuario]    Script Date: 26/10/2023 18:32:32 ******/
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
	[credito] [float] NULL,
	[esAdmin] [bit] NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[idUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Vuelo]    Script Date: 26/10/2023 18:32:32 ******/
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
 CONSTRAINT [PK_Vuelo] PRIMARY KEY CLUSTERED 
(
	[idVuelo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Vuelo_Usuario]    Script Date: 26/10/2023 18:32:32 ******/
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
ALTER TABLE [dbo].[Hotel]  WITH CHECK ADD  CONSTRAINT [FK_Hotel_Ciudad] FOREIGN KEY([ubicacion])
REFERENCES [dbo].[Ciudad] ([idCiudad])
GO
ALTER TABLE [dbo].[Hotel] CHECK CONSTRAINT [FK_Hotel_Ciudad]
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
ALTER TABLE [dbo].[Vuelo]  WITH CHECK ADD  CONSTRAINT [FK_Vuelo_Ciudad] FOREIGN KEY([idOrigen])
REFERENCES [dbo].[Ciudad] ([idCiudad])
GO
ALTER TABLE [dbo].[Vuelo] CHECK CONSTRAINT [FK_Vuelo_Ciudad]
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
