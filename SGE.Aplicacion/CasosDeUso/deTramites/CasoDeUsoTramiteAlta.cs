namespace SGE.Aplicacion;

public class CasoDeUsoTramiteAlta(ITramiteRepositorio repo, TramiteValidador valida,IServicioAutorizacion serviA):TramiteCasoDeUso(repo)
{
    public void Ejecutar(Tramite tra,Usuario us){
        if(!serviA.PoseeElPermiso(us.Permisos, Permisos.TramiteAlta)){                       //ve si el usuario tiene autorizacion
            throw new AuthorizationException("El usuario que intenta realizar la operacion no tiene los permisos necesarios.");
        } 
        if(!valida.Validar(tra,us, out string mensajeError)){                                            //ve si el tramite es valido
            throw new ValidacionException(mensajeError);
        }
       tra.Creacion = DateTime.Now;
       tra.UltimaModificacion = DateTime.Now;
       tra.UsuarioID = us.ID;
       repo.AgregaTramite(tra);
    }
}
