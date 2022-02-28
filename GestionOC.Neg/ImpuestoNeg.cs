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
    public class ImpuestoNeg
    {
        public static List<Impuesto> ListarImpuesto(out int codigo, out string mensaje)
        {
            List<Impuesto> impuestos = new List<Impuesto>();

            try
            {
                DataTable dataImpuestos = ImpuestoDal.ListaImpuesto(out codigo, out mensaje);
                if (codigo >= 1)
                {
                    foreach (DataRow fila in dataImpuestos.Rows)
                    {
                        impuestos.Add(new Impuesto(Convert.ToInt32(fila[0]), Convert.ToSingle(fila[1]), Convert.ToDateTime(fila[2].ToString())));
                    }
                }
                dataImpuestos.Dispose();
                return impuestos;
            }
            catch (Exception e)
            {
                codigo = -1;
                mensaje = e.Message;
                return impuestos;
            }
        }

        public static Impuesto BuscarImpuesto(DateTime impuestoFecha, out int codigo, out string mensaje)
        {
            Impuesto impuesto = new Impuesto();

            try
            {
                DataTable dataImpuestos = ImpuestoDal.BuscaImpuesto(impuestoFecha, out codigo, out mensaje);
                if (codigo >= 1)
                {
                    foreach (DataRow fila in dataImpuestos.Rows)
                    {
                        impuesto = new Impuesto(Convert.ToInt32(fila[0]), Convert.ToSingle(fila[1]), Convert.ToDateTime(fila[2].ToString()));
                    }
                }
                dataImpuestos.Dispose();
                return impuesto;
            }
            catch (Exception e)
            {
                codigo = -1;
                mensaje = e.Message;
                return impuesto;
            }
        }

        public static void GuardarImpuesto(int codigo, float porcentajeCompleto, DateTime fecha, out int codigoSalida, out string mensaje)
        {
            try
            {
                ImpuestoDal.GuardaImpuesto(codigo, porcentajeCompleto, fecha, out codigoSalida, out mensaje);
            }
            catch (Exception ex)
            {
                codigoSalida = -1;
                mensaje = ex.Message;
            }
        }

        public static void EliminarImpuesto(int codigo, out int codigoSalida, out string mensaje)
        {
            try
            {
                ImpuestoDal.EliminaImpuesto(codigo, out codigoSalida, out mensaje);
            }
            catch (Exception ex)
            {
                codigoSalida = -1;
                mensaje = ex.Message;
            }
        }
    }
}
