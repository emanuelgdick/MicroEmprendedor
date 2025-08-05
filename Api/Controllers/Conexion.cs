using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
namespace Api

{
    public class Conexion
    {
        public static string cn = "server=Manolo;database=MicroEmprendedor;Integrated Security=true;TrustServerCertificate=true;";//ConfigurationManager.ConnectionStrings["cadena"].ToString();
    }
}
