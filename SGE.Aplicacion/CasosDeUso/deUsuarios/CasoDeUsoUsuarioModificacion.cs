namespace SGE.Aplicacion;

public class CasoDeUsoUsuarioModificacion(IUsuarioRepositorio repo):UsuarioCasoDeUso(repo){
    public void Ejecutar(Usuario unUsuario){   
        repo.ModificarUsuario(unUsuario); 
    }
}