using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GestionOC.Mod
{
    public class FuncionGlobal
    {
        internal const string InputkeyRindjael = "cldimensionproductos/+";
        internal const string SaltRindjael = "cldimensionproductos/+";
        internal const string KeyMd5 = "cldimensionproductos";

        public static string formatearRut(string rut)
        {
            int cont = 0;
            string format;
            if (rut.Length == 0)
            {
                return "";
            }
            else
            {
                rut = rut.Replace(".", "");
                rut = rut.Replace("-", "");
                format = "-" + rut.Substring(rut.Length - 1);
                for (int i = rut.Length - 2; i >= 0; i--)
                {
                    format = rut.Substring(i, 1) + format;
                    cont++;
                    if (cont == 3 && i != 0)
                    {
                        format = "." + format;
                        cont = 0;
                    }
                }
                return format;
            }
        }

        public static int FormaterarRutEntero(string rut)
        {
            int numeroRut = -1;
            try
            {
                rut = rut.Replace(".", "");
                if (rut.Contains("-")) { rut = rut.Substring(0, rut.IndexOf("-")); }
                numeroRut = Convert.ToInt32(rut);
                return numeroRut;
            }
            catch (Exception)
            {
                return numeroRut;
            }
        }

        public static bool validarRut(string rut)
        {
            bool validacion = false;
            try
            {
                rut = rut.ToUpper();
                rut = rut.Replace(".", "");
                rut = rut.Replace("-", "");
                int rutAux = int.Parse(rut.Substring(0, rut.Length - 1));

                char dv = char.Parse(rut.Substring(rut.Length - 1, 1));

                int m = 0, s = 1;
                for (; rutAux != 0; rutAux /= 10)
                    s = (s + rutAux % 10 * (9 - m++ % 6)) % 11;

                if (dv == (char)(s != 0 ? s + 47 : 75))
                    validacion = true;
            }
            catch (Exception)
            {

            }
            return validacion;
        }

        public static string DV(int rut)
        {
            int suma = 0;
            int multiplicador = 1;
            while (rut != 0)
            {
                multiplicador++;
                if (multiplicador == 8)
                    multiplicador = 2;
                suma += (rut % 10) * multiplicador;
                rut = rut / 10;
            }
            suma = 11 - (suma % 11);
            switch (suma)
            {
                case 11:
                    return "0";
                case 10:
                    return "K";
                default:
                    return suma.ToString();
            }
        }

        public static string FMoneda(int codigo = 2, decimal monto = 0)
        {
            string mtosalida = "0";
            try
            {
                switch (codigo)
                {
                    //PESOS
                    case 1: mtosalida = monto.ToString("N0"); break;
                    //DOLAR
                    case 2: mtosalida = monto.ToString("N2"); break;
                    //UF
                    case 3: mtosalida = monto.ToString("N2"); break;
                    //NINGUNA
                    default: mtosalida = monto.ToString("N2"); break;
                }
            }
            catch (Exception ex)
            {
                mtosalida = "0";
                string msg = ex.ToString();
            }
            return mtosalida;
        }

        #region ENCRYPTACION RINDJAEL

        #region Rijndael Encryption
        //https://www.codeproject.com/Tips/704372/How-to-Use-Rijndael-ManagedEncryption-with-Csharp

        public static string EncryptRijndael(string text)
        {
            if (string.IsNullOrEmpty(text))
                throw new ArgumentNullException("text");

            var aesAlg = NewRijndaelManaged();

            var encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);
            var msEncrypt = new MemoryStream();
            using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
            using (var swEncrypt = new StreamWriter(csEncrypt))
            {
                swEncrypt.Write(text);
            }

            return Convert.ToBase64String(msEncrypt.ToArray());
        }
        #endregion

        #region Rijndael Dycryption

        public static bool IsBase64String(string base64String)
        {
            base64String = base64String.Trim();
            return (base64String.Length % 4 == 0) &&
                   Regex.IsMatch(base64String, @"^[a-zA-Z0-9\+/]*={0,3}$", RegexOptions.None);

        }

        /// <summary>
        /// Decrypts the given text
        /// </summary>
        /// <param name="cipherText" />The encrypted BASE64 text
        /// <param name="salt" />The pasword salt
        /// <returns>The decrypted text</returns>
        public static string DecryptRijndael(string cipherText)
        {
            if (string.IsNullOrEmpty(cipherText))
                throw new ArgumentNullException("cipherText");

            if (!IsBase64String(cipherText))
                throw new Exception("The cipherText input parameter is not base64 encoded");

            string text;

            var aesAlg = NewRijndaelManaged();
            var decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);
            var cipher = Convert.FromBase64String(cipherText);

            using (var msDecrypt = new MemoryStream(cipher))
            {
                using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                {
                    using (var srDecrypt = new StreamReader(csDecrypt))
                    {
                        text = srDecrypt.ReadToEnd();
                    }
                }
            }
            return text;
        }
        #endregion

        #region NewRijndaelManaged

        private static RijndaelManaged NewRijndaelManaged()
        {
            if (SaltRindjael == null) throw new ArgumentNullException("salt");
            var saltBytes = Encoding.ASCII.GetBytes(SaltRindjael);
            var key = new Rfc2898DeriveBytes(InputkeyRindjael, saltBytes);

            var aesAlg = new RijndaelManaged();
            aesAlg.Key = key.GetBytes(aesAlg.KeySize / 8);
            aesAlg.IV = key.GetBytes(aesAlg.BlockSize / 8);

            return aesAlg;
        }
        #endregion

        #endregion

        #region ENCRYOPTACION MD5

        public static string Encriptar(string texto)
        {
            try
            {
                byte[] arregloACifrar = UTF8Encoding.UTF8.GetBytes(texto);

                //Se utilizan las clases de encriptación MD5

                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();

                var keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(KeyMd5));

                hashmd5.Clear();

                //Algoritmo TripleDES
                TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider
                {
                    Key = keyArray,
                    Mode = CipherMode.ECB,
                    Padding = PaddingMode.PKCS7
                };


                ICryptoTransform cTransform = tdes.CreateEncryptor();

                byte[] arrayResultado = cTransform.TransformFinalBlock(arregloACifrar, 0, arregloACifrar.Length);

                tdes.Clear();

                //se regresa el resultado en forma de una cadena
                texto = Convert.ToBase64String(arrayResultado, 0, arrayResultado.Length);

            }
            catch (Exception ex)
            {

            }
            return texto;
        }
        public static string Desencriptar(string textoEncriptado)
        {
            try
            {
                string key = "cldimensionproductos";
                byte[] arrayADescifrar = Convert.FromBase64String(textoEncriptado);

                //algoritmo MD5
                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();

                var keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));

                hashmd5.Clear();

                TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider
                {
                    Key = keyArray,
                    Mode = CipherMode.ECB,
                    Padding = PaddingMode.PKCS7
                };


                ICryptoTransform cTransform = tdes.CreateDecryptor();

                byte[] resultArray = cTransform.TransformFinalBlock(arrayADescifrar, 0, arrayADescifrar.Length);

                tdes.Clear();
                textoEncriptado = UTF8Encoding.UTF8.GetString(resultArray);

            }
            catch (Exception ex)
            {

            }
            return textoEncriptado;
        }

        #endregion
    }
}
