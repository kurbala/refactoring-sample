using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RentalMovies
{
    public class Customer
    {
        private string _name;
        private ICollection<Rental> _rentals = new List<Rental>();

        public Customer(string name)
        {
            _name = name;
        }

        public void AddRental(Rental arg)
        {
            _rentals.Add(arg);
        }

        public string Name
        {
            get { return _name; }
        }

        public string statement()
        {
            double totalAmount = 0;
            int frequentRenterPoints = 0;
            string result = "Учет аренды для " + _name + "\n";
            foreach (var each in _rentals)
            {
                double thisAmount = 0;

                thisAmount = amountFor(each);
                
                // Добавить очки для активного арендатора
                frequentRenterPoints++;
                // Бонус за аренду новинки на два дня
                if ((each.Movie.PriceCode == Movie.NEW_RELEASE) &&
                    each.DaysRented > 1) frequentRenterPoints++;

                // Показать результаты для этой аренды
                result += "\t" + each.Movie.Title + "\t" +
                    thisAmount.ToString() + "\n";
                totalAmount += thisAmount;
            }
            // Добавить нижний колонтитул
            result += "Сумма задолженности составляет " +
                totalAmount.ToString() + "\n";
            result += "Вы заработали " + frequentRenterPoints.ToString() +
                " очков за активность";
            return result;
        }

        private double amountFor(Rental rental)
        {
            double result = 0;
            switch (rental.Movie.PriceCode)
            {
                case Movie.REGULAR:
                    result += 2;
                    if (rental.DaysRented > 2)
                        result += (rental.DaysRented - 2) * 1.5;
                    break;
                case Movie.NEW_RELEASE:
                    result += rental.DaysRented * 3;
                    break;
                case Movie.CHILDRENS:
                    result += 1.5;
                    if (rental.DaysRented > 3)
                        result += (rental.DaysRented - 3) * 1.5;
                    break;
            }
            return result;
        }
    } 
}
