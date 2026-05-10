namespace SGE.Aplicacion;

public class CasoDeUsoExpedienteAlta(IExpedienteRepositorio repo, ExpedienteValidador valid,IServicioAutorizacion autoEx):ExpedienteCasoDeUso(repo)
{
    public void Ejecutar(Expediente expe,Usuario us){
       if(!autoEx.PoseeElPermiso(us.Permisos, Permisos.ExpedienteAlta)){                                   //Ve si esta autorizado el usuario
            throw new AuthorizationException("El usuario que intenta realizar la operacion no tiene los permisos necesarios.");
       }
       if(!valid.Validar(expe,us,out string mensajeError)){                                                //Ve si es valido el expediente a agregar
           throw new ValidacionException(mensajeError);
       }
       expe.Creacion = DateTime.Now;
       expe.UltimaModificacion = DateTime.Now;
       expe.UsuarioID = us.ID;
       repo.AgregarExpediente(expe);
    }
}
