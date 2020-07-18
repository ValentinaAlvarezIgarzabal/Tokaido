using System;
using System.Collections.Generic;

namespace Library
{
    public class TravelToHotWater : ITravel
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
            AcceptedVisitors(travellers);
            foreach(Traveller traveller in welcomedVisitors)
            {
                if(point.HotWaters == 0)
                {
                    var result = handler.Handler("Hot Water",traveller);
                    string[] places = {"Mountain","Farm","Mountain","Edo"};
                    List<string> placesToGo = new List<string>(places);
                    round.WhereNext(placesToGo,traveller);
                }
                else
                {
                    string[] places = {"Mountain","Farm","Mountain","Edo"};
                    List<string> placesToGo = new List<string>(places);
                    round.WhereNext(placesToGo,traveller);
                }

            }
            foreach(Traveller traveller in rejectedVisitors)
            {
                subject.HotWatersVisitors("There are visitors who cannot go to the hot waters, it would surpass the limit.If this is yoy case you'll be asked for a new destination.");
                if(point.HotWaters == 0)
                {
                    string[] places = {"Mountain","Farm","Mountain","Edo"};
                    List<string> placesToGo = new List<string>(places);
                    round.WhereNext(placesToGo,traveller);
                }
                else
                {
                    string[] places = {"Mountain","Farm","Mountain","Edo"};
                    List<string> placesToGo = new List<string>(places);
                    round.WhereNext(placesToGo,traveller);
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
            else if (visitors >= 3)
            {
                rejectedVisitors = travellers.GetRange(3,visitors);
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