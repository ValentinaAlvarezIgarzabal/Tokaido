using System;
using System.Collections.Generic;

namespace Library
{
    /*
            Esta clase tiene la unica responsabilidad de representar a los jugadores. Por esta razon cumple SRP o 
            Principio de Unica Responsabilidad, dado que el principio dice que una clase debe tener una unica razon 
            para cambiar y que cada responsabilidad es un eje de cambio. Si se recive mas de una responsabilidad hay 
            mas razon de cambio y las responsabilidades se acoplarian.
            En esta clase la unica razon de cambio es una nueva forma de definir a un jugador.
    
    
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

        /// <summary>
        /// Se crea un acceso a los puntos de la clase Money.
        /// </summary>
        /// <returns></returns>
        Money money = new Money();

        /// <summary>
        /// Money es el dinero que tiene un jugador.
        /// </summary>
        /// <value></value>
        public int totalMoney {get;set;}

        /// <summary>
        /// Se crea un acceso a los datos de la clase Points.
        /// </summary>
        /// <returns></returns>
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

        public void Update(string notification)
        {
            Console.WriteLine(notification);
        }
    }
}