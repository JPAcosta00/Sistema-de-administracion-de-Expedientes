namespace SGE.Aplicacion;

public class CasoDeUsoUsuarioTienePermisos(IServicioAutorizacion autoEx){
    public bool Ejecutar(List<Permisos> lista, Permisos debeTener){
        return autoEx.PoseeElPermiso(lista, debeTener);
    }
}