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
                new() {AllowPets = true, Name = "Hotel1", 
                    Rooms = new List<Room>
                    {
                        new() { Capacity = 1},
                        new() { Capacity = 2},
                        new() { Capacity = 3}
                    }},
                new() {AllowPets = false, Name = "Hotel2",
                    Rooms = new List<Room>
                    {
                        new() { Capacity = 1},
                        new() { Capacity = 2}
                    }}
            });
            
            var group = new Group
            {
                Guests = new List<Guest>
                {
                    new() { Age = 22, FirstName = "FN", LastName = "LN" }
                },
                HasPets = false
            };

            var validator = new GroupValidator();
            var bookingService = new BookingService(validator, this.hotelRepository.Object);

            var expectedHotels = new List<Hotel>(this.hotelsList);
            var hotelsResult = bookingService.GetSuitableHotelNames(group);

            CollectionAssert.AreEqual(expectedHotels, hotelsResult);
        }

        [Test]
        public void GetSuitableHotelNames_CapacityIsNotEnough_TrowArgumentException()
        {
            this.hotelsList.AddRange(new List<Hotel>
            {
                new() {AllowPets = true, Name = "Hotel1", 
                    Rooms = new List<Room>
                    {
                        new() { Capacity = 1},
                        new() { Capacity = 2}
                    }},
                new() {AllowPets = true, Name = "Hotel2",
                    Rooms = new List<Room>
                    {
                        new() { Capacity = 1},
                    }}
            });
            
            var group = new Group
            {
                Guests = new List<Guest>
                {
                    new() { Age = 22, FirstName = "FN", LastName = "LN" },
                    new() { Age = 21, FirstName = "FN", LastName = "LN" },
                    new() { Age = 23, FirstName = "FN", LastName = "LN" }
                },
                HasPets = false
            };

            var validator = new GroupValidator();
            var bookingService = new BookingService(validator, this.hotelRepository.Object);
            
            Assert.Throws<ArgumentException>(() => bookingService.GetSuitableHotelNames(group));
        }


        [Test]
        public void Book_ValidGroupAndHotelName_ReturnsRoomList()
        {
            this.hotelsList.AddRange(new List<Hotel>
            {
                new() {AllowPets = true, Name = "Hotel1"},
                new() {AllowPets = false, Name = "Hotel2"}
            });

            var group = new Group
            {
                Guests = new List<Guest>
                {
                    new() { Age = 22, FirstName = "FN", LastName = "LN" }
                },
                HasPets = false
            };

            var validator = new GroupValidator();
            var bookingService = new BookingService(validator, this.hotelRepository.Object);

            var expectedRooms = this.hotelsList[0].Rooms;
            var roomsResult = bookingService.Book(this.hotelsList[0].Name, group);

            CollectionAssert.AreEqual(expectedRooms, roomsResult);
        }

        [Test]
        public void Book_ValidGroupAndEmptyHotelName_TrowArgumentException()
        {
            this.hotelsList.AddRange(new List<Hotel>
            {
                new() {AllowPets = true, Name = string.Empty},
                new() {AllowPets = false, Name = null}
            });

            var group = new Group
            {
                Guests = new List<Guest>
                {
                    new() { Age = 22, FirstName = "FN", LastName = "LN" }
                },
                HasPets = false
            };

            var validator = new GroupValidator();
            var bookingService = new BookingService(validator, this.hotelRepository.Object);
            
            Assert.Throws<ArgumentException>(() => bookingService.Book(this.hotelsList[0].Name, group));
        }

        [Test]
        public void Book_ValidGroupAndNullHotelName_TrowArgumentException()
        {
            this.hotelsList.AddRange(new List<Hotel>
            {
                new() {AllowPets = true, Name = string.Empty},
                new() {AllowPets = true, Name = null}
            });

            var group = new Group
            {
                Guests = new List<Guest>
                {
                    new() { Age = 22, FirstName = "FN", LastName = "LN" }
                },
                HasPets = false
            };

            var validator = new GroupValidator();
            var bookingService = new BookingService(validator, this.hotelRepository.Object);
            
            Assert.Throws<ArgumentException>(() => bookingService.Book(this.hotelsList[1].Name, group));
        }

        [Test]
        public void Book_GroupWithPetsHotelsDisallowPets_TrowArgumentException()
        {
            this.hotelsList.AddRange(new List<Hotel>
            {
                new() {AllowPets = false, Name = "Hotel1"},
                new() {AllowPets = false, Name = "Hotel2"}
            });

            var group = new Group
            {
                Guests = new List<Guest>
                {
                    new() { Age = 22, FirstName = "FN", LastName = "LN" }
                },
                HasPets = true
            };

            var validator = new GroupValidator();
            var bookingService = new BookingService(validator, this.hotelRepository.Object);
            
            Assert.Throws<ArgumentException>(() => bookingService.Book(this.hotelsList[0].Name, group));
        }

        [Test]
        public void Book_InvalidGroup_TrowArgumentException()
        {
            this.hotelsList.AddRange(new List<Hotel>
            {
                new() {AllowPets = true, Name = "Hotel1"},
                new() {AllowPets = true, Name = "Hotel2"}
            });

            var group = new Group
            {
                Guests = new List<Guest>
                {
                    new() { Age = 2, FirstName = "FN", LastName = "LN" }
                },
                HasPets = false
            };

            var validator = new GroupValidator();
            var bookingService = new BookingService(validator, this.hotelRepository.Object);
            
            Assert.Throws<ArgumentException>(() => bookingService.Book(this.hotelsList[0].Name, group));
        }

        [TearDown]
        public void TearDown()
        {
            this.hotelsList.Clear();
        }
    }
}
