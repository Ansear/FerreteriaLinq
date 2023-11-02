using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ferreteria.Entities;
public class DetalleFactura
{
    public int Id { get; set; }
    public int NroFactura { get; set; }
    public int IdProd { get; set; }
    public int Cantidad { get; set; }
    public double Valor { get; set; }
}