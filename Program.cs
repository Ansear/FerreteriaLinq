using System;
using Ferreteria.Querys;
internal class Program
{
    private static void Main(string[] args)
    {
        Querys querys = new Querys();
        Console.BackgroundColor = ConsoleColor.Black;
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Clear();

        while (true)
        {
            Console.Clear();

            Console.WriteLine("╔════════════════════════════════════════════════╗");
            Console.WriteLine("║                Menú Principal                  ║");
            Console.WriteLine("╠════════════════════════════════════════════════╣");
            Console.WriteLine("║ 1. Productos del inventario                    ║");
            Console.WriteLine("║ 2. Productos a punto de agotarse               ║");
            Console.WriteLine("║ 3. Productos a comprar y cantidad a comprar    ║");
            Console.WriteLine("║ 4. Total de facturas de enero de 2023          ║");
            Console.WriteLine("║ 5. Productos vendidos en una factura específica║");
            Console.WriteLine("║ 6. Calcular el valor total del inventario      ║");
            Console.WriteLine("║ 7. Salir                                       ║");
            Console.WriteLine("╚════════════════════════════════════════════════╝");

            Console.Write("Por favor, elija una opción: ");
            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    Console.Clear();
                    Console.WriteLine($"Cantidad de productos en Inventario: {querys.Count()}");
                    break;
                case "2":
                    Console.Clear();
                    querys.ProductoMin();
                    break;
                case "3":
                    Console.Clear();
                    querys.ProductoComprar();
                    break;
                case "4":
                    Console.Clear();
                    querys.Enero2023();
                    break;
                case "5":
                    Console.Clear();
                    Console.Write("Ingrese el numero de factura: ");
                    int num = Convert.ToInt32(Console.ReadLine());
                    querys.ProductosFactura(num);
                    break;
                case "6":
                    Console.Clear();
                    Console.WriteLine($"El valor del inventario actual es: {querys.Inventario()}");
                    break;
                case "7":
                    Console.Clear();
                    Console.WriteLine("Saliendo del programa. ¡Hasta luego!");
                    return;
                default:
                    Console.Clear();
                    Console.WriteLine("Opción no válida. Por favor, elija una opción válida.");
                    break;
            }

            Console.WriteLine("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
        }
    }
}