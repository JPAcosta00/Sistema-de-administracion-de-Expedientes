namespace SGE.Aplicacion;

public class Expediente {
    public int ID {get; set;} 
    public int TramiteID {get; set;} 
    public string Caratula {get; set;} = " ";
    public DateTime Creacion {get; set;}
    public DateTime UltimaModificacion {get; set;}
    public int UsuarioID {get; set;}
    public EstadoExpediente Estado {get; set;}
    public List<Tramite>? Tramites {get; set;}                  //El Entity FrameWork identifique sus tramites.

    public Expediente(){ }

    public Expediente(int idTramite, string unaCaratula,int unUsuario,EstadoExpediente unEstado){
        TramiteID = idTramite;
        Caratula = unaCaratula;
        UsuarioID = unUsuario;
        Estado = unEstado;
    }
    public override string ToString(){
        return ($"ID: {ID} \n ID Tramite: {TramiteID} \n Caratula: {Caratula} \n Hora y Fecha de Creacion: {Creacion} \n Hora y Fecha de la Ultima Modificacion: {UltimaModificacion} \n Usuario que Realizo la ultima modificacion: {UsuarioID} \n Estado del Expediente: {Estado}");
    }

}