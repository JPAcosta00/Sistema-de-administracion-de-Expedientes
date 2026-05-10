namespace SGE.Aplicacion;

public interface IServicioAutorizacion {
     bool PoseeElPermiso(List<Permisos> lis, Permisos debeTener);  
     //recibe la lista de permisos que tiene el usuario y 
     //el permiso en especifico para realizar la accion en especial.
}