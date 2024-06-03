using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.RepositoryInterfaces
{
    public interface IPaymentRepository : IBaseRepository<Payment>
    {
        Task<Payment> GetPayment(Expression<Func<Payment, bool>> predicate);
        Task<IEnumerable<Payment>> GetAllPayment();
        Task<IEnumerable<Payment>> GetAllPayment(Expression<Func<Payment, bool>> predicate);
    }
}