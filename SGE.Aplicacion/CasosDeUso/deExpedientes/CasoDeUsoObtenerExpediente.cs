namespace SGE.Aplicacion;

public class CasoDeUsoObtenerExpediente(IExpedienteRepositorio repositorio):ExpedienteCasoDeUso(repositorio)
{
  public Expediente? Ejecutar(int id)
  {
     return Repositorio.GetExpediente(id);
  }
}