using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMan.ConsoleApp.DataServices
{
    using Models;
    using System.IO;
    using System.Runtime.Serialization.Formatters.Binary;

    /// <summary>
    /// Class dùng để lưu trữ dữ liệu trong file nhị phân
    /// </summary>
    public class BinaryDataAccess : IDataAccess
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
            using (FileStream stream = File.OpenRead(_file))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                Books = formatter.Deserialize(stream) as List<Book>;
            }
        }
        /// <summary>
        /// Lưu thông tin vào file
        /// </summary>
        public void SaveChanges()
        {
            using (FileStream stream = File.OpenWrite(_file))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, Books);
            }
        }
    }
}
