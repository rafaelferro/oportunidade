using System;
using System.Collections.Generic;
using System.Text;

namespace MinutoSeguros.Application.ViewModel
{
   public class BlogViewModel
    {
        public string Title { get; set; }
        public List<WordsCountViewModel> wordsCountViewModels { get; set; }
        public long totalcount { get; set; }


    }
}
