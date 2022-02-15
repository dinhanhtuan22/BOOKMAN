using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BookMan.ConsoleApp.DataServices
{
    using Models;
    using System.IO;
    /// <summary>
    /// Class dùng để lưu trữ dữ liệu trong file json
    /// </summary>
    public class JsonDataAccess : IDataAccess
    {
        public List<Book> Books { get; set; } = new List<Book>();
        private readonly string _file = Config.Instance.DataFile;
        /// <summary>
        /// Load thông tin trong file
        /// </summary>
        public void Load()
        {
            if (!File.Exists(_file))
            {
                SaveChanges();
                return;
            }
            JsonSerializer serializer = new JsonSerializer();
            using (StreamReader sReader = new StreamReader(_file))
            using (JsonReader jReader = new JsonTextReader(sReader))
            {
                Books = serializer.Deserialize<List<Book>>(jReader);
            }
        }
        /// <summary>
        /// Lưu thông tin vào file
        /// </summary>
        public void SaveChanges()
        {
            JsonSerializer serializer = new JsonSerializer();
            using (StreamWriter sWriter = new StreamWriter(_file))
            using (JsonWriter jWriter = new JsonTextWriter(sWriter))
            {
                serializer.Serialize(jWriter, Books);
            }
        }
    }
}
