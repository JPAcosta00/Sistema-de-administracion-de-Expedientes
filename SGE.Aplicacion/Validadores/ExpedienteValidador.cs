namespace SGE.Aplicacion;
public class ExpedienteValidador{

    public bool Validar(Expediente unExpediente,Usuario usu, out string mensajeError){
        mensajeError = " ";
        if(string.IsNullOrWhiteSpace(unExpediente.Caratula)){
            mensajeError = "Caratula de la excepcion vacia.";
        }
        if(usu.Correo == null){
            mensajeError += "Correo de usuario invalido";
        }
        return (mensajeError == " ");
    }
}