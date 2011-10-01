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

                // Определить сумму для каждой строки
                switch (each.Movie.PriceCode)
                {
                    case Movie.REGULAR:
                        thisAmount += 2;
                        if (each.DaysRented > 2)
                            thisAmount += (each.DaysRented - 2) * 1.5;
                        break;
                    case Movie.NEW_RELEASE:
                        thisAmount += each.DaysRented * 3;
                        break;
                    case Movie.CHILDRENS:
                        thisAmount += 1.5;
                        if (each.DaysRented > 3)
                            thisAmount += (each.DaysRented - 3) * 1.5;
                        break;
                }
                
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
    } 
}
