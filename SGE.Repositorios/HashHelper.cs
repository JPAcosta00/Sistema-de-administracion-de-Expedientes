using System.Security.Cryptography;
using System.Text;
namespace SGE.Repositorios;

public static class HashHelper{
  public static string HashContraseña(string rawData)
  {
    // Crear una instancia de SHA256
    using (SHA256 sha256Hash = SHA256.Create())
    {
      byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));  //convierte la cadena en un arreglo de bytes
      StringBuilder builder = new StringBuilder(); //convierte el arreglo en una cadena 
      foreach (byte b in bytes)
      {
        builder.Append(b.ToString("x2"));
      }

      return builder.ToString();
    }
  }
}

