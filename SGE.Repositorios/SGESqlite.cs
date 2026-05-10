namespace SGE.Repositorios;

public class SGESqlite
{
   public static void Inicializar()
   {
       using var context = new SGEContext();
        if (context.Database.EnsureCreated())                     //si no existe la base de datos entonces la crea
       {
          Console.WriteLine("Se creó base de datos");
       }
   }
}