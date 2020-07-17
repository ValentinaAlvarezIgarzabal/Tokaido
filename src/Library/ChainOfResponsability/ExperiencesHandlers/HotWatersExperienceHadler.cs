using System;

namespace Library
{
    /*
        Esta clase cumple con SRP ya que la unica responsabilidad que tiene es procesar un pedido en caso de ser necesario,
        al procesar el pedido suma puntaje al jugador. La unica razon para cambiar esta clase es que se cambie la forma de
        procesar los encuentros en las aguas termales. Que se de mas puntaje o menos, o que de de dinero y puntos, o solo dinero.
        Solo al cambiar el intercambio en las aguas termales cambiaria la clase.
    */
    public class HotWatersExperience : BaseHandler
    {
        /// <summary>
        /// En esta calse de Aguas Termales el mtodo handler necesita saber que se requiere para poder saber
        /// si debe cumplir con su responsabilidad o no. Ademas tiene que poder saber quien es el jugadore que
        /// quiere ir a las aguas termales para poder darle los puntos necesarios.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="traveller"></param>
        /// <returns></returns>
        public override object Handler(string request, Traveller traveller)
        {
            if ((request) == "Hot Waters")
            {
                traveller.totalPoints += 2;
                return $"It's great to take a break, you're gifted with two more points. Your total is {traveller.totalPoints}";
            }
            else
            {
                return base.Handler(request,traveller);
            }
        }
    }
}