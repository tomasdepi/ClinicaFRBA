USE [GD2C2016]
GO
/****** Object:  StoredProcedure [dbo].[MigracionDatosBono]    Script Date: 21/10/2016 19:17:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[MigracionDatosBono]
AS
BEGIN
	INSERT INTO GD2C2016.dbo.Bono(bono_fecha_compra,bono_fecha_impresion,bono_numero_consulta_medica)
	SELECT Compra_Bono_Fecha,Bono_Consulta_Fecha_Impresion,Bono_Consulta_Numero 
	FROM GD2C2016.gd_esquema.Maestra;
END
GO
/****** Object:  StoredProcedure [dbo].[MigracionDatosConsulta]    Script Date: 21/10/2016 19:17:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[MigracionDatosConsulta]
AS
BEGIN
	INSERT INTO GD2C2016.dbo.Consulta(consulta_sintomas,consulta_enfermedad)
	SELECT Consulta_Sintomas,Consulta_Enfermedades FROM GD2C2016.gd_esquema.Maestra;
END
GO
/****** Object:  StoredProcedure [dbo].[MigracionDatosEspecialidad]    Script Date: 21/10/2016 19:17:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[MigracionDatosEspecialidad]
AS
BEGIN
	INSERT INTO GD2C2016.dbo.Especialidad(especialidad_codigo,especialidad_descripcion,
	especialidad_codigo_tipo,especialidad_descripcion_tipo)
	SELECT Especialidad_Codigo,Especialidad_Descripcion,Tipo_Especialidad_Codigo,
	Tipo_Especialidad_Descripcion
	 FROM GD2C2016.gd_esquema.Maestra;
END
GO
/****** Object:  StoredProcedure [dbo].[MigracionDatosPlan]    Script Date: 21/10/2016 19:17:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[MigracionDatosPlan]
AS
BEGIN
	INSERT INTO GD2C2016.dbo.PlanMedico(plan_codigo,plan_descripcion,plan_precio_bono_consulta,plan_precio_bono_farmacia)
	SELECT Plan_Med_Codigo,Plan_Med_Descripcion,Plan_Med_Precio_Bono_Consulta,Plan_Med_Precio_Bono_Farmacia 
	FROM GD2C2016.gd_esquema.Maestra;
END
GO
/****** Object:  StoredProcedure [dbo].[MigracionDatosProfesional]    Script Date: 21/10/2016 19:17:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[MigracionDatosProfesional]
AS
BEGIN
	INSERT INTO GD2C2016.dbo.Usuario(usuario_nombre,usuario_apellido,usuario_numero_documento,usuario_direccion,
				usuario_telefono,usuario_mail,usuario_fecha_nacimiento) SELECT Medico_Nombre,Medico_Apellido
				,Medico_Dni,Medico_Direccion,Medico_Telefono,Medico_Mail,Medico_Fecha_Nac FROM GD2C2016.gd_esquema.Maestra;
	UPDATE GD2C2016.dbo.Usuario set usuario_rol = 'PROFESIONAL' where usuario_rol IS NULL;
END
GO
/****** Object:  StoredProcedure [dbo].[MigracionDatosTurno]    Script Date: 21/10/2016 19:17:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[MigracionDatosTurno]
AS
BEGIN
	INSERT INTO GD2C2016.dbo.Turno(turno_numero_turno,turno_fecha_turno) 
	SELECT Turno_Numero,Turno_Fecha FROM GD2C2016.gd_esquema.Maestra;
END
GO
/****** Object:  StoredProcedure [dbo].[MigracionDatosUser]    Script Date: 21/10/2016 19:17:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,Esteban Martinez>
-- Create date: <Create Date,18/10/2016>
-- Description:	<Description,Migracion Datos Usuario>
-- =============================================
CREATE PROCEDURE [dbo].[MigracionDatosUser] 

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	INSERT INTO GD2C2016.dbo.Usuario(usuario_nombre,usuario_apellido,usuario_numero_documento,usuario_direccion,
				usuario_telefono,usuario_mail,usuario_fecha_nacimiento) SELECT Paciente_Nombre,Paciente_Apellido,
				Paciente_Dni,Paciente_Direccion,Paciente_Telefono,Paciente_Mail,Paciente_Fecha_Nac FROM GD2C2016.gd_esquema.Maestra;
	UPDATE GD2C2016.dbo.Usuario set usuario_rol = 'AFILIADO' where usuario_rol IS NULL;
END

GO
/****** Object:  Table [dbo].[Afiliado]    Script Date: 21/10/2016 19:17:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Afiliado](
	[afiliado_id_afiliado] [int] IDENTITY(1,1) NOT NULL,
	[afiliado_estado_actual] [int] NOT NULL,
	[afiliado_plan] [varchar](50) NOT NULL,
	[afiliado_numero_afiliado] [int] NOT NULL,
	[afiliado_cantidad_familiares] [int] NOT NULL,
	[afiliado_numero_consulta] [int] NOT NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Agenda]    Script Date: 21/10/2016 19:17:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Agenda](
	[agenda_id_agenda] [int] IDENTITY(1,1) NOT NULL,
	[agenda_especialidad] [time](7) NOT NULL,
	[agenda_hora_inicio] [time](7) NOT NULL,
	[agenda_hora_fin] [smalldatetime] NOT NULL,
	[agenda_id_profesional] [int] NOT NULL,
	[agenda_fecha_inicio] [date] NOT NULL,
	[agenda_fecha_fin] [date] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Asistencia]    Script Date: 21/10/2016 19:17:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Asistencia](
	[asistencia_numero_turno] [int] NOT NULL,
	[asistencia_fecha_y_hora] [smalldatetime] NOT NULL,
	[asistencia_bono] [varchar](50) NOT NULL,
	[asistencia_atendido] [int] NOT NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Bono]    Script Date: 21/10/2016 19:17:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bono](
	[bono_id_bono] [int] IDENTITY(1,1) NOT NULL,
	[bono_codigo_plan] [numeric](18, 0) NULL,
	[bono_fecha_compra] [datetime] NULL,
	[bono_fecha_impresion] [datetime] NULL,
	[bono_id_afiliado_compra] [numeric](18, 0) NULL,
	[bono_id_afiliado_utilizo] [numeric](18, 0) NULL,
	[bono_numero_consulta_medica] [int] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Consulta]    Script Date: 21/10/2016 19:17:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Consulta](
	[consulta_numero_turno] [numeric](18, 0) NULL,
	[consulta_fecha_y_hora] [datetime] NULL,
	[consulta_sintomas] [varchar](255) NULL,
	[consulta_enfermedad] [varchar](255) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Especialidad]    Script Date: 21/10/2016 19:17:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Especialidad](
	[especialidad_codigo] [numeric](18, 0) NULL,
	[especialidad_descripcion] [varchar](255) NULL,
	[especialidad_codigo_tipo] [numeric](18, 0) NULL,
	[especialidad_descripcion_tipo] [varchar](255) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Funcionalidad]    Script Date: 21/10/2016 19:17:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Funcionalidad](
	[funcionalidad_id_funcionalidad] [int] IDENTITY(1,1) NOT NULL,
	[funcionalidad_funcionalidades] [varchar](50) NOT NULL,
	[funcionalidad_descripcion] [varchar](50) NOT NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[FuncionalidadxRol]    Script Date: 21/10/2016 19:17:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FuncionalidadxRol](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[id_funcionalidad] [int] NOT NULL,
	[nombre_rol] [nchar](50) NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PlanMedico]    Script Date: 21/10/2016 19:17:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PlanMedico](
	[plan_codigo] [numeric](18, 0) NULL,
	[plan_descripcion] [varchar](255) NULL,
	[plan_precio_bono_consulta] [numeric](18, 0) NULL,
	[plan_precio_bono_farmacia] [numeric](18, 0) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Profesional]    Script Date: 21/10/2016 19:17:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Profesional](
	[profesional_id_profesional] [int] IDENTITY(1,1) NOT NULL,
	[profesional_especialidades] [varchar](50) NOT NULL,
	[profesional_matricula] [int] NOT NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ProfesionalxAgenda]    Script Date: 21/10/2016 19:17:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProfesionalxAgenda](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[id_profesional] [int] NOT NULL,
	[id_agenda] [int] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ProfesionalxEspecialidad]    Script Date: 21/10/2016 19:17:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProfesionalxEspecialidad](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[id_profesional] [int] NOT NULL,
	[especialidad_codigo] [int] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Rol]    Script Date: 21/10/2016 19:17:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rol](
	[rol_nombre] [nvarchar](50) NOT NULL,
	[rol_funcionalidades] [nvarchar](50) NOT NULL,
	[rol_habilitado] [int] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RolxUsuario]    Script Date: 21/10/2016 19:17:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RolxUsuario](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre_rol] [varchar](50) NOT NULL,
	[username] [varchar](50) NOT NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Turno]    Script Date: 21/10/2016 19:17:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Turno](
	[turno_numero_turno] [numeric](18, 0) NULL,
	[turno_fecha_turno] [datetime] NULL,
	[turno_id_paciente] [numeric](18, 0) NULL,
	[turno_id_doctor] [numeric](18, 0) NULL,
	[turno_estado_turno] [numeric](18, 0) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TurnoCancelado]    Script Date: 21/10/2016 19:17:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TurnoCancelado](
	[cancelado_numero_turno] [int] NOT NULL,
	[cancelado_motivo] [varchar](200) NOT NULL,
	[cancelado_tipo] [varchar](50) NOT NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 21/10/2016 19:17:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Usuario](
	[usuario_user] [varchar](255) NULL,
	[usuario_pass] [varchar](255) NULL,
	[usuario_rol] [varchar](255) NULL,
	[usuario_nombre] [varchar](255) NULL,
	[usuario_tipo_documento] [varchar](255) NULL,
	[usuario_numero_documento] [numeric](18, 0) NULL,
	[usuario_telefono] [numeric](18, 0) NULL,
	[usuario_direccion] [varchar](255) NULL,
	[usuario_mail] [varchar](255) NULL,
	[usuario_fecha_nacimiento] [datetime] NULL,
	[usuario_sexo] [varchar](255) NULL,
	[usuario_apellido] [varchar](255) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO


