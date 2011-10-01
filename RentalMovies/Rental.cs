using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RentalMovies
{
    public class Rental
    {
        private Movie _movie;
        private int _daysRented;

        public Rental(Movie movie, int daysRented)
        {
            _movie = movie;
            _daysRented = daysRented;
        }

        public double GetCharge()
        {
            double result = 0;
            switch (Movie.PriceCode)
            {
                case Movie.REGULAR:
                    result += 2;
                    if (DaysRented > 2)
                        result += (DaysRented - 2) * 1.5;
                    break;
                case Movie.NEW_RELEASE:
                    result += DaysRented * 3;
                    break;
                case Movie.CHILDRENS:
                    result += 1.5;
                    if (DaysRented > 3)
                        result += (DaysRented - 3) * 1.5;
                    break;
            }
            return result;
        }

        public int DaysRented
        {
            get { return _daysRented; }
        }

        public Movie Movie
        {
            get { return _movie; }
        }
    }
}
