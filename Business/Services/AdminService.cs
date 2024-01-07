using Business.Models;
using DataAccess.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public interface IUserService
    {
        IQueryable<AdminModel> Query();

    }
    public class AdminService : IUserService
    {
        private readonly Db _db;

        public AdminService(Db db)
        {
            _db = db;
        }

        public IQueryable<AdminModel> Query()
        {
            return _db.Admins.OrderByDescending(e => e.Email)
               .Select(e => new AdminModel()
               {
                   Id = e.Id,
                   Email = e.Email,
                   Password = e.Password
               });
        }
    }
}
