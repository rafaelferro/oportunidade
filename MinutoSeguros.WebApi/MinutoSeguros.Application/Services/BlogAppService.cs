using MinutoSeguros.Application.Interfaces;
using MinutoSeguros.Application.ViewModel;
using MinutoSeguros.Domain.Interfaces;
using MinutoSeguros.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MinutoSeguros.Application.Services
{
    public class BlogAppService : IBlogAppService
    {
        public readonly IBlogRepository blogRepository;

        public BlogAppService(IBlogRepository blog)
        {
            blogRepository = blog;
        }

        public IEnumerable<BlogViewModel> getMainWords()
        {
            List<BlogViewModel> blogViewModels = new List<BlogViewModel>();
            List<string> vs = new List<string>();

            var ListArticles = blogRepository.GetXML();

            foreach (Blog b in ListArticles)
            {
                BlogViewModel Bvm = new BlogViewModel();
                Bvm.Title = b.Title;
                Bvm.totalcount = 0;

                string clearText = string.Concat(b.Title, b.Description, b.Bory);
                List<WordsCountViewModel> WcVM = new List<WordsCountViewModel>();

                var t = clearText.Split(' ');

                foreach (string a in t)
                {
                    vs.Add(a);
                }

                var mainWords = vs.Distinct().ToList();
                List<string> articles = blogRepository.GetWords();

                foreach (string a in mainWords)
                {
                    if (!string.IsNullOrWhiteSpace(articles.FirstOrDefault(e => e == a)))
                        continue;

                    int  count = vs.Count(c => c == a);

                    Bvm.totalcount += Convert.ToInt64(count);

                    if (WcVM.Count >= 10)
                    {
                        WordsCountViewModel w = WcVM.OrderBy(e => e.Count).FirstOrDefault();

                        if (w.Count < count)
                        {
                            WordsCountViewModel wc = new WordsCountViewModel();
                            wc.Word = a;
                            wc.Count = count;

                            int index = WcVM.FindIndex(e => e.Word == w.Word);
                            WcVM[index] = wc;
                        }
                    }
                    else
                    {
                        WcVM.Add(new WordsCountViewModel
                        {
                            Word = a,
                            Count = count
                        });
                    }
                }

                Bvm.wordsCountViewModels = WcVM;
                blogViewModels.Add(Bvm);

            }

            IEnumerable<BlogViewModel> blogs = blogViewModels.Select(a => a);
            return blogs;
        }
    }
}