namespace SGE.Aplicacion;

public abstract class ExpedienteCasoDeUso (IExpedienteRepositorio repositorio)
{
   protected IExpedienteRepositorio Repositorio { get; } = repositorio;

}