namespace SGE.Aplicacion;

public class CasoDeUsoUsuarioListar(IUsuarioRepositorio repositorio):UsuarioCasoDeUso(repositorio){
    public List<Usuario> Ejecutar(){
        return repositorio.ListarUsuario();
    }
}