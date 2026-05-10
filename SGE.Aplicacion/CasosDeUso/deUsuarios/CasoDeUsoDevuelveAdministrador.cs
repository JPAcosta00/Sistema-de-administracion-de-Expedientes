namespace SGE.Aplicacion;

public class CasoDeUsoDevuelveAdministrador(IUsuarioRepositorio repo):UsuarioCasoDeUso(repo){
    public Usuario? Ejecutar (){
        return repo.getAdministrador();
    }
}