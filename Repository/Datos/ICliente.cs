using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Datos
{
    internal interface ICliente
    {
        bool add(ClienteModel cliente);

        bool remove(int id);

        bool update(ClienteModel cliente);

        ClienteModel get(int id);

        IEnumerable<ClienteModel> List();

    }
}
