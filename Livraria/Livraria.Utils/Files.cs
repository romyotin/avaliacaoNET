using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Livraria.Utils
{
    public class Files
    {
        public static System.IO.FileStream AbrirArquivo(string path)
        {
            // Create a temporary file, and put some data into it.
            using (FileStream fs = File.Open(path, FileMode.Open, FileAccess.Write, FileShare.None))
            {
                return fs;
            }
        }

        public static void Registrar(string texto, string path)
        {
            var file = AbrirArquivo(path);
            Byte[] info = new UTF8Encoding(true).GetBytes(texto);
            // Add some information to the file.
            file.Write(info, 0, info.Length);
        }
    }
}
