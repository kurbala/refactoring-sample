using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace RentalMovies.Tests
{
    [TestFixture]
    class CustomerTest
    {
        private string resultString = "Учет аренды для {0}\n" + "\t{1}\t{2}\n" +
                                      "Сумма задолженности составляет {3}\n" +
                                      "Вы заработали {4} очков за активность";

        private string resultHtmlString = "<H1>Операции аренды для <EM>{0}" +
                                          "</EM></H1><P>\n" +
                                          "{1}:{2}<BR>\n" +
                                          "{3}:{4}<BR>\n" +
                                          "<P>Ваша задолженность составляет <EM>{5}</EM><P>\n" +
                                          "На этой аренде вы заработали <EM>{6}" +
                                          "</EM> очков за активность<P>";


        [Test]
        public void ReturnHtmlResult()
        {
            var CustomerName = "Customer 1";
            var movieName = "Movie";
            var customer = new Customer(CustomerName);
            customer.AddRental(new Rental(
                new Movie(movieName, 1), 10));

            var movieName2 = "Movie2";
            customer.AddRental(new Rental(
                new Movie(movieName2, 1), 1));

            var amount = 30;
            var amount2 = 3;
            var total = amount + amount2;

            var renterPoints = 3;

            var result = customer.htmlStatement();

            Assert.AreEqual(string.Format(resultHtmlString,
                CustomerName, movieName, amount, movieName2,
                amount2, total, renterPoints), result);
        }

        
        [Test]
        public void ReturnResultIfMovieIsNewReleaseAndDaysRentedMoreThanOne()
        {
            var CustomerName = "Customer 1";
            var movieName = "Movie";
            var customer = new Customer(CustomerName);
            customer.AddRental(new Rental(
                new Movie(movieName, 1), 10));

            var amount = 30;
            var renterPoints=2;

            var result = customer.statement();

            Assert.AreEqual(string.Format(resultString, 
                CustomerName, movieName, amount, amount, 
                renterPoints), result);
        }

        [Test]
        public void ReturnResultIfMovieIsNewReleaseAndDaysRentedNotMoreThanOne()
        {
            var CustomerName = "Customer 1";
            var movieName = "Movie";
            var customer = new Customer(CustomerName);
            customer.AddRental(new Rental(
                new Movie(movieName, 1), 1));

            var amount = 3;
            var renterPoints = 1;

            var result = customer.statement();

            Assert.AreEqual(string.Format(resultString,
                CustomerName, movieName, amount, amount,
                renterPoints), result);
        }

        [Test]
        public void ReturnResultIfMovieIsChildrensAndDaysRentedMoreThanThree()
        {
            var CustomerName = "Customer 2";
            var movieName = "Movie 2";
            var customer = new Customer(CustomerName);
            customer.AddRental(new Rental(
                new Movie(movieName, 2), 10));

            var amount = 12;
            var renterPoints = 1;

            var result = customer.statement();

            Assert.AreEqual(string.Format(resultString,
                CustomerName, movieName, amount, amount,
                renterPoints), result);
        }

        [Test]
        public void ReturnResultIfMovieIsChildrensAndDaysRentedNotMoreThanThree()
        {
            var CustomerName = "Customer 2";
            var movieName = "Movie 2";
            var customer = new Customer(CustomerName);
            customer.AddRental(new Rental(
                new Movie(movieName, 2), 1));

            var amount = 1.5;
            var renterPoints = 1;

            var result = customer.statement();

            Assert.AreEqual(string.Format(resultString,
                CustomerName, movieName, amount, amount,
                renterPoints), result);
        }

        [Test]
        public void ReturnResultIfMovieIsRegularAndDaysRentedMoreThanTwo()
        {
            var CustomerName = "Customer 3";
            var movieName = "Movie 3";
            var customer = new Customer(CustomerName);
            customer.AddRental(new Rental(
                new Movie(movieName, 0), 10));

            var amount = 14;
            var renterPoints = 1;

            var result = customer.statement();

            Assert.AreEqual(string.Format(resultString,
                CustomerName, movieName, amount, amount,
                renterPoints), result);
        }

        [Test]
        public void ReturnResultIfMovieIsRegularAndDaysRentedNotMoreThanTwo()
        {
            var CustomerName = "Customer 3";
            var movieName = "Movie 3";
            var customer = new Customer(CustomerName);
            customer.AddRental(new Rental(
                new Movie(movieName, 0), 1));

            var amount = 2;
            var renterPoints = 1;

            var result = customer.statement();

            Assert.AreEqual(string.Format(resultString,
                CustomerName, movieName, amount, amount,
                renterPoints), result);
        }

        static void Main(string[] args)
        {
        }
    }
}
