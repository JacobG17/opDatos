using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace opDatos
{
    public class ParametrosConexion
    {
        StringBuilder parametroConexion = new StringBuilder();
        public ParametrosConexion()
        {
            this.DataBase = "master";
            this.Server = string.Empty;
            this.User = string.Empty;
            this.Password = string.Empty;
        }

        public string DataBase { get; set; }

        public string Server { get; set; }

        public string User { get; set; }

        public string Password { get; set; }

        public StringBuilder obtenerCadena()
        {
            parametroConexion.Clear();
            parametroConexion.Append("Data Source=").Append(Server).Append(";");
            parametroConexion.Append("Initial Catalog=master;");
            parametroConexion.Append("User=").Append(User).Append(";");
            parametroConexion.Append("Password=").Append(Password).Append(";");

            return parametroConexion;
        }

    }
}
