using Ae___Controle_de_Vendas.Classes.Outros;
using Ae___Controle_de_Vendas.Formulários;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ae___Controle_de_Vendas
{
    internal static class Program
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        //[STAThread]

        
        static void Main()
        {
           
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Global.LerAppConfig();
            Application.Run(new frmPrincipal());
                
            
        }
    }
}
