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
                frequentRenterPoints += each.GetFrequentRenterPoints();

                // Показать результаты для этой аренды
                result += "\t" + each.Movie.Title + "\t" +
                    each.GetCharge().ToString() + "\n";
                totalAmount += each.GetCharge();
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
