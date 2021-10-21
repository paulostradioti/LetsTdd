using System;
using LetsTdd.Domain;
using Xunit;

namespace LetsTdd.UnitTests
{
    public class BankAccountUnitTests
    {
        private BankAccount _sut;
        public BankAccountUnitTests()
        {
            _sut = new BankAccount();
        }


        [Fact]
        public void NewAccount_Balance_Is25()
        {
            //Arrange
            var expected = 25d;

            //Act
            var actual = _sut.Balance;

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Withdrawal_ThrowsException_WhenInsufficientBalance()
        {
            //Arrange
            Func<double, double> method = _sut.Withdraw;
            var expectedMessage = "Insufficient Balance";

            var exception = Assert.Throws<InvalidOperationException>(() => method(100d));
            var actualMessage = exception.Message;

            Assert.Equal(expectedMessage, actualMessage);
        }

        [Fact]
        public void Withdrawal_ThrowsException_WhenAmountIsNegative()
        {
            Func<double, double> method = _sut.Withdraw;
            var expectedMessage = "Invalid Amount";

            var exception = Assert.Throws<ArgumentException>(() => method(-10));
            var actualMessage = exception.Message;

            Assert.Contains(expectedMessage, actualMessage);
        }

        [Fact]
        public void Withdrawal_UpdatesBalance_WhenAmountIsValid()
        {
            var expected = 15d;

            var actual = _sut.Withdraw(10);

            Assert.Equal(expected, actual);
        }
    }
}
