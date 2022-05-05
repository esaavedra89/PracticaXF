
using Android.App;
using Android.Views;
using Android.Widget;
using PracticaXF.Droid.Implementaciones;
using PracticaXF.Interfaces;

[assembly: Xamarin.Forms.Dependency(typeof(MensajeAndroid))]
namespace PracticaXF.Droid.Implementaciones
{
    public class MensajeAndroid : MensajeI
    {
        /// <summary>
        /// Configura un mensaje toast de larga duración.
        /// </summary>
        /// <param name="message">Mensaje a mostrar.</param>
        public void AlertaLarga(string message)
        {
            Toast toast = Toast.MakeText(Application.Context, message, ToastLength.Long);
            toast.SetGravity(Gravity.GetAbsoluteGravity(GravityFlags.Center, GravityFlags.FillHorizontal), 0, 0);
            toast.Show();
            //Toast.MakeText(Application.Context, message, ToastLength.Long).Show();
        }

        /// <summary>
        /// Configura un mensaje toast de corta duración.
        /// </summary>
        /// <param name="message">Mensaje a mostrar.</param>
        public void AlertaCorta(string message)
        {
            //Toast.MakeText(Application.Context, message, ToastLength.Short).Show();
            Toast toast = Toast.MakeText(Application.Context, message, ToastLength.Short);
            toast.SetGravity(Gravity.GetAbsoluteGravity(GravityFlags.Center, GravityFlags.FillHorizontal), 0, 0);
            toast.Show();
        }
    }
}