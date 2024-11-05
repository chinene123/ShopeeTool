using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopee
{
    public class CookieReader
    {
        private string _databaseFilePath;

        // Constructor nhận đường dẫn đến tệp cơ sở dữ liệu
        public CookieReader(string path)
        {
            _databaseFilePath = path;
        }
        public string[] GetCookieValues(List<string> keys)
        {
            var resultList = new List<string>(); // Danh sách chứa các kết quả

            using (var connection = new SQLiteConnection($"Data Source={_databaseFilePath};Version=3;"))
            {
                try
                {
                    connection.Open();
                    Console.WriteLine("Kết nối thành công đến cơ sở dữ liệu.");

                    foreach (var key in keys)
                    {
                        // Tạo truy vấn SQL để lấy giá trị của khóa cụ thể
                        string query = "SELECT value FROM cookies WHERE name = @name;";

                        using (var command = new SQLiteCommand(query, connection))
                        {
                            // Thêm tham số vào câu lệnh
                            command.Parameters.AddWithValue("@name", key);

                            // Thực thi lệnh và đọc dữ liệu
                            object result = command.ExecuteScalar();
                            if (result != null)
                            {
                                string value = result.ToString();
                                resultList.Add($"{key}={value}"); // Thêm kết quả vào danh sách
                            }
                            else
                            {
                                resultList.Add($"Không tìm thấy khóa '{key}'."); // Thêm thông báo không tìm thấy
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    resultList.Add($"Lỗi: {ex.Message}"); // Thêm thông báo lỗi vào danh sách
                }
            }

            return resultList.ToArray(); // Trả về mảng kết quả
        }
    }
}
