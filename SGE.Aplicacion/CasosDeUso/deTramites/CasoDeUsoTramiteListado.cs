namespace SGE.Aplicacion;

public class CasoDeUsoTramiteListado(ITramiteRepositorio repo):TramiteCasoDeUso(repo){
    public List<Tramite> Ejecutar(){
        return repo.ListadoTramites();
    }
}