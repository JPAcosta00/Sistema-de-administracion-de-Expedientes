namespace SGE.Aplicacion;

public class Usuario{
    public int ID {get; set;}
    public string? Nombre {get; set;}
    public string? Apellido {get; set;}
    public string? Correo {get; set;}
    public string? Contraseña {get; set;} 
    public List<Permisos> Permisos {get; set;} = new List<Permisos>();
    public new string ToString(){
        return ($"Nombre de usuario: {Nombre} \n Apellido: {Apellido} \n Correo: {Correo}");
    }
}