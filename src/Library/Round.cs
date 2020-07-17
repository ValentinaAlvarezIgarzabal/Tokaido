using System;
using System.Collections.Generic;
using System.Linq;

namespace Library
{
    public class Round
    {
        /// <summary>
        /// Creo un acceso a la clase NextExperience para acceder a sus metodos.
        /// </summary>
        /// <returns></returns>
        NextExperience next = new NextExperience();

        /// <summary>
        /// Lista de visitantes que terminan su recorrido.
        /// </summary>
        /// <typeparam name="Traveller"></typeparam>
        /// <returns></returns>
        List<Traveller> edo = new List<Traveller>();

        /// <summary>
        /// Creo acceso a los datos de una clase.
        /// </summary>
        /// <returns></returns>
        NextExperience nextExperience = new NextExperience();

        /// <summary>
        /// Lista de strings con los lugares elegidos por los visitantes.
        /// </summary>
        /// <typeparam name="string"></typeparam>
        /// <returns></returns>
        List<string> whereVisitorsWouldLikeToGo = new List<string>();


        /// <summary>
        /// Lista de visitantes que quieren ir a las aguas termales.
        /// </summary>
        /// <typeparam name="Traveller"></typeparam>
        /// <returns></returns>
        List<Traveller> hotWaters = new List<Traveller>();

        /// <summary>
        /// Lista de visitantes que quieren ir al oceano.
        /// </summary>
        /// <typeparam name="Traveller"></typeparam>
        /// <returns></returns>
        List<Traveller> oceans = new List<Traveller>();

        /// <summary>
        /// Lista de visitantes que quieren ir a las montañas.
        /// </summary>
        /// <typeparam name="Traveller"></typeparam>
        /// <returns></returns>
        List<Traveller> mountains = new List<Traveller>();

        /// <summary>
        /// Lista de visitantes que quieren ir a una granja.
        /// </summary>
        /// <typeparam name="Traveller"></typeparam>
        /// <returns></returns>
        List<Traveller> farms = new List<Traveller>();

       

        /// <summary>
        /// Metodo que comienza el juego.
        /// </summary>
        public void Initialize()
        {
            var options = new List<string>() {"Hot Waters","Ocean","Mountain","Farm","Edo"};
            DecideWhereToGo(nextExperience.travellers,options);
        }

        /// <summary>
        /// Metodo al que se le pasa por parametro los visitantes y las opciones de lugares a donde pueden ir.
        /// </summary>
        /// <param name="travellers"></param>
        /// <param name="options"></param>
        public void DecideWhereToGo(List<Traveller> travellers, List<string> options)
        {
            int i = 0;
            foreach (Traveller traveller in travellers)
            {
                i++;
                Console.WriteLine($"Where would you like to go next?");
                Console.WriteLine(options.ToString());
                options.Clear();
                string request = Console.ReadLine();
                whereVisitorsWouldLikeToGo.Add(request);
                var destinationCount = whereVisitorsWouldLikeToGo.GroupBy(item => item).ToDictionary(x => x.Key, x => x.Count());
                if (request == "Hot Waters")
                {
                    hotWaters.Add(traveller);
                }
                else if (request == "Ocean")
                {
                    oceans.Add(traveller);
                }
                else if (request == "Mountain")
                {
                    mountains.Add(traveller);
                }
                else if (request == "Farm")
                {
                    farms.Add(traveller);
                }
                else if (request == "Edo")
                {
                    edo.Add(traveller);
                }
                else
                {
                    throw new Exception ("Select sommething form the list");
                }
            }
            next.TravellingFarms(farms);
            next.TravellingMountain(mountains);
            next.TravellingOcean(oceans);
            next.TravellingHotWaters(hotWaters);
            next.TravellingEdo(edo);
        }


    }
}