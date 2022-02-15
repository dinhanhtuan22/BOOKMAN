using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMan.ConsoleApp.DataServices
{
    using Models;
    /// <summary>
    /// 
    /// </summary>
    public interface IDataAccess
    {
        List<Book> Books { get; set; }
        /// <summary>
        /// Load thông tin trong file
        /// </summary>
        void Load();
        /// <summary>
        /// Lưu thông tin vào file
        /// </summary>
        void SaveChanges();
    }
}
