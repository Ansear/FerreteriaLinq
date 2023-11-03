using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ferreteria.Data;
using Ferreteria.Entities;



namespace Ferreteria.Querys;
public class Querys
{
    static DataEntity _data = new ();
    static List<Productos> _productos = _data._productos;
    static List<Factura> _factura = _data._factura;
    static List<DetalleFactura> _detalleFactura = _data._detalleFactura;
    public void Count()
    {
        var count = (from p in _productos select new { p.Nombre, p.PrecioUnt, p.Cantidad }).ToList();
            Console.WriteLine("╔════════════════════════════════════════════════════════╗");
            Console.WriteLine("║                   Productos                            ║");
            Console.WriteLine("╚════════════════════════════════════════════════════════╝");
            count.ForEach(p => Console.Write($"║Nombre: {p.Nombre}".PadRight(25) + $"Cantidad: {p.Cantidad}".PadRight(15) +$"Precio c/u: {p.PrecioUnt}║\n"));
            Console.WriteLine("╚════════════════════════════════════════════════════════╝");
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
        var factu = _factura.Where(f => f.NroFactura == NumFactura);
        if (factu.Count() < 1)
            Console.WriteLine("No hay Facturas con ese numero");
        else
        {
            List<DetalleFactura> detaF = _detalleFactura.Where(df => df.NroFactura == NumFactura).ToList();
            var resul = _productos.Join(
                detaF,
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
        var total = (from s in _productos select new { s.PrecioUnt, s.Cantidad }).ToList();
        double contTotal = 0;
        foreach (var item in total)
        {
            contTotal += item.PrecioUnt * item.Cantidad;
        }
        return contTotal;
    }

}