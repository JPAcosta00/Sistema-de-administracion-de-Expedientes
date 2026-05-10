namespace SGE.Aplicacion;

public class CasoDeUsoDevuelveUsuario(IUsuarioRepositorio repo):UsuarioCasoDeUso(repo){
    public Usuario? Ejecutar(string unCorreo){
       return repo.DevuelveUsuario(unCorreo);
    }
}