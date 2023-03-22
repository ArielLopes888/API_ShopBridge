using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Infra.Interfaces
{
    public interface IProductsRepository : IBaseRepository<Products>
    {
        Task<List<Products>> SearchByName (string name);
        Task<List<Products>> SearchByCategory (string category);

    }
}

/*interface that inherits from Base and defines a contract for a repository 
 that must implement basic CRUD operations (Create, Read, Update and Delete),*/