USE [GD2C2016]


GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON


GO
CREATE PROCEDURE [dbo].[MigracionPlanMedico]
AS
BEGIN
	Insert into dbo.[Plan](intCodigoPlan, varDescripcion, monPrecioBonoConsulta, monPrecioBonoFarmacia)
	select Plan_Med_Codigo, Plan_Med_Descripcion, Plan_Med_Precio_Bono_Consulta, Plan_Med_Precio_Bono_Farmacia
	from gd_esquema.Maestra
END


GO
CREATE PROCEDURE [dbo].[CreacionFuncionalidades]
AS
BEGIN
	Insert into dbo.Funcionalidad(intIdFuncionalidad, varFuncionalidad, varDescripcion) values 
	(1, 'ABM Rol', 'AMB Rol'),
	(2, 'Registro Usuario', 'Registro Usuario'),
	(3, 'ABM Afiliado', 'ABM Afiliado'),
	(4, 'ABM Profecional', 'AMB Profecional'),
	(5, 'ABM Esp Medicas', 'ABM Esp Medicas'),
	(6, 'ABM Planes', 'ABM Planes'),
	(7, 'Registrar Agenda', 'Registrar Agenda'),
	(8, 'Comprar Bonos', 'Comprar Bonos'),
	(9, 'Pedir Turnos', 'Pedir Turnos'),
	(10, 'Registro Llegada Atencion Medica', 'Registro Llegada Atencion Medica'),
	(11, 'Registro Resultado Atencion Medica', 'Registro Resultado Atencion Medica'),
	(12, 'Cancelar Atencion Medica', 'Cancelar Atencion Medica'),
	(13, 'Listado Estadistico','Listado Estadistico')

	Insert Into dbo.FuncionalidadXRol(intIdFuncionalidad, varNombreRol) values
	(1, 'Administrativo'),
	(2, 'Administrativo'),
	(3, 'Administrativo'),
	(4, 'Administrativo'),
	(5, 'Administrativo'),
	(6, 'Administrativo'),
	(7, 'Administrativo'),
	(7, 'Profecional'),
	(8, 'Afiliado'),
	(9, 'Administrativo'),
	(9, 'Afiliado'),
	(10, 'Administrativo'),
	(11, 'Profecional'),
	(12, 'Profecional'),
	(12, 'Afiliado'),
	(13, 'Administrativo')

	insert into dbo.Rol(varNombreRol, bitHabilitado) values
	('Afiliado', 1),
	('Profecional', 1),
	('Administrativo', 1)

END

GO
CREATE PROCEDURE [dbo].[MigracionAfiliado]
AS
BEGIN
	Insert into dbo.Afiliado(intIdUsuario, intCodigoPlan, bitEstadoActual, intNumeroConsultaMedica)
	select distinct Paciente_Dni, Plan_Med_Codigo, 1, 0
	from gd_esquema.Maestra

	Insert into dbo.Usuario(intIdUsuario,nvarPassword, varNombre, varApellido, varTipoDocumento, intNroDocumento, intTelefono, varDireccion, varMail, datFechaNacimiento)
	select distinct Paciente_Dni, HASHBYTES('SHA2_256', 'afiliado'), Paciente_Nombre, Paciente_Apellido, 'DNI', Paciente_Dni, Paciente_Telefono, Paciente_Direccion, Paciente_Mail, Paciente_Fecha_Nac
	from gd_esquema.Maestra

	Insert into dbo.UsuarioXRol(varNombreRol, intIdUsuario)
	select distinct 'Afiliado', Paciente_Dni  from gd_esquema.Maestra
END


GO
CREATE PROCEDURE [dbo].[MigracionEspecialidad]
AS
BEGIN
	insert into dbo.Especialidad(intEspecialidadCodigo, varDescripcion, intCodigoTipoEspecialidad, varDescripcionTipoEspecialidad)
	select Especialidad_Codigo, Especialidad_Descripcion, Tipo_Especialidad_Codigo, Tipo_Especialidad_Descripcion
	from gd_esquema.Maestra
END

GO
CREATE PROCEDURE [dbo].[MigracionProfecional]
AS
BEGIN
	insert into dbo.Profesional(intIdUsuario)
	select distinct Medico_Dni
	from gd_esquema.Maestra

	Insert into dbo.Usuario(intIdUsuario,nvarPassword, varNombre, varApellido, varTipoDocumento, intNroDocumento, intTelefono, varDireccion, varMail, datFechaNacimiento)
	select distinct Medico_Dni, HASHBYTES('SHA2_256', 'profecional'), Medico_Nombre, Medico_Apellido, 'DNI', Medico_Dni, Medico_Telefono, Medico_Direccion, Medico_Mail, Medico_Fecha_Nac
	from gd_esquema.Maestra

	Insert into dbo.UsuarioXRol(varNombreRol, intIdUsuario)
	select distinct Paciente_Dni, 'Profesional' from gd_esquema.Maestra

	Insert into dbo.ProfecionalXEspecialidad(intIdUsuario, intEspecialidadCodigo)
	select distinct Medico_Dni, Especialidad_Codigo
	from gd_esquema.Maestra
END

GO
CREATE PROCEDURE [dbo].[MigracionTurno]
AS
BEGIN
	Insert into dbo.Turno(intIdTurno, datFechaTurno, intIdPaciente,intIdDoctor, bitEstado)
	select distinct Turno_Numero, Turno_Fecha, Paciente_Dni, Medico_Dni, 1
	from gd_esquema.Maestra

	insert into dbo.Asistencia(intIdTurno, datFechaYHora, bitAtendido)
	select Turno_Numero, Turno_Fecha, 1
	from gd_esquema.Maestra
	where Consulta_Sintomas is not NULL

	insert into dbo.Consulta(intIdTurno, datFechaYHora, varSintomas, varEnfermedad)
	select Turno_Numero, Turno_Fecha, Consulta_Sintomas, Consulta_Enfermedades
	from gd_esquema.Maestra
	where Consulta_Sintomas is not NULL
END

GO
CREATE PROCEDURE [dbo].[MigracionBono]
AS
BEGIN
	INSERT INTO dbo.Bono(intCodigoPlan, datFechaCompra,datFechaImpresion,intNumeroConsultaMedica, intIdAfiliadoCompro, intIdAfiliadoUtilizo)
	SELECT Plan_Med_Codigo, Compra_Bono_Fecha,Bono_Consulta_Fecha_Impresion,Bono_Consulta_Numero, Paciente_Dni, Paciente_Dni
	FROM GD2C2016.gd_esquema.Maestra
	where Compra_Bono_Fecha is not null
END