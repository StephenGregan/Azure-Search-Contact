using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Search;
using Microsoft.Azure.Search.Models;

namespace ConsoleAppStephensFridayTestAzureSearch
{
    class Helper
    {
        public const string IndexName = "contactazuresearch";

        public static SearchServiceClient Initialize(string serviceName, string apiKey)
        {
            SearchServiceClient serviceClient = new SearchServiceClient(serviceName, new SearchCredentials(apiKey));
            DeleteIfIndexExists(serviceClient);
            return serviceClient;
        }

        public static void CreateIndex(SearchServiceClient client)
        {
            var IndexDefinition = new Index()
            {
                Name = IndexName,
                Fields = new[]
                {
                    new Field("Id", DataType.String)                                              { IsKey = true},
                    new Field("Id", DataType.String)                                              { IsSearchable = true, IsFacetable = true, IsRetrievable = true},
                    new Field("Id", DataType.String)                                              { IsSearchable = true, IsFacetable = true, IsRetrievable = true},
                    new Field("Id", DataType.String)                                              { IsSearchable = true, IsFacetable = true, IsRetrievable = true},
                    new Field("Id", DataType.String)                                              { IsSearchable = true, IsFacetable = true, IsRetrievable = true},
                    new Field("Id", DataType.String)                                              { IsSearchable = true, IsFacetable = true, IsRetrievable = true},
                    new Field("Id", DataType.String)                                              { IsSearchable = true, IsFacetable = true, IsRetrievable = true},
                    new Field("Id", DataType.String)                                              { IsSearchable = true, IsFacetable = true, IsRetrievable = true},
                    new Field("Id", DataType.String)                                              { IsSearchable = true, IsFacetable = true, IsRetrievable = true},


                }
            };

            client.Indexes.Create(IndexDefinition);
        }

        public static void DeleteIfIndexExists(SearchServiceClient client)
        {
            if (client.Indexes.Exists(IndexName))
            {
                client.Indexes.Delete(IndexName);
            }
        }
    }
}
