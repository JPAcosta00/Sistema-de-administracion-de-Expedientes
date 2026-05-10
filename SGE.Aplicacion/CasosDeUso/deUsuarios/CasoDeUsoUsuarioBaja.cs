namespace SGE.Aplicacion;

public class CasoDeUsoUsuarioBaja(IUsuarioRepositorio repo):UsuarioCasoDeUso(repo){
    public void Ejecutar(string correo){   //se pasa el usuario a eliminar
        //validaciones
        repo.EliminarUsuario(correo);
    }
}