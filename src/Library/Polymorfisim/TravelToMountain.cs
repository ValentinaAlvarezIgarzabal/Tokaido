using System;
using System.Collections.Generic;

namespace Library
{
    public class TravelToMountain : ITravel
    {
        BaseHandler handler;
        Subject subject = new Subject();
        Round round = new Round();

        /// <summary>
        /// Lista que guarda objetos Traveller, en este caso almacena los visitantes que no pueden ingresar a un paisaje.
        /// </summary>
        /// <typeparam name="Traveller"></typeparam>
        /// <returns></returns>
        private List<Traveller> rejectedVisitors = new List<Traveller>();

        /// <summary>
        /// Lista que guarda objetos Traveller, en este caso almacena los visitantes que son aceptados en los paisajes.
        /// </summary>
        /// <typeparam name="Traveller"></typeparam>
        /// <returns></returns>

        private List<Traveller> welcomedVisitors = new List<Traveller>();


        /// <summary>
        /// Metodo travel que decide que otros movimientos puede tomar un visitante, ademas de negarle o aceptarle 
        /// el pedido de ir a un paisaje.
        /// </summary>
        /// <param name="point"></param>
        /// <param name="money"></param>
        /// <param name="travellers"></param>

        public void Travel(Points point, Money money, List<Traveller> travellers)
        {
            foreach(Traveller traveller in welcomedVisitors)
            {
                if(point.Mountain == 0)
                {
                    var result = handler.Handler("Mountain",traveller);
                    Console.WriteLine("Where to go next");
                    string[] places = {"Farm","Mountain","Edo"};
                    List<string> placesToGo = new List<string>(places);
                    round.WhereNext(placesToGo,traveller);
                }
                else if (point.Mountain < 2)
                {
                    var result = handler.Handler("Mountain",traveller);
                    Console.WriteLine("You can only go to one place");
                    string[] places = {"Edo"};
                    List<string> placesToGo = new List<string>(places);
                    round.WhereNext(placesToGo,traveller);
                }
                else
                {
                    var result = handler.Handler("Edo",traveller);
                }

            }
            foreach(Traveller traveller in rejectedVisitors)
            {
                subject.MountainVisitors("There are visitors who cannot go to the Mountain, there's a limited number of hickers.If this is yoy case you'll be asked for a new destination.");
                if(point.Mountain == 0)
                {
                    string[] places = {"Farm","Mountain","Edo"};
                    List<string> placesToGo = new List<string>(places);
                    round.WhereNext(placesToGo,traveller);
                }
                else
                {
                    var result = handler.Handler("Edo",traveller);
                }
            } 
        }

        /// <summary>
        /// Metodo que segun una lista de visitantes y una regla de capacidad maxima el cada paisaje, determina
        /// que visitantes pueden pasar y quienes no, separandolos en listas.
        /// </summary>
        /// <param name="travellers"></param>

        public void AcceptedVisitors(List<Traveller> travellers)
        {
            int visitors = travellers.Count;
            if (visitors == 0)
            {
                throw new Exception("This list is empty!");
            }
            else if (visitors == 5)
            {
                rejectedVisitors.Add(travellers[4]);
            }
            else
            {
                foreach(Traveller traveller in travellers)
                {
                    welcomedVisitors.Add(traveller);
                }
            }
        }
    }
}