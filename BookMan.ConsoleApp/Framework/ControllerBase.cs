using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework
{
    /// <summary>
    /// Lớp controller cơ sở
    /// </summary>
    public class ControllerBase
    {
        /// <summary>
        /// Render dữ liệu ra view
        /// </summary>
        /// <param name="view"></param>
        public virtual void Render(ViewBase view)
        {
            view.Render();
        }
        /// <summary>
        /// Render dữ liệu ra view hoặc ghi vào file
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="view"></param>
        /// <param name="path"></param>
        /// <param name="both">True - both, False - Chỉ ghi vào file</param>
        public virtual void Render<T>(ViewBase<T> view, string path ="", bool both = false)
        {
            if(string.IsNullOrEmpty(path))
            {
                view.Render();
                return;
            }
            if(both)
            {
                view.Render();
                view.RenderToFile(path);
                return;
            }
            view.RenderToFile(path);
        }
        /// <summary>
        /// Render có thêm thông báo (message)
        /// </summary>
        /// <param name="message"></param>
        public virtual void Render(Message message) => Render(new MessageView(message));
        /// <summary>
        /// Thông báo thành công
        /// </summary>
        /// <param name="text"></param>
        /// <param name="label"></param>
        public virtual void Success(string text, string label = "SUCCESS") => Render(new Message { Type = MessageType.Success, Text = text, Label = label });
        /// <summary>
        /// Thông báo thông tin 
        /// </summary>
        /// <param name="text"></param>
        /// <param name="label"></param>
        public virtual void Inform(string text, string label = "INFORMATION") => Render(new Message { Type = MessageType.Information, Text = text, Label = label });
        /// <summary>
        /// Thông báo lỗi
        /// </summary>
        /// <param name="text"></param>
        /// <param name="label"></param>
        public virtual void Error(string text, string label = "ERROR") => Render(new Message { Type = MessageType.Error, Text = text, Label = label });
        /// <summary>
        /// Thông báo về tùy chọn (Hỏi ý kiến Y/N?)
        /// </summary>
        /// <param name="text"></param>
        /// <param name="route"></param>
        /// <param name="label"></param>
        public virtual void Confirm(string text, string route, string label = "CONFIRMATION") => Render(new Message { Type = MessageType.Confirmation, Text = text, Label = label, BackRoute = route });
    }
}
