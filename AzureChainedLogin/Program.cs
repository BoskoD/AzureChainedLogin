using Azure.Identity;
using Azure.Storage.Blobs;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace AzureChainedLogin
{
    internal class Program
    {
        private readonly static Uri docUrl = new("blob url");
        static async Task Main(string[] args)
        {
            var credential = new ChainedTokenCredential(new AzureCliCredential());
            var blobClient = new BlobClient(docUrl, credential);
            using MemoryStream stream = new();
            var blob = await blobClient.DownloadToAsync(stream);
            var blobTxt = Encoding.UTF8.GetString(stream.ToArray());

            Console.WriteLine(blobTxt);
        }
    }
}
