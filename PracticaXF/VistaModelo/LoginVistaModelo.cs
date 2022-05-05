using Newtonsoft.Json;
using PracticaXF.Interfaces;
using PracticaXF.Modelo;
using PracticaXF.Vista;
using System;
using System.ComponentModel;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PracticaXF.VistaModelo
{
    public class LoginVistaModelo : INotifyPropertyChanged
    {
        BaseDatosI baseDatosI;

        #region INotifyPropertyChanged

        // INotifyPropertyChanged interfaz que permite notificar cuando una propiedad ha cambiado.
        // Muy importante para poder determinar el cambio de valor de una propiedad en las ViewModels.
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        #region Atributos

        string _usuario;

        string _contrasenna;

        #endregion

        #region Propiedades

        public string Usuario
        {
            get { return _usuario; }
            set
            {
                _usuario = value;
                OnPropertyChanged("Usuario");
            }
        }

        public string Contrasenna
        {
            get { return _contrasenna; }
            set
            {
                _contrasenna = value;
                OnPropertyChanged("Contrasenna");
            }
        }

        #endregion

        #region Constructors

        public LoginVistaModelo()
        {
        }

        #endregion

        #region Comandos

        public Command EnviarCommand
        {
            get
            {
                return new Command(async () =>
                {
                    await Enviar().ConfigureAwait(false);
                });
            }
        }

        #endregion

        async void AsignarDatos()
        {
            try
            {
                await baseDatosI.ObtenerListaUsuarioPrueba();
                
            }
            catch (Exception exc)
            {
                
            }
        }

        async Task Enviar()
        {
            try
            {
                UsuarioPrueba objUsuarioPrueba = new UsuarioPrueba();
                objUsuarioPrueba.Login = this.Usuario;
                objUsuarioPrueba.Contrasenna = this.Contrasenna;

                // Creamos el JSON.
                string json = JsonConvert.SerializeObject(objUsuarioPrueba);

                // Configuración para evitar error de certificado.
                HttpClientHandler httpClientHandler = new HttpClientHandler();
                httpClientHandler.ServerCertificateCustomValidationCallback =
                (message, cert, chain, errors) => { return true; };
                
                HttpClient httpClient = new HttpClient(httpClientHandler);

                // Headers.
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("Application/json"));

                // petición.
                HttpResponseMessage response = await httpClient.PostAsync(
                        "https://neobusinessapi.conveyor.cloud/Usuario_AutenticarPrueba", new StringContent(json, Encoding.UTF8, "application/json")).ConfigureAwait(false);
                if (!response.IsSuccessStatusCode)
                {
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        Application.Current.MainPage.DisplayAlert(
                            response.StatusCode.ToString(),
                            response.ReasonPhrase.ToString(), "Aceptar");
                    });
                }
                else
                {
                    string resultadoJson = await response.Content.ReadAsStringAsync();

                    var objUsuarioRespuesta = JsonConvert.DeserializeObject<UsuarioPrueba>(resultadoJson);
                    if (objUsuarioRespuesta != null && objUsuarioRespuesta.IdUsuario > 0)
                    {
                        Device.BeginInvokeOnMainThread(async()=> 
                        { await Application.Current.MainPage.Navigation.PushAsync(new HomeVista(), false); 
                        });
                    }
                }

                //DataContext objDataContext = new DataContext();

                //var objObtenido = await objDataContext.AutenticarUsuario_Local(this.Usuario, this.Contrasenna);

                //if (objObtenido != null && objObtenido.Count > 0)
                //{
                //    await Application.Current.MainPage.Navigation.PushAsync(new HomeVista(), false);
                //}
            }
            catch (Exception exc)
            {

            }
        }
    }
}
