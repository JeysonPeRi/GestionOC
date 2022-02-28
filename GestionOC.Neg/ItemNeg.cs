using GestionOC.Dal;
using GestionOC.Mod;
using System;
using System.Collections.Generic;
using System.Data;

namespace GestionOC.Neg
{
    public class ItemNeg
    {
        public static List<Item> ListarItem(int ordenCompraNumero, out int codigo, out string mensaje)
        {
            List<Item> items = new List<Item>();

            try
            {
                DataTable dataItems = ItemDal.ListaItem(ordenCompraNumero, out codigo, out mensaje);
                if (codigo >= 1)
                {
                    foreach (DataRow fila in dataItems.Rows)
                    {
                        items.Add(new Item(Convert.ToInt32(fila[0]), fila[1].ToString(), Convert.ToDouble(fila[2]),
                            Convert.ToDouble(fila[3]), Convert.ToDouble(fila[4])));
                    }
                }
                dataItems.Dispose();
                return items;
            }
            catch (Exception e)
            {
                codigo = -1;
                mensaje = e.Message;
                return items;
            }
        }
    }
}
