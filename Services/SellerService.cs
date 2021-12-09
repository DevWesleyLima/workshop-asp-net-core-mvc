using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesWebMvc.Models;
using SalesWebMvc.Data;

namespace SalesWebMvc.Services
{
    public class SellerService
    {
        private readonly SalesWebMvcContext Context;

        public SellerService(SalesWebMvcContext context)
        {
            Context = context;
        }

        public List<Seller> FindAll()
        {
            return Context.Seller.ToList();
        }

        public void Insert(Seller obj)
        {            
            Context.Add(obj);
            Context.SaveChanges();
        }

        public Seller FindById(int id)
        {
            return Context.Seller.FirstOrDefault(obj => obj.Id == id);
        }

        public void Remove(int id)
        {
            var obj = Context.Seller.Find(id);
            Context.Seller.Remove(obj);
            Context.SaveChanges();
        }
    }
}
