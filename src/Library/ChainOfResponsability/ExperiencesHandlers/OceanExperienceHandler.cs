using System;

namespace Library
{
    /*
        Esta clase cumple con SRP ya que la unica responsabilidad que tiene es procesar un pedido en caso de ser necesario,
        al procesar el pedido suma puntaje al jugador. La unica razon para cambiar esta clase es que se cambie la forma de
        procesar los encuentros en los oceanos. Que se de mas puntaje o menos, o que de de dinero y puntos, o solo dinero.
        Solo al cambiar el intercambio en los oceanos cambiaria la clase.

    */

    public class OceanExperience : BaseHandler
    {
        Points points = new Points();

        /// <summary>
        /// En la clase del Oceano el metodo handler necesita saber que es lo requerido para saber 
        /// si debe cumplir su responsabilidad o no. Ademas necesita saber quien es el jugador asi
        /// le puede dar los puntos que se gano.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="traveller"></param>
        /// <returns></returns>
        public override object Handler(string request, Traveller traveller)
        {
            if ((request) == "Ocean")
            {
                if (points.Ocean == 1)
                {
                    traveller.totalPoints += (points.Ocean + 2);
                }
                else
                {
                    traveller.totalPoints += (points.Ocean + 2);
                }
                return $"This is are your current points {traveller.totalPoints}";
            }
            else
            {
                return base.Handler(request,traveller);
            }
        }
    }
}