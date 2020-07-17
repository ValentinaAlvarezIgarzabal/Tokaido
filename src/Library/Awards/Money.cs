using System;

namespace Library
{
    /*
            Esta clase contine los valores de las monedas que recibe un jugador al pasar por una 
            experiencia. En el caso de querer agregar mas experiencias que tengan una forma de dar o remover 
            monedas en relacion a distintas situaciones.
            Por ejemplo se quiere agregar una experiencia de un restauran de comida tradicional, el restoran
            solo cobra en yen y los viajantes son extranjeros. Se puede crear una nueva experiencia de un Banco
            donde se resta el dinero de su pais y se intercambia por yens.
            
            Tambien se puede tener monedas de oro, plata, cobre para los primeros en pasar por una experiencia.
            Solo se debe agregar una variable que la represente y esta sumarla al total en la clase player.
    */
    public class Money
    {
        public int Coin {get;set;}

    }
}