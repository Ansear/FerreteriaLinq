using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ferreteria.Entities;
public class Data
{
    List<Cliente> _cliente = new List<Cliente>(){
            new Cliente(){Id = 1,Nombre = "Sebastian",Email="sebas@fmil.com"},
            new Cliente(){Id = 2,Nombre = "Andres",Email="andres@fmil.com"},
            new Cliente(){Id = 3,Nombre = "Santis",Email="santis@fmil.com"}
        };




    
}