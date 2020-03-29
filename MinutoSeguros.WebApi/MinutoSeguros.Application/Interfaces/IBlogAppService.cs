using MinutoSeguros.Application.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace MinutoSeguros.Application.Interfaces
{
   public interface IBlogAppService
    {
        public IEnumerable<BlogViewModel> getMainWords();

    }
}
