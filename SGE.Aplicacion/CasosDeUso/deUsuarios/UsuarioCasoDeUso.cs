using SGE.Aplicacion;
namespace SGE.Aplicacion;
public abstract class UsuarioCasoDeUso (IUsuarioRepositorio repositorio)
{
   protected IUsuarioRepositorio Repositorio { get; } = repositorio;

}