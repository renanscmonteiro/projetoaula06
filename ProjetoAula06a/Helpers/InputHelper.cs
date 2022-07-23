using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAula06a.Helpers
{
    /// <summary>
    /// Classe para auxiliar a entrada de dados através do console
    /// </summary>
    public static class InputHelper
    {
        public static string? Get(string message)
        {
            Console.Write(message);
            return Console.ReadLine();
        }
    }
}