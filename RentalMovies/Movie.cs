using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RentalMovies
{
    public class Movie
    {
        public const int CHILDRENS = 2;
        public const int REGULAR = 0;
        public const int NEW_RELEASE = 1;

        private string _title;
        private int _priceCode;

        public Movie(string title, int priceCode)
        {
            _title = title;
            _priceCode = priceCode;
        }

        public int PriceCode 
        {
            get { return _priceCode; }
            set { _priceCode = value; }
        }

        public string Title
        {
            get { return _title; }
        }

        public double GetCharge(int daysRented)
        {
            double result = 0;
            switch (_priceCode)
            {
                case Movie.REGULAR:
                    result += 2;
                    if (daysRented > 2)
                        result += (daysRented - 2) * 1.5;
                    break;
                case Movie.NEW_RELEASE:
                    result += daysRented * 3;
                    break;
                case Movie.CHILDRENS:
                    result += 1.5;
                    if (daysRented > 3)
                        result += (daysRented - 3) * 1.5;
                    break;
            }
            return result;
        }

        public int GetFrequentRenterPoints(int daysRented)
        {
            // Бонус за аренду новинки на два дня
            if ((_priceCode == Movie.NEW_RELEASE) &&
                daysRented > 1)
                return 2;
            else
                return 1;
        }


    }
}
