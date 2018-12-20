using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shop.Data;
using Shop.Data.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Shop.Tests
{
    [TestClass]
    public class ClientIntegrationTest
    {
        private readonly IUnitOfWork _unitOfWork= new UnitOfWork();

        //public ClientIntegrationTest(IUnitOfWork unitOfWork)
        //{
        //    _unitOfWork = unitOfWork;
        //}


        [TestMethod]
        public void Test_DbRecording()
        {
            // Assign 
            using (var ctx = new ShopDataModel())
            {
                // Act
                var isExist = ctx.Client.Any();
                // Assert
                Assert.IsTrue(isExist);
            }
        }

        [TestMethod]
        public void Test_ClientAdding()
        {
            // Assign 
            using (var ctx = new ShopDataModel())
            {
                int count = ctx.Client.Count();

                using (var ts = new TransactionScope())
                {
                    // Act
                    _unitOfWork.EFClientRepository.Add(
                        new Client
                        {
                            IsDeleted = false,
                            Name = "Test Client2",
                        });

                    _unitOfWork.Save();
                    // Assert
                    Assert.AreEqual(count + 1, ctx.Client.Count());
                }
            }
        }

        [TestMethod]
        public void Test_ClientGetAll()
        {
            // Assign 
            using (var ctx = new ShopDataModel())
            {
                var count = ctx.Client.Count(x => !x.IsDeleted.HasValue || !x.IsDeleted.Value);
                // Act
                var repoCount = _unitOfWork.EFClientRepository.Get().Count;
                // Assert

                Assert.AreEqual(count, repoCount);
            }
        }

        [TestMethod]
        public void Test_ClientGetDeyeits_ExistingClient()
        {
            // Assign 
            using (var ctx = new ShopDataModel())
            {
                var client = ctx.Client.FirstOrDefault(x=>x.IsDeleted.HasValue||x.IsDeleted.Value);
                // Act
                if (client == null)
                {
                    Assert.IsTrue(true, "Empty recordset");
                    return;
                }

                var uOwClient = _unitOfWork.EFClientRepository.GetDeteils(client.Id);
                // Assert
                Assert.AreEqual(client.Id, uOwClient.Id);
                Assert.AreEqual(client.Name, uOwClient.Name);
                Assert.AreEqual(client.IsDeleted, uOwClient.IsDeleted);
            }
        }

        [TestMethod]
        public void Test_ClientGetDeyeits_NullableClient()
        {
            // Assign 
            using (var ctx = new ShopDataModel())
            {
                var maxId = ctx.Client.Max(x => x.Id);
                // Act
                var client = _unitOfWork.EFClientRepository.GetDeteils(maxId);

                // Assert
                Assert.IsNull(client);
            }
        }

        [TestMethod]
        public void Test_ClientGetDeyeits_DeletedClient()
        {
            // Assign 
            using (var ctx = new ShopDataModel())
            {
                var deletedClient = ctx.Client.FirstOrDefault(x=>x.IsDeleted == true);
                // Act
                if (deletedClient == null)
                {
                    Assert.IsTrue(true, "No Deleted client");
                    return;
                }

                var client = _unitOfWork.EFClientRepository.GetDeteils(deletedClient.Id);

                // Assert
                Assert.IsNull(client);
            }
        }

        [TestMethod]
        public void Test_ClientUpdate()
        {
            // Assign 
            using (var ctx = new ShopDataModel())
            {
                using (var ts = new TransactionScope())
                {
                    var client = ctx.Client.FirstOrDefault(x => x.IsDeleted.HasValue || x.IsDeleted.Value);
                    // Action
                    if (client == null)
                    {
                        Assert.IsTrue(true, "Empty recordset");
                        return;
                    }

                    client.Name = "!";
                    _unitOfWork.EFClientRepository.Update(client);

                    _unitOfWork.Save();
                    var uOwClient = _unitOfWork.EFClientRepository.GetDeteils(client.Id);
                    // Assert
                    Assert.AreEqual(client.Id, uOwClient.Id);
                    Assert.AreEqual(client.Name, uOwClient.Name);
                    Assert.AreEqual(client.IsDeleted, uOwClient.IsDeleted);
                }
            }
        }
    }
}
