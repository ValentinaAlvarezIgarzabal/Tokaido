namespace Library
{
    /*
        Esta clase cumple con SRP ya que la unica responsabilidad que tiene es informar al visitante, los puntos y 
        monedas que gano durante el camino. La unica razon para cambiar esta clase es que se le quiera informar
        algo distino al visitante, como por ejemplo que se cambie la ruta del juego de Tokio a Edo a Edo - Tokio.
        En ese caso se tiene que cambiar el despido al visitante por un saludo.
    */
    public class EdoExperienceHandler : BaseHandler
    {
        /// <summary>
        /// Metodo para ejecutar un pedido. En este caso al estar en Edo se informa de los puntos y monedas que gano
        /// un visitante durante el camino.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="traveller"></param>
        /// <returns></returns>
        public override object Handler(string request, Traveller traveller)
        {
            if ((request) == "Edo")
            {
                int money = traveller.totalMoney;
                int points = traveller.totalPoints;
                return $"This is the end, {traveller.Name} your stats are the following : /n Coins: {traveller.totalMoney} /n Points: {traveller.totalPoints}";
            }
            else
            {
                return base.Handler(request,traveller);
            }
           
        }
    }
}