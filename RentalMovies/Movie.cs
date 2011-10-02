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
        private Price _price;

        public Movie(string title, int priceCode)
        {
            _title = title;
            PriceCode = priceCode;
        }

        public int PriceCode 
        {
            get 
            { 
                return _price.GetPriceCode(); 
            }
            set 
            {
                switch (value)
                {
                    case REGULAR:
                        _price = new RegularPrice();
                        break;
                    case CHILDRENS:
                        _price = new ChildrensPrice();
                        break;
                    case NEW_RELEASE:
                        _price = new NewReleasePrice();
                        break;
                    default:
                        throw new ArgumentException("Incorrect Price Code");
                }
            }
        }

        public string Title
        {
            get { return _title; }
        }

        public double GetCharge(int daysRented)
        {
            return _price.GetCharge(daysRented);
        }

        public int GetFrequentRenterPoints(int daysRented)
        {
            // Бонус за аренду новинки на два дня
            if ((PriceCode == Movie.NEW_RELEASE) &&
               daysRented > 1)
                return 2;
            else
                return 1;
        }


    }
}
