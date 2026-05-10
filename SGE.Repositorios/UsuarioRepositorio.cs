using Microsoft.EntityFrameworkCore;
namespace SGE.Repositorios;
using SGE.Aplicacion;

public class  UsuarioRepositorio : IUsuarioRepositorio{
     private bool _ADMIN {get; set;}
     public Usuario _administrador {get; set;}
     public bool IniciarSesion(string correo, string contraseña){
         using var db = new SGEContext();
         var auxPerfil = db.Usuario.Where(c => c.Correo == correo).SingleOrDefault();  //Encuentra el perfil almacenado en la db
         string contra = HashHelper.HashContraseña(contraseña);                        //Se aplica la funcion de hashing a la contraseña que se ingreso
         
         if((auxPerfil.Correo != null)&&(contra == auxPerfil.Contraseña)){             //Si se encontro el perfil y la contraseña coincide con la registrada
            return true;
         }else{
            return false;                           
         }
     }
     public Usuario getAdministrador (){
         return _administrador;
     }
     public void RegistrarUsuario(Usuario unUsuario){
        using var db = new SGEContext();
        if(!_ADMIN){
            _ADMIN = true;
            _administrador = unUsuario;
        }
        unUsuario.Contraseña = HashHelper.HashContraseña(unUsuario.Contraseña);
        db.Usuario.Add(unUsuario);
        db.SaveChanges();
     }
     private void cargaTodosLosPermisos(){
            using var db = new SGEContext();
            Usuario administrador = db.Usuario.Where(a => a.ID == _administrador.ID).SingleOrDefault();
            administrador.Permisos.Add(Permisos.ExpedienteAlta);
            administrador.Permisos.Add(Permisos.ExpedienteBaja);
            administrador.Permisos.Add(Permisos.ExpedienteModificacion);
            administrador.Permisos.Add(Permisos.TramiteAlta);
            administrador.Permisos.Add(Permisos.TramiteBaja);
            administrador.Permisos.Add(Permisos.TramiteModificacion);
            db.SaveChanges();
     }
     public Usuario DevuelveUsuario(string correo){             //se usa para el inicio de sesion en la interfaz
        using var db = new SGEContext();
        return db.Usuario.Where(a => a.Correo == correo).SingleOrDefault();
     }
     public void EliminarUsuario(string unCorreo){
         using var db = new SGEContext();
         var aux = db.Usuario.Where(c => c.Correo== unCorreo).SingleOrDefault();
         if(aux != null){
            db.Remove(aux);
         }else{
            throw new RepositorioException("El Usuario que se quiere eliminar no existe");
         }
         db.SaveChanges();
         bool isEmpty = !db.Usuario.Any();
         if(isEmpty){
            _ADMIN = false;                                      //osea no hay administrador
            db.Database.ExecuteSqlRaw("DELETE FROM Usuario");
            db.Database.ExecuteSqlRaw("DELETE FROM sqlite_sequence WHERE name='Usuario'");      //resetea el contador de ids si se vacio al base de datos
            db.SaveChanges();
         }
     }
     private static Usuario Clonar(Usuario u) {
        return new Usuario()
        {
            ID = u.ID,
            Nombre = u.Nombre,
            Apellido = u.Apellido,
            Correo = u.Correo,
            Contraseña = "**********",                               //no manda la contraseña ni siquiera con el hashing
        };
    }
     public List<Usuario> ListarUsuario(){
         using var db = new SGEContext();
         return db.Usuario.Select(u => Clonar(u)).ToList();
     }
     public void ModificarUsuario(Usuario unUsuario){
         using var db = new SGEContext();
         var usuarioM = db.Usuario.Where(usuario => usuario.Correo == unUsuario.Correo).SingleOrDefault();
         if(usuarioM != null){
            usuarioM.ID = unUsuario.ID;
            usuarioM.Nombre = unUsuario.Nombre;
            usuarioM.Apellido = unUsuario.Apellido;
            usuarioM.Correo = unUsuario.Correo;
            usuarioM.Contraseña = unUsuario.Contraseña;
            usuarioM.Permisos = unUsuario.Permisos;
         }else{
            throw new RepositorioException("El Usuario que se quiere modificar no existe.");
         }
         db.SaveChanges();
     }
}