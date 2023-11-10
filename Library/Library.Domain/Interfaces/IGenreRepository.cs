﻿using Library.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.Interfaces
{
    public interface IGenreRepository : IRepository<Genre>
    {
        Task<Genre> FirstOrDefault(Expression<Func<Genre, bool>> filter, CancellationToken cancellationToken);
    }
}
