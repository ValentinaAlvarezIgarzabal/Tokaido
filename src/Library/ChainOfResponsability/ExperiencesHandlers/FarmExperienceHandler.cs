using System;

namespace Library
{
    /*
        Esta clase cumple con SRP ya que la unica responsabilidad que tiene es procesar un pedido en caso de ser necesario,
        al procesar el pedido suma monedas al jugador. La unica razon para cambiar esta clase es que se cambie la forma de
        procesar los encuentros en una granja. Que se de mas dinero o menos, o que de de dinero y puntos, o solo puntos.
        Solo al cambiar el intercambio en la granja cambiaria la clase.
    */
    public class FarmExperience : BaseHandler
    {
        /// <summary>
        /// En esta clase de Granja el metodo Handler cuando cumple su responsabilidad de acreditar
        /// puntos a un jugador. Este metodo debe conocer cual el es pedido para saber si es su 
        /// responsabilidad y debe saber quien es el juador que pasa por la Granja para darle los puntos.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="traveller"></param>
        /// <returns></returns>
        public override object Handler(string request, Traveller traveller)
        {
            if ((request) == "Farm")
            {
                traveller.totalMoney += 3;
                return $"All this hard work payed off now youo have {traveller.totalMoney}";

            }
            else
            {
                return base.Handler(request,traveller);  
            }
        }
    }
}