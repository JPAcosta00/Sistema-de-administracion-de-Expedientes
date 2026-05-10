namespace SGE.Repositorios;
using SGE.Aplicacion;
public class SGESqlite
{
   public static void Inicializar()
   {
       using var context = new SGEContext();
        
        // EnsureCreated crea la base si no existe y devuelve true
        if (context.Database.EnsureCreated())
        {
            Console.WriteLine("Base de datos creada. Insertando datos iniciales...");

            // 1. Creamos un par de expedientes
            var exp1 = new Expediente(1, "Solicitud de Beca Universitaria", 101, EstadoExpediente.RecienIniciado)
            {
                Creacion = DateTime.Now,
                UltimaModificacion = DateTime.Now
            };

            var exp2 = new Expediente(2, "Habilitación de Comercio - Centro", 102, EstadoExpediente.ParaResolver)
            {
                Creacion = DateTime.Now.AddDays(-5),
                UltimaModificacion = DateTime.Now
            };

            context.Expediente.AddRange(exp1, exp2);
            context.SaveChanges(); // Guardamos para que generen sus IDs

            // 2. Agregamos trámites asociados a esos expedientes
            var tramite1 = new Tramite(exp1.ID, EtiquetaTramite.PaseaEstudio, "El usuario presentó DNI y Certificado de Alumno Regular.", 101)
            {
                Creacion = DateTime.Now,
                UltimaModificacion = DateTime.Now
            };

            var tramite2 = new Tramite(exp2.ID, EtiquetaTramite.Despacho, "Inspección técnica aprobada sin observaciones.", 102)
            {
                Creacion = DateTime.Now.AddDays(-2),
                UltimaModificacion = DateTime.Now
            };

            context.Tramite.AddRange(tramite1, tramite2);
            
            // 3. Persistimos los cambios finales
            context.SaveChanges();
            Console.WriteLine("Datos iniciales cargados con éxito.");
        }
   }
}