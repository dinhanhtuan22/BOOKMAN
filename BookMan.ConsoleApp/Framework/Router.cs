using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework //Lưu ý không gian tên
{
    // alias cho một kiểu dữ liệu
    // Lưu ý, khai báo trực tiếp trong namespace
    using RoutingTable = Dictionary<string, ControllerAction>;

    /// <summary>
    /// khai báo delegate
    /// </summary>
    /// <param name="parameter"></param>
    public delegate void ControllerAction(Parameter parameter = null);

    /// <summary>
    /// Lớp cho phép ánh xạ truy vấn với phương thức
    /// </summary>
    public class Router
    {
        //Lưu ý: ở đây đang sử dụng alias của Dictionary<string, ControllerAction> cho ngắn gọn
        private readonly RoutingTable _routingTable;
        private readonly Dictionary<string, string> _helpTable;

        // nhóm 3 lệnh dưới đây biến Router thành một singleton
        private static Router _instance;
        private Router()
        {
            _routingTable = new RoutingTable();
            //Nếu không sử dụng alias, có thể viết lại như sau
            //_routingTable = new Dictionary<string, ControllerAction>;
            _helpTable = new Dictionary<string, string>();
        }
        public static Router Instance => _instance ?? (_instance = new Router());

        public string GetRoutes()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var k in _routingTable.Keys)
                sb.AppendFormat("{0}, ", k);
            return sb.ToString();
        }

        public string GetHelp(string key)
        {
            if (_helpTable.ContainsKey(key))
                return _helpTable[key];
            else
                return "Documentation not ready yet!";
        }

        /// <summary>
        /// đăng ký một route mới, mỗi route ánh xạ một chuỗi truy vấn với một phương thức
        /// </summary>
        /// <param name="route"></param>
        /// <param name="action"></param>
        /// <param name="help"></param>
        public void Register(string route, ControllerAction action, string help = "")
        {
            //nếu _routingTable đã chứa route này thì bỏ qua
            if (!_routingTable.ContainsKey(route))
            {
                _routingTable[route] = action;
                _helpTable[route] = help;
            }
        }

        public void Forward(string request)
        {
            var req = new Request(request);
            if (!_routingTable.ContainsKey(req.Route))
                throw new Exception("Command not found!");
            if (req.Parameter == null)
                _routingTable[req.Route]?.Invoke();
            else
                _routingTable[req.Route]?.Invoke(req.Parameter);
        }

        /// <summary>
        /// Lớp xử lý truy vấn
        /// </summary>
        private class Request
        {
            /// <summary>
            /// Thành phần lệnh của truy vấn
            /// </summary>
            public string Route { get; private set; }
            public Parameter Parameter { get; private set; }
            public Request(string request)
            {
                Analyze(request);
            }

            /// <summary>
            /// phân tích truy vấn để tách ra thành phần lệnh và thành phần tham số
            /// </summary>
            /// <param name="request"></param>
            private void Analyze(string request)
            {
                //tìm xem trong chuỗi truy vấn có tham số hay không
                var firstIndex = request.IndexOf('?');
                //trường hợp truy vấn không chứa tham số
                if (firstIndex < 0)
                {
                    Route = request.ToLower().Trim();
                }
                //trường hợp truy vấn chứa tham số
                else
                {
                    //nếu chuỗi lỗi (chỉ chứa tham số, không chứa route)
                    if (firstIndex <= 1)
                        throw new Exception("Invalid request parameter");

                    //cắt chuỗi truy vấn lấy mốc là ký tự ?
                    //sau phép toán này thu được mảng 2 phần tử: thứ nhất là route, thứ hai là chuỗi parameter
                    var tokens = request.Split(new[] { '?' }, 2, StringSplitOptions.RemoveEmptyEntries);

                    //route là thành phần lệnh của truy vấn
                    Route = tokens[0].Trim().ToLower();

                    //parameter là thành phần tham số của truy vấn
                    var parameterPart = request.Substring(firstIndex + 1).Trim();

                    Parameter = new Parameter(parameterPart);
                }
            }
        }
    }
}
