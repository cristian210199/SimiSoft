using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimiSoft.BML
{
    public class Usuario
    {
        private DataAccess dataAccess = DataAccess.Instance();
        public int idUsuario { get; set; }
        public string nombre { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public bool activo { get; set; }
        public Usuario () { }
        public int Add()
        {
            var parametros = new DynamicParameters();
            parametros.Add("@nombre", nombre);
            parametros.Add("@username", username);
            parametros.Add("@password", password);
            return dataAccess.Execute("stp_usuarios_add", parametros);
        }
        public int Update()
        {
            var parametros = new DynamicParameters();
            parametros.Add("@idUsuario", idUsuario);
            parametros.Add("@nombre", nombre);
            parametros.Add("@username", username);
            parametros.Add("@password", password);
            return dataAccess.Execute("stp_usuarios_update", parametros);
        }
        public List<Usuario> GetAll()
        {
            return dataAccess.Query<Usuario>("stp_usuarios_getall");
        }
        public Usuario GetById()
        {
            var parametros = new DynamicParameters();
            parametros.Add("@idUsuario", idUsuario);
            return dataAccess.QuerySingle<Usuario>("stp_usuarios_getbyid", parametros);
        }
        public int Delete()
        {
            var parametros = new DynamicParameters();
            parametros.Add("@idUsuario", idUsuario);
            return dataAccess.Execute("stp_usuarios_delete", parametros);
        }
        public Usuario Login()
        {
            var parametros = new DynamicParameters();
            parametros.Add("@username", username);
            parametros.Add("@password", password);
            return dataAccess.QuerySingleOrDefault<Usuario>("stp_usuarios_login", parametros);
        }
    }
}
