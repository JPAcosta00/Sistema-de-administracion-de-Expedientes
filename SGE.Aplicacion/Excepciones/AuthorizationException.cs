namespace SGE.Aplicacion;
public class AuthorizationException :Exception{
    public AuthorizationException() { }
    public AuthorizationException(string msj) : base(msj) { }
}