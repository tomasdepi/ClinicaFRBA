 use GD2C2016
 
 go
  create procedure comprarBono @Usuario int, @cantidad int, @codigoPlan int
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