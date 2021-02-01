using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using TestingTask.Core.Interfaces;
using TestingTask.Core.Models;

namespace TestingTask.Core.Test
{
    [TestFixture]
    public class BookingServiceTest
    {
        private List<Hotel> hotelsList = new();
        private Mock<IHotelRepository> hotelRepository;

        [SetUp]
        public void SetUp()
        {
            this.hotelRepository = new Mock<IHotelRepository>();
            this.hotelRepository.Setup(x => x.GetHotels()).Returns(() => this.hotelsList.AsQueryable());
        }

        [Test]
        public void GetSuitableHotelNames_ValidGroupWithoutPets_ReturnsTwoHotelNames()
        {
            this.hotelsList.AddRange(new List<Hotel>
            {
                new() {AllowPets = true, Name = "Hotel1"},
                new() {AllowPets = false, Name = "Hotel2"}
            });

            var validator = new GroupValidator();
            var bookingService = new BookingService(validator, this.hotelRepository.Object);

            var group = new Group
            {
                Guests = new List<Guest>
                {
                    new() { Age = 22, FirstName = "FN", LastName = "LN" }
                },
                HasPets = false
            };

            var expectedHotels = new List<Hotel>(this.hotelsList);

            var hotelsResult = bookingService.GetSuitableHotelNames(group);

            CollectionAssert.AreEqual(expectedHotels, hotelsResult);
        }

        [TearDown]
        public void TearDown()
        {
            this.hotelsList.Clear();
        }
    }
}
