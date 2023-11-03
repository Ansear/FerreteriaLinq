using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BetterConsoleTables;
using Ferreteria.Data;
using Ferreteria.Entities;



namespace Ferreteria.Querys;
public class Querys
{
    static DataEntity _data = new();
    static List<Productos> _productos = _data._productos;
    static List<Factura> _factura = _data._factura;
    static List<DetalleFactura> _detalleFactura = _data._detalleFactura;
    public void Count()
    {
        var count = (from p in _productos select new { p.Nombre, p.PrecioUnt, p.Cantidad }).ToList();
        var table = new Table("Nombre", "Cantidad", "Precio c/u");
        count.ForEach(p => table.AddRow(p.Nombre, p.Cantidad, $"${p.PrecioUnt}"));
        table.Config = TableConfiguration.UnicodeAlt();
        Console.WriteLine(table.ToString());
    }

    public void ProductoMin()
    {
        var products = _productos.Where(p => p.Cantidad < p.StockMin).Select((p) => new { p.Nombre }).ToList();
        if (products.Count() < 1)
            Console.WriteLine("Todos los productos estan bien");
        else
        {
            var table = new Table("Nombre Producto");
            products.ForEach(p => table.AddRow(p.Nombre));
            table.Config = TableConfiguration.UnicodeAlt();
            Console.WriteLine(table.ToString());
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
            var producto = (from p in productos select new { p.Nombre, p.Cantidad, p.StockMax }).ToList();
            var table = new Table("Nombre Producto", "Cantidad a Comprar");
            producto.ForEach(p => table.AddRow(p.Nombre, p.Cantidad));
            table.Config = TableConfiguration.UnicodeAlt();
            Console.WriteLine(table.ToString());
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
            var table = new Table("Nro Facturas", "Fecha Factura", "IdCliente");
            facturas.ForEach(p => table.AddRow(p.NroFactura, p.Fecha, p.IdCliente));
            table.Config = TableConfiguration.UnicodeAlt();
            Console.WriteLine(table.ToString());
            Console.WriteLine("╔════════════════════╗");
            Console.WriteLine($"║Total Facturas: {facturas.Count()}   ║");
            Console.WriteLine("╚════════════════════╝");
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
            var table = new Table("Nombre Producto");
            resul.ForEach(p => table.AddRow(p.nombre));
            table.Config = TableConfiguration.UnicodeAlt();
            Console.WriteLine(table.ToString());
        }
    }

    public void Inventario()
    {
        var total = (from s in _productos select new { s.PrecioUnt, s.Cantidad }).ToList();
        double contTotal = 0;
        total.ForEach(x => contTotal += x.PrecioUnt * x.Cantidad);
        var table = new Table("El valor del inventario actual");
        table.AddRow($"${contTotal}");
        table.Config = TableConfiguration.UnicodeAlt();
        Console.WriteLine(table.ToString());
    }

}