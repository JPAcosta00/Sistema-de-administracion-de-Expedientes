namespace SGE.Aplicacion;

public class ExpecificacionCambioEstado(EtiquetaTramite unaEtiqueta){
    public EstadoExpediente Ejecutar(){
        EstadoExpediente nuevoEstado = new EstadoExpediente();
        if(unaEtiqueta == EtiquetaTramite.Resolucion){
            nuevoEstado = EstadoExpediente.ConResolucion;
        }else if(unaEtiqueta == EtiquetaTramite.PaseaEstudio){
            nuevoEstado = EstadoExpediente.ParaResolver;
        }else if(unaEtiqueta == EtiquetaTramite.PaseAlArchivo){
            nuevoEstado = EstadoExpediente.Finalizado;
        }
        return nuevoEstado;
    }
}