using FigureAPI.Models;
using Newtonsoft.Json;
using System.IO;

namespace FigureAPI.Data
{
    public static class FileAsDB
    {
        public static void WriteJson(this string filePath, List<Figure> list)
        {
            using (StreamWriter sw = new(filePath))
            {
                string serializedJson = JsonConvert.SerializeObject(list, Formatting.Indented, new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.Objects,
                    TypeNameAssemblyFormatHandling = TypeNameAssemblyFormatHandling.Simple
                });
                sw.Write(serializedJson);

            }
        }

    }
}
