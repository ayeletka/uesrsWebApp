



namespace myWebApp.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.Azure.Documents.Client;
    using Microsoft.Azure.Documents;
    using User = myWebApp.Models.User;
    using Newtonsoft.Json.Linq;

    public class CosmosDbUsersRepository : IUsersRepository
    {
        private static readonly string EndpointUrl = "https://my-users-db.documents.azure.com:443/";
        private static readonly string DatabaseId = "UsersDB";
        private static readonly string CollectionId = "0";
        private static readonly string AuthorizationKey = "vqH5loaTDkNmqkzgA1r5MEorYdaLKDjN7oHzTajcXLy1DkxWE5OCBngoB518Te7CEDhveMCpudmVhIatZpSM0g==";
        private static readonly Uri CollectionLink = UriFactory.CreateDocumentCollectionUri(DatabaseId, CollectionId);
        private static readonly DocumentClient Client = new DocumentClient(new Uri(EndpointUrl), AuthorizationKey);
    
        public async Task AddUser(User user)
        {
            Document created = await Client.CreateDocumentAsync(CollectionLink, user);
        }

        public async Task<List<string>> GetUsers()
        {
            List<string> usersList = new List<string>();
            var docs = await Client.ReadDocumentFeedAsync(CollectionLink, new FeedOptions { MaxItemCount = 100 });

            foreach (var d in docs)
            {
                JObject json = JObject.Parse(d.ToString());
                string name = json.GetValue("Name").ToString();
                usersList.Add(name);
            }

            return usersList;
        }
    }
}