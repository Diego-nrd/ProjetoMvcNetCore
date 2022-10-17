﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebSalesMvc.Data;
using WebSalesMvc.Models;
using WebSalesMvc.Services.Exceptions;

namespace WebSalesMvc.Services
{
    public class SellerService
    {
        private readonly WebSalesMvcContext _context;

        public SellerService(WebSalesMvcContext context)
        {
            _context = context;
        }

        public async Task<List<Seller>> FindAllAsync()
        {
            return await _context.Sellers.ToListAsync();
        }

        public async Task InsertAsync(Seller obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }

        public async Task<Seller> FindByIdAsync(int id)
        {
            return await _context.Sellers.Include(obj => obj.Department).FirstOrDefaultAsync(obj => obj.Id == id);

        }

        public async Task RemoveAsync(int id)
        {
            var obj = await _context.Sellers.FindAsync(id);
            _context.Sellers.Remove(obj);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Seller obj)
        {
            bool hasAny = await _context.Sellers.AnyAsync(x => x.Id == obj.Id);
            if (!hasAny)
            {
                throw new NotFoundException("Id not Found");
            }
            try
            {
                _context.Update(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbCouncureencyException(e.Message);
            }
        }

    }
}
