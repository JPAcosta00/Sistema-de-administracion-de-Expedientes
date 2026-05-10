namespace SGE.Aplicacion;
public interface IUsuarioRepositorio{
    void RegistrarUsuario(Usuario unUser);
    void EliminarUsuario(string unCorreo);
    void ModificarUsuario(Usuario unUser);
    Usuario? DevuelveUsuario(string unCorreo);
    bool IniciarSesion(string correo, string contraseña);
    Usuario? getAdministrador();
    List<Usuario> ListarUsuario();
}