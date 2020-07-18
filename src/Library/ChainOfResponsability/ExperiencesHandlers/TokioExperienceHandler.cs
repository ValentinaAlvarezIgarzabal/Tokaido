namespace Library
{
    /*
        Esta clase cumple con SRP ya que la unica responsabilidad que tiene es saludar al visitante. La unica razon 
        para cambiar esta clase es que se le quiera informar algo distino al visitante, como por ejemplo que el juego 
        cambie y se haga de Edo a Tokio. En ese caso, en lugar de saludarlo, lo despide informando de los puntos y
        monedas ganadas en el camino.
    */
    public class TokioExperienceHandler : BaseHandler
    {
        /// <summary>
        /// Metodo que recibe un pedido y lo ejecuta, dando por resultado un saludo al jugador que se encuentre en Tokio.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="traveller"></param>
        /// <returns></returns>
        public override object Handler(string request, Traveller traveller)
        {
            if ((request) == "Tokio")
            {
                return $"Hello welcome to the begining of this journey";
            }
            else
            {
                return base.Handler(request,traveller);
            }
        }
    }
}