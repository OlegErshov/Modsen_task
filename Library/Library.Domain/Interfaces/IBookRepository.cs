using Library.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.Interfaces
{
    public interface IBookRepository: IRepository<Book>
    {
        public  Task GetBookByISDN(string isdn);
    }
}
