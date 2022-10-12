using System;
using PistasAterrizaje;

namespace PistasAterrizaje{
    public class Menu{
        public static void MenuAeropuerto(){
            Console.Clear();
            Helpers.MostrarLogo();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n\t\t\t\t\t\t¡¡ Bienvenidos al Aeropuerto FACET !!\n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\t\t\t\t\t\tPresione enter para continuar...\n\n");
            Console.ReadLine();
            Console.Clear();
        }
    }
}