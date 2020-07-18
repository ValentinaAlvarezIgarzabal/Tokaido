using System;
using System.Collections.Generic;

namespace Library
{
    public interface ITravel
    {
        void Travel(Points point, Money money, List<Traveller> travellers);
    }
}