using Dapper;
using Repository.Conexion;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Datos
{
    public class FacturaRepository : IFactura
    {

        private IDbConnection conexionDB;
        public FacturaRepository(string _connectionString)
        {
            conexionDB = new DbConection(_connectionString).dbConnection();
        }

        public bool add(FacturaModel factura)
        {
            try
            {
                if (conexionDB.Execute("Insert into public.\"Factura\"(id, \"id_cliente\", \"Nro_Factura\", \"Fecha_Hora\"," +
                    " \"Total\", \"Total_iva5\", \"Total_iva10\", \"Total_iva\", \"Total_letras\", \"Sucursal\")" +
                    " values(@id, @id_cliente, @Nro_Factura, @Fecha_Hora, @Total," +
                     "@Total_iva5, @Total_iva10, @Total_iva, @Total_letras, @Sucursal)", factura) > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public FacturaModel get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<FacturaModel> List()
        {
            throw new NotImplementedException();
        }

        public bool remove(int id_fac)
        {
            try
            {
                if (conexionDB.Execute("DELETE FROM public.\"Factura\" " +
                $" WHERE \"id_fac\" = {id_fac} ") > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool updateFactura(FacturaModel factura, int id_fac)
        {
            try
            {
                if (conexionDB.Execute("UPDATE public.\"Factura\" SET id_cliente=@id_cliente, \"Nro_Factura\"=@Nro_Factura, \"Fecha_Hora\"=@Fecha_Hora," +
                " \"Total\"=@Total, \"Total_iva5\"=@Total_iva5, \"Total_iva10\"=@Total_iva10, \"Total_iva\"=@Total_iva, " +
                " \"Total_letras\"=@Total_letras, \"Sucursal\"=@Sucursal " +
                $" WHERE \"id_fac\" = {id_fac} ", factura) > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool update(FacturaModel factura)
        {
            throw new NotImplementedException();
        }
    }
}
