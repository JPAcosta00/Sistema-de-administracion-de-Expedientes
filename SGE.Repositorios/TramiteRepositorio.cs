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
         // La base de datos filtra y solo nos envía lo que coincide. 
        // Usamos AsNoTracking porque es una consulta de solo lectura.
        return db.Tramite
             .AsNoTracking()
             .Where(registro => registro.Etiqueta == e)
             .ToList();
    }
    public List<Tramite> ListadoTramites(){
       using var db = new SGEContext();
       return db.Tramite.AsNoTracking().ToList();
    }
    public Tramite? GetTramite(int ID){
         using var db = new SGEContext();
        // devuelve obj encontrado o null
        return db.Tramite.AsNoTracking().FirstOrDefault(t => t.ID == ID);
    }
    public EtiquetaTramite? DevuelveEtiqueta(int expeID){
         using var db = new SGEContext();
         // Buscamos directamente el primer trámite que coincida con el ExpedienteID
         var etiqueta = db.Tramite
                     .AsNoTracking()
                     .Where(t => t.ExpedienteID == expeID)
                     .Select(t => t.Etiqueta)
                     .FirstOrDefault();

         // Si no se encontró nada (el valor por defecto de un Enum suele ser el primero, 
         // pero aquí verificamos si existe el registro)
        if (etiqueta == null) { 
             throw new RepositorioException("El Tramite por el que se esta consultando no existe.");
         }

         return etiqueta;
    }
}