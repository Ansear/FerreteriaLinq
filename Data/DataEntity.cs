using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ferreteria.Entities;

namespace Ferreteria.Data;
public class DataEntity
{
    public List<Productos> _productos = new List<Productos>(){
            new Productos(){Id = 1,Nombre = "Tuerca Exagonal",PrecioUnt=2.23, Cantidad=3, StockMin=5, StockMax=100},
            new Productos(){Id = 2,Nombre = "Tornillo",PrecioUnt=1.10,Cantidad=800, StockMin=50, StockMax=2000},
            new Productos(){Id = 3,Nombre = "Taladro",PrecioUnt=50,Cantidad=20, StockMin=5, StockMax=30},
            new Productos(){Id = 4,Nombre = "Broca 3/4",PrecioUnt=2.30,Cantidad=100, StockMin=10, StockMax=380},
            new Productos(){Id = 5,Nombre = "Pegante pvc",PrecioUnt=8.5,Cantidad=20, StockMin=6, StockMax=100},
            new Productos(){Id = 6,Nombre = "Varilla 1/2",PrecioUnt=2.5,Cantidad=100, StockMin=20, StockMax=300}
        };
    public List<Factura> _factura = new List<Factura>(){
            new Factura(){NroFactura=1, Fecha= new DateOnly(2023, 01, 10), IdCliente=1, TotalFactura=22},
            new Factura(){NroFactura=2, Fecha= new DateOnly(2023, 10, 17), IdCliente=2, TotalFactura=22.3},
            new Factura(){NroFactura=3, Fecha= new DateOnly(2023, 01, 21), IdCliente=3, TotalFactura=34.2},
            new Factura(){NroFactura=4, Fecha= new DateOnly(2023, 11, 02), IdCliente=3, TotalFactura=34.2}
        };

    public List<DetalleFactura> _detalleFactura = new List<DetalleFactura>(){
            new DetalleFactura(){Id=1,NroFactura=1,IdProd=1,Cantidad=20,Valor=22},
            new DetalleFactura(){Id=2,NroFactura=1,IdProd=3,Cantidad=8,Valor=22},
            new DetalleFactura(){Id=3,NroFactura=1,IdProd=4,Cantidad=20,Valor=22},
            new DetalleFactura(){Id=4,NroFactura=3,IdProd=5,Cantidad=5,Valor=22},
            new DetalleFactura(){Id=4,NroFactura=4,IdProd=2,Cantidad=5,Valor=22},
            new DetalleFactura(){Id=4,NroFactura=2,IdProd=6,Cantidad=5,Valor=22},
        };
    public List<Cliente> _cliente = new List<Cliente>(){
            new Cliente(){Id = 1,Nombre = "Sebastian",Email="sebas@fmil.com"},
            new Cliente(){Id = 2,Nombre = "Andres",Email="andres@fmil.com"},
            new Cliente(){Id = 3,Nombre = "Santis",Email="santis@fmil.com"}
        };
}