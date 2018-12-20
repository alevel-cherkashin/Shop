using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Shop.BusinnesLogic.Services;
using Shop.Data;
using Shop.Data.Repozitory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Tests
{
    [TestClass]
    public class ClientUnitTests
    {
        private Mock<UnitOfWork> _mockedUoW;

        private Mock<EFClientRepository> _mockedEfRepo;

        [TestInitialize]
        public void Initialize()
        {
            _mockedEfRepo = new Mock<EFClientRepository>();
            _mockedUoW = new Mock<UnitOfWork>();
        }

        [TestMethod]
        public void CheckLimited()
        {
            //Assing
            _mockedEfRepo.Setup(x => x.Get()).Returns(
                new List<Data.DataModels.Client>
                {
                    new Data.DataModels.Client
                    {
                        Id =1,
                        Name = "TC",
                        IsDeleted = false
                    }
                });
           
            _mockedUoW.Setup(x => x.EFClientRepository).Returns(_mockedEfRepo.Object);

            int number = 1;

            var clientServise = new ClientService(_mockedUoW.Object);
            //Action 

            var result = clientServise.GetLimited(number);

            //Assert
            Assert.AreEqual(number, result.Count);
        }

        [TestMethod]
        public void CheckSearch()
        {
            //Assing
            _mockedEfRepo.Setup(x => x.Get()).Returns(
                new List<Data.DataModels.Client>
                {
                    new Data.DataModels.Client
                    {
                        Id =1,
                        Name = "ABCD",
                        IsDeleted = false
                    },

                    new Data.DataModels.Client
                    {
                        Id =2,
                        Name = "ABCR",
                        IsDeleted = false
                    },

                    new Data.DataModels.Client
                    {
                        Id =3,
                        Name = "CDHFD",
                        IsDeleted = false
                    },

                    new Data.DataModels.Client
                    {
                        Id =4,
                        Name = "ACDOOF",
                        IsDeleted = false
                    }
                });

            _mockedUoW.Setup(x => x.EFClientRepository).Returns(_mockedEfRepo.Object);

            string searchParam = "CD";

            var clientServise = new ClientService(_mockedUoW.Object);
            //Action 

            var filteredList = clientServise.Search(searchParam);

            //Assert
            Assert.AreEqual(3, filteredList.Count);
        }
    }
}
