namespace PistasAterrizaje{
    public class Helpers{
    public static void MostrarAvionAterrizando(){
      
        // Lee el archivo y muestra línea por línea  
        foreach (string line in System.IO.File.ReadLines(@".\images\AvionAterrizando.txt"))
        {  
            Console.ForegroundColor = ConsoleColor.Green;
            System.Console.WriteLine(line); 
            Console.ForegroundColor = ConsoleColor.White; 
        }  
        
    }

    public static void MostrarAvionDespegando(){

        // Lee el archivo y muestra línea por línea  
        foreach (string line in System.IO.File.ReadLines(@".\images\AvionDespegando.txt"))
        {  
            Console.ForegroundColor = ConsoleColor.Red;
            System.Console.WriteLine(line);  
            Console.ForegroundColor = ConsoleColor.White;
        } 
 
    }

    public static void MostrarLogo(){

        // Lee el archivo y muestra línea por línea  
        foreach (string line in System.IO.File.ReadLines(@".\images\Logo.txt"))
        {  
            Console.ForegroundColor = ConsoleColor.Blue;
            System.Console.WriteLine(line);  
            Console.ForegroundColor = ConsoleColor.White;
        } 
 
    }
}
}