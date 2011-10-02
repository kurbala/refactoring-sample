using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RentalMovies
{
    public class ChildrensPrice : Price
    {
        public override int GetPriceCode()
        {
            return Movie.CHILDRENS;
        }
    }
}
