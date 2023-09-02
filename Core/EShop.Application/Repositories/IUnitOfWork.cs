using EShop.Application.Repositories.CustomerRepository;
using EShop.Application.Repositories.OrderRepository;
using EShop.Application.Repositories.ProductRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Application.Repositories
{
    public interface IUnitOfWork
    {
        ICustomerReadRepository CustomerReadRepository { get; }
        IOrderReadRepository OrderReadRepository { get; }
        IProductReadRepository ProductReadRepository { get; }

        ICustomerWriteRepository CustomerWriteRepository { get; }
        IOrderWriteRepository OrderWriteRepository { get; }
        IProductWriteRepository ProductWriteRepository { get; }
    }
}
