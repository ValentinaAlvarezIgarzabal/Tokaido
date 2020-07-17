using System;

namespace Library
{
    /*
            En este caso para tratar con el camino del juego se utiliza el patron de Cadena de Responsabilidad,
            para implementarlo se necesitan 4 partes:

            - El Handler (IExperienceHandler) : declara la interfaz para todos los handlers concretos.
                Por general tiene un unico metodo para manejar los requerimientos, pero a veces tiene otro metodo 
                para inicializar un proximo handler. En este caso se hicieron los dos metodos para poder crear una
                cadena que represente el camino que se hace en el juego.

            - La Base Handler (BaseHandler) : clase donde se pone el codigo comun a todas las clases de handle.

            - Las Concrete Handlers (Farm/Ocean/Mountain/Hot Waters) : contienen el codigo para procesar los pedidos.
                Luego de recibir un pedido debe decidir si lo procesa o lo pasa al siguiente eslavon de la cadena.

            - El Client (NextExperience) : construye cadenas, un pedido se puede enviar a cualquiera de los handlers en 
                la cadena, no tiene que se le primero.

            Una de las libertades que perimite el patron de Cadena de Responsabilidad es poder hacer nuevos handlers sin
            tener que estar modificando codigo existente. Es decir podriamos ampliar el juego y agregar nuevos sitios a la
            cadena, como una playa o un templo. Por esta razon, se cumple el principo OCP (Principio de Abierto/Cerrado : 
            "las entidades de software deben estar abiertas para su extencion, pero cerradas para su modificacion).

            Ademas, una ventaja del patron es que reduce el acomplamiento. Ya que libera a un objeto de tener que saber
            que otro objeto maneja una peticion. En lugar de que los objetos mantengan referencias entre todos los posibles 
            receptores,solo tienen una unica referencia a sus sucesor.

            srp

    */
    public interface IExperienceHandler
    {
        /// <summary>
        /// Este metodo se declara para poder crear una cadena de responsabilidades
        /// que se comporta como el reccorido del juego.
        /// </summary>
        /// <param name="handler"></param>
        /// <returns></returns>
        IExperienceHandler Next(IExperienceHandler handler);

        /// <summary>
        /// La interfaz declara un metodo para ejecutar un pedido.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="traveller"></param>
        /// <returns></returns>
        object Handler (string request, Traveller traveller);
    } 
}
