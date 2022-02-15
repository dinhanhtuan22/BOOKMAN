using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Framework
{
    /// <summary>
    /// Xây dựng phương thức đọc tham số từ router
    /// 1. Lưu các cặp khóa-giá trị do người dùng nhập;
    /// 2. Chuỗi tham số cần viết ở dạng khóa=giá trị;
    /// 3. Nếu có nhiều tham số thì viết tách nhau bằng ký tự &
    /// </summary>
    public class Parameter
    {
        private readonly Dictionary<string, string> _pairs = new Dictionary<string, string>();

        /// <summary>
        /// nạp chồng phép toán indexing[]; cho phép truy xuất giá trị theo kiểu biến[khóa]=giá_trị;
        /// </summary>
        /// <param name="key">khóa</param>
        /// <returns>giá trị tương ứng</returns>
        public string this[string key]          // Để nạp chồng phép toán indexing phải viết hai phương thức get, set
        {
            get
            {
                if (_pairs.ContainsKey(key))
                    return _pairs[key];
                else
                    return null;
            } 
            set
            {
                _pairs[key] = value;
            }
        }

        /// <summary>
        /// Kiểm tra xem 1 khóa có trong danh sách tham số không
        /// </summary>
        /// <param name="key">khóa cần kiểm tra</param>
        /// <returns></returns>
        public bool ContainsKey(string key)
        {
            return _pairs.ContainsKey(key);
        }

        /// <summary>
        /// Nhận chuỗi ký tự và phân tích, chuyển thành các cặp khóa-giá trị
        /// </summary>
        /// <param name="parameter">chuỗi giá trị theo quy tắc khóa_1=giá_trị_1&khóa_2=giá_trị_2</param>
        public Parameter(string parameter)
        {
            //cắt chuỗi theo mốc ký tự là &
            //kết quả của phép toán này là 1 mảng, mỗi phần tử là một chuỗi có dạng khóa=giá_trị
            var pairs = parameter.Split(new[] { '&' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var pair in pairs)
            {
                var p = pair.Split('=');
                if (p.Length == 2) //một cặp khóa = giá_trị đúng sau khi cắt sẽ phải có 2 phần
                {
                    var key = p[0].Trim();
                    var value = p[1].Trim();
                    this[key] = value;//lưu lại cặp khóa-giá_trị này sử dụng phép toán indexing

                    // cũng có thể viết theo kiểu khác, trực tiếp sử dụng biến _pairs
                    // _pairs[key] = value;
                }
            }
        }        
    }
}
