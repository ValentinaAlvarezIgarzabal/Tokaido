using System;
namespace Library
{
    /*
        La interfaz ISubject provee metodos para adjuntar, remover o actualizar cualquier observador. 
    */
    public interface ISubject
    {
        void Attach(Traveller traveller);
        void Detach(Traveller traveller);
        void Notify();
    }
}