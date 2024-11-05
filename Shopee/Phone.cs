using KAutoHelper;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using xNet;

namespace Shopee
{
    public class Phone
    {
        public string deviceID;
        public DataBitmap dataBitmap;
       
        public Random r;

        public Phone(string deviceID)
        {

            r = new Random();
        
            dataBitmap = new DataBitmap();
            this.deviceID = deviceID;

        }
        public void skipsetup()
        {

           


        }
        public string UploadImageToImgur(string imagePath, string clientId)
        {
            var options = new RestClientOptions("https://api.imgur.com")
            {
                MaxTimeout = -1,
                UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/130.0.0.0 Safari/537.36",
            };

            var client = new RestClient(options);
            var request = new RestRequest($"/3/upload?client_id={clientId}", Method.Post);

            // Thêm các header cần thiết
            request.AddHeader("accept", "*/*");
            request.AddHeader("accept-language", "vi,vi-VN;q=0.9,fr-FR;q=0.8,fr;q=0.7,en-US;q=0.6,en;q=0.5");
            request.AddHeader("origin", "https://imgur.com");
            request.AddHeader("referer", "https://imgur.com/");
            request.AddHeader("sec-ch-ua", "\"Chromium\";v=\"130\", \"Google Chrome\";v=\"130\", \"Not?A_Brand\";v=\"99\"");
            request.AddHeader("sec-ch-ua-mobile", "?0");
            request.AddHeader("sec-ch-ua-platform", "\"Windows\"");
            request.AddHeader("sec-fetch-dest", "empty");
            request.AddHeader("sec-fetch-mode", "cors");
            request.AddHeader("sec-fetch-site", "same-site");

            // Đảm bảo rằng đây là multipart form data
            request.AlwaysMultipartFormData = true;

            // Thêm tệp hình ảnh vào yêu cầu
            request.AddFile("image", imagePath); // Sử dụng tệp cục bộ từ đường dẫn được cung cấp

            // Thực hiện yêu cầu
            var response = client.Execute(request);

            if (response.IsSuccessful)
            {
                return response.Content; // Trả về nội dung phản hồi nếu thành công
            }
            else
            {
                throw new Exception($"Error uploading image: {response.ErrorMessage}");
            }
        }
        public string UpdateCookie(string cookieValue, int status, string id, string content)
        {
            // Create RestClientOptions with the base URL
            var options = new RestClientOptions("http://103.237.86.136")
            {
                MaxTimeout = -1,
            };

            // Initialize RestClient with options
            var client = new RestClient(options);

            // Create a new RestRequest for the specified endpoint
            var request = new RestRequest("/api/admin/update_cookie.php", Method.Post);

            // Add necessary headers
            request.AddHeader("Authorization", "Bearer eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJ1c2VyX2lkIjoxLCJ1c2VybmFtZSI6ImR1Y2NoaTEiLCJyb2xlIjoiYWRtaW4iLCJpYXQiOjE3MzA2OTkwMzh9.lqCGnZ9MwsM706QpZMO_lltti7KCtSMJQiW5KghRCJw");
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Cookie", "PHPSESSID=9g741f60kmmbk9ktk5tdn3fk87");

            // Create the request body with dynamic values
            var body = $@"{{
            ""cookie"": ""{cookieValue}"",
            ""status"": {status},
            ""id"": ""{id}"",
            ""content"": ""{content}""
        }}";

            // Add the body to the request
            request.AddStringBody(body, DataFormat.Json);

            // Execute the request synchronously
            RestResponse response = client.Execute(request);

            // Return the response content
            return response.Content;
        }
        public  bool checkexist(string sdt)
        {
            var options = new RestClientOptions("https://mall.shopee.vn")
            {
                MaxTimeout = -1,
                UserAgent = "Android app Shopee appver=33018 app_type=1 platform=native_android os_ver=33 Cronet/102.0.5005.61",
            };
            var client = new RestClient(options);
            var request = new RestRequest("/api/v4/account/basic/check_phone_exist", Method.Post);
            request.AddHeader("353e05bb", "UxWGv9zWS3lVzKIwDP0e/yEDbnj=");
            request.AddHeader("9f170551", "7SYZWwtT1VubpwBfiDsGPizpF+oeqfPBjc9vFpJsCIKhX/rLSG70dBlVR5xpMXe9dXRo8lxez5nX5xtlC8vW1pLEm/zswwtO5wS99MTuWNURQc1JW5jVzim7assWIw8c9pW8e2nE8JPU6ZNNuuLHrjTXrf60Bae2/dlLpzXDKzAcY2ZjsZQwHobDiO8QhJpc7/Oa4mHYLamJIaysVLv4ZtOcreapO5gfgJ6TQm9vyUMign3mb8WEBz0iWe/sDx+ouUEfe/5DQac2SHowLxKAogmvsj+1oWg+9le9gI0e+gAS2AfXgAXP/gNAUjoIVhTBf94DA8Pa0NJGNU4bjwVeBfDwIN3riDZHqiQ0X1vh14/SEEBOiWzbQv5yrRNZxGpYgP0qtCb79fLIN7GhDiWtxpjf9GnWFgpxS9Evgsi7RtoC+aDD3zNIKkZdaRVyMmt6VqhsrhdCn6yWpBjxwsg/g2iiM0pDbfU66Gbv8B4nxmt04K+9vz3+suwjmA7uvGlwT+U8qC1pfYEKt10NfsG0qo15iyJY91wZemOBCYfHQWY7RWUnAoqT+oGb4W25PiKMv14U98n3dZ7rXC/mQzSVihQvlcd+s3Z6Jzs7CqKN+TAEKqR7zHhuwas/T6BbS/DCa8tCMf0LaBRMnl1w8Nfl/RQtFls/WhDaFbsfMGAa6J6jizk3whxHvxxZNymroTuVllfIPjNStWax5vMem0hseHCHXudczC7fR5xGuj==");
            request.AddHeader("accept", "application/json");
            request.AddHeader("accept-encoding", "gzip, deflate, br");
            request.AddHeader("af-ac-enc-dat", "SPC_ST=.MGlQV0ZraDdUT3EyOEc3TLGJKh5H16LiCPaGKKJXxth15lxGIpRUrx3Qa2xfMoxk2YEOmENomc7Wgbqlj+hGXBfrKoPCBBz61OfwkmMbHF5r3sMrgh2qez7b5O3AdoLCvt9zkszJLZ5WFdmv1l7Z6gCkIjNWXN7sxcinU5Sr0bWxQ8uHjCVS+qweGpxg0Tdsz2fdYXRZlLdDL6y59Jq57dl+kIpawhQFqBEtORRyKk7eKDZ9AI1cyQNeEE7YUqt0; SPC_EC=.MGlQV0ZraDdUT3EyOEc3TLGJKh5H16LiCPaGKKJXxth15lxGIpRUrx3Qa2xfMoxk2YEOmENomc7Wgbqlj+hGXBfrKoPCBBz61OfwkmMbHF5r3sMrgh2qez7b5O3AdoLCvt9zkszJLZ5WFdmv1l7Z6gCkIjNWXN7sxcinU5Sr0bWxQ8uHjCVS+qweGpxg0Tdsz2fdYXRZlLdDL6y59Jq57dl+kIpawhQFqBEtORRyKk7eKDZ9AI1cyQNeEE7YUqt0");
            request.AddHeader("af-ac-enc-id", "6R+UIvavGFSV4ugfC0tbesWxXEkhBq18eOKUEE/BndMq9OXeGiIa/NZWCpD0Y3NL710beg==");
            request.AddHeader("af-ac-enc-sz-token", "YqYqrw3kPcGMKR/4yVSheg==|6gw1BtQDGkJjNzCNmhFRTl2CUWtu/XC1Te5gk3yyaNM3nYmg+LMlfJWgKOTH1MURRcPyCvBU8cLi54+S8PYMUWWl6ya18zZe/Q==|3ILD5DMhMm1ttpIs|08|1");
            request.AddHeader("cache-control", "no-cache, no-store");
            request.AddHeader("client-request-id", "0282c231-e41c-446d-a1a6-95611e86b422.279");
            request.AddHeader("connection", "Keep-Alive");
            request.AddHeader("content-type", "application/json");
            request.AddHeader("cookie", "SPC_DID=V2Rc+1irDB1lHeY8KEceEjANNrRjKj+4RtcrzysApRg=; SPC_F=bd0daefd4524362f_unknown; AC_CERT_D=U2FsdGVkX18+rDuRGA/8Oemksxp2jVWdLwIVs8jvvaURi2uwD0lw1HPdNqGixDyXqo7ynaSojoAuOFN81fSAW6tOovcGHt0ZE4EI/MUYreplhp04uLh13nFFNpLnG1GlGNc+6JK2K4Dq27mLQe3eGKGnLHtgdK8Te6Ggk2KD2+QMa7xEPm645cAfXYr/gs/Hy3a/y3h/X+SXIpmFd8GqRchBUtISjYzw8T8+aSUgOSd8abzoaARpoqXVPFeMB6RqOBcOZO6Rdtn0TN72Ahfzus3gk6fYYwHOVHFfqkcvtwqzAjWMKpaicQPJytmGq4Mh9/5OtEuEdgOGINho6fG/0KdaGvecmdnCzsM+xw8RmcZydN1zusT4wuC3MAJPn5LfOczj0wxBWYYshg9WIq374tmTh8L3l5lAiuK1WK+hPIfXrzNml5A80FMi1QlnQ6PIRfHgPohTT/NlL8QiuMFTBKbVjqTnXAqYt4KJAVBy8rbBE8DrpgIzmdWO0QFyAy8ONkWyrTlNGTMtNWb37wRFheNbqRsTUm5jPoETdIVpbU2BaAloNdwoAM71LOStBeG1YNMUDmUQJLvnKIdc2ryeozbwJRgPlux+unEEL8AIZ8zGYRcPtohn9lLRcGWjjzkaN/CvR1zTICGJF3m5pY7D5cBE0TlZUTs4YP+JNyaupBxuZdK3WRgFd/wqOfgW3qLneuKrs99aPNsrLCY37MD5RqNTMXX4+5Azrr4EsGr9s96D++OOCES+iO+jxTkYAQiNGVeIpcUhZiRwRvxG3PodhXJDIE5I4byfTDXMcQjlXUdBNLgIilKldZoRyNboflmS7MTiF19LPH7ZHPm7uJ1riUm0YgbAOZ41qZ4aa3+YuGOnd+g9mVWzVfmZtQFrfWv6Vb1NfAE15Koeam5IpB+p9QQe2I42hVYyer6h70jBELINTNk2BNGx5Z+dMj0oHoRLKYCvDym7hJTlvK0CtKM4DKk+XbU6OR6vJZP13d+7aRQbRUNc6Nyayt4p4/eZq7320re/KO3I5uF3RadWSB2WVOgMYWSE4py4zBK4IEaj5LuBvuOGXPcp52y+SDeqKY9zI+0i0pl00cDwwVviwrnhbw==; SPC_SI=pmWfZgAAAABGTkN3aWh5N3jMogQAAAAAbVhKNm9YM2g=; SPC_SEC_SI=v1-YktkNTU5SG9ZQjNianBIZXCa38jQ1Tkt6MZa2CALQ96o8lM4TrtKtc+PkpeQ0XtEm4hd2C7ov+xYKoikvsseqBnmPlCCcDH6mUW9R6i5acU=; REC_T_ID=d95e6a84-69f3-11ef-ae87-563e7378c2f4; UA=Shopee%20Android%20Beeshop%20locale%2Fvi%20version%3D33018%20appver%3D33018; SPC_AFTID=NoGoogleService; SPC_CLIENTID=V2Rc+1irDB1lHeY8xotcgmkbuomqzhcc; language=vi; shopee_app_version=33018; shopee_rn_version=1725276036; csrftoken=hhL5oaK5VmZ34HkLRRCVUbrhIvpWz4eP; shopee_rn_bundle_version=6028011; language=vi; SPC_RNBV=6028011; SPC_F=bd0daefd4524362f_unknown; userid=1335293022; shopid=1334631348; username=dngcch419; shopee_token=EUkS4izcloh4ogq85IH4/zlg06Izk+QKUjOUl5zXVjQWonYIhVrkqxHtFXyaz8inxgYZ/vi6bHGxdBqmoH/2G5JLwzmAlAY=; SPC_U=1335293022; SPC_ST=.MGlQV0ZraDdUT3EyOEc3TLGJKh5H16LiCPaGKKJXxth15lxGIpRUrx3Qa2xfMoxk2YEOmENomc7Wgbqlj+hGXBfrKoPCBBz61OfwkmMbHF5r3sMrgh2qez7b5O3AdoLCvt9zkszJLZ5WFdmv1l7Z6gCkIjNWXN7sxcinU5Sr0bWxQ8uHjCVS+qweGpxg0Tdsz2fdYXRZlLdDL6y59Jq57dl+kIpawhQFqBEtORRyKk7eKDZ9AI1cyQNeEE7YUqt0; SPC_EC=.MGlQV0ZraDdUT3EyOEc3TLGJKh5H16LiCPaGKKJXxth15lxGIpRUrx3Qa2xfMoxk2YEOmENomc7Wgbqlj+hGXBfrKoPCBBz61OfwkmMbHF5r3sMrgh2qez7b5O3AdoLCvt9zkszJLZ5WFdmv1l7Z6gCkIjNWXN7sxcinU5Sr0bWxQ8uHjCVS+qweGpxg0Tdsz2fdYXRZlLdDL6y59Jq57dl+kIpawhQFqBEtORRyKk7eKDZ9AI1cyQNeEE7YUqt0; SPC_R_T_IV=ZzlMb0tWbklzY2pwbkI5Sg==; SPC_T_ID=lkb84K6KMte2kTLh01IdF9V/QJ7bXxtiznqAC/0G3Hnq9oK/HDHyk66wUSPr3g3Zr6bD3QDvO5sGWB9l6g4kYpncUOn4qr+MdOxZIkMmQ7S0R8estiopW9oSxqBHGdkU9/Hs9+VULU6vjnJDnPzML6fLk0wWCoEcTpA26eNEyEY=; SPC_T_IV=ZzlMb0tWbklzY2pwbkI5Sg==; SPC_R_T_ID=lkb84K6KMte2kTLh01IdF9V/QJ7bXxtiznqAC/0G3Hnq9oK/HDHyk66wUSPr3g3Zr6bD3QDvO5sGWB9l6g4kYpncUOn4qr+MdOxZIkMmQ7S0R8estiopW9oSxqBHGdkU9/Hs9+VULU6vjnJDnPzML6fLk0wWCoEcTpA26eNEyEY=; csrftoken=L2uHkXE75xdc8RZJJm040Fd6dp66gScM; REC_T_ID=d5692d13-6959-11ef-aa78-5a615f2bd8d8; SPC_EC=.MGlQV0ZraDdUT3EyOEc3TLGJKh5H16LiCPaGKKJXxth15lxGIpRUrx3Qa2xfMoxk2YEOmENomc7Wgbqlj+hGXBfrKoPCBBz61OfwkmMbHF5r3sMrgh2qez7b5O3AdoLCvt9zkszJLZ5WFdmv1l7Z6gCkIjNWXN7sxcinU5Sr0bWxQ8uHjCVS+qweGpxg0Tdsz2fdYXRZlLdDL6y59Jq57dl+kIpawhQFqBEtORRyKk7eKDZ9AI1cyQNeEE7YUqt0; SPC_F=zVMux4zxmTS1EFxtAUO4mobTWsh4wxMb; SPC_R_T_ID=lkb84K6KMte2kTLh01IdF9V/QJ7bXxtiznqAC/0G3Hnq9oK/HDHyk66wUSPr3g3Zr6bD3QDvO5sGWB9l6g4kYpncUOn4qr+MdOxZIkMmQ7S0R8estiopW9oSxqBHGdkU9/Hs9+VULU6vjnJDnPzML6fLk0wWCoEcTpA26eNEyEY=; SPC_R_T_IV=ZzlMb0tWbklzY2pwbkI5Sg==; SPC_SI=pmWfZgAAAABGTkN3aWh5N3jMogQAAAAAbVhKNm9YM2g=; SPC_ST=.MGlQV0ZraDdUT3EyOEc3TLGJKh5H16LiCPaGKKJXxth15lxGIpRUrx3Qa2xfMoxk2YEOmENomc7Wgbqlj+hGXBfrKoPCBBz61OfwkmMbHF5r3sMrgh2qez7b5O3AdoLCvt9zkszJLZ5WFdmv1l7Z6gCkIjNWXN7sxcinU5Sr0bWxQ8uHjCVS+qweGpxg0Tdsz2fdYXRZlLdDL6y59Jq57dl+kIpawhQFqBEtORRyKk7eKDZ9AI1cyQNeEE7YUqt0; SPC_T_ID=lkb84K6KMte2kTLh01IdF9V/QJ7bXxtiznqAC/0G3Hnq9oK/HDHyk66wUSPr3g3Zr6bD3QDvO5sGWB9l6g4kYpncUOn4qr+MdOxZIkMmQ7S0R8estiopW9oSxqBHGdkU9/Hs9+VULU6vjnJDnPzML6fLk0wWCoEcTpA26eNEyEY=; SPC_T_IV=ZzlMb0tWbklzY2pwbkI5Sg==; SPC_U=1335293022; SPC_SEC_SI=v1-eFdmdG9xeFR4RU5NZ1pBZBQgOVwOfOBKSASeMueyluI13LLHeNBLT/XWGBAl0sgU6N03nLUH72uUz/6RTD0Hkd6Q+lDcx8e5muml2WAExLo=; REC_T_ID=0c93d49c-96a6-11ef-bd8f-364035b388fc; SPC_EC=-; SPC_F=P31nJ3WY01xbuIMEXKVvV3TVW2I8Si9t; SPC_R_T_ID=lkb84K6KMte2kTLh01IdF9V/QJ7bXxtiznqAC/0G3Hnq9oK/HDHyk66wUSPr3g3Zr6bD3QDvO5sGWB9l6g4kYpncUOn4qr+MdOxZIkMmQ7S0R8estiopW9oSxqBHGdkU9/Hs9+VULU6vjnJDnPzML6fLk0wWCoEcTpA26eNEyEY=; SPC_R_T_IV=ZzlMb0tWbklzY2pwbkI5Sg==; SPC_SI=pmWfZgAAAABGTkN3aWh5N3jMogQAAAAAbVhKNm9YM2g=; SPC_T_ID=lkb84K6KMte2kTLh01IdF9V/QJ7bXxtiznqAC/0G3Hnq9oK/HDHyk66wUSPr3g3Zr6bD3QDvO5sGWB9l6g4kYpncUOn4qr+MdOxZIkMmQ7S0R8estiopW9oSxqBHGdkU9/Hs9+VULU6vjnJDnPzML6fLk0wWCoEcTpA26eNEyEY=; SPC_T_IV=ZzlMb0tWbklzY2pwbkI5Sg==; SPC_U=-; SPC_SEC_SI=v1-UndTTG9wZUkyMjRsODJ1V9x4uLbj9qDPqX1ijiLJUqctgw5c1Z880DlyE6ZzZVYEh/x4HFZPPz/AtzSEO5EEw+fDFXTftRoj4Rk2Zg3gpvI=");
            request.AddHeader("df351511", "hsfD1ge0mFe+y2rTaLECoBMrF4b=");
            request.AddHeader("e26b600c", "TP+sancKMBdnZ5boEvtGK4y/8zy=");
            request.AddHeader("host", "mall.shopee.vn");
            request.AddHeader("if-none-match-", "55b03-bbc4b2ddbbf3e5ef1e3001ba5464e784");
            request.AddHeader("referer", "https://mall.shopee.vn/");
            request.AddHeader("shopee_http_dns_mode", "1");
            request.AddHeader("x-api-source", "rn");
            request.AddHeader("x-csrftoken", "L2uHkXE75xdc8RZJJm040Fd6dp66gScM");
            request.AddHeader("x-sap-ri", "dc07d766eb2ac6ace679221001cb318073311ccf593a7887cb46");

            request.AddHeader("x-shopee-client-timezone", "Asia/Ho_Chi_Minh");
            var body = $@"{{""phone"":""84{sdt}"",""vcode_token"":""""}}";
            request.AddStringBody(body, DataFormat.Json);
            var response = client.Execute(request);
            if (response.IsSuccessful)
            {
                try
                {
                    // Parse the response content
                    var jsonResponse = JObject.Parse(response.Content);
                    bool exists = (bool)jsonResponse["data"]["exist"];

                    // Return true if "exist" is true, otherwise false
                    return exists;
                }
                catch (JsonException ex)
                {
                    Console.WriteLine("Error parsing JSON response: " + ex.Message);
                    return false;
                }
            }
            else
            {
                // Handle errors or unsuccessful response
                Console.WriteLine($"Error: {response.ErrorMessage}");
                return false;
            }

        }
        public void addGmail(string user, string pass)

        {
            
           
          
            KAutoHelper.ADBHelper.ExecuteCMD($"adb -s {deviceID} shell am start -a android.settings.ADD_ACCOUNT_SETTINGS");
          //  ImgForTime(dataBitmap.google,10);
            List<string> textsToCheck = new List<string> { "Create account","Bạn quên địa chỉ email?" };
            int timeLimit = 10; // Time in seconds

            TextForTimeList(textsToCheck, timeLimit);
            //KAutoHelper.ADBHelper.TapByPercent(deviceID, 19.2, 32.1);
            // DumpText("Forgot email?", 1);
            List<string> textbutton = new List<string> { "Forgot email?", "Bạn quên địa chỉ email?" };
            DumpTextXY(textbutton, 1,0,-50);
            Thread.Sleep(500);
            KAutoHelper.ADBHelper.InputText(deviceID, user);
            Thread.Sleep(1000);
            KAutoHelper.ADBHelper.TapByPercent(deviceID, 86.6, 89.3);
            //checkuser
            //hiện mật khẩu
            // ImgForTime(dataBitmap.user, 10);
            List<string> textsToCheck2 = new List<string> { "Forgot password?", "Bạn quên mật khẩu?" };
            int timeLimit2 = 10; // Time in seconds

            TextForTimeList(textsToCheck2, timeLimit2);
            KAutoHelper.ADBHelper.TapByPercent(deviceID, 20.2, 34.1);
            Thread.Sleep(300);
            KAutoHelper.ADBHelper.InputText(deviceID, pass);
            Thread.Sleep(500);
            KAutoHelper.ADBHelper.TapByPercent(deviceID, 94.0, 90.0);
            Thread.Sleep(5000);
            KAutoHelper.ADBHelper.SwipeByPercent(deviceID, 62.9, 91.2, 62.9, 16.7, 500);
            Thread.Sleep(1000);
            KAutoHelper.ADBHelper.TapByPercent(deviceID, 82.5, 89.2);//clicl tôi đồng ý
            Thread.Sleep(3000);
            KAutoHelper.ADBHelper.TapByPercent(deviceID, 82.2, 89.0);
            Thread.Sleep(3000);
            KAutoHelper.ADBHelper.TapByPercent(deviceID, 17.8, 89.0);
            Thread.Sleep(3000);
            List<string> textbutton3 = new List<string> { "Tôi đồng ý", "I agree" };
            DumpTextXY(textbutton3,1,0,0);
            //KAutoHelper.ADBHelper.TapByPercent(deviceID, 83.5, 89.9);
            Thread.Sleep(5000);
        }
        public void reg()
        {
            installapp("shopee.apk");
            KAutoHelper.ADBHelper.ExecuteCMD($"adb -s {deviceID} shell am start -n com.shopee.vn/com.shopee.app.ui.home.HomeActivity_");
            //ImgForTime(dataBitmap.anhshopee,15);
            Thread.Sleep(10000);
            KAutoHelper.ADBHelper.TapByPercent(deviceID, 70.7, 91.9);
            //if (ishaveText("BẮT ĐẦU"))
            //{
            //    KAutoHelper.ADBHelper.TapByPercent(deviceID, 51.4, 95.4);
            //    Thread.Sleep(5000);
            //    KAutoHelper.ADBHelper.TapByPercent(deviceID, 91.0, 91.4);
            //    Thread.Sleep(6000);
            //    KAutoHelper.ADBHelper.TapByPercent(deviceID, 87.6, 12.5);
            //}

           
            //Thread.Sleep(2000);
            //List<string> textsToCheck3 = new List<string> { "Đăng ký bằng Google", "Sign Up with Google" };

            //DumpTextXY(textsToCheck3, 1, 0, 0);
            //Thread.Sleep(5000);
            //List<string> textsToCheck2 = new List<string> { "Thêm tài khoản khác", "Add another account" };
           
            //DumpTextXY(textsToCheck2,1,0,-50);
            //Thread.Sleep(7000);
            //DumpText("@gmail.com",1);
        }


        public void installapp(string path)
        {
            KAutoHelper.ADBHelper.ExecuteCMD($"adb -s {deviceID} install {path}");
        }

        public string DumpText(string button, int exitwhile, bool dumx = false)
        {
            int num = 0;
            while (true)
            {
                if (dumx == false)
                {
                    KAutoHelper.ADBHelper.ExecuteCMD("adb -s " + deviceID + " shell uiautomator dump /sdcard/window_dump_" + deviceID + ".xml && adb -s " + deviceID + " pull /sdcard/window_dump_" + deviceID + ".xml");
                }
                XmlDocument doc = new XmlDocument();
                doc.Load("window_dump_" + deviceID + ".xml");
                XmlNode book;
                XmlNode root = doc.DocumentElement;

                book = root.SelectSingleNode("//node[@text=\'" + button + "\']");
                if (book != null)
                {
                    string toadonext = book.Attributes["bounds"].Value;
                    toadonext = toadonext.Replace("][", ",").Replace("]", "").Replace("[", "");
                    string toado_1 = toadonext.Split(',')[0];
                    string toado_2 = toadonext.Split(',')[1];
                    int toado1 = Int32.Parse(toado_1);
                    int toado2 = Int32.Parse(toado_2);
                    KAutoHelper.ADBHelper.Tap(deviceID, toado1, toado2);

                    return "0";
                }
                else
                {
                    num++;
                    if (num == exitwhile)
                    {
                        return "1";
                    }
                }
            }

        }
        public string DumpTextXY(List<string> buttons, int exitwhile, int x, int y, bool dumx = false)
        {
            int num = 0;
            while (true)
            {
                if (dumx == false)
                {
                    KAutoHelper.ADBHelper.ExecuteCMD("adb -s " + deviceID + " shell uiautomator dump /sdcard/window_dump_" + deviceID + ".xml && adb -s " + deviceID + " pull /sdcard/window_dump_" + deviceID + ".xml");
                }

                XmlDocument doc = new XmlDocument();
                doc.Load("window_dump_" + deviceID + ".xml");
                XmlNode root = doc.DocumentElement;

                foreach (var button in buttons)
                {
                    XmlNode book = root.SelectSingleNode("//node[@text=\'" + button + "\']");
                    if (book != null)
                    {
                        string toadonext = book.Attributes["bounds"].Value;
                        toadonext = toadonext.Replace("][", ",").Replace("]", "").Replace("[", "");
                        string toado_1 = toadonext.Split(',')[0];
                        string toado_2 = toadonext.Split(',')[1];
                        int toado1 = Int32.Parse(toado_1) + x;
                        int toado2 = Int32.Parse(toado_2) + y;
                        KAutoHelper.ADBHelper.Tap(deviceID, toado1, toado2);

                        return "0"; // Return 0 if any button is found and tapped
                    }
                }

                num++;
                if (num == exitwhile)
                {
                    return "1"; // Return 1 if the loop exits without finding any button
                }
            }
        }



        public void changerAllPhone()
        {
            KAutoHelper.ADBHelper.ExecuteCMD($"adb -s {deviceID} shell su -c am start -n com.xbackup.evolution/.auto.MainActivity");
            Thread.Sleep(5000);
            KAutoHelper.ADBHelper.TapByPercent(deviceID, 8.0, 9.9);
            Thread.Sleep(2000);
            KAutoHelper.ADBHelper.TapByPercent(deviceID, 57.5, 30.9);
            Thread.Sleep(500);
            KAutoHelper.ADBHelper.TapByPercent(deviceID, 33.4, 42.8);
            Thread.Sleep(500);
            KAutoHelper.ADBHelper.TapByPercent(deviceID, 33.4, 46.5);
            Thread.Sleep(200);

            KAutoHelper.ADBHelper.TapByPercent(deviceID, 33.4, 55.5);//click brand
            Thread.Sleep(400);
            KAutoHelper.ADBHelper.TapByPercent(deviceID, 69.6, 54.8);//click device
            Thread.Sleep(400);
            KAutoHelper.ADBHelper.TapByPercent(deviceID, 33.1, 59.0);
            Thread.Sleep(400);
            KAutoHelper.ADBHelper.TapByPercent(deviceID, 67.9, 58.9);
            Thread.Sleep(400);
            KAutoHelper.ADBHelper.TapByPercent(deviceID, 33.1, 67.3);
            Thread.Sleep(400);
            KAutoHelper.ADBHelper.TapByPercent(deviceID, 68.6, 67.5); //click wipe gms
            Thread.Sleep(400);
            KAutoHelper.ADBHelper.TapByPercent(deviceID, 69.0, 74.8);
            Thread.Sleep(400);
            KAutoHelper.ADBHelper.TapByPercent(deviceID, 33.4, 87.3); //click dalvic
            Thread.Sleep(400);
            KAutoHelper.ADBHelper.TapByPercent(deviceID, 78.1, 92.4);
            Thread.Sleep(90000);
        }
        public void changerTEXT()
        {
            KAutoHelper.ADBHelper.ExecuteCMD($"adb -s {deviceID} shell su -c /system/dial");


        }
        public bool loginaccgmail(string accgmail, string passsgmail)
        {
            bool acclogin = false;
            KAutoHelper.ADBHelper.ExecuteCMD($"adb -s {deviceID} shell su -c am start -n com.android.settings/com.android.settings.accounts.AddAccountSettings");
            Thread.Sleep(5000);
            TextForTime("email", 30);
            KAutoHelper.ADBHelper.TapByPercent(deviceID, 19.9, 30.8);
            Thread.Sleep(200);
            KAutoHelper.ADBHelper.TapByPercent(deviceID, 19.9, 30.8);
            Thread.Sleep(200);
            KAutoHelper.ADBHelper.InputText(deviceID, accgmail);
            Thread.Sleep(200);
            KAutoHelper.ADBHelper.TapByPercent(deviceID, 91.0, 86.6);
            Thread.Sleep(200);
            TextForTime("mật khẩu", 10);
            KAutoHelper.ADBHelper.InputText(deviceID, passsgmail);
            Thread.Sleep(200);
            KAutoHelper.ADBHelper.TapByPercent(deviceID, 82.5, 86.6);
            Thread.Sleep(4000);
            //if (ishaveText("Tôi hiểu")|| ishaveText("TÔI HIỂU") || ishaveText("Entendi"))
            //{
            KAutoHelper.ADBHelper.TapByPercent(deviceID, 79.1, 73.9);//click toi dong y
            Thread.Sleep(300);
            KAutoHelper.ADBHelper.SwipeByPercent(deviceID, 54, 84, 54, 29, 300);
            Thread.Sleep(2000);

            KAutoHelper.ADBHelper.TapByPercent(deviceID, 84.2, 88.3);//click toi hieu
            Thread.Sleep(4000);
            //TextForTime("Tôi đồng ý", 10);
            KAutoHelper.ADBHelper.TapByPercent(deviceID, 82.2, 93.1);
            Thread.Sleep(1000);
            KAutoHelper.ADBHelper.TapByPercent(deviceID, 77.4, 89.5);
            Thread.Sleep(1000);
            KAutoHelper.ADBHelper.TapByPercent(deviceID, 81.5, 64.5);
            Thread.Sleep(1000);
            KAutoHelper.ADBHelper.TapByPercent(deviceID, 82.5, 73.6);
            Thread.Sleep(2000);
            acclogin = true;
            //}
            return acclogin;

        }


        public bool ClickImg(Bitmap imgFind)
        {
            try
            {
                Bitmap bm = (Bitmap)imgFind.Clone();
                var screen = ADBHelper.ScreenShoot(deviceID);

                // Tìm tọa độ của hình ảnh trên màn hình
                var point = ImageScanOpenCV.FindOutPoint(screen, bm);

                if (point != null)
                {
                    // Nhấp chuột tại vị trí tìm được
                    ADBHelper.ExecuteCMD($"adb -s {deviceID} shell input tap {point.Value.X} {point.Value.Y}");
                    return true;
                }
            }
            catch (Exception ex)
            {
                // Xử lý lỗi ở đây nếu cần
                Console.WriteLine("Error: " + ex.Message);
            }

            return false;
        }
        public void TextForTimeList(List<string> texts, int time)
        {
            int timeCount = 0;
            while (timeCount < time)
            {
                if (IsHaveTextList(texts))
                {
                    // Perform your action here, for example:
                    // Tapimg(Img);
                    break;
                }
                else
                {
                    timeCount++;
                    Thread.Sleep(500);
                }
            }
        }

        public void TextForTime(string text, int time)
        {
            int timecount = 0;
            while (timecount < time)
            {
                if (ishaveText(text))
                {
                    //  Tapimg(Img);
                    break;
                }
                else
                {
                    timecount++;
                    Thread.Sleep(500);
                }
            }

        }
        public bool ImgForTime(Bitmap imgFind, int time)
        {
            bool check = false;
            int elapsedTime = 0;

            try
            {
                Bitmap bm = (Bitmap)imgFind.Clone();

                while (elapsedTime < time)
                {
                    var screen = ADBHelper.ScreenShoot(deviceID);
                    var point = ImageScanOpenCV.FindOutPoint(screen, bm);

                    if (point != null)
                    {
                        check = true;
                        break;
                    }

                    // Tạm dừng một khoảng thời gian (500ms) trước khi kiểm tra lại
                    Thread.Sleep(1000);
                    elapsedTime++;
                }
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ nếu cần
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            return check;
        }

        public bool IsHaveTextList(List<string> texts)
        {
            bool check = false;
        retry:
            try
            {
                //KAutoHelper.ADBHelper.ExecuteCMD("adb -s " + deviceID + " shell uiautomator dump /sdcard/window_dump_" + deviceID + ".txt && adb -s " + deviceID + " pull /sdcard/window_dump_" + deviceID + ".txt");
                KAutoHelper.ADBHelper.ExecuteCMD("adb -s " + deviceID + " shell uiautomator dump /sdcard/window_dump_" + deviceID + ".txt && adb -s " + deviceID + " pull /sdcard/window_dump_" + deviceID + ".txt");
                string windowDump = System.IO.File.ReadAllText("window_dump_" + deviceID + ".txt");

                System.IO.File.Delete("window_dump_" + deviceID + ".txt");

                foreach (string text in texts)
                {
                    if (Regex.IsMatch(windowDump, Regex.Escape(text)))
                    {
                        check = true;
                        break;
                    }
                }
            }
            catch
            {
                goto retry;
            }

            return check;
        }
        private static string windowDump = null;
        public bool ishaveText(string text)
        {
            bool check = false;
        aaaaa:
            try
            {

                KAutoHelper.ADBHelper.ExecuteCMD("adb -s " + deviceID + " shell uiautomator dump /sdcard/window_dump_" + deviceID + ".txt && adb -s " + deviceID + " pull /sdcard/window_dump_" + deviceID + ".txt");
                KAutoHelper.ADBHelper.ExecuteCMD("adb -s " + deviceID + " shell uiautomator dump /sdcard/window_dump_" + deviceID + ".txt && adb -s " + deviceID + " pull /sdcard/window_dump_" + deviceID + ".txt");
                windowDump = System.IO.File.ReadAllText("window_dump_" + deviceID + ".txt");


                System.IO.File.Delete("window_dump_" + deviceID + ".txt");
                if (Regex.Matches(windowDump, text).Count > 0)
                {
                    check = true;
                }

            }
            catch
            {
                goto aaaaa;
            }
            return check;


        }
        public int CountText(string text)
        {

            KAutoHelper.ADBHelper.ExecuteCMD("adb -s " + deviceID + " shell uiautomator dump /sdcard/window_dump_" + deviceID + ".txt && adb -s " + deviceID + " pull /sdcard/window_dump_" + deviceID + ".txt");
            windowDump = System.IO.File.ReadAllText("window_dump_" + deviceID + ".txt");
            System.IO.File.Delete("window_dump_" + deviceID + ".txt");
            int aaa = Regex.Matches(windowDump, text).Count;

            return aaa;


        }
        //public bool IsHaveText(string text)
        //{
        //    bool check = false;
        //    using (var automation = new UiAutomation(UiDevice.GetInstance()))
        //    {
        //        var window = automation.RootInActiveWindow;
        //        var node = window.FindByText(text);
        //        if (node != null)
        //        {
        //            check = true;
        //        }
        //    }
        //    return check;
        //}
        public bool IshaveImg(Bitmap ImgFind)
        {
            bool Check = false;
            try
            {

                Bitmap bm = (Bitmap)ImgFind.Clone();
                var screen = ADBHelper.ScreenShoot(deviceID);
                var Point = ImageScanOpenCV.FindOutPoint(screen, bm);
                if (Point != null)
                {
                    Check = true;
                }


            }
            catch
            {


            }
            return Check;
        }

        public bool IshaveImgScreen(Bitmap screen, Bitmap ImgFind)
        {
            bool Check = false;
            try
            {

                Bitmap bm = (Bitmap)ImgFind.Clone();

                var Point = ImageScanOpenCV.FindOutPoint(screen, bm);
                if (Point != null)
                {
                    Check = true;
                }


            }
            catch
            {


            }
            return Check;
        }
        public bool IsAnyImagePresents(Bitmap screen, List<Bitmap> imagesToFind)
        {
            bool isPresent = false;
            try
            {


                foreach (var image in imagesToFind)
                {
                    Bitmap bm = (Bitmap)image.Clone();
                    var point = ImageScanOpenCV.FindOutPoint(screen, bm);
                    if (point != null)
                    {
                        isPresent = true;
                        break;
                    }
                }
            }
            catch
            {

            }
            return isPresent;
        }

    }
}
