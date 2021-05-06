using Lil.Products.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lil.Products.DAL
{
    //la intención con esta interfaz es implementar todas las abstracciones
    //de la funcionalidad que necesitamos para este proveedor de datos
    public interface IProductsProvider
    {
        public Task<Product> GetAsync(string id);
    }
}
