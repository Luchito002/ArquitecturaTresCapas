using System;
using System.Security.Cryptography;
using System.Text;

namespace Tools
{
    public class Encriptacion
    {
        // Generar un par de claves RSA (pública y privada)
        public static void GenerarClaves(out string clavePublica, out string clavePrivada)
        {
            using (var rsa = new RSACryptoServiceProvider(2048)) // 2048 es el tamaño de la clave
            {
                clavePublica = Convert.ToBase64String(rsa.ExportRSAPublicKey());
                clavePrivada = Convert.ToBase64String(rsa.ExportRSAPrivateKey());
            }
        }

        // Encriptar con clave pública
        public static string EncriptarConClavePublica(string texto, string clavePublica)
        {
            using (var rsa = new RSACryptoServiceProvider(2048))
            {
                rsa.ImportRSAPublicKey(Convert.FromBase64String(clavePublica), out _);

                byte[] datos = Encoding.UTF8.GetBytes(texto);
                byte[] datosEncriptados = rsa.Encrypt(datos, false);

                return Convert.ToBase64String(datosEncriptados);
            }
        }

        // Desencriptar con clave privada
        public static string DesencriptarConClavePrivada(string textoEncriptado, string clavePrivada)
        {
            using (var rsa = new RSACryptoServiceProvider(2048))
            {
                rsa.ImportRSAPrivateKey(Convert.FromBase64String(clavePrivada), out _);

                byte[] datosEncriptados = Convert.FromBase64String(textoEncriptado);
                byte[] datosDesencriptados = rsa.Decrypt(datosEncriptados, false);

                return Encoding.UTF8.GetString(datosDesencriptados);
            }
        }
    }
}
