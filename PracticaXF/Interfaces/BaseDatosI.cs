using PracticaXF.Modelo;
using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PracticaXF.Interfaces
{
    public interface BaseDatosI
    {
        //SQLiteConnection GetConnection();

        Task EliminarContenidoTablaUsuario();
        Task EliminarUsuario(int idUsuario);
        Task GuardarUsuario(UsuarioPrueba objUsuarioPrueba);
        Task GuardarUsuario(List<UsuarioPrueba> objListaUsuarioPrueba);
        Task<List<UsuarioPrueba>> ObtenerListaUsuarioPrueba();
        Task<List<UsuarioPrueba>> AutenticarUsuario_Local(string usuario, string clave);
    }
}
