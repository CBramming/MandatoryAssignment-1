using Microsoft.VisualStudio.TestTools.UnitTesting;
using Football;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football.Tests
{
    [TestClass()]
    public class FootballPlayerTests
    {
        FootballPlayer footballPlayer = new FootballPlayer { Id = 1, Name = "Casper", Age = 25, ShirtNumber = 7 };
        FootballPlayer footballPlayerNameTooShort = new FootballPlayer { Id = 2, Name = "C", Age = 18, ShirtNumber = 10 };
        FootballPlayer footballPlayerAgeTooYoung = new FootballPlayer { Id = 3, Name = "Torben", Age = -1, ShirtNumber = 3 };
        FootballPlayer footballPlayerShirtNumberTooLow = new FootballPlayer { Id = 4, Name = "Lucas", Age = 22, ShirtNumber = 0 };
        FootballPlayer footballPlayerShirtNumberTooHigh = new FootballPlayer { Id = 5, Name = "Bob", Age = 21, ShirtNumber = 100 };

        [TestMethod()]
        public void ValidateNameTest()
        {
            Assert.ThrowsException<ArgumentException>(() => footballPlayerNameTooShort.ValidateName());
        }


        [TestMethod()]
        [DataRow(1)]
        [DataRow(2)]
        public void ValidateAgeTest(int age)
        {
            footballPlayer.Age = age;
            footballPlayer.ValidateAge();
        }

        [TestMethod]
        public void ValidateAgeOutOfRangeTest()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => footballPlayerAgeTooYoung.ValidateAge());
        }

        [TestMethod()]
        [DataRow(1)]
        [DataRow(2)]
        [DataRow(98)]
        [DataRow(99)]
        public void ValidateShirtNumberTest(int shirtNumber)
        {
            footballPlayer.ShirtNumber = shirtNumber;
            footballPlayer.ValidateShirtNumber();
        }

        [TestMethod]
        public void ValidateShirtNumberOutOfRangeTest()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => footballPlayerShirtNumberTooLow.ValidateShirtNumber());
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => footballPlayerShirtNumberTooHigh.ValidateShirtNumber());
        }


        [TestMethod()]
        public void ValidateTest()
        {
            footballPlayer.Validate();
            Assert.ThrowsException<ArgumentException>(() => footballPlayerNameTooShort.Validate());
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => footballPlayerAgeTooYoung.Validate());
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => footballPlayerShirtNumberTooLow.Validate());
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => footballPlayerShirtNumberTooHigh.Validate());
        }

        [TestMethod()]
        public void ToStringTest()
        {
            string str = footballPlayer.ToString();
            Assert.AreEqual("{Id=1, Name=Casper, Age=25, ShirtNumber=7}", str);
        }
    }
}