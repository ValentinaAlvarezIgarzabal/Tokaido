using System;
using System.Collections.Generic;
using System.Linq;

namespace Library
{
    /*
            La clase NextExperience es el codigo cliente en el patron de cadena de responsabiidad.
            La clase Cliente puede crear una cadena una unica vez o dinamicamente segun la logica 
            del programa. 
    */
    public class NextExperience 
    {
        /// <summary>
        /// Lista de visitantes que terminan su recorrido.
        /// </summary>
        /// <typeparam name="Traveller"></typeparam>
        /// <returns></returns>
        List<Traveller> edo = new List<Traveller>();

        /// <summary>
        /// Creo un acceso a los datos y metodos de la clase.
        /// </summary>
        /// <returns></returns>
        Traveller travel = new Traveller();
        /// <summary>
        /// Diccionario que guarda el lugar que se quiere visitar y la cantidad de personas que lo quieren visitar.
        /// </summary>
        /// <typeparam name="string"></typeparam>
        /// <typeparam name="Int32"></typeparam>
        /// <returns></returns>
        public Dictionary<string,Int32> destinationCount = new Dictionary<string,Int32>();


        /// <summary>
        /// Creo un acceso a los datos de la clase.
        /// </summary>
        /// <returns></returns>
        Subject subject = new Subject();
        
        /// <summary>
        /// Creo un acceso a los metodos de la clase.
        /// </summary>
        /// <returns></returns>
        Points points = new Points();

        BaseHandler handler;


        /// <summary>
        /// Creo un acceso a los metodos y datos de la clase.
        /// </summary>
        /// <returns></returns>
        Round round = new Round();


        /// <summary>
        /// Tengo una lista de tipo Traveller para todos los visitantes
        /// </summary>
        /// <typeparam name="Traveller"></typeparam>
        /// <returns></returns>
        public List<Traveller> travellers = new List<Traveller>();

        /// <summary>
        /// Necesitamos un acceso para la clase Traveller
        /// </summary>
        /// <returns></returns>
        Traveller traveller = new Traveller();

        /// <summary>
        /// Lista que guarda los destinos a donde quieren ir los visitantes.
        /// </summary>
        /// <typeparam name="string"></typeparam>
        /// <returns></returns>
        List<string> visitorsWantedExperience = new List<string>();
        
        /// <summary>
        /// Lista con los nombres de los visitantes.
        /// </summary>
        /// <value></value>
        string[] names = {"Hirotada","Hiroshige","Yoshiyasu","Umeage","Sasayakko"};


        /// <summary>
        /// Metodo que crea a los visitantes.
        /// </summary>
        /// <param name="names"></param>
        public void CreateTraveller(List<string> names)
        {
            var subject = new Subject();
            foreach(string name in names)
            {
                traveller.Name = name;
                traveller.totalPoints = 0;
                traveller.totalMoney = 0;
                travellers.Add(traveller);
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
            if (possibleWinner.Count == 1)
            {
                Console.WriteLine($"The winner is {traveller.Name}");
            }
            else
            {
                Console.WriteLine("The winners are:");
                foreach (Traveller traveller in possibleWinner)
                {
                    Console.WriteLine($"{traveller.Name}");
                }       
            }
        }

        
        /// <summary>
        /// Metodo al que se le pasa por parametro los visitantes que quieren ir a las montañas.
        /// El metodo revisa si el lugar esta lleno y les avisa a los visitantes, ademas les perimite 
        /// elegir a donde se puede continuar. Chequea si es la primer montaña o la segunda por donde pasan
        /// y les ofrece (si es la primera o la segunda) opciones para ir luego.
        /// </summary>
        /// <param name="travellers"></param>
        public void TravellingMountain(List<Traveller> travellers)
        {
            List<Traveller> travellers1 = new List<Traveller>();
            foreach(KeyValuePair<string,Int32> visitingSpots in destinationCount)
            {
                foreach (Traveller traveller in travellers)
                {
                    //Quiere ir a la montaña, hay lugrar y no paso por la primera
                    if ((visitingSpots.Key == "Mountain") && (visitingSpots.Value <= 4) && (points.Mountain == 0))
                    {
                        var result = handler.Handler("Mountain",traveller);
                        travellers1.Add(traveller);
                        var options = new List<string>{"Farm", "Mountain", "Edo"};
                        round.DecideWhereToGo(travellers1,options);
                    }
                    //si no hay lugar para ir a la montaña
                    else if (visitingSpots.Value >= 5)
                    {
                        subject.VisitorsInMountains = visitingSpots.Value;
                        travellers1.Add(traveller);
                        var options = new List<string>{"Farm", "Mountain", "Edo"};
                        round.DecideWhereToGo(travellers1,options);
                    }
                    //si hay espacio para ir a la montaña pero ya fue a una antes solo puede ir a Edo
                    else
                    {
                        var result = handler.Handler("Edo",traveller);
                        edo.Add(traveller);
                    }
                }
            }
        }



        /// <summary>
        /// Metodo al que se le pasa por parametro los visitantes que quieren ir a las aguas termales.
        /// El metodo revisa si el lugar esta lleno y les avisa a los visitantes dandoles opciones para
        /// continuar con su recorrido. Si no esta lleno les permite ir al lugar y les da opciones de a donde seguir.
        /// </summary>
        /// <param name="travellers"></param>
        public void TravellingHotWaters(List<Traveller> travellers)
        {
            List<Traveller> travellers1 = new List<Traveller>();
            foreach(KeyValuePair<string,Int32> visitingSpots in destinationCount)
            {
                foreach (Traveller traveller in travellers)
                {
                    //Si quiere ir a las aguas termales y hay lugar
                    if ((visitingSpots.Key == "Hot Water") && (visitingSpots.Value <= 2))
                    {
                        var result = handler.Handler("Hot Waters",traveller);
                        travellers1.Add(traveller);
                        var options = new List<string>{"Mountain", "Farm", "Edo"};
                        round.DecideWhereToGo(travellers1,options);
                    }
                    //Si esta lleno que pase por los lugares que siguen 
                    else if (visitingSpots.Value >= 2)
                    {
                        subject.VisitorsInHotWaters = visitingSpots.Value;
                        travellers1.Add(traveller);
                        var options = new List<string>{"Mountain", "Farm", "Edo"};
                        round.DecideWhereToGo(travellers1,options);
                    }
                }
            }
        }


        /// <summary>
        /// Metodo al que se le pasa por parametro los visitantes que quieren ir al oceano.
        /// El metodo revisa si el lugar esta lleno y les avisa a los visitantes, si lo esta les da opciones
        /// de a donde seguir el recorrido ya que no se puede ir al oceano. Chequea si es el primer
        /// oceano o el segundo por donde pasan y les ofrece (si es la primera o la segunda) opciones para ir 
        /// luego.
        /// </summary>
        /// <param name="travellers"></param>

        public void TravellingOcean(List<Traveller> travellers)
        {
            List<Traveller> travellers1 = new List<Traveller>();
            foreach(KeyValuePair<string,Int32> visitingSpots in destinationCount)
            {
                foreach (Traveller traveller in travellers)
                {
                    //Si quiere ir al oceano, hay lugar y no paso por todos los oceanos
                    if ((visitingSpots.Key == "Ocean") && (visitingSpots.Value <= 2) && (points.Ocean != 3))
                    {
                        var result = handler.Handler("Ocean",traveller); 
                        travellers1.Add(traveller);
                        var options = new List<string>{"Ocean","Hot Waters", "Mountain","Farm", "Edo"};
                        round.DecideWhereToGo(travellers1,options);
                    }
                    //Si quiere ir pero no hay lugar y ya paso por un oceano
                    else if ((visitingSpots.Value >= 2) && (points.Ocean == 1))
                    {
                        subject.VisitorsInMountains = visitingSpots.Value;
                        travellers1.Add(traveller);
                        var options = new List<string>{"Hot Waters", "Mountain","Farm", "Edo"};
                        round.DecideWhereToGo(travellers1,options);
                    }
                }
            }
        }

        /// <summary>
        /// Metodo al que se le pasa por parametro los visitantes que quieren ir a la granja.
        /// El metodo revisa si el lugar esta lleno y les avisa a los visitantes, de estar lleno 
        /// se dan opciones de los lugares que seguien en el camino a Edo. Chequea si es la primera
        /// granja o la segunda por donde pasan y les ofrece (si es la primera o la segunda) opciones para ir 
        /// luego.
        /// </summary>
        /// <param name="travellers"></param>

        public void TravellingFarms(List<Traveller> travellers)
        {
            List<Traveller> travellers1 = new List<Traveller>();
            foreach(KeyValuePair<string,Int32> visitingSpots in destinationCount)
            {
                foreach (Traveller traveller in travellers)
                {
                    //Quiere ir a la granja, hay espacio para la persona, es a la primera a la que va 
                    if ((visitingSpots.Key == "Farm") && (visitingSpots.Value <= 3) && (travel.totalMoney != 0))
                    {
                        var result = handler.Handler("Farm",traveller); 
                        travellers1.Add(traveller);
                        var options = new List<string>{"Ocean", "Ocean", "Hot Waters", "Mountain","Farm","Mountain","Edo"};
                        round.DecideWhereToGo(travellers1,options);
                    }
                    //no hay espacio para que entre,ya paso por una granja
                    else if ((visitingSpots.Value >= 4) && (travel.totalMoney == 3))
                    {
                        subject.VisitorsInFarms = visitingSpots.Value;
                        travellers1.Add(traveller);
                        var options = new List<string>{"Mountain", "Edo"};
                        round.DecideWhereToGo(travellers1,options);
                    }
                }
            }
        }

        /// <summary>
        /// Metodo donde se pasa por parametro los jugadores que llegaron a Edo, es decir que terminaron el 
        /// recorrido. Por lo tanto se puede decidir el ganador de la partida.
        /// </summary>
        /// <param name="travellers"></param>
        public void TravellingEdo(List<Traveller> travellers)
        {
            if (travellers.Count == 5)
            {
                Winner();
            }
        }
        
    }
}