using System;

namespace Library
{
    /*
            Esta clase contine los valores de los puntajes que recibe un jugador al pasar por una 
            experiencia. En el caso de querer agregar mas experiencias que tengan una forma de puntaje 
            en relacion a distintas situaciones, por ejemplo si se visitan varios lugares historicos.
            Solo se deberia agregar esa nueva variable en referencia a los "Monumentos", crear un handler
            que la utiliza y sumar este nuevo dato a los puntos totales de los jugadores.
    */
    public class Points
    {
        /// <summary>
        /// HotWaters representa los puntos que tiene un jugador al pasar 
        /// por un lugar de aguas termales.
        /// </summary>
        /// <value></value>
        public int HotWaters {get;set;}

        /// <summary>
        /// Ocean representa los puntos de un jugador cuando pasa por un oceano,
        /// el puntaje al pasar por varios oceanos tiene un calculo especial.
        /// </summary>
        /// <value></value>
        public int Ocean {get;set;} = -1;

        /// <summary>
        /// Mountain representa los puntos que tiene un juagdor al pasar por las monrañas,
        /// el calculo del puntaje al pasar por varias montañas tiene una forma especial.
        /// </summary>
        /// <value></value>
        public int Mountain {get;set;}

    }
}