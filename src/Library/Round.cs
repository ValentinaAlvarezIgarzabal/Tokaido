using System;
using System.Collections.Generic;
using System.Linq;

namespace Library
{
    public class Round
    {
        Points points = new Points();
        Money money = new Money();
        TravelToFarm travelToFarm = new TravelToFarm();
        TravelToHotWater travelToHotWater = new TravelToHotWater();
        TravelToMountain travelToMountain = new TravelToMountain();
        TravelToOcean travelToOcean = new TravelToOcean();
        List<Traveller> travellers = new List<Traveller>();
        /// <summary>
        /// Creo un acceso a la clase NextExperience para acceder a sus metodos.
        /// </summary>
        /// <returns></returns>
       // NextExperience next = new NextExperience();

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
        //NextExperience nextExperience = new NextExperience();

        /// <summary>
        /// Lista de strings con los lugares elegidos por los visitantes.
        /// </summary>
        /// <typeparam name="string"></typeparam>
        /// <returns></returns>
        List<string> whereVisitorsWouldLikeToGo = new List<string>();


      
       

       
/*
        /// <summary>
        /// Metodo que comienza el juego.
        /// </summary>
        public void Initialize()
        {
            var options = new List<string>() {"Hot Waters","Ocean","Mountain","Farm","Edo"};
            DecideWhereToGo(nextExperience.travellers,options);
        }
*/
        /// <summary>
        /// Metodo al que se le pasa por parametro los visitantes y las opciones de lugares a donde pueden ir.
        /// </summary>
        /// <param name="travellers"></param>
        /// <param name="options"></param>
        public void DecideWhereToGoForFirstTime(List<Traveller> travellers)
        {
            List<Traveller> hotWaters = new List<Traveller>();
            List<Traveller> oceans = new List<Traveller>();
            List<Traveller> mountains = new List<Traveller>();
            List<Traveller> farms = new List<Traveller>();
            foreach (Traveller traveller in travellers)
            {
                Console.WriteLine($"Where would you like to go next?");
                Console.WriteLine("Farm - Ocean - Ocean - Hot Waters - Mountain - Farm - Mountain - Edo");
                string request = Console.ReadLine();
                whereVisitorsWouldLikeToGo.Add(request);
                //var destinationCount = whereVisitorsWouldLikeToGo.GroupBy(item => item).ToDictionary(x => x.Key, x => x.Count());
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
            travelToFarm.Travel(points,money,farms);
            travelToOcean.Travel(points,money,oceans);
            travelToHotWater.Travel(points,money,hotWaters);
            travelToMountain.Travel(points,money,mountains);
        }

        public void WhereNext(List<string> options, Traveller traveller)
        {
            List<Traveller> farms = new List<Traveller>();
            List<Traveller> ocean = new List<Traveller>();
            List<Traveller> hotWaters = new List<Traveller>();
            List<Traveller> mountains = new List<Traveller>();
            List<Traveller> edo = new List<Traveller>();
            Console.WriteLine("Where to go next?");
            Console.WriteLine(options);
            var request = Console.ReadLine();
            if (request == "Hot Waters")
            {
                hotWaters.Add(traveller);
                travelToHotWater.Travel(points,money,hotWaters);
            }
            else if (request == "Ocean")
            {
                ocean.Add(traveller);
                travelToOcean.Travel(points,money,ocean);
            }
            else if (request == "Mountain")
            {
                mountains.Add(traveller);
                travelToMountain.Travel(points,money,mountains);
            }
            else if (request == "Farm")
            {
                farms.Add(traveller);
                travelToFarm.Travel(points,money,farms);
            }
            else if(request == "Edo")
            {
                Console.WriteLine("Hello, let's wait for everyone to arrive");
                edo.Add(traveller);
                if(edo.Count == 5)
                {
                    Winner();
                }
            }
            else
            {
                throw new Exception("Make sure that you selected a given option");
            }
        }

            
        /// <summary>
        /// Metodo que agrega observadores a una lista para que se les informe de los posibles cambios en la capacidad
        /// maxima de un destino.
        /// </summary>
        public void AttachObservers()
        {
            Subject subject = new Subject();
            foreach(Traveller traveller in travellers)
            {
                subject.Attach(traveller);
            }
        
        }

        /// <summary>
        /// Este metodo del codigo cliente construye la cadena. Aunque el codigo cliente puede enviar
        /// una peticion a cualquier elemento de la cadena no solo al primero de la cadena.
        /// </summary>
        public void StartChain()
        {
            var tokio = new TokioExperienceHandler();
            var ocean = new OceanExperience();
            var mountain = new MountainExperience();
            var hotWaters = new HotWatersExperience();
            var farm = new FarmExperience();
            var edo = new EdoExperienceHandler();


            // Cadena o camino del juego.
            tokio.Next(farm).Next(ocean).Next(ocean).Next(hotWaters).Next(mountain).Next(farm).Next(mountain).Next(edo);
        } 

        /// <summary>
        /// Metodo que determina al ganador o ganadores del juego en base a los puntos de sus experiencias.
        /// </summary>
        public void Winner()
        {
            int maxPoints = travellers.Max(x => x.totalPoints);
            List<Traveller> possibleWinner = new List<Traveller>();
            foreach(Traveller traveller in travellers)
            {
                if (maxPoints == traveller.totalPoints)
                {
                    possibleWinner.Add(traveller);
                }
            }
            foreach(Traveller traveller in possibleWinner)
            {
                if (possibleWinner.Count == 1)
                {
                    Console.WriteLine($"Winner is {traveller.Name}");
                }
                else
                {
                    Console.WriteLine("The winners are:");
                    Console.WriteLine($"{traveller.Name}");
                }       
            }
        }
    }
}