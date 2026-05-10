namespace SGE.Aplicacion;
public class ServicioAutorizacion : IServicioAutorizacion{
    public bool PoseeElPermiso(List<Permisos> lis, Permisos debeTener){
         bool retorno = false;
         foreach(Permisos p in lis){                //recorre la lista de los permisos que tiene el usuario, y corrobora que tenga el permiso necesario para realizar la operacion.           
            if(p == debeTener){
                retorno = true;
            }
         }
         return retorno;
    }
}