using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework
{
    /// <summary>
    /// Class hỗ chợ các chức năng tương tác với console
    /// </summary>
    public static class ViewHelp
    {
        /// <summary>
        /// Xuất thông tin ra console với màu sắc (WriteLine có màu)
        /// </summary>
        /// <param name="message">thông tin cần xuất</param>
        /// <param name="color">màu chữ</param>
        /// <param name="resetColor">trả lại màu mặc định hay không</param>
        public static void WriteLine(string message, ConsoleColor color = ConsoleColor.White, bool resetColor = true)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            if (resetColor)
                Console.ResetColor();
        }
        /// <summary>
        /// Xuất thông tin ra console với màu sắc (Write có màu)
        /// </summary>
        /// <param name="message">thông tin cần xuất</param>
        /// <param name="color">màu chữ</param>
        /// <param name="resetColor">trả lại màu mặc định hay không</param>
        public static void Write(string message, ConsoleColor color = ConsoleColor.White, bool resetColor = true)
        {
            Console.ForegroundColor = color;
            Console.Write(message);
            if (resetColor)
                Console.ResetColor();
        }

        /// <summary>
        /// In ra thông báo và tiếp nhận chuỗi ký tự người dùng nhập
        /// sau đó chuyển sang kiểu bool
        /// </summary>
        /// <param name="label">dòng thông báo</param>
        /// <param name="labelColor">màu chữ thông báo</param>
        /// <param name="valueColor">màu chữ người dùng nhập</param>
        /// <returns></returns>
        public static bool InputBool(string label, ConsoleColor labelColor = ConsoleColor.Magenta, ConsoleColor valueColor = ConsoleColor.White)
        {
            Write($"{label} [y/n]: ", labelColor);
            ConsoleKeyInfo key = Console.ReadKey();
            Console.WriteLine();
            bool @char = key.KeyChar == 'y' || key.KeyChar == 'Y' ? true : false;
            return @char;
        }

        /// <summary>
        /// In ra thông báo và tiếp nhận chuỗi ký tự người dùng nhập
        /// sau đó chuyển sang kiểu bool.
        /// Nếu người dùng không nhập thì trả về giá trị cũ
        /// </summary>
        /// <param name="label">dòng thông báo</param>
        /// <param name="oldValue">giá trị gốc</param>
        /// <param name="labelColor">màu chữ thông báo</param>
        /// <param name="valueColor">màu chữ người dùng nhập</param>
        /// <returns></returns>
        public static bool InputBool(string label, bool oldValue, ConsoleColor labelColor = ConsoleColor.Magenta, ConsoleColor valueColor = ConsoleColor.White)
        {
            Write($"{label} [y/n]: ", labelColor);
            ConsoleKeyInfo key = Console.ReadKey();
            Console.WriteLine();
            if (key != null)
            {
                bool @char = key.KeyChar == 'y' || key.KeyChar == 'Y' ? true : false;
                return @char;
            }
            return oldValue;
        }

        /// <summary>
        /// In ra thông báo và tiếp nhận chuỗi ký tự người dùng nhập        
        /// </summary>
        /// <param name="label">dòng thông báo</param>
        /// <param name="labelColor">màu chữ thông báo</param>
        /// <param name="valueColor">màu chữ người dùng nhập</param>
        /// <returns></returns>
        public static string InputString(string label, ConsoleColor labelColor = ConsoleColor.Magenta, ConsoleColor valueColor = ConsoleColor.White)
        {
            Write($"{label}: ", labelColor, false);
            Console.ForegroundColor = valueColor;
            string value = Console.ReadLine();
            Console.ResetColor();
            return value;
        }
        /// <summary>
        /// Cập nhật giá trị kiểu string. Nếu ấn enter mà không nhập dữ liệu sẽ trả lại giá trị cũ
        /// </summary>
        /// <param name="lable">thông báo</param>
        /// <param name="oldValue">giá trị gốc</param>
        /// <param name="lableColor">màu chữ thông báo</param>
        /// <param name="valueColor">màu chữ nhập liệu</param>
        /// <returns></returns>
        public static string InputString(string lable, string oldValue, ConsoleColor lableColor = ConsoleColor.Magenta, ConsoleColor valueColor = ConsoleColor.White)
        {
            Write($"{lable}: ", lableColor);
            WriteLine(oldValue, ConsoleColor.Yellow);
            Write("New value >> ", ConsoleColor.Green);
            Console.ForegroundColor = valueColor;
            string newValue = Console.ReadLine();
            return string.IsNullOrEmpty(newValue) ? oldValue : newValue;
        }

        /// <summary>
        /// In ra thông báo và tiếp nhận chuỗi ký tự người dùng nhập
        /// sau đó chuyển sang kiểu int
        /// </summary>
        /// <param name="label">dòng thông báo</param>
        /// <param name="labelColor">màu chữ thông báo</param>
        /// <param name="valueColor">màu chữ người dùng nhập</param>
        /// <returns></returns>
        public static int InputInt(string label, ConsoleColor labelColor = ConsoleColor.Magenta, ConsoleColor valueColor = ConsoleColor.White)
        {
            while (true)
            {
                var str = InputString(label, labelColor, valueColor);
                int i;
                var result = int.TryParse(str, out i);
                if (result == true)
                {
                    return i;
                }
            }
        }

        /// <summary>
        /// In ra thông báo và tiếp nhận chuỗi ký tự người dùng nhập
        /// sau đó chuyển sang kiểu int.
        /// Nếu người dùng không nhập thì trả về giá trị cũ
        /// </summary>
        /// <param name="label">dòng thông báo</param>
        /// <param name="oldValue">giá trị gốc</param>
        /// <param name="labelColor">màu chữ thông báo</param>
        /// <param name="valueColor">màu chữ người dùng nhập</param>
        /// <returns></returns>
        public static int InputInt(string label, int oldValue, ConsoleColor labelColor = ConsoleColor.Magenta, ConsoleColor valueColor = ConsoleColor.White)
        {
            while (true)
            {
                var str = InputString(label, oldValue.ToString(), labelColor, valueColor);
                int i;
                var result = int.TryParse(str, out i);
                if (result == true)
                {
                    return i;
                }
            }
        }

    }
}
