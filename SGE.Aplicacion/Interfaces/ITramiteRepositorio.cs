namespace SGE.Aplicacion;
public interface ITramiteRepositorio{
     void AgregaTramite(Tramite unTramite);
     void EliminaTramite(int identificacionTramite);
     void ModificaTramite(Tramite unTramite);
     List<Tramite>? ConsultaPorEtiqueta(EtiquetaTramite eti);
     Tramite? GetTramite(int id);
     List<Tramite> ListadoTramites();
     EtiquetaTramite? DevuelveEtiqueta(int IDexpediente);
}