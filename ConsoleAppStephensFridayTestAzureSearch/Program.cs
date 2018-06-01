using Microsoft.Azure.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppStephensFridayTestAzureSearch
{
    class Program
    {
        static void Main(string[] args)
        {
            string serviceName = "";
            string apiKey = "";

            SearchServiceClient searchClientApi = Helper.Initialize(serviceName, apiKey);
            ISearchIndexClient indexClientApi = searchClientApi.Indexes.GetClient(Helper.IndexName);

            Uploader uploader = new Uploader();
            uploader.Upload(indexClientApi);

            Searcher searcher = new Searcher();
            Console.WriteLine("Search by name.........\n");
            searcher.SearchDocuments(indexClientApi, "");
            Console.WriteLine(string.Empty);

            Console.WriteLine("Search by Id.........\n");
            searcher.SearchDocuments(indexClientApi, "Id eq '10000'");
            Console.WriteLine(string.Empty);

            Console.WriteLine("Search to check the employment status of a contact......");
            searcher.SearchDocuments(indexClientApi, "EmploymentStatus eq 'true'");
            Console.WriteLine(string.Empty);

            List<string> facets = new List<string>();
            facets.Add("Category");
            Console.ReadLine();



        }
    }
}
