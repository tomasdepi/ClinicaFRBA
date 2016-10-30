USE [GD2C2016]
GO
/****** Object:  Table [dbo].[Afiliado]    Script Date: 22/10/2016 20:32:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Afiliado](
	[intIdUsuario] [int] NOT NULL,
	[bitEstadoActual] [bit] NULL,
	[intCodigoPlan] [int] NULL,
	[intNumeroAfiliado] [int] NULL,
	[intCantidadFamiliares] [int] NULL,
	[intNumeroConsultaMedica] [int] NULL,
 CONSTRAINT [PK_Afiliado] PRIMARY KEY CLUSTERED 
(
	[intIdUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Agenda]    Script Date: 22/10/2016 20:32:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Agenda](
	[intIdAgenda] [int] IDENTITY(1,1) NOT NULL,
	[timeHoraInicio] [time](7) NULL,
	[timeHoraFin] [time](7) NULL,
	[varDia] [varchar](50) NULL,
	[datFechaInicio] [datetime] NULL,
	[datFechaFin] [datetime] NULL,
 CONSTRAINT [PK_Agenda] PRIMARY KEY CLUSTERED 
(
	[intIdAgenda] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Asistencia]    Script Date: 22/10/2016 20:32:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Asistencia](
	[intIdTurno] [int] NOT NULL,
	[datFechaYHora] [datetime] NULL,
	[varBono] [varchar](50) NULL,
	[bitAtendido] [bit] NULL,
	[intIdAsistencia] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_Asistencia] PRIMARY KEY CLUSTERED 
(
	[intIdTurno] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Bono]    Script Date: 22/10/2016 20:32:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bono](
	[intIdBono] [int] IDENTITY(1,1) NOT NULL,
	[intCodigoPlan] [int] NULL,
	[datFechaCompra] [datetime] NULL,
	[datFechaImpresion] [datetime] NULL,
	[intIdAfiliadoCompro] [int] NULL,
	[intIdAfiliadoUtilizo] [int] NULL,
	[intNumeroConsultaMedica] [int] NULL,
 CONSTRAINT [PK_Bono] PRIMARY KEY CLUSTERED 
(
	[intIdBono] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Consulta]    Script Date: 22/10/2016 20:32:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Consulta](
	[intIdTurno] [int] NOT NULL,
	[datFechaYHora] [datetime] NULL,
	[varSintomas] [varchar](150) NULL,
	[varEnfermedad] [varchar](150) NULL,
 CONSTRAINT [PK_Consulta] PRIMARY KEY CLUSTERED 
(
	[intIdTurno] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Especialidad]    Script Date: 22/10/2016 20:32:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Especialidad](
	[intEspecialidadCodigo] [int] NOT NULL,
	[varDescripcion] [varchar](50) NULL,
	[intCodigoTipoEspecialidad] [int] NULL,
	[varDescripcionTipoEspecialidad] [nchar](10) NULL,
 CONSTRAINT [PK_Especialidad] PRIMARY KEY CLUSTERED 
(
	[intEspecialidadCodigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Funcionalidad]    Script Date: 22/10/2016 20:32:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Funcionalidad](
	[intIdFuncionalidad] [int] IDENTITY(1,1) NOT NULL,
	[varFuncionalidad] [varchar](50) NULL,
	[varDescripcion] [varchar](50) NULL,
 CONSTRAINT [PK_Funcionalidad] PRIMARY KEY CLUSTERED 
(
	[intIdFuncionalidad] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[FuncionalidadXRol]    Script Date: 22/10/2016 20:32:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[FuncionalidadXRol](
	[intIdFuncionalidadXRol] [int] NOT NULL,
	[intIdFuncionalidad] [int] NULL,
	[varNombreRol] [varchar](50) NULL,
 CONSTRAINT [PK_FuncionalidadXRol] PRIMARY KEY CLUSTERED 
(
	[intIdFuncionalidadXRol] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Plan]    Script Date: 22/10/2016 20:32:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Plan](
	[intCodigoPlan] [int] NOT NULL,
	[varDescripcion] [varchar](150) NULL,
	[monPrecioBonoConsulta] [money] NULL,
	[monPrecioBonoFarmacia] [money] NULL,
 CONSTRAINT [PK_Plan] PRIMARY KEY CLUSTERED 
(
	[intCodigoPlan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Profesional]    Script Date: 22/10/2016 20:32:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Profesional](
	[intIdUsuario] [int] IDENTITY(1,1) NOT NULL,
	[intMatricula] [int] NULL,
 CONSTRAINT [PK_Profesional] PRIMARY KEY CLUSTERED 
(
	[intIdUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ProfesionalXAgenda]    Script Date: 22/10/2016 20:32:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProfesionalXAgenda](
	[intIdProfesionalXAgenda] [int] IDENTITY(1,1) NOT NULL,
	[intIdUsuario] [int] NULL,
	[intIdAgenda] [int] NULL,
 CONSTRAINT [PK_ProfesionalXAgenda] PRIMARY KEY CLUSTERED 
(
	[intIdProfesionalXAgenda] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ProfesionalXEspecialidad]    Script Date: 22/10/2016 20:32:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProfesionalXEspecialidad](
	[intIdProfesionalXEspecialidad] [int] IDENTITY(1,1) NOT NULL,
	[intIdUsuario] [int] NULL,
	[intEspecialidadCodigo] [int] NULL,
 CONSTRAINT [PK_ProfesionalXEspecialidad] PRIMARY KEY CLUSTERED 
(
	[intIdProfesionalXEspecialidad] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Rol]    Script Date: 22/10/2016 20:32:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Rol](
	[varNombreRol] [varchar](50) NOT NULL,
	[bitHabilitado] [bit] NULL,
 CONSTRAINT [PK_Rol] PRIMARY KEY CLUSTERED 
(
	[varNombreRol] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Turno]    Script Date: 22/10/2016 20:32:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Turno](
	[intIdTurno] [int] NOT NULL,
	[datFechaTurno] [nchar](10) NULL,
	[intIdPaciente] [int] NULL,
	[intIdDoctor] [int] NULL,
	[bitEstado] [bit] NULL,
 CONSTRAINT [PK_Turno] PRIMARY KEY CLUSTERED 
(
	[intIdTurno] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TurnoCancelado]    Script Date: 22/10/2016 20:32:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TurnoCancelado](
	[intIdTurno] [int] NOT NULL,
	[varMotivo] [varchar](50) NULL,
	[varTipo] [varchar](50) NULL,
 CONSTRAINT [PK_TurnoCancelado] PRIMARY KEY CLUSTERED 
(
	[intIdTurno] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 22/10/2016 20:32:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Usuario](
	[intIdUsuario] [int] IDENTITY(1,1) NOT NULL,
	[nvarPassword] [nvarchar](4000) NULL,
	[varNombreRol] [varchar](50) NULL,
	[varNombre] [varchar](50) NULL,
	[varApellido] [varchar](50) NULL,
	[varTipoDocumento] [varchar](50) NULL,
	[intNroDocumento] [int] NULL,
	[intTelefono] [int] NULL,
	[varDireccion] [varchar](250) NULL,
	[varMail] [varchar](150) NULL,
	[datFechaNacimiento] [datetime] NULL,
	[chrSexo] [char](1) NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[intIdUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UsuarioXRol]    Script Date: 22/10/2016 20:32:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[UsuarioXRol](
	[intIdUsuarioXRol] [int] IDENTITY(1,1) NOT NULL,
	[varNombreRol] [varchar](50) NULL,
	[intIdUsuario] [int] NULL,
 CONSTRAINT [PK_UsuarioXRol] PRIMARY KEY CLUSTERED 
(
	[intIdUsuarioXRol] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[Afiliado]  WITH CHECK ADD  CONSTRAINT [FK_Afiliado_Plan] FOREIGN KEY([intCodigoPlan])
REFERENCES [dbo].[Plan] ([intCodigoPlan])
GO
ALTER TABLE [dbo].[Afiliado] CHECK CONSTRAINT [FK_Afiliado_Plan]
GO
ALTER TABLE [dbo].[Afiliado]  WITH CHECK ADD  CONSTRAINT [FK_Afiliado_Usuario] FOREIGN KEY([intIdUsuario])
REFERENCES [dbo].[Usuario] ([intIdUsuario])
GO
ALTER TABLE [dbo].[Afiliado] CHECK CONSTRAINT [FK_Afiliado_Usuario]
GO
ALTER TABLE [dbo].[Asistencia]  WITH CHECK ADD  CONSTRAINT [FK_Asistencia_Turno] FOREIGN KEY([intIdTurno])
REFERENCES [dbo].[Turno] ([intIdTurno])
GO
ALTER TABLE [dbo].[Asistencia] CHECK CONSTRAINT [FK_Asistencia_Turno]
GO
ALTER TABLE [dbo].[Bono]  WITH CHECK ADD  CONSTRAINT [FK_Bono_AfiliadoCompro] FOREIGN KEY([intIdAfiliadoCompro])
REFERENCES [dbo].[Afiliado] ([intIdUsuario])
GO
ALTER TABLE [dbo].[Bono] CHECK CONSTRAINT [FK_Bono_AfiliadoCompro]
GO
ALTER TABLE [dbo].[Bono]  WITH CHECK ADD  CONSTRAINT [FK_Bono_AfiliadoUtilizo] FOREIGN KEY([intIdAfiliadoUtilizo])
REFERENCES [dbo].[Afiliado] ([intIdUsuario])
GO
ALTER TABLE [dbo].[Bono] CHECK CONSTRAINT [FK_Bono_AfiliadoUtilizo]
GO
ALTER TABLE [dbo].[Bono]  WITH CHECK ADD  CONSTRAINT [FK_Bono_Plan] FOREIGN KEY([intCodigoPlan])
REFERENCES [dbo].[Plan] ([intCodigoPlan])
GO
ALTER TABLE [dbo].[Bono] CHECK CONSTRAINT [FK_Bono_Plan]
GO
ALTER TABLE [dbo].[Consulta]  WITH CHECK ADD  CONSTRAINT [FK_Consulta_Asistencia] FOREIGN KEY([intIdTurno])
REFERENCES [dbo].[Asistencia] ([intIdTurno])
GO
ALTER TABLE [dbo].[Consulta] CHECK CONSTRAINT [FK_Consulta_Asistencia]
GO
ALTER TABLE [dbo].[FuncionalidadXRol]  WITH CHECK ADD  CONSTRAINT [FK_FuncionalidadXRol_Funcionalidad] FOREIGN KEY([intIdFuncionalidad])
REFERENCES [dbo].[Funcionalidad] ([intIdFuncionalidad])
GO
ALTER TABLE [dbo].[FuncionalidadXRol] CHECK CONSTRAINT [FK_FuncionalidadXRol_Funcionalidad]
GO
ALTER TABLE [dbo].[FuncionalidadXRol]  WITH CHECK ADD  CONSTRAINT [FK_FuncionalidadXRol_Rol] FOREIGN KEY([varNombreRol])
REFERENCES [dbo].[Rol] ([varNombreRol])
GO
ALTER TABLE [dbo].[FuncionalidadXRol] CHECK CONSTRAINT [FK_FuncionalidadXRol_Rol]
GO
ALTER TABLE [dbo].[Profesional]  WITH CHECK ADD  CONSTRAINT [FK_Profesional_Usuario] FOREIGN KEY([intIdUsuario])
REFERENCES [dbo].[Usuario] ([intIdUsuario])
GO
ALTER TABLE [dbo].[Profesional] CHECK CONSTRAINT [FK_Profesional_Usuario]
GO
ALTER TABLE [dbo].[ProfesionalXAgenda]  WITH CHECK ADD  CONSTRAINT [FK_ProfesionalXAgenda_Agenda] FOREIGN KEY([intIdAgenda])
REFERENCES [dbo].[Agenda] ([intIdAgenda])
GO
ALTER TABLE [dbo].[ProfesionalXAgenda] CHECK CONSTRAINT [FK_ProfesionalXAgenda_Agenda]
GO
ALTER TABLE [dbo].[ProfesionalXAgenda]  WITH CHECK ADD  CONSTRAINT [FK_ProfesionalXAgenda_Profesional] FOREIGN KEY([intIdUsuario])
REFERENCES [dbo].[Profesional] ([intIdUsuario])
GO
ALTER TABLE [dbo].[ProfesionalXAgenda] CHECK CONSTRAINT [FK_ProfesionalXAgenda_Profesional]
GO
ALTER TABLE [dbo].[ProfesionalXEspecialidad]  WITH CHECK ADD  CONSTRAINT [FK_ProfesionalXEspecialidad_Especialidad] FOREIGN KEY([intEspecialidadCodigo])
REFERENCES [dbo].[Especialidad] ([intEspecialidadCodigo])
GO
ALTER TABLE [dbo].[ProfesionalXEspecialidad] CHECK CONSTRAINT [FK_ProfesionalXEspecialidad_Especialidad]
GO
ALTER TABLE [dbo].[ProfesionalXEspecialidad]  WITH CHECK ADD  CONSTRAINT [FK_ProfesionalXEspecialidad_Profesional] FOREIGN KEY([intIdUsuario])
REFERENCES [dbo].[Profesional] ([intIdUsuario])
GO
ALTER TABLE [dbo].[ProfesionalXEspecialidad] CHECK CONSTRAINT [FK_ProfesionalXEspecialidad_Profesional]
GO
ALTER TABLE [dbo].[Turno]  WITH CHECK ADD  CONSTRAINT [FK_Turno_Afiliado] FOREIGN KEY([intIdPaciente])
REFERENCES [dbo].[Afiliado] ([intIdUsuario])
GO
ALTER TABLE [dbo].[Turno] CHECK CONSTRAINT [FK_Turno_Afiliado]
GO
ALTER TABLE [dbo].[Turno]  WITH CHECK ADD  CONSTRAINT [FK_Turno_Profesional] FOREIGN KEY([intIdDoctor])
REFERENCES [dbo].[Profesional] ([intIdUsuario])
GO
ALTER TABLE [dbo].[Turno] CHECK CONSTRAINT [FK_Turno_Profesional]
GO
ALTER TABLE [dbo].[TurnoCancelado]  WITH CHECK ADD  CONSTRAINT [FK_TurnoCancelado_Turno] FOREIGN KEY([intIdTurno])
REFERENCES [dbo].[Turno] ([intIdTurno])
GO
ALTER TABLE [dbo].[TurnoCancelado] CHECK CONSTRAINT [FK_TurnoCancelado_Turno]
GO
ALTER TABLE [dbo].[UsuarioXRol]  WITH CHECK ADD  CONSTRAINT [FK_UsuarioXRol_Rol] FOREIGN KEY([varNombreRol])
REFERENCES [dbo].[Rol] ([varNombreRol])
GO
ALTER TABLE [dbo].[UsuarioXRol] CHECK CONSTRAINT [FK_UsuarioXRol_Rol]
GO
ALTER TABLE [dbo].[UsuarioXRol]  WITH CHECK ADD  CONSTRAINT [FK_UsuarioXRol_Usuario] FOREIGN KEY([intIdUsuario])
REFERENCES [dbo].[Usuario] ([intIdUsuario])
GO
ALTER TABLE [dbo].[UsuarioXRol] CHECK CONSTRAINT [FK_UsuarioXRol_Usuario]
GO
