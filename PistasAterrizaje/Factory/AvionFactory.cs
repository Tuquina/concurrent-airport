using PistasAterrizaje.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PistasAterrizaje.Factory
{
    internal class AvionFactory
    {
        private static int numeroAvion = 0;

        private Mutex mutex;
        public Queue<Avion> colaAviones { get; set; }

        public AvionFactory(Queue<Avion> colaAviones, Mutex mutex)
        {
            this.colaAviones = colaAviones;
            this.mutex = mutex;
        }


        public void Run()
        {
            Thread t = new Thread(new ParameterizedThreadStart(Accion));
            t.Start(1);
        }

        public void Accion(object num)
        {

            while (true)
            {
                // Tiempo al azar para crear aviones
                int time = RandomNumberGenerator.GetInt32(10) * 400 + 1000;

                try
                {
                    Thread.Sleep(time);
                }
                catch (Exception)
                {
                    Console.WriteLine("Error - Excepción en AvionFactory - Accion");
                    throw;
                }
                finally
                {
                    GenerarAvion();
                }
            }
        }

        private void GenerarAvion()
        {
            numeroAvion++;
            Random random = new Random();
            String estado = (random.NextInt64() % 2 == 0) ? "aterrizando" : "despegando";

            Avion avion = new Avion(numeroAvion, estado, mutex);

            try
            {
                mutex.WaitOne();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"El avión {avion.numAvion} hace fila para {(avion.estado == "aterrizando" ? "aterrizar" : "despegar")}");
                Console.ForegroundColor = ConsoleColor.White;

                // Agrego el avión a la cola de aviones
                colaAviones.Enqueue(avion);

                mutex.ReleaseMutex();   

            }
            catch (Exception)
            {
                Console.WriteLine("Error - Excepción en AvionFactory - GenerarAvion");
                throw;
            }

        }

    }
}
