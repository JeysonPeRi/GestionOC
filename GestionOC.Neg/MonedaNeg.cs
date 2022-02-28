using GestionOC.Dal;
using GestionOC.Mod;
using System;
using System.Collections.Generic;
using System.Data;

namespace GestionOC.Neg
{
    public class MonedaNeg
    {
        public static List<Moneda> ListarMoneda(out int codigo, out string mensaje)
        {
            List<Moneda> monedas = new List<Moneda>();

            try
            {
                DataTable dataMonedas = MonedaDal.ListaMoneda(out codigo, out mensaje);
                if (codigo >= 1)
                {
                    foreach (DataRow fila in dataMonedas.Rows)
                    {
                        monedas.Add(new Moneda(Convert.ToInt32(fila[0]), fila[1].ToString(), fila[2].ToString()));
                    }
                }
                dataMonedas.Dispose();
                return monedas;
            }
            catch (Exception e)
            {
                codigo = -1;
                mensaje = e.Message;
                return monedas;
            }
        }

        public static Moneda BuscarMoneda(int monedaCodigo, out int codigo, out string mensaje)
        {
            Moneda moneda = new Moneda();

            try
            {
                DataTable dataMonedas = MonedaDal.BuscaMoneda(monedaCodigo, out codigo, out mensaje);
                if (codigo >= 1)
                {
                    foreach (DataRow fila in dataMonedas.Rows)
                    {
                        moneda = new Moneda(Convert.ToInt32(fila[0]), fila[1].ToString(), fila[2].ToString());
                    }
                }
                dataMonedas.Dispose();
                return moneda;
            }
            catch (Exception e)
            {
                codigo = -1;
                mensaje = e.Message;
                return moneda;
            }
        }

        public static void GuardarActualizarMoneda(int codigo, string glosa, string simbolo, out int codigoSalida, out string mensaje)
        {
            try
            {
                MonedaDal.GuardaActualizaMoneda(codigo, glosa, simbolo, out codigoSalida, out mensaje);
            }
            catch (Exception ex)
            {
                codigoSalida = -1;
                mensaje = ex.Message;
            }
        }

        public static void EliminarMoneda(int codigo, out int codigoSalida, out string mensaje)
        {
            try
            {
                MonedaDal.EliminaMoneda(codigo, out codigoSalida, out mensaje);
            }
            catch (Exception ex)
            {
                codigoSalida = -1;
                mensaje = ex.Message;
            }
        }
    }
}
