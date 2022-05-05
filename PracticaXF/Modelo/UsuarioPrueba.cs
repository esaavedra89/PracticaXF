
using SQLite;

namespace PracticaXF.Modelo
{
    public class UsuarioPrueba
    {
        [PrimaryKey, AutoIncrement]
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Edad { get; set; }
        public string Ocupacion { get; set; }
        public string Login { get; set; }
        public string Contrasenna { get; set; }
    }
}
