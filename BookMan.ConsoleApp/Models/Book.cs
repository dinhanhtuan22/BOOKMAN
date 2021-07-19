using System;

namespace BookMan.ConsoleApp.Models
{
    /// <summary>
    /// Lớp mô tả sách điện tử
    /// </summary>
    [Serializable]
    public class Book
    {
        private int _id = 1;
        /// <summary>
        /// Số định danh cho mỗi object
        /// </summary>
        public int Id
        {
            get { return _id; }
            set { if (value >= 1) _id = value; }
        }
        private string _authors = "Unknown author";
        /// <summary>
        /// Tên tác giả, không nhận chuỗi rỗng
        /// </summary>
        public string Authors
        {
            get { return _authors; }
            set { if (!string.IsNullOrEmpty(value)) _authors = value; }
        }
        private string _title = "A new book";
        /// <summary>
        /// Tên sách, không nhận chuỗi rỗng
        /// </summary>
        public string Title
        {
            get { return _title; }

            set { if (!string.IsNullOrEmpty(value)) _title = value; }
        }
        private string _publisher = "Unknown publisher";
        /// <summary>
        /// Tên Nhà xuất bản, không nhận chuỗi rỗng
        /// </summary>
        public string Publisher
        {
            get { return _publisher; }
            set { if (!string.IsNullOrEmpty(value)) _publisher = value; }

        }
        private int _year = 2018;
        /// <summary>
        /// Năm xuất bản, không nhận trước 1950
        /// </summary>
        public int Year
        {
            get { return _year; }
            set { if (value >= 1950) _year = value; }
        }
        private int _edition = 1;
        /// <summary>
        /// Lần tái bản, không nhận nhỏ hơn 1
        /// </summary>
        public int Edition
        {
            get { return _edition; }
            set { if (value >= 1) _edition = value; }
        }
        /// <summary>
        /// Mã quốc tế
        /// </summary>
        public string Isbn { get; set; } = "";
        /// <summary>
        /// Từ khóa mô tả nội dung
        /// </summary>
        public string Tags { get; set; } = "";

        /// <summary>
        /// Mô tả tóm tắt nội dung
        /// </summary>
        public string Description { get; set; } = "A new book";
        private string _file;
        /// <summary>
        /// file sách (gồm đường dẫn)
        /// </summary>
        public string File
        {
            get { return _file; }
            set { if (System.IO.File.Exists(value)) _file = value; }
        }
        /// <summary>
        /// File sách (KHÔNG có đường dẫn)
        /// </summary>
        public string FileName
        {
            get { return System.IO.Path.GetFileName(_file); }
        }

        /// <summary>
        /// Đánh dấu đã đọc
        /// </summary>
        public bool Reading { get; set; } = false;
        private int _rating = 1;
        /// <summary>
        /// Đánh giá cá nhân, 1-5, 1-thấp nhất
        /// </summary>
        public int Rating
        {
            get { return _rating; }
            set { if (value >= 1 && value <= 5) _rating = value; }
        }
    }
}
