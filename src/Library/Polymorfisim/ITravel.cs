using System;
using System.Collections.Generic;

namespace Library
{
    /*
        El polimorfismo es la capacidad de un objeto de adquirir varias formas.
        El uso mas comun de polimorfismo se da cuando se utiliza la referencia de una 
        clase padre, para referirse al objeto de la clase hijo.
        Esta caracteristica permite definir distinos comportamientos para un metodo
        dependiendo de la clase sobre la que se realice la implementacion.

        Los metodos Travel y AcceptedVisitors van a tener distintos comportamientos en
        cada clase que realiza la implementacion de la interfaz ITravel.
    */
    public interface ITravel
    {
        /// <summary>
        /// Metodo travel que se usaran en todas las clases que implementen la interfaz. Este metodo decidira si pueden
        /// acceder o no a su destino y les dira a que otros paisajes pueden continuar.
        /// </summary>
        /// <param name="point"></param>
        /// <param name="money"></param>
        /// <param name="travellers"></param>
        void Travel(Points point, Money money, List<Traveller> travellers);

        /// <summary>
        /// Metodo AcceptedVisitors controla la cantidad deseada de visitantes en cada paisaje. 
        /// Los divide en visitantes acceptados y rechazados.
        /// Este metodo es usado en la logica de el metodo Travel.
        /// En caso de querer que mas personas entren a un paisaje, se debe modificar solo este metodo.
        /// </summary>
        /// <param name="travellers"></param>
        void AcceptedVisitors(List<Traveller> travellers);
    }
}