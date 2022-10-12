/*
 *  Enunciado:
 * 
 *  En un aeropuerto existen dos pistas de aterrizaje/despegue y una torre de control.
 *  Los aviones que tiene este aeropuerto como base realizan vuelos de reconocimiento.
 *  Programe el proceso avión y el proceso torre de tal manera que se eviten las colisiones en las pistas
 *  (una misma pista no puede ser usada simultáneamente por más de un avión)
 */

using PistasAterrizaje;
using PistasAterrizaje.Data;
using PistasAterrizaje.Factory;
public class Aeropuerto
{
    public static void Main()
    {

        Menu.MenuAeropuerto();

        Console.WriteLine("\t\tComenzando el trabajo de direccionar aviones: \n\n");

        // Inicializo las colas de despegue y aterrizaje
        Queue<Avion> colaAviones = new Queue<Avion>();
        // Inicializo un mutex general
        Mutex mutex = new Mutex();

        // Inicializo la torre para el control de 2 pistas de aterrizaje
        Torre torre = new Torre(2, colaAviones, mutex);
        AvionFactory factory = new AvionFactory(colaAviones, mutex);

        torre.Run();
        factory.Run();
  
    }
}