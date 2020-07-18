using System;
namespace Library
{
    /*
        El sujeto proporciona una iterfaz para agregar y eliminar observadores.
        El Sujeto conoce a todos sus observadores.
    */
    public interface ISubject
    {
        /// <summary>
        /// Metodo que adjunta visitantes a una lista de observadores.
        /// </summary>
        /// <param name="traveller"></param>
        void Attach(Traveller traveller);

        /// <summary>
        /// Metodo que elimina visitantes de una lista de observadores.
        /// </summary>
        /// <param name="traveller"></param>
        void Detach(Traveller traveller);

        /// <summary>
        /// Metodo que notifica de un cambio a los visitantes que se encuentran en una lista de observadores.
        /// </summary>
        void Notify();
    }
}