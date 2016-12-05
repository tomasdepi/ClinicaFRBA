USE [GD2C2016]
GO
/****** Object:  StoredProcedure [dbo].[actualizarIntentoLogin]    Script Date: 04/12/2016 23:53:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[actualizarIntentoLogin](@username int)
as
begin
	UPDATE GD2C2016.dbo.Usuario SET intIntentosLogin = 0 WHERE intIdUsuario = @username;
end

GO
/****** Object:  StoredProcedure [dbo].[comprarBono]    Script Date: 04/12/2016 23:53:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

 
create procedure [dbo].[comprarBono] @Usuario int, @cantidad int, @codigoPlan int
as
begin transaction
declare @aux int
set @aux = 0
  
	while(@aux < @cantidad)
	begin
	set @aux = @aux + 1
	insert into dbo.Bono (intCodigoPlan, datFechaCompra, intIdAfiliadoCompro) values (@codigoPlan, GETDATE(), @Usuario)
	end
 commit


GO
/****** Object:  StoredProcedure [dbo].[CreacionFuncionalidades]    Script Date: 04/12/2016 23:53:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CreacionFuncionalidades]
AS
BEGIN
	insert into dbo.Rol(varNombreRol, bitHabilitado) values
	('Afiliado', 1),
	('Profesional', 1),
	('Administrativo', 1)

	Insert into dbo.Funcionalidad(varFuncionalidad, varDescripcion) values 
	('ABM Rol', 'AMB Rol'),
	('Registro Usuario', 'Registro Usuario'),
	('ABM Afiliado', 'ABM Afiliado'),
	('ABM Profesional', 'AMB Profesional'),
	('ABM Esp Medicas', 'ABM Esp Medicas'),
	('ABM Planes', 'ABM Planes'),
	('Registrar Agenda', 'Registrar Agenda'),
	('Comprar Bonos', 'Comprar Bonos'),
	('Pedir Turnos', 'Pedir Turnos'),
	('Registro Llegada Atencion Medica', 'Registro Llegada Atencion Medica'),
	('Registro Resultado Atencion Medica', 'Registro Resultado Atencion Medica'),
	('Cancelar Atencion Medica', 'Cancelar Atencion Medica'),
	('Listado Estadistico','Listado Estadistico')

	Insert Into dbo.FuncionalidadXRol(intIdFuncionalidad,varNombreRol) values
	(1,'Administrativo'),
	(2,'Administrativo'),
	(3,'Administrativo'),
	(4,'Administrativo'),
	(5,'Administrativo'),
	(6,'Administrativo'),
	(7,'Administrativo'),
	(7,'Profesional'),
	(8,'Afiliado'),
	(9,'Administrativo'),
	(9,'Afiliado'),
	(10,'Administrativo'),
	(11,'Profesional'),
	(12,'Profesional'),
	(12,'Afiliado'),
	(13,'Administrativo')


END



GO
/****** Object:  StoredProcedure [dbo].[eliminarRol]    Script Date: 04/12/2016 23:53:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  CREATE PROCEDURE [dbo].[eliminarRol] @rol varchar(20)
  AS
  BEGIN
		delete from dbo.FuncionalidadXRol where varNombreRol = @rol;
 END



GO
/****** Object:  StoredProcedure [dbo].[MigracionAfiliado]    Script Date: 04/12/2016 23:53:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[MigracionAfiliado]
AS
BEGIN
	Insert into dbo.Usuario(intIdUsuario,nvarPassword, varNombre, varApellido, varTipoDocumento, intNroDocumento, intTelefono, varDireccion, varMail, datFechaNacimiento)
	select distinct Paciente_Dni, HASHBYTES('SHA2_256', 'afiliado'), Paciente_Nombre, Paciente_Apellido, 'DNI', Paciente_Dni, Paciente_Telefono, Paciente_Direccion, Paciente_Mail, Paciente_Fecha_Nac
	from gd_esquema.Maestra

	Insert into dbo.Afiliado(intIdUsuario, intCodigoPlan, bitEstadoActual, intNumeroConsultaMedica)
	select distinct Paciente_Dni, Plan_Med_Codigo, 1, 0
	from gd_esquema.Maestra

	Insert into dbo.UsuarioXRol(intIdUsuario)
	select distinct Paciente_Dni  from gd_esquema.Maestra

	UPDATE dbo.UsuarioXRol SET varNombreRol = 'Afiliado' where varNombreRol is null;
END




GO
/****** Object:  StoredProcedure [dbo].[MigracionAgenda]    Script Date: 04/12/2016 23:53:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[MigracionAgenda]
AS
BEGIN
DECLARE @profesional int;
DECLARE profesionales CURSOR FOR SELECT DISTINCT intIdUsuario 
FROM Profesional WHERE intIdUsuario IS NOT NULL;
OPEN profesionales;

FETCH profesionales INTO @profesional;

WHILE @@FETCH_STATUS = 0
BEGIN 
	INSERT INTO Agenda (intIdProfesional,charDia,dateFechaInicio,dateFechaFin,timeHoraInicio,timeHoraFin)
	VALUES(@profesional,'lunes','2010-01-01','2018-01-01','7:00','18:00');
	INSERT INTO Agenda (intIdProfesional,charDia,dateFechaInicio,dateFechaFin,timeHoraInicio,timeHoraFin)
	VALUES(@profesional,'martes','2010-01-01','2018-01-01','7:00','18:00');
	INSERT INTO Agenda (intIdProfesional,charDia,dateFechaInicio,dateFechaFin,timeHoraInicio,timeHoraFin)
	VALUES(@profesional,'miercoles','2010-01-01','2018-01-01','7:00','18:00');
	INSERT INTO Agenda (intIdProfesional,charDia,dateFechaInicio,dateFechaFin,timeHoraInicio,timeHoraFin)
	VALUES(@profesional,'jueves','2010-01-01','2018-01-01','7:00','18:00');
	FETCH profesionales INTO @profesional
END
CLOSE profesionales;
DEALLOCATE profesionales;
END


GO
/****** Object:  StoredProcedure [dbo].[MigracionBono]    Script Date: 04/12/2016 23:53:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[MigracionBono]
AS
BEGIN
	INSERT INTO dbo.Bono(intCodigoPlan, datFechaCompra,datFechaImpresion,intNumeroConsultaMedica, intIdAfiliadoCompro, intIdAfiliadoUtilizo)
	SELECT Plan_Med_Codigo, Compra_Bono_Fecha,Bono_Consulta_Fecha_Impresion,Bono_Consulta_Numero, Paciente_Dni, Paciente_Dni
	FROM GD2C2016.gd_esquema.Maestra
	where Compra_Bono_Fecha is not null
END

GO
/****** Object:  StoredProcedure [dbo].[MigracionEspecialidad]    Script Date: 04/12/2016 23:53:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[MigracionEspecialidad]
AS
BEGIN
	insert into dbo.Especialidad(intEspecialidadCodigo, varDescripcion, intCodigoTipoEspecialidad, varDescripcionTipoEspecialidad)
	select distinct Especialidad_Codigo, Especialidad_Descripcion, Tipo_Especialidad_Codigo, Tipo_Especialidad_Descripcion
	from gd_esquema.Maestra where Especialidad_Codigo is not null
END



GO
/****** Object:  StoredProcedure [dbo].[MigracionPlanMedico]    Script Date: 04/12/2016 23:53:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[MigracionPlanMedico]
AS
BEGIN
	Insert into dbo.[Plan](intCodigoPlan, varDescripcion, monPrecioBonoConsulta, monPrecioBonoFarmacia)
	select distinct Plan_Med_Codigo, Plan_Med_Descripcion, Plan_Med_Precio_Bono_Consulta, Plan_Med_Precio_Bono_Farmacia
	from gd_esquema.Maestra
END




GO
/****** Object:  StoredProcedure [dbo].[MigracionProfesional]    Script Date: 04/12/2016 23:53:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[MigracionProfesional]
AS
BEGIN
	Insert into dbo.Usuario(intIdUsuario,nvarPassword, varNombre, varApellido, varTipoDocumento, intNroDocumento, intTelefono, varDireccion, varMail, datFechaNacimiento)
	select distinct Medico_Dni, HASHBYTES('SHA2_256', 'Profesional'), Medico_Nombre, Medico_Apellido, 'DNI', Medico_Dni, Medico_Telefono, Medico_Direccion, Medico_Mail, Medico_Fecha_Nac
	from gd_esquema.Maestra where Medico_Dni IS NOT NULL
	
	insert into dbo.Profesional(intIdUsuario)
	select distinct Medico_Dni
	from gd_esquema.Maestra where Medico_Dni is not null

	Insert into dbo.UsuarioXRol(intIdUsuario)
	select distinct Medico_Dni from gd_esquema.Maestra

	UPDATE dbo.UsuarioXRol SET varNombreRol = 'Profesional' where varNombreRol is null;

	Insert into dbo.ProfesionalXEspecialidad(intIdUsuario, intEspecialidadCodigo)
	select distinct Medico_Dni, Especialidad_Codigo
	from gd_esquema.Maestra where Medico_Dni is not null
END



GO
/****** Object:  StoredProcedure [dbo].[MigracionTurno]    Script Date: 04/12/2016 23:53:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[MigracionTurno]
AS
BEGIN
	Insert into dbo.Turno(intIdTurno, datFechaTurno, intIdPaciente,intIdDoctor, bitEstado)
	select distinct Turno_Numero, Turno_Fecha, Paciente_Dni, Medico_Dni, 1
	from gd_esquema.Maestra where Turno_Numero is not null

	insert into dbo.Asistencia(intIdTurno, datFechaYHora, bitAtendido)
	select distinct Turno_Numero, Turno_Fecha, 1
	from gd_esquema.Maestra
	where Consulta_Sintomas is not NULL

	insert into dbo.Consulta(intIdTurno, datFechaYHora, varSintomas, varEnfermedad)
	select distinct Turno_Numero, Turno_Fecha, Consulta_Sintomas, Consulta_Enfermedades
	from gd_esquema.Maestra
	where Consulta_Sintomas is not NULL

	INSERT INTO dbo.Agenda(intIdProfesional,dateHorarioAtencion, intIdEspecialidad)
	SELECT DISTINCT Medico_Dni,Turno_Fecha, Especialidad_Codigo FROM gd_esquema.Maestra;
END


GO
/****** Object:  StoredProcedure [dbo].[procedureSumarIntentoLogin]    Script Date: 04/12/2016 23:53:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[procedureSumarIntentoLogin] @username int
AS
BEGIN
	UPDATE GD2C2016.dbo.Usuario SET intIntentosLogin = intIntentosLogin + 1 WHERE intIdUsuario = @username;	
END

GO
/****** Object:  UserDefinedFunction [dbo].[validarUsuario]    Script Date: 04/12/2016 23:53:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE FUNCTION [dbo].[validarUsuario](@username INT, @pass varchar(100))
RETURNS VARCHAR(50)
AS
BEGIN
	DECLARE @devolver varchar(50);
	DECLARE @nombreRol varchar(50);
	DECLARE @cantidadRoles INT;
	DECLARE @cantidadIntentos INT;

	SELECT @nombreRol = p.varNombreRol,@cantidadRoles = COUNT(p.varNombreRol),@cantidadIntentos = u.intIntentosLogin FROM GD2C2016.dbo.Usuario u,GD2C2016.dbo.UsuarioXRol p 
	WHERE u.intIdUsuario = p.intIdUsuario and u.intIdUsuario = @username and u.nvarPassword =  HASHBYTES('SHA2_256', @pass)
	GROUP BY p.varNombreRol,u.intIntentosLogin;
		IF(@cantidadIntentos < 3)
			BEGIN
				IF(@cantidadRoles is not null) 
				BEGIN
					--exec dbo.actualizarIntentoLogin @username
					--UPDATE GD2C2016.dbo.Usuario SET intIntentosLogin = 0 WHERE intIdUsuario = @username;
				SET	@devolver = CONVERT(VARCHAR(100),@cantidadRoles)+@nombreRol;
				END
			END
		ELSE 
			BEGIN
				--exec procedureSumarIntentoLogin @username
			--	UPDATE GD2C2016.dbo.Usuario SET intIntentosLogin = intIntentosLogin + 1 WHERE intIdUsuario = @username;
				SET	@devolver = 'LOGIN INVALIDO';
			END
		RETURN @devolver;
END
GO
/****** Object:  Table [dbo].[Afiliado]    Script Date: 04/12/2016 23:53:19 ******/
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
/****** Object:  Table [dbo].[Agenda]    Script Date: 04/12/2016 23:53:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Agenda](
	[intIdAgenda] [int] IDENTITY(1,1) NOT NULL,
	[intIdProfesional] [int] NULL,
	[dateFechaInicio] [date] NULL,
	[dateFechaFin] [date] NULL,
	[timeHoraInicio] [time](7) NULL,
	[timeHoraFin] [time](7) NULL,
	[charDia] [char](15) NULL,
 CONSTRAINT [PK_Agenda] PRIMARY KEY CLUSTERED 
(
	[intIdAgenda] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Asistencia]    Script Date: 04/12/2016 23:53:19 ******/
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
/****** Object:  Table [dbo].[Bono]    Script Date: 04/12/2016 23:53:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bono](
	[intIdBono] [int] IDENTITY(1,1) NOT NULL,
	[intCodigoPlan] [int] NULL,
	[datFechaCompra] [datetime] NULL,
	[intIdAfiliadoCompro] [int] NULL,
	[intIdAfiliadoUtilizo] [int] NULL,
	[intNumeroConsultaMedica] [int] NULL,
	[datFechaImpresion] [datetime] NULL,
 CONSTRAINT [PK_Bono] PRIMARY KEY CLUSTERED 
(
	[intIdBono] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Consulta]    Script Date: 04/12/2016 23:53:19 ******/
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
/****** Object:  Table [dbo].[Especialidad]    Script Date: 04/12/2016 23:53:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Especialidad](
	[intEspecialidadCodigo] [numeric](18, 0) NOT NULL,
	[varDescripcion] [varchar](255) NULL,
	[intCodigoTipoEspecialidad] [numeric](18, 0) NULL,
	[varDescripcionTipoEspecialidad] [varchar](255) NULL,
 CONSTRAINT [PK_Especialidad] PRIMARY KEY CLUSTERED 
(
	[intEspecialidadCodigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Funcionalidad]    Script Date: 04/12/2016 23:53:19 ******/
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
/****** Object:  Table [dbo].[FuncionalidadXRol]    Script Date: 04/12/2016 23:53:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[FuncionalidadXRol](
	[intIdFuncionalidadXRol] [int] IDENTITY(1,1) NOT NULL,
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
/****** Object:  Table [dbo].[Plan]    Script Date: 04/12/2016 23:53:19 ******/
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
/****** Object:  Table [dbo].[Profesional]    Script Date: 04/12/2016 23:53:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Profesional](
	[intIdUsuario] [int] NOT NULL,
	[intMatricula] [int] NULL,
 CONSTRAINT [PK_Profesional] PRIMARY KEY CLUSTERED 
(
	[intIdUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ProfesionalXEspecialidad]    Script Date: 04/12/2016 23:53:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProfesionalXEspecialidad](
	[intIdProfesionalXEspecialidad] [int] IDENTITY(1,1) NOT NULL,
	[intIdUsuario] [int] NULL,
	[intEspecialidadCodigo] [numeric](18, 0) NULL,
 CONSTRAINT [PK_ProfesionalXEspecialidad] PRIMARY KEY CLUSTERED 
(
	[intIdProfesionalXEspecialidad] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Rol]    Script Date: 04/12/2016 23:53:19 ******/
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
/****** Object:  Table [dbo].[Turno]    Script Date: 04/12/2016 23:53:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Turno](
	[intIdTurno] [int] NOT NULL,
	[datFechaTurno] [datetime] NULL,
	[intIdPaciente] [int] NULL,
	[intIdDoctor] [int] NULL,
	[bitEstado] [bit] NULL,
 CONSTRAINT [PK_Turno] PRIMARY KEY CLUSTERED 
(
	[intIdTurno] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TurnoCancelado]    Script Date: 04/12/2016 23:53:19 ******/
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
/****** Object:  Table [dbo].[Usuario]    Script Date: 04/12/2016 23:53:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Usuario](
	[intIdUsuario] [int] NOT NULL,
	[nvarPassword] [nvarchar](100) NULL,
	[varNombre] [varchar](50) NULL,
	[varApellido] [varchar](50) NULL,
	[varTipoDocumento] [varchar](50) NULL,
	[intNroDocumento] [int] NULL,
	[intTelefono] [int] NULL,
	[varDireccion] [varchar](250) NULL,
	[varMail] [varchar](150) NULL,
	[datFechaNacimiento] [datetime] NULL,
	[chrSexo] [char](1) NULL,
	[intIntentosLogin] [int] NOT NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[intIdUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UsuarioXRol]    Script Date: 04/12/2016 23:53:19 ******/
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
ALTER TABLE [dbo].[Usuario] ADD  DEFAULT ((0)) FOR [intIntentosLogin]
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
