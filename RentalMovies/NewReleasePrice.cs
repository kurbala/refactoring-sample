using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RentalMovies
{
    public class NewReleasePrice: Price
    {
        public override int GetPriceCode()
        {
            return Movie.NEW_RELEASE;
        }
    }
}
