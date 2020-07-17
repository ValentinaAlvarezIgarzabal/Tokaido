namespace Library
{
    /*
        La cinterfaz IObserver define una actualizacion para los objetos que deben 
        ser notificados de cambios en un sujeto.
    */
    public interface IObserver
    {
        void Update(ISubject subject);
    }
}