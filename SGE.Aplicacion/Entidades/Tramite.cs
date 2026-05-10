namespace SGE.Aplicacion;

public class Tramite{
    public int ID {get; set;}
    public int ExpedienteID {get; set;}
    public EtiquetaTramite Etiqueta {get; set;}
    public string Contenido {get; set;} = " ";
    public DateTime Creacion {get; set;}
    public DateTime UltimaModificacion {get; set;}
    public int UsuarioID {get; set;}
    public Tramite(){ }
    public Tramite ( int unIDexpediente, EtiquetaTramite unaEtiqueta,string unContenido, int unUsuario){
        ExpedienteID = unIDexpediente;
        Etiqueta = unaEtiqueta;
        Contenido = unContenido;
        UsuarioID = unUsuario;
    }
    public override string ToString(){
        return ($"ID: {ID} \n ID Expediente: {ExpedienteID} \n Etiqueta: {Etiqueta} \n Contenido: {Contenido} \n Fecha y Hora de creacion: {Creacion} \n Fecha y Hora de la ultima modificacion: {UltimaModificacion} \n Usuario que realizo la ultima modificacion: {UsuarioID}");
    }
}