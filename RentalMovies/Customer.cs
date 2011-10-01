﻿using System;
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
            string result = "Учет аренды для " + _name + "\n";
            foreach (var each in _rentals)
            {
                // Показать результаты для этой аренды
                result += "\t" + each.Movie.Title + "\t" +
                    each.GetCharge().ToString() + "\n";
            }
            // Добавить нижний колонтитул
            result += "Сумма задолженности составляет " +
                GetTotalCharge().ToString() + "\n";
            result += "Вы заработали " + GetTotalFrequentRenterPoints().ToString() +
                " очков за активность";
            return result;
        }

        private int GetTotalFrequentRenterPoints()
        {
            int result = 0;
            foreach (var each in _rentals)
            {
                result += each.GetFrequentRenterPoints();
            };
            return result;
        }

        private double GetTotalCharge()
        {
            double result = 0;
            foreach (var each in _rentals)
            {
                result += each.GetCharge();
            };
            return result;
        }
    } 
}
