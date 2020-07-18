namespace Library
{
    /*
        El patron Observer define una dependencia del tipo "uno a muchos" entre objetos,
        de manera que cuando uno de los objetos cambia su estado, notifica este cambio a 
        todos los dependientes. 
        La interfaz Observer define el metodo que usa el sujeto para modificar cambios en 
        su estado.
    */
    public interface IObserver
    {
        void Update(string notifiaction);
    }
}