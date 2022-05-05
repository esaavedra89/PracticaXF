
namespace PracticaXF.Interfaces
{
    public interface MensajeI
    {
        /// <summary>
        /// Mensaje de mayor duración.
        /// </summary>
        /// <param name="message">Mensaje a mostrar.</param>
        void AlertaLarga(string message);

        /// <summary>
        /// Mensaje de menor duración.
        /// </summary>
        /// <param name="message">Mensaje a mostrar.</param>
        void AlertaCorta(string message);
    }
}
