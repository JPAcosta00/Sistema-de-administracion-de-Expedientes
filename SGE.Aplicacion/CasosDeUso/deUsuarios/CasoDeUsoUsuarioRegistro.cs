namespace SGE.Aplicacion;

public class CasoDeUsoUsuarioRegistro(IUsuarioRepositorio repo):UsuarioCasoDeUso(repo){
    public void Ejecutar(Usuario unUsuario){
        if(unUsuario == null){
            throw new ValidacionException("El Usuario no puede ser nulo");
        }
        repo.RegistrarUsuario(unUsuario);
    }
}