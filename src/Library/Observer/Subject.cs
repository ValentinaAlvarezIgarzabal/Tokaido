using System;
using System.Collections.Generic;

namespace Library
{
    /*
        
    */
    public class Subject : ISubject
    {
        /// <summary>
        /// VisitorsInFarms lleva la cuenta de la cantidad de personas que se encuentran en una granja.
        /// </summary>
        /// <value></value>
        public int VisitorsInFarms {get;set;}
        private int visitorsInFarms
        {
            get {return visitorsInFarms;}
            set
            {
                if(visitorsInFarms >= 4)
                {
                    Notify();
                }
            }
        }

        /// <summary>
        /// VisitorsInOceans lleva la cuenta de cuantas personas se encuentran visitando un oceano.
        /// </summary>
        /// <value></value>

        public int VisitorsInOceans {get;set;}
        private int visitorsInOceans
        {
            get {return visitorsInOceans;}
            set
            {
                if (visitorsInOceans >= 3)
                {   
                    Notify();
                }
            }
        }


        /// <summary>
        /// VisitorsInMountains lleva la cuenta de la cantidad de personas que se encuantran visitando una montaña.
        /// </summary>
        /// <value></value>
        public int VisitorsInMountains {get;set;}
        private int visitorsInMountain
        {
            get {return visitorsInMountain;}
            set
            {
                if (visitorsInMountain >= 5)
                {
                    Notify();
                }  
            }
        }

        /// <summary>
        /// VisitorsInHotWaters lleva la cuenta de la cantidad de personas que se encuentran en las aguas termales.
        /// </summary>
        /// <value></value>
        public int VisitorsInHotWaters {get;set;}
        private int visitorsInHotWaters
        {
            get {return visitorsInHotWaters;}
            set
            {
                if (visitorsInHotWaters >= 3)
                {
                    Notify();
                }
            }
        }

        /// <summary>
        /// Tenemos una lista de observadores (visitantes) a los que se le informara de no poder ingresar a un destino.
        /// </summary>
        /// <typeparam name="IObserver"></typeparam>
        /// <returns></returns>
        private List<IObserver> observers = new List<IObserver>();
        public void Attach(IObserver observer)
        {
            this.observers.Add(observer);
        }

        /// <summary>
        /// Metodo que permite a un observador dejar de ser informado sobre la capacidad de los lugares.
        /// </summary>
        /// <param name="observer"></param>
        public void Detach(IObserver observer)
        {
            this.observers.Remove(observer);
        }


        /// <summary>
        /// Metodo que notifica a los observadores (visitantes) de haber llegado a la maxima capacidad de un lugar.
        /// </summary>
        public void Notify()
        {
            observers.ForEach(observer =>{observer.Update(this);});
        }

    }
}