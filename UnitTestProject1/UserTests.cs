using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UserFormSubmission.Repo;
using UserFormSubmission.Services;
using NUnit;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace UserTest
{
    [TestFixture]
    public class UserTest
    {
        private static IUserService _userService;
        private static IUserRepository _userRepository;

        [SetUp]
        public static void SetUp()
        {
            _userRepository = new UserRepository();
            _userService = new UserService(_userRepository);
        }
        [Test]
        public void CheckUserDoesntExist()
        {
            //arrange
            var email = "doesntExist@yahoo.co.uk";
            bool result;

            //act
            result = _userRepository.CheckUserExists(email);

            //assert
            Assert.IsFalse(result);
        }

        [Test]
        public void CheckUserDoesExist()
        {
            //arrange
            var email = "doesExist@yahoo.co.uk";
            var password = "123";
            bool result;

            //act
            var insert = _userRepository.InsertUser(email, password);
            result = _userRepository.CheckUserExists(email);

            //assert
            Assert.IsTrue(result);
            //clean down user
            _userRepository.RemoveUser(email);
        }


        [Test]
        public void CheckUserDoesExistError()
        {
            //arrange
            var email = "";
            bool result;

            //act
            result = _userRepository.CheckUserExists(email);

            //assert
            Assert.IsFalse(result);

        }

        [Test]
        public void InsertUserSuccess()
        {
            //arrange
            var email = "test@yahoo.co.uk";
            var password = "1234";
            string result;

            //act
            result = _userRepository.InsertUser(email, password);

            //assert
            Assert.AreEqual("User Added Successfully", result);
            _userRepository.RemoveUser(email);
        }

        [Test]
        public void InsertUserNoEmailFail()
        {
            //arrange
            var email = "";
            var password = "1234";
            string result;

            //act
            result = _userRepository.InsertUser(email, password);

            //assert
            Assert.AreEqual("Invalid Data, Please try again", result);
        }

        [Test]
        public void InsertUserNoPasswordFail()
        {
            //arrange
            var email = "test@yahoo.co.uk";
            var password = "";
            string result;

            //act
            result = _userRepository.InsertUser(email, password);

            //assert
            Assert.AreEqual("Invalid Data, Please try again", result);
        }

        [Test]
        public void RemoveUserSuccess()
        {
            //arrange
            var email = "test@yahoo.co.uk";
            var password = "1234";
            bool result;
            string insert;
            //act
            insert = _userService.InsertUser(email, password);
            result = _userRepository.RemoveUser(email);

            //assert
            Assert.IsTrue(result);
        }

        [Test]
        public void RemoveUserFail()
        {
            //arrange
            var email = "test@yahoo.co.uk";
            var password = "1234";
            bool result;
            string insert;
            //act
            insert = _userService.InsertUser(email, password);
            email = "";
            result = _userRepository.RemoveUser(email);

            //assert
            Assert.IsFalse(result);
        }

    }

}
