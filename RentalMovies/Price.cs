using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RentalMovies
{
    public abstract class Price
    {
        public abstract int GetPriceCode();

        public abstract double GetCharge(int daysRented);

        public int GetFrequentRenterPoints(int daysRented)
        {
            // Бонус за аренду новинки на два дня
            if ((GetPriceCode() == Movie.NEW_RELEASE) &&
               daysRented > 1)
                return 2;
            else
                return 1;
        }

    }
}
