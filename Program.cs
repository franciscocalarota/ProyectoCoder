using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using ProyectoCoder.Properties;

namespace ProyectoCoder
{
    internal static class Program
    { 
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

            Form1 db = new Form1();
            try
            {
                Usuario usuarioObtenido = db.ObtenerUsuarioPorId(id: 2);
            }
            catch (Exception ex) 
            { 
                Console.WriteLine(ex.Message);
            }

            

        }
    }
}
