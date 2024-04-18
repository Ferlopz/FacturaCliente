using Dapper;
using Microsoft.VisualBasic;
using Repository.Conexion;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Datos
{
    public class ClienteRepository : ICliente
    {
        private IDbConnection conexionDB;
        public ClienteRepository(string _connectionString)
        {
            conexionDB = new DbConection(_connectionString).dbConnection();
        }

        public bool add(ClienteModel cliente)
        {
            try
            {
                if(conexionDB.Execute("Insert into public.\"Cliente\"(id_banco, \"Nombre\", \"Apellido\", \"Documento\", \"Mail\", \"Celular\", \"Estado\", \"Direccion\") values(@id_banco, @Nombre, @Apellido, @Documento," +
                     "@Mail, @Celular, @Estado, @Direccion)", cliente) > 0)
                     return true;
                else
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ClienteModel get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ClienteModel> List()
        {
            throw new NotImplementedException();
        }

        public bool remove(ClienteModel cliente)
        {
            throw new NotImplementedException();
        }

        public bool update(ClienteModel cliente)
        {
            return false;
        }

        public bool updateCliente(ClienteModel cliente, int id_cli)
        {
            try
            {
                if (conexionDB.Execute("UPDATE public.\"Cliente\" SET id_banco=@id_banco, \"Nombre\"=@Nombre, \"Apellido\"=@Apellido, \"Documento\"=@Documento, \"Mail\"=@Mail, \"Celular\"=@Celular, \"Estado\"=@Estado, \"Direccion\"=@Direccion" +
                $" WHERE \"Id_cli\" = {id_cli} ", cliente) > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool delete(ClienteModel cliente, int id_cli)
        {
            return false;
        }

        public bool remove(int id)
        {
            try
            {
                if (conexionDB.Execute("DELETE FROM public.\"Cliente\" " +
                $" WHERE \"Id_cli\" = {id} ") > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool listar()
        {
            try
            {
                if (conexionDB.Execute("SELECT * FROM public.\"Cliente\"") > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }

}
