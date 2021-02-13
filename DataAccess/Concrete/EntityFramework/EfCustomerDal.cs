using Core.DataAcces;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCustomerDal : EfEntityRepositoryBase<Customer, CarRentalContext>, ICustomerDal
    {
        public List<CustomerDetailDto> GetCustomerDetails(Expression<Func<Customer, bool>> filter = null)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var result = from c in filter is null
                             ? context.Customers
                             : context.Customers.Where(filter)
                             join u in context.Users
                             on c.UserId equals u.Id                          
                             select new CustomerDetailDto
                             {
                                 Id = c.Id,
                                 UserId = u.Id,
                                 FirstName = u.FirstName,
                                 LastName = u.LastName,
                                 Mail = u.Mail,
                                 CompanyName = c.CompanyName                                 
                             };

                return result.ToList();
            }
        }
    }
}
