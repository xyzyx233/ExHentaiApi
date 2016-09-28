using ExHentaiApi.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using ExHentaiApi.Expressions;

namespace ExHentaiApi.Test
{
    class Program
    {
        static void Main(string[] args)
        {

            var ex = new ExHentaiApi();

            var data = ex.GetGalleryTokens();
            Console.WriteLine(data.ShowingStart);
            Console.WriteLine(data.ShowingEnd);
            Console.WriteLine(data.SearchCount);
            Console.WriteLine(data.PageCount);

            foreach (var item in data)
            {
                Console.WriteLine(item.ToString());
            }

            Console.ReadLine();
        }

    }
}
