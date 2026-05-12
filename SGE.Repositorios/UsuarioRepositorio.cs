using Microsoft.EntityFrameworkCore;
namespace SGE.Repositorios;
using SGE.Aplicacion;

public class  UsuarioRepositorio : IUsuarioRepositorio{

     public bool IniciarSesion(string correo, string contraseña){
         using var db = new SGEContext();
         var hashEntrada = HashHelper.HashContraseña(contraseña);
    
         // Filtramos directamente en la base de datos
         return db.Usuario.Any(u => u.Correo == correo && u.Contraseña == hashEntrada);
     }
     public Usuario? getAdministrador() {
          using var db = new SGEContext();
          return db.Usuario.AsNoTracking().FirstOrDefault(); // El primero que se registró
      }
     public void RegistrarUsuario(Usuario unUsuario){
        using var db = new SGEContext();
        
        // 1. Verificamos si es el primer usuario de la historia del sistema
        bool esPrimerUsuario = !db.Usuario.Any();

        unUsuario.Contraseña = HashHelper.HashContraseña(unUsuario.Contraseña);
        
        // 2. Si es el primero, le cargamos todos los permisos manualmente
        if (esPrimerUsuario)
        {
            AsignarPermisosTotales(unUsuario);
        }

        db.Usuario.Add(unUsuario);
        db.SaveChanges();
     }
     private void AsignarPermisosTotales(Usuario usuario)
    {
        // Aseguramos que la lista de permisos no sea nula
        usuario.Permisos ??= new List<Permisos>();

        // Agregamos todos los permisos posibles
        var todosLosPermisos = Enum.GetValues(typeof(Permisos)).Cast<Permisos>();
        foreach (var permiso in todosLosPermisos)
        {
            if (!usuario.Permisos.Contains(permiso))
            {
                usuario.Permisos.Add(permiso);
            }
        }
    }
     public Usuario DevuelveUsuario(string correo){             //se usa para el inicio de sesion en la interfaz
        using var db = new SGEContext();
        // Incluimos los permisos para que la interfaz sepa qué puede hacer el usuario
        return db.Usuario
            .Include(u => u.Permisos)
            .AsNoTracking()
            .SingleOrDefault(a => a.Correo == correo);
     }
     public void EliminarUsuario(string unCorreo){
         using var db = new SGEContext();
        var usuario = db.Usuario.SingleOrDefault(c => c.Correo == unCorreo);
        
        if (usuario != null)
        {
            db.Usuario.Remove(usuario);
            db.SaveChanges();

            // Si después de borrar no queda nadie, reseteamos el ID de SQLite
            if (!db.Usuario.Any())
            {
                db.Database.ExecuteSqlRaw("DELETE FROM sqlite_sequence WHERE name='Usuario'");
            }
        }
        else
        {
            throw new RepositorioException("El Usuario que se quiere eliminar no existe.");
        }
     }
     public List<Usuario> ListarUsuario(){
         using var db = new SGEContext();
         return db.Usuario
            .AsNoTracking()
            .Select(u => new Usuario {
                 ID = u.ID,
                 Nombre = u.Nombre,
                 Apellido = u.Apellido,
                 Correo = u.Correo,
                 Contraseña = "**********" })
            .ToList();
     }
     public void ModificarUsuario(Usuario unUsuario){
         using var db = new SGEContext();
         var usuarioM = db.Usuario
            .Include(u => u.Permisos)
            .SingleOrDefault(u => u.Correo == unUsuario.Correo);

        if (usuarioM != null){
            usuarioM.Nombre = unUsuario.Nombre;
            usuarioM.Apellido = unUsuario.Apellido;
            usuarioM.Contraseña = unUsuario.Contraseña;
            
            // Actualización de permisos: reemplazamos la lista actual
            usuarioM.Permisos = unUsuario.Permisos;
            
            db.SaveChanges();
        }else{
            throw new RepositorioException("El Usuario que se quiere modificar no existe.");
        }
     }
}