using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace TitkositoV2
{
    public static class Titkosito
    {
        public static string Message { get; set; }

        public static void Kodolas(string fajlnev,string kodoltFajlnev,string jelszo)
        {
            
            try
            {
                Aes aes=Aes.Create();
                SHA256 sha256 = SHA256.Create();
                aes.GenerateIV();
                
                byte[] fajl=File.ReadAllBytes(fajlnev);
                int fajlLength=fajl.Length;
                byte[] kulcs = sha256.ComputeHash(Encoding.UTF8.GetBytes(jelszo));
                byte[] tartalomHash = sha256.ComputeHash(fajl);
                byte[] binFajlnev=Encoding.UTF8.GetBytes(fajlnev);
                int binFajlnevLength=binFajlnev.Length;

                ICryptoTransform encoder = aes.CreateEncryptor(kulcs,aes.IV);
                byte[] encoded = encoder.TransformFinalBlock(fajl,0,fajl.Length); 
                int encodedLength=encoded.Length;

                byte[] encodedFile = new byte[aes.IV.Length+binFajlnevLength+binFajlnev.Length+tartalomHash.Length+encodedLength+encoded.Length];

                using (MemoryStream ms=new MemoryStream(encodedFile))
                {
                    using (BinaryWriter writer=new BinaryWriter(ms))
                    {
                        writer.Write(aes.IV);
                        writer.Write(binFajlnevLength);
                        writer.Write(binFajlnev);
                        writer.Write(tartalomHash);
                        writer.Write(encodedLength);
                        writer.Write(encoded);
                    }
                    File.WriteAllBytes(kodoltFajlnev, encodedFile);
                    Message = $"{kodoltFajlnev} kiírva";
                }
            }
            catch (Exception ex)
            {
                Message = ex.Message;                
            }

        }

        public static void Dekodolas()
        {

        }
    }
}
