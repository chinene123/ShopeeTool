using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xNet;

namespace Shopee
{
    public class Viotp
    {
        public string keyapi;
        public int oderid;
        public string phone;
        public string otp;
        public Viotp(string apikey)
        {
            this.keyapi = apikey;
        }
        public String GetSDT()
        {
            HttpRequest http = new HttpRequest();
            try
            {
                String html = http.Get("https://api.viotp.com/request/getv2?token=" + this.keyapi + $"&serviceId=4").ToString();
                try
                {

                    var id = JsonConvert.DeserializeObject<IDVioOTP>(html);
                    if (id.status_code == 200)
                    {
                        this.phone = id.data.phone_number;
                        this.oderid = id.data.request_id;
                    }

                }
                catch
                {


                }
            }
            catch
            {
                phone = null;

            }
            return this.phone;

        }
        public String GetSDTService(int serviceId)
        {
            HttpRequest http = new HttpRequest();
            try
            {
                String html = http.Get("https://api.viotp.com/request/getv2?token=" + this.keyapi + $"&serviceId={serviceId}").ToString();
                try
                {

                    var id = JsonConvert.DeserializeObject<IDVioOTP>(html);
                    if (id.status_code == 200)
                    {
                        this.phone = id.data.phone_number;
                        this.oderid = id.data.request_id;
                    }

                }
                catch
                {


                }
            }
            catch
            {
                phone = null;

            }
            return this.phone;

        }
        public String OTP()
        {
            HttpRequest http = new HttpRequest();
            string otp = null;
            String html = http.Get($"https://api.viotp.com/session/getv2?requestId={this.oderid}&token={this.keyapi}").ToString();
            try
            {
                var c = JsonConvert.DeserializeObject<OTPVioOTP>(html);
                if (c.data.Code != null)
                {
                    otp = (string)c.data.Code;
                    this.otp = otp;
                }
                else
                {

                }
            }
            catch
            {


            }


            return otp;
        }

    }
    public class IDVioOTP
    {
        public int status_code { get; set; }
        public string message { get; set; }
        public bool success { get; set; }
        public DataPhone data { get; set; }
    }

    public class DataPhone
    {
        public string phone_number { get; set; }
        public string re_phone_number { get; set; }
        public string countryISO { get; set; }
        public string countryCode { get; set; }
        public int request_id { get; set; }
        public int balance { get; set; }
    }

    public class OTPVioOTP
    {
        public int status_code { get; set; }
        public string message { get; set; }
        public bool success { get; set; }
        public DataOTP data { get; set; }
    }

    public class DataOTP
    {
        public int ID { get; set; }
        public int ServiceID { get; set; }
        public string ServiceName { get; set; }
        public int Price { get; set; }
        public object SmsContent { get; set; }
        public int Status { get; set; }
        public DateTime CreatedTime { get; set; }
        public bool IsSound { get; set; }
        public object Code { get; set; }
        public string PhoneOriginal { get; set; }
        public string Phone { get; set; }
        public string CountryISO { get; set; }
        public string CountryCode { get; set; }
    }
}
