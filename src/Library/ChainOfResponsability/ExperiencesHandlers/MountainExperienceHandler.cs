using System;

namespace Library
{
    /*
        Esta clase cumple con SRP ya que la unica responsabilidad que tiene es procesar un pedido en caso de ser necesario,
        al procesar el pedido suma puntaje al jugador. La unica razon para cambiar esta clase es que se cambie la forma de
        procesar los encuentros en las montañas. Que se de mas puntaje o menos, o que de de dinero y puntos, o solo dinero.
        Solo al cambiar el intercambio en las montañas cambiaria la clase.
    */
    public class MountainExperience : BaseHandler
    {
        Points points = new Points();

        /// <summary>
        /// En esta clase de Montaña en metodo handler necesita saber cual es el requerimiento para poder saber si debe cumplir con 
        /// su responsabilidad. Ademas necesita conocer quien es el jugador que quiere visitar las montañas para darle los puntos.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="traveller"></param>
        /// <returns></returns>
        public override object Handler(string request, Traveller traveller)
        {
            if ((request) == "Mountain")
            {
                traveller.totalPoints += (points.Mountain + 1);
                return $"It's a great view form above, while distracted you were acredited with more ponits. Your total is {traveller.totalPoints}";
            }
            else
            {
                return base.Handler(request,traveller);
            }
        }
    }
}