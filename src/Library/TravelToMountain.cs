using System;
using System.Collections.Generic;

namespace Library
{
    public class TravelToMountain : ITravel
    {
        BaseHandler handler;
        Subject subject = new Subject();
        public void Travel(Points point, Money money, List<Traveller> travellers)
        {
            int last = travellers.Count;
            List<Traveller> welcomedOnes = travellers.GetRange(0,3);
            List<Traveller> rejectedOnes = travellers.GetRange(4,last);
            foreach(Traveller traveller in welcomedOnes)
            {
                if(point.Mountain == 0)
                {
                    var result = handler.Handler("Mountain",traveller);
                    Console.WriteLine("Where to go next");
                    string[] places = {"Farm","Mountain","Edo"};
                        //metodo para ver a donde quiere ir
                }
                else if (point.Mountain < 2)
                {
                    var result = handler.Handler("Mountain",traveller);
                    Console.WriteLine("You can only go to one place");
                    string[] places = {"Edo"};
                    //metodo
                }
                else
                {
                    var result = handler.Handler("Edo",traveller);
                }

            }
            foreach(Traveller traveller in rejectedOnes)
            {
                subject.MountainVisitors("Cannot go to the Mountain, there's a limited number of hickers");
                if(point.Mountain == 0)
                {
                    string[] places = {"Farm","Mountain","Edo"};
                    //metodo para ir
                }
                else
                {
                    var result = handler.Handler("Edo",traveller);
                }
            } 
        }
    }
}