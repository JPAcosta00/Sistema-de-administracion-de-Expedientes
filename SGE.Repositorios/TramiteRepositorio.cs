using Microsoft.EntityFrameworkCore;
namespace SGE.Repositorios;
using SGE.Aplicacion;

public class TramiteRepositorio : ITramiteRepositorio{

    public void AgregaTramite(Tramite unTramite){
        using var db = new SGEContext();
        db.Tramite.Add(unTramite);
        db.SaveChanges();
    }
    public void EliminaTramite(int identi){ 
        using var db = new SGEContext();                                    
       var dato = db.Tramite.Where(a => a.ID == identi).SingleOrDefault();
       if(dato != null){
            db.Remove(dato);
       }else{
            throw new RepositorioException("El Tramite que se quiere eliminar no existe en el repositorio.");
       }
       db.SaveChanges();
       bool isEmpty = !db.Tramite.Any();                                        
       if(isEmpty){
          db.Database.ExecuteSqlRaw("DELETE FROM Tramites");
          db.Database.ExecuteSqlRaw("DELETE FROM sqlite_sequence WHERE name='Tramite'");             //resetea el contador de ids si se vacio al base de datos
       }
       db.SaveChanges();
    }

    public void ModificaTramite(Tramite unTramite){
        using var db = new SGEContext();
         var modificacion = db.Tramite.Where(a => a.ID == unTramite.ID).SingleOrDefault();
        if(modificacion != null){
            modificacion.ID = unTramite.ID;
            modificacion.ExpedienteID = unTramite.ExpedienteID;
            modificacion.Etiqueta = unTramite.Etiqueta;
            modificacion.Contenido = unTramite.Contenido;
            modificacion.Creacion = unTramite.Creacion;
            modificacion.UltimaModificacion = unTramite.UltimaModificacion;
            modificacion.UsuarioID = unTramite.UsuarioID;
        }else{
            throw new RepositorioException("El Tramite que se quiere modificar no existe en el repositorio.");
        }
        db.SaveChanges();
    }

    public List<Tramite>? ConsultaPorEtiqueta(EtiquetaTramite e){
        using var db = new SGEContext();
        List<Tramite>? listado = new List<Tramite>();
        foreach(Tramite registro in db.Tramite){
            if(registro.Etiqueta == e){
                listado.Add(registro);
            }
        }
        return listado;
    }
    private static Tramite Clonar(Tramite Tra) {
        return new Tramite()
        {
            ID = Tra.ID,
            ExpedienteID = Tra.ExpedienteID,
            Etiqueta = Tra.Etiqueta,
            Contenido = Tra.Contenido,
            Creacion = Tra.Creacion,
            UltimaModificacion = Tra.UltimaModificacion,
            UsuarioID = Tra.UsuarioID
        };
    }
    public List<Tramite> ListadoTramites(){
       using var db = new SGEContext();
        return db.Tramite.Select(t => Clonar(t)).ToList();
    }
    public Tramite? GetTramite(int ID){
        using var db = new SGEContext();
        var aux = db.Tramite.Where(t => t.ID == ID).SingleOrDefault();
        if (aux != null)
        {
            return  Clonar(aux);
        }else{
            return null;
        }
    }
    public EtiquetaTramite? DevuelveEtiqueta(int expeID){
         using var db = new SGEContext();
         bool aux = true;
         foreach(Tramite dato in db.Tramite){
            if(dato.ExpedienteID == expeID){
                return dato.Etiqueta;
                aux = false;
            }
         }
         if(aux == false){
            throw new RepositorioException("El Tramite por el que se esta consultando no existe en el repositorio.");
         }
         return null;
    }
}