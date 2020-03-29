using Microsoft.Extensions.DependencyInjection;
using MinutoSeguros.Application.Interfaces;
using MinutoSeguros.Application.Services;
using MinutoSeguros.Domain.Interfaces;
using MinutoSeguros.Repository.Repositorys;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace MinutoSegurosTest
{
   public class CountWorsTest
    {

        public IBlogAppService blogAppService;

        public CountWorsTest()
        {
            var service = new ServiceCollection();

            service.AddTransient<IBlogAppService, BlogAppService>();
            service.AddTransient<IBlogRepository, BlogRepository>();



            var provider = service.BuildServiceProvider();
            blogAppService = provider.GetService<IBlogAppService>();
        }


        [Fact]
        public void totalcountTest()
        {

        }


    }
}
