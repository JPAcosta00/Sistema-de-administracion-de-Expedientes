namespace SGE.Aplicacion;

public class CasoDeUsoTramiteConsultaPorEtiqueta(ITramiteRepositorio repo):TramiteCasoDeUso(repo)
{
    public List<Tramite>? Ejecutar(EtiquetaTramite eti){
        return repo.ConsultaPorEtiqueta(eti);
    }
}