namespace SGE.Aplicacion;

public class CasoDeUsoExpedienteBaja(IExpedienteRepositorio repo,IServicioAutorizacion servicio):ExpedienteCasoDeUso(repo)
{
    public void Ejecutar(int idenEx,Usuario unUsuario){
        if(!servicio.PoseeElPermiso(unUsuario.Permisos, Permisos.ExpedienteBaja)){                          //Ve si esta autorizado el usuario
          throw new AuthorizationException("El usuario que intenta realizar la operacion no tiene los permisos necesarios.");
        }
        repo.EliminarExpediente(idenEx);
    }
}