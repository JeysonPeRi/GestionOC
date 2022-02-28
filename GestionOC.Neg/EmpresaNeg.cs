using GestionOC.Dal;
using GestionOC.Mod;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionOC.Neg
{
    public class EmpresaNeg
    {
        public static Empresa BuscarEmpresa(int empresaCodigo, out int codigo, out string mensaje)
        {
            Empresa empresa = new Empresa();

            try
            {
                DataTable dataEmpresas = EmpresaDal.BuscaEmpresa(empresaCodigo, out codigo, out mensaje);
                if (codigo >= 1)
                {
                    foreach (DataRow fila in dataEmpresas.Rows)
                    {
                        empresa = new Empresa(Convert.ToInt32(fila[0]), fila[1].ToString(), fila[2].ToString(), Convert.ToInt32(fila[3]),
                            fila[4].ToString(), Convert.ToInt32(fila[5]), Convert.ToInt32(fila[6]), fila[7].ToString(), fila[7].ToString());
                    }
                }
                dataEmpresas.Dispose();
                return empresa;
            }
            catch (Exception e)
            {
                codigo = -1;
                mensaje = e.Message;
                return empresa;
            }
        }
    }
}
