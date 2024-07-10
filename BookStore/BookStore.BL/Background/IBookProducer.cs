using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Models.Models;

namespace BookStore.BL.Background
{
    public interface IBookProducer
    {
        Task Produce(Book book);
    }
}
