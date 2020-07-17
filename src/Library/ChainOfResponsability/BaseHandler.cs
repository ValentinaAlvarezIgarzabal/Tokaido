using System;

namespace Library
{
    /*
            Como ya se habla en la interfaz IExperienceHandler, se usa el patron de Cadena de Responsabilidad.
            La clase BaseHandler contine codigo comun a todas las clases que son handler.
    */

    /// <summary>
    /// El comportamiento que cambia se puede implementar en una clase base.
    /// </summary>
    public abstract class BaseHandler : IExperienceHandler
    {
        private IExperienceHandler nextHandler;

        /// <summary>
        /// Este metodo nos permitira crear una cadena que representaria el camino del juego.
        /// </summary>
        /// <param name="handler"></param>
        /// <returns></returns>
        public IExperienceHandler Next(IExperienceHandler handler)
        {
            this.nextHandler = handler;
            return handler;
        }

        public virtual object Handler(string request, Traveller traveller)
        {
            if (this.nextHandler != null)
            {
                return this.nextHandler.Handler(request,traveller);
            }
            else
            {
                return null;
            }
        }
    }
}