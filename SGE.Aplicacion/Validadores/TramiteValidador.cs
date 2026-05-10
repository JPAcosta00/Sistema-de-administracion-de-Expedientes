namespace SGE.Aplicacion;
public class TramiteValidador{
    public bool Validar(Tramite unTramite,Usuario usu, out string mensajeError){
        mensajeError = " ";
        if(string.IsNullOrWhiteSpace(unTramite.Contenido)){
            mensajeError = "Contenido del tramite vacio";
        }
        if(usu.Correo == null){
            mensajeError += "Correo de usuario invalido";
        }
        return (mensajeError == " ");
    }
}