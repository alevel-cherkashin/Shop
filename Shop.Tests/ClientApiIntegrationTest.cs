using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shop.BusinnesLogic.Models;
using Shop.Data.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Shop.Tests
{
    [TestClass]
    public class ClientApiIntegrationTest
    {
        private HttpClient _httpClient;
        private ShopDataModel _ctx;
        //private int _id = 14;

        [TestInitialize]
        public void Initializer()
        {
            _ctx = new ShopDataModel();
            _httpClient = new HttpClient();

            // Update port # in the following line.
            _httpClient.BaseAddress = new Uri("http://localhost:54917/api/");
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            //  _ctx.Database.ExecuteSqlCommand(@"INSERT INTO Client ([Name], IsDeleted) VALUES ('Test api client', 0)");
        }

        [TestCleanup]
        public void Destroyer()
        {
            // _ctx.Database.ExecuteSqlCommand($"DELETE FROM Client Where Id = {_id}");
        }

        [TestMethod]
        public async Task Check_GetAll()
        {
            // Assign 
            var count = _ctx.Client.Count(c => c.IsDeleted.HasValue || c.IsDeleted.Value);
            // Act
            var result = await _httpClient.GetAsync("Clients");
            Assert.AreEqual(System.Net.HttpStatusCode.OK, result.StatusCode);

            var list = await result.Content.ReadAsAsync<List<Client>>();

            // Assert
            Assert.AreEqual(count, list.Count);
        }

        [TestMethod]
        public async Task Check_Add()
        {
            // Assign 
            var client = new ClientViewModel()
            {
                Name = "Test"
            };
            
            // Act
            var result = await _httpClient.PostAsJsonAsync("clients", client);

            // Assert
            Assert.AreEqual(System.Net.HttpStatusCode.BadRequest, result.StatusCode);
        }

    }
}
