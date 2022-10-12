using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PistasAterrizaje.Data
{
    internal class Torre
    {
        private Mutex mutex;
        public Semaphore pistasDisponibles { get; set; }
        public Queue<Avion> colaAviones { get; set; }

        public Torre (int pistas, Queue<Avion> colaAviones, Mutex mutex)
        {
            this.colaAviones = colaAviones;
            this.mutex = mutex;
            pistasDisponibles = new Semaphore(pistas, pistas);
        }

        public void Run()
        {
            Thread t = new Thread(new ParameterizedThreadStart(Accion));
            t.Start(0);

        }
        private void Accion(object num)
        {
            while (true)
            {
                try
                {
                    
                    

                    // Reservo la pista
                    pistasDisponibles.WaitOne();

                    mutex.WaitOne();
                    // Coloco los aviones que estén en la cola
                    ElegirAvion();

                    mutex.ReleaseMutex();
                }
                catch (Exception)
                {
                    Console.WriteLine("Error - Exepción en Torre - Accion");
                    throw;
                }
            }
        }

        private void ElegirAvion()
        {
            Avion avion;
            Queue<Avion>? cola = ElegirCola();

            if(cola != null)
            {
                avion = cola.Dequeue();
                avion.SetPistasDisponibles(pistasDisponibles);
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine($"La torre reservó la pista para el avión {avion.numAvion} que está {avion.estado}");
                Console.ForegroundColor = ConsoleColor.White;
                avion.Run();
            }
            else
            {
                pistasDisponibles.Release();
            }

        }

        private Queue<Avion>? ElegirCola()
        {
            // Los aviones que quieren aterrizar y despegar se guardan en la misma cola
            if (colaAviones.Count > 0)
            {
                return colaAviones;
            }
            return null;
        }
    }
}
