using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMan.ConsoleApp
{
    using DataServices;
    /// <summary>
    /// Class xây dựng cấu hình cho client
    /// 1. Thay đổi màu sắc và văn bản của dấu nhắc lệnh
    /// 2. Thay đổi cơ chế và nơi lưu trữ dữ liệu
    /// </summary>
    internal class Config
    {
        private static Config _instance;

        /// <summary>
        /// Thuộc tính tĩnh tạo đối tượng Config để sử dụng
        /// </summary>
        public static Config Instance = _instance ?? (_instance = new Config());
        private Config() { }
        private Properties.Settings _s = Properties.Settings.Default;

        public void Reload() => _s.Reload();
        
        /// <summary>
        /// Cấu hình cơ chế lưu trữ dữ liệu (binary, json, xml)
        /// </summary>
        public IDataAccess IDataAccess
        {
            get
            {
                var da = _s.DataAccess;
                switch(da.ToLower())
                {
                    case "binary":return new BinaryDataAccess();
                    case "json": return new JsonDataAccess();
                    case "xml": return new XmlDataAccess();
                    default: return new BinaryDataAccess();
                }
            }
        } 
        public string DataAccess
        {
            get { return _s.DataAccess; }
            set
            {
                _s.DataAccess = value;
                _s.Save();
            }
        } 
        /// <summary>
        /// Cấu hình chữ mặc định của command
        /// </summary>
        public string PromptText
        {
            get { return _s.PromptText; }
            set
            {
                _s.PromptText = value;
                _s.Save();
            }
        }
        /// <summary>
        /// Cấu hình màu chữ của command
        /// </summary>
        public ConsoleColor PromptColor
        {
            get
            { return _s.PromptColor; }
            set
            {
                _s.PromptColor = value;
                _s.Save();
            }
        }

        /// <summary>
        /// Cấu hình nơi lưu trữ dữ liệu
        /// </summary>
        public string DataFile
        {
            get { return _s.DataFile; }
            set
            {
                _s.DataFile = value;
                _s.Save();
            }
        }
    }
}
