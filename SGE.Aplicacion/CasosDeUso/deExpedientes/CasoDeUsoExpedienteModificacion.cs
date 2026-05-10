namespace SGE.Aplicacion;
public class CasoDeUsoExpedienteModificacion(IExpedienteRepositorio repo,IServicioAutorizacion serAuto){
   
    public void Ejecutar(Expediente expe,Usuario us){
        if(!serAuto.PoseeElPermiso(us.Permisos, Permisos.ExpedienteModificacion)){                   //ve si esta autorizado el usuario
            throw new AuthorizationException("El usuario que intenta realizar la operacion no tiene los permisos necesarios.");
        }
        expe.UltimaModificacion = DateTime.Now;
        expe.UsuarioID = us.ID;
        repo.ModificarExpediente(expe);
    }
}