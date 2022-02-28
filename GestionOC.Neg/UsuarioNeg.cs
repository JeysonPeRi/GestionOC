using GestionOC.Dal;
using GestionOC.Mod;
using System;
using System.Collections.Generic;
using System.Data;

namespace GestionOC.Neg
{
    public class UsuarioNeg
    {
        public static Usuario BuscarUsuario(int usuarioNumero, out int codigo, out string mensaje)
        {
            Usuario usuario = new Usuario();

            try
            {
                DataTable dataUsuario = UsuarioDal.BuscaUsuario(usuarioNumero, out codigo, out mensaje);
                if (codigo >= 1)
                {
                    foreach (DataRow fila in dataUsuario.Rows)
                    {
                        usuario = new Usuario(Convert.ToInt32(fila[0]), Convert.ToString(fila[4]), Convert.ToString(fila[1]),
                            Convert.ToString(fila[2]), Convert.ToString(fila[3]), BuscarUsuarioAcceso(usuarioNumero, out _, out _),
                            BuscarUsuarioFormularios(usuarioNumero, out _, out _));
                    }
                }
                dataUsuario.Dispose();
                return usuario;
            }
            catch (Exception e)
            {
                codigo = -1;
                mensaje = e.Message;
                return usuario;
            }
        }

        public static List<int> BuscarUsuarioAcceso(int usuarioNumero, out int codigo, out string mensaje)
        {
            List<int> codigoAccesoSistema = new List<int>();

            try
            {
                DataTable dataUsuarioAcceso = UsuarioDal.BuscaUsuarioAcceso(usuarioNumero, out codigo, out mensaje);
                if (codigo >= 1)
                {
                    foreach (DataRow fila in dataUsuarioAcceso.Rows)
                    {
                        codigoAccesoSistema.Add(Convert.ToInt32(fila[1]));
                    }
                }
                dataUsuarioAcceso.Dispose();
                return codigoAccesoSistema;
            }
            catch (Exception e)
            {
                codigo = -1;
                mensaje = e.Message;
                return codigoAccesoSistema;
            }
        }

        public static List<string> BuscarUsuarioFormularios(int usuarioNumero, out int codigo, out string mensaje)
        {
            List<string> codigoAccesoformularios = new List<string>();

            try
            {
                DataTable dataUsuarioformularios = UsuarioDal.BuscaUsuarioFormularios(usuarioNumero, out codigo, out mensaje);
                if (codigo >= 1)
                {
                    foreach (DataRow fila in dataUsuarioformularios.Rows)
                    {
                        codigoAccesoformularios.Add(Convert.ToString(fila[0]));
                    }
                }
                dataUsuarioformularios.Dispose();
                return codigoAccesoformularios;
            }
            catch (Exception e)
            {
                codigo = -1;
                mensaje = e.Message;
                return codigoAccesoformularios;
            }
        }
    }
}
