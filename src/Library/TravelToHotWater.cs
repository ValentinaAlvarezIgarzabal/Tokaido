using System;
using System.Collections.Generic;

namespace Library
{
    public class TravelToHotWater : ITravel
    {
        BaseHandler handler;
        Subject subject = new Subject();
        public void Travel(Points point, Money money, List<Traveller> travellers)
        {
            int last = travellers.Count;
            List<Traveller> welcomedOnes = travellers.GetRange(0,1);
            List<Traveller> rejectedOnes = travellers.GetRange(2,last);
            foreach(Traveller traveller in welcomedOnes)
            {
                if(point.HotWaters == 0)
                {
                    var result = handler.Handler("Hot Water",traveller);
                    string[] places = {"Mountain","Farm","Mountain","Edo"};
                        //metodo para ver a donde quiere ir
                }
                else
                {
                    string[] places = {"Mountain","Farm","Mountain","Edo"};
                    //lugares donde puede ir 
                }

            }
            foreach(Traveller traveller in rejectedOnes)
            {
                subject.HotWatersVisitors("Cannot go to the hot waters, it would surpass the limit");
                if(point.HotWaters == 0)
                {
                    string[] places = {"Mountain","Farm","Mountain","Edo"};
                    //metodo para ir
                }
                else
                {
                    string[] places = {"Mountain","Farm","Mountain","Edo"};
                    //metodo para decidir
                }
            } 
        }
    }
}