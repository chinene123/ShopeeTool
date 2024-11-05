using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using xNet;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using KAutoHelper;
using System.Threading;

namespace Shopee
{
    public class DichVuGmail
    {
        public string Username { get; set; }
        public string Password { get; set; }





        public void GetGmail(string key)
        {
            HttpRequest http = new HttpRequest();
            string getmail;
            order result = null;
            int maxRetries = 5; 
            int retryCount = 0;

            while (retryCount < maxRetries)
            {
                try
                {
                   
                    getmail = http.Get($"https://dichvugmail.com/DataMailSell/Mail/{key}/shop").ToString();

             
                    result = JsonConvert.DeserializeObject<order>(getmail);

                    if (result != null && result.status == 200)
                    {
                        Username = result.orders.gmail.Split('|')[0];
                        Password = result.orders.gmail.Split('|')[1];
                        break;
                    }
                    if(result.status == 500)
                    {
                        Thread.Sleep(5000);
                        
                    }
                }
                catch (Exception ex)
                {
                  
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }

                retryCount++;
                Console.WriteLine($"Retrying... Attempt {retryCount} of {maxRetries}");
                Thread.Sleep(1000);
            }

            if (result == null || result.status != 200)
            {
             
                Console.WriteLine("Failed to get a valid response after multiple attempts.");
            }
        }






        public class order
        {
            public int status { get; set; }
            public Orders orders { get; set; }
        }

        public class Orders
        {
            public string name { get; set; }
            public string price { get; set; }
            public string gmail { get; set; }
            public object otp { get; set; }
            public string status { get; set; }
            public string order_id { get; set; }
            public string created_time { get; set; }
        }

    }
}
