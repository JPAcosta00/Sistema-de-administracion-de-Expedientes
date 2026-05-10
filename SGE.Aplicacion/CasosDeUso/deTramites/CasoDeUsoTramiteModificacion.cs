namespace SGE.Aplicacion;

public class CasoDeUsoTramiteModificacion(ITramiteRepositorio repo,IServicioAutorizacion serAuto)
{   
    public void Ejecutar(Tramite tra,Usuario us){
        if(!serAuto.PoseeElPermiso(us.Permisos, Permisos.TramiteModificacion)){                   //ve si esta autorizado el usuario
            throw new AuthorizationException("El usuario que intenta realizar la operacion no tiene los permisos necesarios.");
        }
        tra.UltimaModificacion = DateTime.Now;
        tra.UsuarioID = us.ID;                                   //guarda el id del ultimo usuario que lo modifico.
        repo.ModificaTramite(tra);
    }
}