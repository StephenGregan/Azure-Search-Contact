using Microsoft.Azure.Search;
using Microsoft.Azure.Search.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleAppStephensFridayTestAzureSearch
{
    class Uploader
    {
        private List<Contact> PrepareDocuments()
        {
            List<Contact> contactDocuments = new List<Contact>();
            Contact contact = new Contact();
            contactDocuments.Add(contact);
            return contactDocuments;
        }

        public void Upload(ISearchIndexClient indexClient)
        {
            try
            {
                var documents = PrepareDocuments();
                var batch = IndexBatch.Upload(documents);
                indexClient.Documents.Index(batch);
                Thread.Sleep(2000);
            }
            catch(IndexBatchException e)
            {
                Console.WriteLine($"Opps the following index failed...\n {e.IndexingResults.Where(r => !r.Succeeded).Select(r => r.Key)}");

            }
        }
    }
}
