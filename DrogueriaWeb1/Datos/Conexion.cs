using System.Data.SqlClient;

namespace DrogueriaWeb1.Datos
{
    public class Conexion
    {
        private String cadenaSQL = string.Empty;

        public Conexion()
        {

            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

            cadenaSQL = builder.GetSection("ConnectionStrings:CadenaSQL").Value;
        }

        public string getCadenaSQL()
        {
            return cadenaSQL;
        }
    }
}
