﻿using HexaBlogAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HexaBlogAPI.Repositories
{
    public interface IRepository<T> 
    {
        IEnumerable<T> GetAll();

        Task<T> GetByIdAsync(int id);

        Task<T> AddAsync(T item);

        Task<T> UpdateAsync(int id, T item);

        Task<T> DeleteAsync(int id);
    }
}
