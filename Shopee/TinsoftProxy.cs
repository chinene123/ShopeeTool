using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using xNet;

namespace Shopee
{
    public class TinsoftProxy
    {

        public string Host { get; private set; }
        public string Port { get; private set; }
        public string changer_Tinsoft(string key)
        {
            string proxy = null;
            while (proxy == null)
            {
                try
                {

                    HttpRequest http = new HttpRequest();

                    string html = http.Post($"https://proxy.tinsoftsv.com/api/changeProxy.php?key={key}").ToString();
                    var result = JsonConvert.DeserializeObject<Rootobject>(html);
                    if (result.success)
                    {
                        proxy = result.proxy;
                        var proxyParts = proxy.Split(':');
                        if (proxyParts.Length == 2)
                        {
                            Host = proxyParts[0];
                            Port = proxyParts[1];
                        }
                        break;
                    }
                    else
                    {
                        int time = TachSo(result.next_change);
                        Thread.Sleep(time * 1000);
                    }
                }
                catch (Exception ex)
                {
                    // Xử lý lỗi (có thể thêm log hoặc thông báo lỗi tùy ý).
                }
            }
            return proxy;
        }
        public string getProxy(string key)
        {
            string proxy = null;
            while (proxy == null)
            {
                try
                {

                    HttpRequest http = new HttpRequest();

                    string html = http.Post($"http://proxy.tinsoftsv.com/api/getProxy.php?key={key}").ToString();
                    var result = JsonConvert.DeserializeObject<Rootobject>(html);
                    if (result.success)
                    {
                        proxy = result.proxy;
                        var proxyParts = proxy.Split(':');
                        if (proxyParts.Length == 2)
                        {
                            Host = proxyParts[0];
                            Port = proxyParts[1];
                        }
                        break;
                    }
                    else
                    {
                        int time = TachSo(result.next_change);
                        Thread.Sleep(time * 1000);
                    }
                }
                catch (Exception ex)
                {
                    // Xử lý lỗi (có thể thêm log hoặc thông báo lỗi tùy ý).
                }
            }
            return proxy;
        }

        private int TachSo(string message)
        {
            // Cài đặt logic để trích xuất số từ message (Bạn cần thay thế nội dung này bằng cài đặt cụ thể của mình).
            // Ví dụ:
            return 10; // Trả về một giá trị mặc định 10 nếu không trích xuất được số.
        }

    }

    public class Rootobject
    {
        public bool success { get; set; }
        public string proxy { get; set; }
        public string location { get; set; }
        public string next_change { get; set; }
        public int timeout { get; set; }
        public string accept_ip { get; set; }
    }

}