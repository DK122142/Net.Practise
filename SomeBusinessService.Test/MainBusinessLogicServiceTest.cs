using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Moq;
using SomeBusinessService.Interfaces;
using SomeBusinessService.Services;
using SomeBusinessService.Models;

namespace SomeBusinessService.Test
{
    public class MainBusinessLogicServiceTest
    {
        [Test]
        public void Create_Product_DbManagerCallCreate()
        {
            var dbMangerMock = new Mock<IDBManager>();
            var service = new MainBusinessLogicService(dbMangerMock.Object);
            var newProduct = new Product();
            newProduct.Name = "TestName1";

            service.Create(newProduct);

            dbMangerMock.Verify(db => db.Create(It.IsAny<Product>()), Times.Once);
        }

        [Test]
        public void Create_Product_ArgumentExceptionDueToNameAbsence()
        {
            var dbMangerMock = new Mock<IDBManager>();
            var service = new MainBusinessLogicService(dbMangerMock.Object);
            var newProduct = new Product();

            newProduct.Id = Guid.NewGuid();
            newProduct.Count = 12;
            newProduct.LastUpdated = DateTime.Now;

            Assert.Throws<ArgumentException>(() => service.Create(newProduct));
        }
        
        [Test]
        public void Delete_Name_DbManagerCallDelete()
        {
            var dbMangerMock = new Mock<IDBManager>();
            var service = new MainBusinessLogicService(dbMangerMock.Object);
            var productName = "TestName1";

            service.Delete(productName);

            dbMangerMock.Verify(db => db.Delete(productName), Times.Once);
        }

        [Test]
        public void Delete_Name_NothingWhenNameEmpty()
        {
            var dbMangerMock = new Mock<IDBManager>();
            var service = new MainBusinessLogicService(dbMangerMock.Object);
            var productName = string.Empty;

            service.Delete(productName);

            dbMangerMock.Verify(db => db.Delete(It.IsAny<string>()), Times.Never);
        }
    }
}
