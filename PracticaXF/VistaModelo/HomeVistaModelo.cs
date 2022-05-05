using Newtonsoft.Json;
using PracticaXF.Interfaces;
using PracticaXF.Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Http;
using System.Net.Http.Headers;
using Xamarin.Forms;

namespace PracticaXF.VistaModelo
{
    public class HomeVistaModelo : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged

        // INotifyPropertyChanged interfaz que permite notificar cuando una propiedad ha cambiado.
        // Muy importante para poder determinar el cambio de valor de una propiedad en las ViewModels.
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        List<UsuarioPrueba> _listaUsuarioPrueba;

        public List<UsuarioPrueba> ListaUsuarioPrueba
        {
            get { return _listaUsuarioPrueba; }
            set
            {
                _listaUsuarioPrueba = value;
                OnPropertyChanged("ListaUsuarioPrueba");
            }
        }

        public HomeVistaModelo()
        {
            LoadData();
        }

        async void LoadData()
        {
            try
            {
                // Mostramos mensaje.
                DependencyService.Get<MensajeI>().AlertaCorta("Consultando...");


                // Configuración para evitar error de certificado.
                HttpClientHandler httpClientHandler = new HttpClientHandler();
                httpClientHandler.ServerCertificateCustomValidationCallback =
                (message, cert, chain, errors) => { return true; };

                HttpClient httpClient = new HttpClient(httpClientHandler);

                // Headers.
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("Application/json"));

                // petición.
                HttpResponseMessage response = await httpClient.GetAsync(
                    "https://neobusinessapi.conveyor.cloud/ObtenerLista")
                    .ConfigureAwait(false);
                if (!response.IsSuccessStatusCode)
                {
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        Application.Current.MainPage.DisplayAlert(
                            response.StatusCode.ToString(),
                            "", "Aceptar");
                    });
                }
                else
                {
                    string resultadoJson = await response.Content.ReadAsStringAsync();

                    List<UsuarioPrueba> objUsuarioRespuesta = JsonConvert.DeserializeObject<List<UsuarioPrueba>>(resultadoJson);
                    if (objUsuarioRespuesta != null && objUsuarioRespuesta.Count > 0)
                    {
                        this.ListaUsuarioPrueba = objUsuarioRespuesta;
                    }
                }
            }
            catch (Exception exc)
            {
                // Mostramos mensaje.
                DependencyService.Get<MensajeI>().AlertaCorta("Ha ocurrido un error: " + exc.Message);
            }
        }
    }
}
