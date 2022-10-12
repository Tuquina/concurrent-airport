using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PistasAterrizaje.Data
{
    internal class Avion
    {
        public int numAvion { get; set; }
        public String estado { get; set; }
        public Semaphore? pistasDisponibles { get; set; }
        private Mutex mutex;

        public Avion(int numAvion, String estado, Mutex mutex)
        {
            this.numAvion = numAvion;
            this.estado = estado;
            this.mutex = mutex;
        }

        public void Run()
        {
            Thread t = new Thread(new ParameterizedThreadStart(Accion));
            t.Start(2);
        }

        private void Accion(object num)
        {
            // Console.ForegroundColor = ConsoleColor.Red;
            // Console.WriteLine("Thread {0} comienza - Avion", num);
            // Console.ForegroundColor = ConsoleColor.White;
            try
            {
                if(estado == "aterrizando"){
                    Console.ForegroundColor = ConsoleColor.Green;        
                }
                else{
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                Console.WriteLine($"El avión {numAvion} está {estado}");
                Console.ForegroundColor = ConsoleColor.White;

                // Tiempo que permanece el avión en la pista
                Thread.Sleep(10000);

                // Libero el avión luego de que sale de la pista
                pistasDisponibles.Release();

                if(estado == "aterrizando"){
                    
                    mutex.WaitOne();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"\t----------------- El avión {numAvion} salió de la pista ----------------- \n");
                    Console.ForegroundColor = ConsoleColor.White;
                    Helpers.MostrarAvionAterrizando();
                    mutex.ReleaseMutex();
                }
                else{
                    mutex.WaitOne();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\t----------------- El avión {numAvion} salió de la pista ----------------- \n");
                    Console.ForegroundColor = ConsoleColor.White;
                    Helpers.MostrarAvionDespegando();
                    mutex.ReleaseMutex();
        
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Error - Excepción en avión - Accion");
                throw;
            }
        }

        public void SetPistasDisponibles(Semaphore pistasDisponibles)
        {
            this.pistasDisponibles = pistasDisponibles;
        }
    }
}
