using PracticaXF;
using PracticaXF.Interfaces;
using PracticaXF.Modelo;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

[assembly: Dependency(typeof(DataContext))]
namespace PracticaXF
{
    public class DataContext : BaseDatosI
    {
        #region Attributes
        //public static SQLiteConnection cnn;
        SQLiteAsyncConnection db;
        //public SQLiteAsyncConnection db;
        #endregion

        public DataContext()
        {
            
        }

        async Task Init()
        {
            try
            {
                //cnn = DependencyService.Get<BaseDatosI>().GetConnection();

                //cnn.CreateTable<UsuarioPrueba>();

                if (db != null)
                    return;

                // Get an absolute path to the database file
                var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "TestBD01.db");

                db = new SQLiteAsyncConnection(databasePath);

                await db.CreateTableAsync<UsuarioPrueba>();
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public async Task EliminarContenidoTablaUsuario()
        {
            try
            {
                await Init();
                //cnn.Execute("DELETE FROM UsuarioPrueba");
                await db.ExecuteAsync("DELETE FROM UsuarioPrueba");
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }
        public async Task EliminarUsuario(int idUsuario)
        {
            try
            {
                await Init();
                //cnn.Table<UsuarioPrueba>().Delete(p => p.IdUsuario == idUsuario);
                await db.Table<UsuarioPrueba>().DeleteAsync(p => p.IdUsuario == idUsuario);
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public async Task GuardarUsuario(UsuarioPrueba objUsuarioPrueba)
        {
            try
            {
                await Init();
                if (objUsuarioPrueba.IdUsuario == 0)
                {
                    //cnn.Insert(objUsuarioPrueba);
                    await db.InsertAsync(objUsuarioPrueba);
                }
                else
                {
                    //cnn.Update(objUsuarioPrueba);
                    await db.UpdateAsync(objUsuarioPrueba);
                }
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public async Task GuardarUsuario(List<UsuarioPrueba> objListaUsuarioPrueba)
        {
            try
            {
                await Init();
                //cnn.InsertAll(objListaUsuarioPrueba);
                await db.InsertAllAsync(objListaUsuarioPrueba);
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public async Task<List<UsuarioPrueba>> ObtenerListaUsuarioPrueba()
        {
            try
            {
                await Init();
                // Obtenemos todos los registros.
                object[] objeto = new object[0];

                //List<UsuarioPrueba> objetoObtenido = cnn.Query<UsuarioPrueba>("SELECT * FROM UsuarioPrueba", objeto);
                List<UsuarioPrueba> objetoObtenido = await db.QueryAsync<UsuarioPrueba>("SELECT * FROM UsuarioPrueba", objeto);

                // Retornamos la objeto.
                return objetoObtenido;
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public async Task<List<UsuarioPrueba>> AutenticarUsuario_Local(string usuario, string clave)
        {
            try
            {
                await Init();
                // Obtenemos todos los registros.
                object[] objeto = new object[0];

                //List<UsuarioPrueba> objetoObtenido = cnn.Query<UsuarioPrueba>(
                //    "SELECT * FROM UsuarioPrueba WHERE Login =" + usuario + " AND Contrasenna =" + clave, objeto);
                List<UsuarioPrueba> objetoObtenido = await db.QueryAsync<UsuarioPrueba>(
                    "SELECT * FROM UsuarioPrueba WHERE Login =" + usuario + " AND Contrasenna =" + clave, objeto);

                // Retornamos la objeto.
                return objetoObtenido;
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }
    }
}
