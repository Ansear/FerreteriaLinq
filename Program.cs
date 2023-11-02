using Ferreteria.Querys;

internal class Program
{
    private static void Main(string[] args)
    {
        Querys querys = new Querys();

        //Console.WriteLine(querys.Count());//Cantidad de productos
        
        //querys.ProductoMin();//Productos Que estan a punto de agotarse

        //querys.ProductoComprar();//Productos y cantidad para comprar
        
        //querys.Enero2023();//Facturas del mes de enero
        
        Console.Write("Ingrese el numero de factura: ");
        int num = Convert.ToInt32(Console.ReadLine());
        querys.ProductosFactura(num);
    }
}