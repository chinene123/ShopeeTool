using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xNet;

namespace Shopee
{
    public class ChayCodeApi
    {
        public string keyapi;
        public int oderid;
        public string phone;
        public string otp;
        public ChayCodeApi(string apikey)
        {
            this.keyapi = apikey;
        }
        public string GetSDT()
        {
            HttpRequest http = new HttpRequest();
            try
            {
                // Gửi yêu cầu GET đến API
                string url = $"https://chaycodeso3.com/api?act=number&apik={this.keyapi}&appId=1002";
                string response = http.Get(url).ToString();

                // Phân tích phản hồi JSON
                var result = JsonConvert.DeserializeObject<id>(response);
                if (result.ResponseCode == 0)
                {
                    this.phone = result.Result.Number;
                    this.oderid = result.Result.Id;
                }
            }
            catch (Exception ex)
            {
                // Ghi lại lỗi hoặc xử lý theo cách bạn muốn
                Console.WriteLine($"Error: {ex.Message}");
                this.phone = null;
            }

            return this.phone;
        }
        public string GetOTP()
        {
            HttpRequest http = new HttpRequest();
            try
            {
                // Gửi yêu cầu GET đến API
                string url = $"https://chaycodeso3.com/api?act=code&apik={this.keyapi}&id={this.oderid}";
                string response = http.Get(url).ToString();

                // Phân tích phản hồi JSON
                var result = JsonConvert.DeserializeObject<id>(response);
                if (result.ResponseCode == 0)
                {
                    this.phone = result.Result.Number;
                    this.oderid = result.Result.Id;
                }
            }
            catch (Exception ex)
            {
                // Ghi lại lỗi hoặc xử lý theo cách bạn muốn
                Console.WriteLine($"Error: {ex.Message}");
                this.phone = null;
            }

            return this.otp;
        }
        public string Cancel()
        {
            HttpRequest http = new HttpRequest();
            try
            {
                // Gửi yêu cầu GET đến API
                string url = $"https://chaycodeso3.com/api?act=expired&apik={this.keyapi}&id={this.oderid}";
                string response = http.Get(url).ToString();

                // Phân tích phản hồi JSON
               
            }
            catch (Exception ex)
            {
                // Ghi lại lỗi hoặc xử lý theo cách bạn muốn
                Console.WriteLine($"Error: {ex.Message}");
                this.phone = null;
            }

            return this.otp;
        }



    }
    public class id
    {
        public int ResponseCode { get; set; }
        public string Msg { get; set; }
        public Result Result { get; set; }
    }

    public class Result
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public string App { get; set; }
        public float Cost { get; set; }
        public float Balance { get; set; }
    }



}
