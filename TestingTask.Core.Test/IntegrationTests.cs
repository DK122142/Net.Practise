using System;
using System.Collections.Generic;
using System.Linq;
using Moq;
using NUnit.Framework;
using TestingTask.Core.Interfaces;
using TestingTask.Core.Models;

namespace TestingTask.Core.Test
{
    [TestFixture]
    public class IntegrationTests
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
        public void IBookingService_BookingValidGroups_RoomsBookedByGroups()
        {
            var guests = new List<Guest>
            {
                new() {Age = 23, FirstName = "FName1", LastName = "LName1"},
                new() {Age = 21, FirstName = "FName2", LastName = "LName2"},
                new() {Age = 3, FirstName = "FName4", LastName = "LName4"},
                new() {Age = 2, FirstName = "FName3", LastName = "LName3"}
            };

            var group = new Group {Guests = guests, HasPets = false};
            var groupWithPets = new Group {HasPets = true, Guests = {new Guest(){Age = 22, FirstName = "ff", LastName = "ll"}}};


            var rooms = new List<Room>
            {
                new(){BookedBy = null, Capacity = 2},
                new(){BookedBy = null, Capacity = 3},
                new(){BookedBy = null, Capacity = 4},
            };

            this.hotelsList = new List<Hotel>
            {
                new() {AllowPets = false, Name = "Hotel1", Rooms = rooms},
                new(){AllowPets = true, Name = "Hotel2", Rooms = {new Room {BookedBy = null, Capacity = 2}}}
            };

            var validator = new GroupValidator();
            var bookingService = new BookingService(validator, this.hotelRepository.Object);

            // 4. Ребенок не может жить в номере без взрослых
            Assert.IsTrue(validator.Validate(group));

            // 5. Группа может иметь или не иметь питомцев
            Assert.IsTrue(validator.Validate(groupWithPets));
            
            // 1. Вся группа должна помещаться в одном отеле
            // 2. Вместительность комнаты показывает максимальное количество взрослых + 1 ребенок (до 6 лет)
            // 4. Ребенок не может жить в номере без взрослых
            // 8. Одна группа может иметь только одну бронь
            var suitableHotelNames = bookingService.GetSuitableHotelNames(group);
            var expectedHotels = new List<string> {"Hotel1"};

            CollectionAssert.AreEqual(expectedHotels, suitableHotelNames);

            bookingService.Book("Hotel1", group);

            // 3. Два ребенка считаются как один взрослый
            Assert.AreEqual(group, this.hotelsList[0].Rooms[1].BookedBy);
            
            // 8. Одна группа может иметь только одну бронь
            Assert.Throws<ArgumentException>(() => bookingService.Book("Hotel1", group));
            
            // 6. Отель может позволять или не позволять заезд с питомцами
            suitableHotelNames = bookingService.GetSuitableHotelNames(groupWithPets);
            expectedHotels = new List<string>() {"Hotel2"};

            CollectionAssert.AreEqual(expectedHotels, suitableHotelNames);
            
            bookingService.Book("Hotel2", groupWithPets);
            
            Assert.AreEqual(groupWithPets, this.hotelsList[1].Rooms[0].BookedBy);
        }

        
        [Test]
        public void IBookingService_BookingValidGroupsWithoutSuitableHotels_ArgumentException()
        {
            var guests = new List<Guest>
            {
                new() {Age = 23, FirstName = "FName1", LastName = "LName1"},
                new() {Age = 21, FirstName = "FName2", LastName = "LName2"},
                new() {Age = 3, FirstName = "FName4", LastName = "LName4"}
            };

            var group = new Group {Guests = guests, HasPets = false};
            var groupWithPets = new Group {HasPets = true, Guests = {new Guest(){Age = 22, FirstName = "ff", LastName = "ll"}}};

            var rooms = new List<Room>
            {
                new(){BookedBy = null, Capacity = 2},
                new(){BookedBy = null, Capacity = 1},
            };

            this.hotelsList = new List<Hotel>
            {
                new() {AllowPets = false, Name = "Hotel1", Rooms = rooms},
                new(){AllowPets = false, Name = "Hotel2", Rooms = {new Room {BookedBy = null, Capacity = 2}}}
            };

            var validator = new GroupValidator();
            var bookingService = new BookingService(validator, this.hotelRepository.Object);

            // 4. Ребенок не может жить в номере без взрослых
            Assert.IsTrue(validator.Validate(group));

            // 5. Группа может иметь или не иметь питомцев
            Assert.IsTrue(validator.Validate(groupWithPets));

            // 7. Если отели не найдены - должно быть выброшено исключение
            Assert.Throws<ArgumentException>(() => bookingService.GetSuitableHotelNames(group));
            
            Assert.Throws<ArgumentException>(() => bookingService.GetSuitableHotelNames(groupWithPets));
        }

        [TearDown]
        public void TearDown()
        {
            this.hotelsList.Clear();
        }
    }
}
