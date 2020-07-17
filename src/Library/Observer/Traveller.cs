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
    
            Esta clase matiene una referencia con la clase ------- e implementa el metodo Update de IObserver informando 
            de cualquier cammbio de los estados de Subject.
    
    */
    public class Traveller : IObserver
    {
        /// <summary>
        /// Lista de Visitadores.
        /// </summary>
        /// <typeparam name="Traveller"></typeparam>
        /// <returns></returns>
        public List<Traveller> travellers = new List<Traveller>();
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
        /// Metodo donde se informa a un visitante que no puede ingresar a donde queria porque se llego al maximo de capacidad.
        /// </summary>
        /// <param name="subject"></param>
        public void Update(ISubject subject)
        {
            if(subject is Subject subject1)
            {
                Console.WriteLine("You cannot visit this place");
            }
        }
    }
}