namespace SGE.Aplicacion;

public class CasoDeUsoTramiteBaja(ITramiteRepositorio repo, TramiteValidador valida,IServicioAutorizacion serviA):TramiteCasoDeUso(repo)
{
    public void Ejecutar(int id, Usuario unUsuario){
        if(!serviA.PoseeElPermiso(unUsuario.Permisos, Permisos.ExpedienteBaja)){                       //ve si el usuario tiene autorizacion
            throw new AuthorizationException("El usuario que intenta realizar la operacion no tiene los permisos necesarios.");
        }
       repo.EliminaTramite(id);
    }
}
