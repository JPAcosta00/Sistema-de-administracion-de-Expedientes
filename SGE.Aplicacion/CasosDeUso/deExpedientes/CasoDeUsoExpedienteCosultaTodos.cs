namespace SGE.Aplicacion;

public class CasoDeUsoExpedienteConsultaTodos(IExpedienteRepositorio repo):ExpedienteCasoDeUso(repo)
{
    public List<Expediente> Ejecutar(){
       return  repo.ConsultaTodos();
    }

}