﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Commands.AuthorCommands.UpdateCommand
{
    public class UpdateAuthorCommand : IRequest<Unit>
    {
        public UpdateAuthorDTO updateAuthorDTO { get; set; }
    }
}
