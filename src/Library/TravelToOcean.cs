using System;
using System.Collections.Generic;

namespace Library
{
    public class TravelToOcean : ITravel
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
                if(point.Ocean == -1)
                {
                    var result = handler.Handler("Ocean",traveller);
                    string[] places = {"Ocean","Hot Waters","Mountain","Farm","Mountain","Edo"};
                        //metodo para ver a donde quiere ir
                }
                else if (point.Ocean < 3)
                {
                    var result = handler.Handler("Ocean",traveller);
                    string[] places = {"Hot Waters","Mountain","Farm","Mountain","Edo"};
                }
                else
                {
                    string[] places = {"Hot Waters","Mountain","Farm","Mountain","Edo"};
                }

            }
            foreach(Traveller traveller in rejectedOnes)
            {
                subject.OceanVisitors("Cannot go to the ocean, there's not enough lifeguards for all of you");
                if(point.Ocean == -1)
                {
                    string[] places = {"Ocean","Hot Waters","Mountain","Farm","Mountain","Edo"};
                    //metodo para ir
                }
                else if (point.Ocean == 1)
                {
                    string[] places = {"Hot Waters","Mountain","Farm","Mountain","Edo"};
                    //metodo para decidir
                }
                else
                {
                    string[] places = {"Hot Waters","Mountain","Farm","Mountain","Edo"};
                    //metodo para decidir
                }
            } 
        }
    }
}