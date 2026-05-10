namespace SGE.Aplicacion;

public class CasoDeUsoObtenerTramite(ITramiteRepositorio repo):TramiteCasoDeUso(repo){
    public Tramite? Ejecutar(int ID){
        return repo.GetTramite(ID);
    }
}