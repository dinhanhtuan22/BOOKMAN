using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMan.ConsoleApp.DataServices
{
    using Models;
    using System.IO;
    using System.Xml;
    using System.Xml.Serialization;
    /// <summary>
    /// Class dùng để lưu trữ dữ liệu trong file xml
    /// </summary>
    public class XmlDataAccess : IDataAccess
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
            var serializer = new XmlSerializer(typeof(List<Book>));
            using (var reader = XmlReader.Create(_file))
            {
                Books = (List<Book>)serializer.Deserialize(reader);
            }
        }
        /// <summary>
        /// Lưu thông tin vào file
        /// </summary>
        public void SaveChanges()
        {
            var serializer = new XmlSerializer(typeof(List<Book>));
            using (var writer = XmlWriter.Create(_file))
            {
                serializer.Serialize(writer, Books);
            }
        }
    }
}
