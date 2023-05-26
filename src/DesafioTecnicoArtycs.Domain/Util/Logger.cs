using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioTecnicoArtycs.Domain.Util
{
    public static class Logger
    {
        /// <summary>
        /// Inserir texto no console
        /// </summary>
        /// <param name="texto"></param>
        public static void TEXT(string texto)
        {

            Console.WriteLine($"{DateTime.Now.ToString("yyyy-MM-dd HH:MM:ss - ")}DEBUG: {texto}");
            Console.ResetColor();
        }
        /// <summary>
        /// Debugar coidgo no console
        /// </summary>
        /// <param name="texto"></param>
        public static void DEBUG(string texto)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{DateTime.Now.ToString("yyyy-MM-dd HH:MM:ss - ")}DEBUG: {texto}");
            Console.ResetColor();
        }
        /// <summary>
        /// Logar Info no console
        /// </summary>
        /// <param name="texto"></param>
        public static void INFO(string texto)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"{DateTime.Now.ToString("yyyy-MM-dd HH:MM:ss - ")}INFO: {texto}");
            Console.ResetColor();
        }
        /// <summary>
        /// Logar erro no console
        /// </summary>
        /// <param name="texto"></param>
        /// <param name="ex"></param>
        public static void ERROR(string texto, Exception ex = null)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{DateTime.Now.ToString("yyyy-MM-dd HH:MM:ss - ")}ERROR: {texto}");
            if (ex != null)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"MESSAGE: ");
                Console.WriteLine($"{ex.Message}");
                Console.WriteLine($"STACKTRACE: ");
                Console.WriteLine($"{ex.StackTrace}");
            }

            Console.ResetColor();
        }

    }
}
