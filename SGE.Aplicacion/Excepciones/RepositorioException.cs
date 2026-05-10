namespace SGE.Aplicacion;
public class RepositorioException : Exception{
    public RepositorioException (){ }
    public RepositorioException(string msj) :base(msj){
    }
}