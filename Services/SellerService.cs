using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesWebMvc.Models;
using SalesWebMvc.Data;
using Microsoft.EntityFrameworkCore;
using SalesWebMvc.Services.Exceptions;

namespace SalesWebMvc.Services
{
    public class SellerService
    {
        private readonly SalesWebMvcContext Context;

        public SellerService(SalesWebMvcContext context)
        {
            Context = context;
        }

        public async Task<List<Seller>> FindAllAsync()
        {
            return await Context.Seller.ToListAsync();
        }

        public async Task InsertAsync(Seller obj)
        {            
            Context.Add(obj);
            await Context.SaveChangesAsync();
        }

        public async Task<Seller> FindByIdAsync(int id)
        {
            return await Context.Seller.Include(obj => obj.Department).FirstOrDefaultAsync(obj => obj.Id == id);
        }

        public async Task RemoveAsync(int id)
        {
            try
            {
                var obj = await Context.Seller.FindAsync(id);
                Context.Seller.Remove(obj);
                await Context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                throw new IntegrityException("Unable to process this operation! This seller has sales linked to its user, please check.");                
            }
        }

        public async Task UpdateAsync(Seller obj)
        {
            bool hasAny = await Context.Seller.AnyAsync(x => x.Id == obj.Id);
            if (!hasAny)
            {
                throw new NotFoundException("Id not found!");
            }

            try
            {
                Context.Update(obj);
                await Context.SaveChangesAsync();
            }

            catch (DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }

    }
}
