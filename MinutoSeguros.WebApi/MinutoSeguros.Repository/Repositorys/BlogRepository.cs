using MinutoSeguros.Domain.Interfaces;
using MinutoSeguros.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;

namespace MinutoSeguros.Repository.Repositorys
{
    public class BlogRepository : IBlogRepository
    {
        static string Url = "https://www.minutoseguros.com.br/blog/feed/";
        private bool isItem = false;
        private bool isTitle = false;
        private bool isDescripition = false;
        private bool isBory = false;

        public IEnumerable<Blog> GetXML()
        {

            List<Blog> Blogs = new List<Blog>();
            string title = "";
            string descripition = "";
            string bory = "";

            using (XmlTextReader reader = new XmlTextReader(Url))
            {
                while (reader.Read())
                {
                    if (Blogs.Count >= 10)
                        break;

                    if (reader.Name == "item" && reader.NodeType == XmlNodeType.Element)
                        isItem = true;

                    if (reader.Name == "item" && reader.NodeType == XmlNodeType.EndElement)
                    {
                        isItem = false;
                        Blogs.Add(new Blog
                        {
                            Title = title,
                            Description = descripition,
                            Bory = bory
                        });

                        continue;
                    }

                    if (isItem)
                    {

                        if (reader.Name == "title" && reader.NodeType == XmlNodeType.Element)
                            isTitle = true;

                        if (reader.Name == "title" && reader.NodeType == XmlNodeType.EndElement)
                        {
                            isTitle = false;
                            continue;
                        }

                        if (reader.Name == "description" && reader.NodeType == XmlNodeType.Element)
                            isDescripition = true;

                        if (reader.Name == "description" && reader.NodeType == XmlNodeType.EndElement)
                        {
                            isDescripition = false;
                            continue;
                        }

                        if (reader.Name == "content:encoded" && reader.NodeType == XmlNodeType.Element)
                            isBory = true;

                        if (reader.Name == "content:encoded" && reader.NodeType == XmlNodeType.EndElement)
                        {
                            isBory = false;
                            continue;
                        }

                        if (reader.NodeType == XmlNodeType.Text)
                            if (isTitle)
                                title = StripHTML(reader.Value);


                        if (reader.NodeType == XmlNodeType.CDATA)
                        {
                            if (isDescripition)
                                descripition = StripHTML(reader.Value);
                            if (isBory)
                                bory = StripHTML(reader.Value);
                        }
                    }
                }
            }

            IEnumerable<Blog> Blog = Blogs.Select(a => a);

            return Blog;
        }

        public static string StripHTML(string input)
        {
            return Regex.Replace(input, "<.*?>", String.Empty);
        }

        public List<string> GetWords()
        {
            List<string> words = new List<string>();

            words.Add("a");
            words.Add("ao");
            words.Add("aos");
            words.Add("as");
            words.Add("às");
            words.Add("até");
            words.Add("Com");
            words.Add("da");
            words.Add("das");
            words.Add("de");
            words.Add("dê");
            words.Add("do");
            words.Add("dos");
            words.Add("e");
            words.Add("é");
            words.Add("em");
            words.Add("mas");
            words.Add("na");
            words.Add("nas");
            words.Add("no");
            words.Add("nos");
            words.Add("o");
            words.Add("os");
            words.Add("ou");
            words.Add("por");
            words.Add("pôr");
            words.Add("pra");
            words.Add("que");
            words.Add("se");
            words.Add("sem");
            words.Add("seu");
            words.Add("sua");
            words.Add("te");
            words.Add("um");
            words.Add("uma");
            words.Add("só");
            words.Add("com");
            words.Add("para");
            words.Add("são");
            words.Add("mais");
            words.Add("para");
            words.Add("não");
            words.Add("como");
            words.Add("R$");

            






            return words;


        }
    }
}
