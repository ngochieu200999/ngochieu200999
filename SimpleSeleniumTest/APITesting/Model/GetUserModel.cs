using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APITesting.Model
{
    public class GetUserModel
    {
        /// <summary>
        /// Đem các kiểu dữ liệu của Root ra ngoài
        /// </summary>
        public int page { get; set; }
        public int per_page { get; set; }
        public int total { get; set; }
        public int total_pages { get; set; }
        public List<Datum> data { get; set; }
        public Support support { get; set; } //Nếu tên biến trùng kiểu dữ liệu dẫn đến bị lỗi=> Chỉ đổi tên kiểu dữ liệu không đổi tên biến (vd: đổi kiểu dữ liệu và tên Method thành SupportModel)
        public class Datum
        {
            public int id { get; set; }
            public string email { get; set; }
            public string first_name { get; set; }
            public string last_name { get; set; }
            public string avatar { get; set; }
        }

        public class Support
        {
            public string url { get; set; }
            public string text { get; set; }
        }
    }
}
