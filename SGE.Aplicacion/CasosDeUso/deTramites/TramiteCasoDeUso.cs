namespace SGE.Aplicacion;

public abstract class TramiteCasoDeUso (ITramiteRepositorio repositorio)
{
   protected ITramiteRepositorio Repositorio { get; } = repositorio;

}