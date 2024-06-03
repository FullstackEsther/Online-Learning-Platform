using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.RepositoryInterfaces;
using Infrastucture.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastucture.Repository.Implementation
{
    public class PaymentRepository : BaseRepository<Payment>, IPaymentRepository
    {
        public PaymentRepository(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }
        public async Task<IEnumerable<Payment>> GetAllPayment()
        {
            return await _applicationContext.Payments.Include(x => x.Enrollment).ToListAsync();
        }

        public async Task<IEnumerable<Payment>> GetAllPayment(Expression<Func<Payment, bool>> predicate)
        {
            return await _applicationContext.Payments.Include(x => x.Enrollment).Where(predicate).ToListAsync();
        }

        public async Task<Payment> GetPayment(Expression<Func<Payment, bool>> predicate)
        {
            return  await _applicationContext.Payments.Include(x => x.Enrollment).FirstOrDefaultAsync(predicate);
        }
    }
}