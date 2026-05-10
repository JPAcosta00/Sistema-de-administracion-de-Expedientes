namespace SGE.Aplicacion;
public interface IExpedienteRepositorio{
    void AgregarExpediente(Expediente Expe);
    void EliminarExpediente(int identificacion);
    void ModificarExpediente(Expediente Expe);
    List<Tramite> ConsultaPorId(int idExpediente);                //lista todos los tramites del expediente con id pasado por parametro
    List<Expediente> ConsultaTodos();                              
    Expediente? GetExpediente(int id);
}