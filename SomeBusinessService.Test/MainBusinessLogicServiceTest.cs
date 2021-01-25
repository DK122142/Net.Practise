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

            Assert.Throws<ArgumentException>(() => service.Create(newProduct));
        }

        [Test]
        public void Create_Product_ArgumentExceptionDueToIsEmpty()
        {
            var dbMangerMock = new Mock<IDBManager>();
            var service = new MainBusinessLogicService(dbMangerMock.Object);
            var newProduct = new Product();

            newProduct.Name = string.Empty;

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
        public void Delete_Name_NothingWhenNameNull()
        {
            var dbMangerMock = new Mock<IDBManager>();
            var service = new MainBusinessLogicService(dbMangerMock.Object);

            service.Delete(null);

            dbMangerMock.Verify(db => db.Delete(null), Times.Never);
        }

        [Test]
        public void Delete_Name_NothingWhenNameEmpty()
        {
            var dbMangerMock = new Mock<IDBManager>();
            var service = new MainBusinessLogicService(dbMangerMock.Object);
            var productName = string.Empty;

            service.Delete(productName);

            dbMangerMock.Verify(db => db.Delete(productName), Times.Never);
        }

        [Test]
        public void Get_Name_DbManagerCallGet()
        {
            var dbMangerMock = new Mock<IDBManager>();
            var service = new MainBusinessLogicService(dbMangerMock.Object);
            var productName = "TestName1";

            service.Get(productName);

            dbMangerMock.Verify(db => db.Get(productName), Times.Once);
        }

        [Test]
        public void Get_Name_ArgumentNullExceptionWhenNameIsEmpty()
        {
            var dbMangerMock = new Mock<IDBManager>();
            var service = new MainBusinessLogicService(dbMangerMock.Object);

            var productName = string.Empty;

            Assert.Throws<ArgumentNullException>(() => service.Get(productName));
        }

        [Test]
        public void Get_Name_ArgumentNullExceptionWhenNameIsNull()
        {
            var dbMangerMock = new Mock<IDBManager>();
            var service = new MainBusinessLogicService(dbMangerMock.Object);

            Assert.Throws<ArgumentNullException>(() => service.Get(null));
        }

        [Test]
        public void Update_ProductName_DbManagerCallUpdate()
        {
            var dbMangerMock = new Mock<IDBManager>();
            var service = new MainBusinessLogicService(dbMangerMock.Object);
            var product = new Product();
            product.Name = "TestName1";
            product.LastUpdated = DateTime.MinValue;

            service.Update(product, product.Name);

            dbMangerMock.Verify(db => db.Update(product, product.Name), Times.Once);
        }
        
        [Test]
        public void Update_ProductName_ArgumentNullExceptionWhenNameIsEmpty()
        {
            var dbMangerMock = new Mock<IDBManager>();
            var service = new MainBusinessLogicService(dbMangerMock.Object);
            var product = new Product();
            product.Name = string.Empty;
            
            Assert.Throws<ArgumentNullException>(() => service.Update(product, product.Name));
        }
        
        [Test]
        public void Update_ProductName_ArgumentNullExceptionWhenNameIsNull()
        {
            var dbMangerMock = new Mock<IDBManager>();
            var service = new MainBusinessLogicService(dbMangerMock.Object);
            var product = new Product();

            Assert.Throws<ArgumentNullException>(() => service.Update(product, product.Name));
        }
        
        [Test]
        public void Update_ProductName_ArgumentNullExceptionWhenLastUpdatedBiggerThenNow()
        {
            var dbMangerMock = new Mock<IDBManager>();
            var service = new MainBusinessLogicService(dbMangerMock.Object);
            var product = new Product();
            product.Name = "TestName1";
            product.LastUpdated = DateTime.MaxValue;

            Assert.Throws<ArgumentNullException>(() => service.Update(product, product.Name));
        }
    }
}
