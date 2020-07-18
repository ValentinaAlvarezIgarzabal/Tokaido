using System;
using System.Collections.Generic;

namespace Library
{
    /*
        
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
        public void Attach(Traveller traveller)
        {
            this.observers.Add(traveller);
        }

        public List<Traveller> GetObservers()
        {
            return observers;
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

        public void MountainVisitors(string notification)
        {
            this.mountain = notification;
            Notify();    
        }

        public void OceanVisitors(string notification)
        {
            this.ocean = notification;
            Notify();
        }

        public void HotWatersVisitors(string notification)
        {
            this.hotwater = notification;
            Notify();

        }

        public void FarmVisitors(string notification)
        {
            this.farm = notification;
            Notify();
        }

    }
}