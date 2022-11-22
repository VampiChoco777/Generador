using System;
using System.IO;

namespace Generico
{
    public class Error : Exception
    {
        public Error(string mensaje, StreamWriter log)
        {
            Console.WriteLine(mensaje);
            log.WriteLine(mensaje);
        }
    }
}