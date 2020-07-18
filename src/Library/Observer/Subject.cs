using System;
using System.Collections.Generic;

namespace Library
{
    /*
        Implementa la interfaz de actualizacion, guardan la referencia del objeto que observan,
        asi en caso de ser notificadoes de algun cambio pueden preguntar sobre este.
    */
    public class Subject : ISubject
    {
        private string mountain;
        private string hotwater;
        private string ocean;
        private string farm;

        private string notification;

        /// <summary>
        /// Tenemos una lista de observadores (visitantes) a los que se le informara de no poder ingresar a un destino.
        /// </summary>
        /// <typeparam name="IObserver"></typeparam>
        /// <returns></returns>
        private List<Traveller> observers = new List<Traveller>();

        /// <summary>
        /// Metodo que adjunta visitantes a una lista de observadores.
        /// </summary>
        /// <param name="traveller"></param>
        public void Attach(Traveller traveller)
        {
            this.observers.Add(traveller);
        }

        /// <summary>
        /// Metodo que devuelve una lista de observadores.
        /// </summary>
        /// <returns></returns>
        public List<Traveller> GetObservers()
        {
            return observers;
        }

        /// <summary>
        /// Metodo que agrega observadores a una lista para que se les informe de los posibles cambios en la capacidad
        /// maxima de un destino.
        /// </summary>
        public void AttachObservers()
        {
            foreach(Traveller traveller in observers)
            {
                Attach(traveller);
            }
        }

        /// <summary>
        /// Metodo que permite a un observador dejar de ser informado sobre la capacidad de los lugares.
        /// </summary>
        /// <param name="observer"></param>
        public void Detach(Traveller traveller)
        {
            this.observers.Remove(traveller);
        }


        /// <summary>
        /// Metodo que notifica a los observadores (visitantes) de haber llegado a la maxima capacidad de un lugar.
        /// </summary>
        public void Notify()
        {
            foreach(Traveller traveller in observers)
            {
                traveller.Update(notification);
            }
        }

        /// <summary>
        /// Metodo que si cambia se notificara al observador.
        /// </summary>
        /// <param name="notification"></param>

        public void MountainVisitors(string notification)
        {
            this.mountain = notification;
            Notify();    
        }

        /// <summary>
        /// Metodo que si cambia se notificara al observador.
        /// </summary>
        /// <param name="notification"></param>
        public void OceanVisitors(string notification)
        {
            this.ocean = notification;
            Notify();
        }

        /// <summary>
        /// Metodo que si cambia se notificara al observador.
        /// </summary>
        /// <param name="notification"></param>
        public void HotWatersVisitors(string notification)
        {
            this.hotwater = notification;
            Notify();

        }

        /// <summary>
        /// Metodo que si cambia se informara al observador.
        /// </summary>
        /// <param name="notification"></param>
        public void FarmVisitors(string notification)
        {
            this.farm = notification;
            Notify();
        }

    }
}