﻿using Core.Entities;
using Core.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IGenericRepostory<T> where T: BaseEntity
    {
        Task<IReadOnlyList<T>> ListAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<T> GetEntityWithSpec(ISpecification<T> spec);
        Task<IReadOnlyList<T>>  ListAllAsyncSpec(ISpecification<T> spec);
    }
}
