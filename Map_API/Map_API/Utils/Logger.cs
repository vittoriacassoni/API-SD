using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Map_API.Utils
{
    /// <summary>
    /// Classe para gerar logs de erro em arquivo texto
    /// </summary>
    public static class Logger
    {
        private const string fileName = "API_Log.txt";
        public static void GenerateLog(Exception error)
        {
            if (File.Exists(fileName))
            {
                File.AppendAllText($"{AppDomain.CurrentDomain.BaseDirectory}\\{fileName}", $"{DateTime.Now.ToString("dd/MM/yyyy")} - Erro: {error.ToString()}" + Environment.NewLine);
            }
        }
    }
}