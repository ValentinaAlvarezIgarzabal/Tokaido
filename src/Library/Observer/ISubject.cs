using System;
namespace Library
{
    /*
        La interfaz ISubject conoce a los observers y les provee una interfaz para 
        adjuntar o remover cualquier objeto IObserver. 
    */
    public interface ISubject
    {
        void Attach(IObserver observer);
        void Detach(IObserver observer);
        void Notify();
    }
}