namespace SGE.Aplicacion;

public class CasoDeUsoExpedienteConsultaPorId(IExpedienteRepositorio repo):ExpedienteCasoDeUso(repo)
{
    public List<Tramite> Ejecutar(int iden){
        return  repo.ConsultaPorId(iden);
    }
}