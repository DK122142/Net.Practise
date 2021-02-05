using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TestingTask.Core.Interfaces;
using TestingTask.Core.Models;

namespace TestingTask.Core.Test
{
    [TestFixture]
    public class GroupValidatorTest
    {
        private IValidator<Group> validator;
        private Group guestsGroup;

        [SetUp]
        public void SetUp()
        {
            this.validator = new GroupValidator();
            this.guestsGroup = new Group
            {
                Guests = new List<Guest>
                {
                    new() {Age = 5, FirstName = "FirstName1", LastName = "LastName1"},
                    new() {Age = 27, FirstName = "FirstName2", LastName = "LastName2"},
                    new() {Age = 28, FirstName = "FirstName3", LastName = "LastName3"}
                },

                HasPets = false
            };
        }
        
        [Test]
        public void Validate_ValidGroupWithoutPets_True()
        {
            Assert.IsTrue(this.validator.Validate(this.guestsGroup));
        }

        [Test]
        public void Validate_ValidGroupWithPets_True()
        {
            this.guestsGroup.HasPets = true;

            Assert.IsTrue(this.validator.Validate(this.guestsGroup));
        }

        [Test]
        public void Validate_EmptyGroup_False()
        {
            this.guestsGroup = new Group();

            Assert.IsFalse(this.validator.Validate(this.guestsGroup));
        }
        
        [Test]
        public void Validate_EmptyGuests_False()
        {
            this.guestsGroup.Guests = new List<Guest>();

            Assert.IsFalse(this.validator.Validate(this.guestsGroup));
        }

        [Test]
        public void Validate_NullGroup_False()
        {
            this.guestsGroup.Guests = null;

            Assert.IsFalse(this.validator.Validate(this.guestsGroup));
        }

        [Test]
        public void Validate_GroupWithOneEmptyName_False()
        {
            this.guestsGroup.Guests[1].FirstName = string.Empty;

            Assert.IsFalse(this.validator.Validate(this.guestsGroup));
        }

        [Test]
        public void Validate_OneGuestWithNegativeAgeWithoutPets_False()
        {
            this.guestsGroup.Guests[2].Age = -23;

            Assert.IsFalse(this.validator.Validate(this.guestsGroup));
        }
        
        [Test]
        public void Validate_OneGuestWithInvalidHighAgeWithoutPets_False()
        {
            this.guestsGroup.Guests[2].Age = 345;

            Assert.IsFalse(this.validator.Validate(this.guestsGroup));
        }
        
        [Test]
        public void Validate_OneGuestNameContainsInvalidCharacters_False()
        {
            this.guestsGroup.Guests[1].FirstName = "sdf#$@%^&!(*&^?";

            Assert.IsFalse(this.validator.Validate(this.guestsGroup));
        }

        [Test]
        public void Validate_InGroupOnlyChildrenWithoutPets_False()
        {
            this.guestsGroup.Guests[1].Age = 4;
            this.guestsGroup.Guests[2].Age = 3;

            Assert.IsFalse(this.validator.Validate(this.guestsGroup));
        }

        [TearDown]
        public void TearDown()
        {
            this.guestsGroup.Guests.Clear();
            this.guestsGroup = null;
            this.validator = null;
        }
    }
}
