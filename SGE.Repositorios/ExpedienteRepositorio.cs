using System;
using Microsoft.EntityFrameworkCore;
namespace SGE.Repositorios;
using SGE.Aplicacion;

public class ExpedienteRepositorio : IExpedienteRepositorio{
    public void AgregarExpediente(Expediente unExpediente){
        using var db = new SGEContext();
        db.Expediente.Add(unExpediente);
        db.SaveChanges();
    }
    public void EliminarExpediente(int iden){
        using var db = new SGEContext();
       var dato = db.Expediente.Where(a => a.ID == iden).SingleOrDefault();
       if(dato != null){
            db.Remove(dato);
       }else{
            throw new RepositorioException("El Expediente que se quiere eliminar no existe en el repositorio.");
       }
       db.SaveChanges();
       bool isEmpty = !db.Expediente.Any();
       if(isEmpty){
          db.Database.ExecuteSqlRaw("DELETE FROM Expediente"); 
          db.Database.ExecuteSqlRaw("DELETE FROM sqlite_sequence WHERE name='Expediente'");      //resetea el contador de ids si se vacio al base de datos
       }
       db.SaveChanges();
    }
    public void ModificarExpediente(Expediente unExpediente){ 
         using var db = new SGEContext();
        var modificacion = db.Expediente.Where(a => a.ID == unExpediente.ID).SingleOrDefault();
        if(modificacion != null){
            modificacion.ID = unExpediente.ID;
            modificacion.TramiteID = unExpediente.TramiteID;
            modificacion.Caratula = unExpediente.Caratula;
            modificacion.Creacion = unExpediente.Creacion;
            modificacion.UltimaModificacion = unExpediente.UltimaModificacion;
            modificacion.UsuarioID = unExpediente.UsuarioID;
            modificacion.Estado = unExpediente.Estado;
            modificacion.Tramites = unExpediente.Tramites;
        }else{
            throw new RepositorioException("El Expediente que se quiere modificar no existe en el repositorio.");
        }
        db.SaveChanges();
    }
    public List<Tramite>? ConsultaPorId(int iden){    
        using var db = new SGEContext();   
        List<Tramite>? lista = new List<Tramite>();
        foreach(Expediente dato in db.Expediente){
            if(dato.ID == iden){
                if(dato.Tramites != null){
                    foreach(Tramite tra in dato.Tramites){
                        lista.Add(tra);
                    }
                }
                return lista;
            }
        }
        return lista;
    }
    private static Expediente Clonar(Expediente Expe) {
        return new Expediente()
        {
            ID = Expe.ID,
            TramiteID = Expe.TramiteID,
            Caratula = Expe.Caratula,
            Creacion = Expe.Creacion,
            UltimaModificacion = Expe.UltimaModificacion,
            UsuarioID = Expe.UsuarioID,
            Estado = Expe.Estado
        };
    }
    public List<Expediente> ConsultaTodos(){
         using var db = new SGEContext();
        return db.Expediente.Select(E => Clonar(E)).ToList();
    }
     public Expediente? GetExpediente(int id){
        using var db = new SGEContext();
        var aux = db.Expediente.Where(a => a.ID == id).SingleOrDefault();
        if (aux != null){
            return  aux;
        }else{
            return null;
        }
    }
}
