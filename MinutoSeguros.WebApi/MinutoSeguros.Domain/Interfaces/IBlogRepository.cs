using MinutoSeguros.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MinutoSeguros.Domain.Interfaces
{
    public interface IBlogRepository
    {

       public IEnumerable<Blog> GetXML();
        public List<string> GetWords();


    }
}
