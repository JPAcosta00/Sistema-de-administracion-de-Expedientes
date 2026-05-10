namespace SGE.Aplicacion;

public class ServicioActualizacionEstado{

    public Expediente Ejecutar(EtiquetaTramite etiqueta,int idExpediente){
        ExpecificacionCambioEstado cambioEstado = new ExpecificacionCambioEstado(etiqueta);
        EstadoExpediente nuevoEstado = cambioEstado.Ejecutar();                                                  //especifica el cambio de estado que hay que hacer
               
        //Expediente nuevo = new Expediente();                                                                 //crea un expediente para mandar como parametro
        //nuevo.Estado = nuevoEstado;                
        //nuevo.ID = idExpediente;                                                                           //le carga el id del expediente que se modifica                                                                              //Pone el ID de usuario en uno para que pase el permiso de usuario.
       
       // return nuevo;                                                                                      //le manda el expediente a modificar
        return null;
    }   
}

//REHACER