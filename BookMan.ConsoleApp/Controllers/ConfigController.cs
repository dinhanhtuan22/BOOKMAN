using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMan.ConsoleApp.Controllers
{
    using Framework;
    /// <summary>
    /// Class điều khiển việc cấu hình từ client 
    /// 1. Thay đổi màu sắc và văn bản của dấu nhắc lệnh
    /// 2. Thay đổi cơ chế và nơi lưu trữ dữ liệu
    /// </summary>
    internal class ConfigController : ControllerBase
    {
        private Config _c = Config.Instance;
        /// <summary>
        /// Cấu hình nội dung command
        /// </summary>
        /// <param name="text"></param>
        public void ConfigPromptText(string text)
        {
            _c.PromptText = text;
            Success("The command prompt will change next time");
        }
        /// <summary>
        /// Cấu hình màu sắc command
        /// </summary>
        /// <param name="text"></param>
        public void ConfigPromptColor (string text)
        {
            ConsoleColor color;
            if(Enum.TryParse(text, true, out color))
            {
                _c.PromptColor = color;
                Success("The command prompt color will change next time");
            }
        }
        /// <summary>
        /// Lấy thông tin cơ chế lưu trữ dữ liệu (DataAccess) và nơi lưu trữ file
        /// </summary>
        public void CurrentDataAccess()
        {
            var da = _c.DataAccess;
            var file = _c.DataFile;
            Inform($"Current data access engine: {da}\r\nCurrent data file: {file}");
        }

        /// <summary>
        /// Cấu hình cơ chế lưu trữ dữ liệu và nơi lưu trữ file
        /// </summary>
        /// <param name="da">cơ chế lưu trữ dữ liệu</param>
        /// <param name="file">nơi lưu trữ file</param>
        public void ConfigDataAccess(string da, string file)
        {
            _c.DataAccess = da;
            _c.DataFile = file;
            Success("The changes will be available next time");
        }
    }
}
