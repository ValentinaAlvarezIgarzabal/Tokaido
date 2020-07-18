using System;
using System.Collections.Generic;

namespace Library
{
    /*
        Esta clase mantiene el estado de interes para los observadores concretos
        y los notifica cuando cambia su estado.
    */
    public class Traveller : IObserver
    {
        /// <summary>
        /// Lista de Visitadores.
        /// </summary>
        /// <typeparam name="Traveller"></typeparam>
        /// <returns></returns>
        private List<Traveller> travellers = new List<Traveller>();

        /// <summary>
        /// Name es el nombre del jugador.
        /// </summary>
        /// <value></value>
        public string Name {get;set;}

        Money money = new Money();

        /// <summary>
        /// Money es el dinero que tiene un jugador.
        /// </summary>
        /// <value></value>
        public int totalMoney {get;set;}

       
        Points points = new Points();

        /// <summary>
        /// totalPoints representa los puntos finales de un jugador incluyendo 
        /// las visitas en las montañas, los oceanos y las aguas termales.
        /// </summary>
        /// <value></value>
        public int totalPoints {get;set;}

        
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
            foreach(string name in names)
            {
                this.Name = name;
                this.totalPoints = 0;
                this.totalMoney = 0;
                travellers.Add(this);
            }
        }
        
        /// <summary>
        /// Metodo que retorna una lista de visitantes.
        /// </summary>
        /// <returns></returns>
        public List<Traveller> getTravellers()
        {
            return travellers;
        }


        /// <summary>
        /// Metodo que notifica a los observadores de un cambio.
        /// </summary>
        /// <param name="notification"></param>
        public void Update(string notification)
        {
            Console.WriteLine(notification);
        }
    }
}