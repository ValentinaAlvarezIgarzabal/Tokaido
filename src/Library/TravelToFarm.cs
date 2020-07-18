using System;
using System.Collections.Generic;

namespace Library
{
    public class TravelToFarm : ITravel
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
                if(money.Coin == 0)
                {
                    var result = handler.Handler("Farm",traveller);
                    string[] places = {"Ocean","Ocean","Hot Waters","Mountain","Farm","Mountain","Edo"};
                        //metodo para ver a donde quiere ir
                }
                else if (money.Coin == 3)
                {
                    var result = handler.Handler("Farm",traveller);
                    string[] places = {"Mountain","Edo"};
                }
                else
                {
                    string[] places = {"Mountain","Edo"};
                }

            }
            foreach(Traveller traveller in rejectedOnes)
            {
                subject.FarmVisitors("Cannot go to the farm");
                if(money.Coin == 0)
                {
                    string[] places = {"Ocean","Ocean","Hot Waters","Mountain","Farm","Mountain","Edo"};
                    //metodo para ir
                }
                else if (money.Coin == 3)
                {
                    string[] places = {"Mountain","Edo"};
                    //metodo para decidir
                }
                else
                {
                    string[] places = {"Mountain","Edo"};
                    //metodo para decidir
                }
            } 
        }
    }
}