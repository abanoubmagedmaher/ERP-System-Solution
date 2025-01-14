﻿using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastrucure.Data
{
    public class GenericRepostory<T> : IGenericRepostory<T> where T : BaseEntity
    {
        private readonly StoreContext _context;

        public GenericRepostory(StoreContext context)
        {
            _context = context;
        }
        public async Task<T> GetByIdAsync(int id) 
        {
           return await _context.Set<T>().FindAsync(id);
        }
        public async Task<IReadOnlyList<T>> ListAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetEntityWithSpec(ISpecification<T> spec)
        {
           return await ApplySpecifications(spec).FirstOrDefaultAsync();
        }

      

        public async Task<IReadOnlyList<T>> ListAllAsyncSpec(ISpecification<T> spec)
        {
            return await ApplySpecifications(spec).ToListAsync();
        }

        private IQueryable<T> ApplySpecifications(ISpecification<T> spec)
        {
            return SpecificationEvaluator<T>.GetQuery(_context.Set<T>().AsQueryable(), spec);
        }

        public async Task<int> CountAsync(ISpecification<T> Spec)
        {
            return await ApplySpecifications(Spec).CountAsync();
        }
    }
}
