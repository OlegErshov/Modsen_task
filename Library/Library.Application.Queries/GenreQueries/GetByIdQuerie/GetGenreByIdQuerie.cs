﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Queries.GenreQueries.GetByIdQuerie
{
    public class GetGenreByIdQuerie : IRequest<GenreDTO>
    {
        public Guid Id { get; set; }
    }
}
