namespace SGE.Aplicacion;

public class CasoDeUsoInicioSesion(IUsuarioRepositorio repo):UsuarioCasoDeUso(repo){
    public bool Ejecutar (string correo, string contraseña){
        return repo.IniciarSesion(correo,contraseña);
    }
}