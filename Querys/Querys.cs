using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ferreteria.Entities;


namespace Ferreteria.Querys;
public class Querys
{
    List<Productos> _productos = new List<Productos>(){
            new Productos(){Id = 1,Nombre = "Tuerca Exagonal",PrecioUnt=2.23, Cantidad=3, StockMin=5, StockMax=100},
            new Productos(){Id = 2,Nombre = "Tornillo",PrecioUnt=1.10,Cantidad=800, StockMin=50, StockMax=2000},
            new Productos(){Id = 3,Nombre = "Taladro",PrecioUnt=50,Cantidad=20, StockMin=5, StockMax=30},
            new Productos(){Id = 4,Nombre = "Broca 3/4",PrecioUnt=2.30,Cantidad=100, StockMin=10, StockMax=380},
            new Productos(){Id = 5,Nombre = "Pegante pvc",PrecioUnt=8.5,Cantidad=20, StockMin=6, StockMax=100},
            new Productos(){Id = 6,Nombre = "Varilla 1/2",PrecioUnt=2.5,Cantidad=100, StockMin=20, StockMax=300}
        };
    List<Factura> _factura = new List<Factura>(){
            new Factura(){NroFactura=1, Fecha= new DateOnly(2023, 01, 10), IdCliente=1, TotalFactura=22},
            new Factura(){NroFactura=2, Fecha= new DateOnly(2023, 10, 17), IdCliente=2, TotalFactura=22.3},
            new Factura(){NroFactura=3, Fecha= new DateOnly(2023, 01, 21), IdCliente=3, TotalFactura=34.2},
            new Factura(){NroFactura=4, Fecha= new DateOnly(2023, 11, 02), IdCliente=3, TotalFactura=34.2}
        };

    List<DetalleFactura> _detalleFactura = new List<DetalleFactura>(){
            new DetalleFactura(){Id=1,NroFactura=1,IdProd=1,Cantidad=20,Valor=22},
            new DetalleFactura(){Id=2,NroFactura=1,IdProd=3,Cantidad=8,Valor=22},
            new DetalleFactura(){Id=3,NroFactura=1,IdProd=4,Cantidad=20,Valor=22},
            new DetalleFactura(){Id=4,NroFactura=3,IdProd=1,Cantidad=5,Valor=22}
        };
    List<Cliente> _cliente = new List<Cliente>(){
            new Cliente(){Id = 1,Nombre = "Sebastian",Email="sebas@fmil.com"},
            new Cliente(){Id = 2,Nombre = "Andres",Email="andres@fmil.com"},
            new Cliente(){Id = 3,Nombre = "Santis",Email="santis@fmil.com"}
        };
    public int Count()
    {
        int count = _productos.Count();
        return count;
    }

    public void ProductoMin()
    {
        var products = _productos.Where(p => p.Cantidad < p.StockMin).Select((p) => new { p.Nombre }).ToList();
        if (products.Count() < 1)
            Console.WriteLine("Todos los productos estan bien");
        else
        {
            products.ForEach(p => Console.WriteLine($"Producto: {p.Nombre}"));
        }
    }

    public void ProductoComprar()
    {
        Console.Clear();
        var productos = _productos.Where(p => p.Cantidad < p.StockMin).ToList();
        if (productos.Count() < 1)
            Console.WriteLine("No hay productos para comprar");
        else
        {
            var producto = from p in productos select new { p.Nombre, p.Cantidad, p.StockMax };
            Console.WriteLine("Productos a Comprar: ");
            foreach (var item in producto)
            {
                Console.WriteLine($" Producto:{item.Nombre} -- Cantidad:{item.StockMax - item.Cantidad}");
            }
        }
    }

    public void Enero2023()
    {
        Console.Clear();
        var facturas = _factura.Where(p => p.Fecha <= new DateOnly(2023, 01, 30) || p.Fecha <= new DateOnly(2023, 01, 01)).Select((f) => new { f.NroFactura, f.Fecha, f.IdCliente }).ToList();
        if (facturas.Count() < 1)
            Console.WriteLine("No hay facturas del mes de enero");
        else
        {
            facturas.ForEach(f => Console.WriteLine($"NumFactura:{f.NroFactura} -- Fecha:{f.Fecha} -- IdCliente:{f.IdCliente}"));
        }
    }

    public void ProductosFactura(int NumFactura)
    {
        Console.Clear();
        var num = _detalleFactura.Where(df => df.NroFactura == NumFactura);
        if (num.Count() < 1)
        {
            Console.WriteLine("No hay Facturas con ese numero");
        }
        else
        {
            var resul = _productos.Join(
                num,
                p => p.Id,
                df => df.IdProd,
                (p, df) => new
                {
                    nombre = p.Nombre
                }).ToList();
            resul.ForEach(p => Console.Write($"Producto: {p.nombre} \n"));
        }
    }

    public double Inventario()
    {
        Console.Clear();
        var total =( from s in _productos select new {s.PrecioUnt, s.Cantidad}).ToList();
        double contTotal = 0;
        foreach (var item in total)
        {
            contTotal += item.PrecioUnt*item.Cantidad;
        }
        return contTotal;
    }

}