using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingTask.Core.Interfaces;
using TestingTask.Core.Models;

namespace TestingTask.Core
{
    public class BookingService : IBookingService
    {
        private readonly IValidator<Group> groupValidator;
        private readonly IHotelRepository hotelRepository;

        public BookingService(IValidator<Group> groupValidator, IHotelRepository hotelRepository)
        {
            this.groupValidator = groupValidator;
            this.hotelRepository = hotelRepository;
        }

        public List<string> GetSuitableHotelNames(Group @group)
        {
            throw new NotImplementedException();
        }

        public List<Room> Book(string hotelName, Group @group)
        {
            throw new NotImplementedException();
        }
    }
}
