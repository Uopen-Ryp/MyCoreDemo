using EasyOffice;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace CoreAppConsole
{
    class Program
    {


        static void Main(string[] args)
        {
            //services.AddEasyOffice(new OfficeOptions());
            //new OfficeOptions();

            //string url = "https://api.weixin.qq.com/cgi-bin/material/add_material?access_token=38_4VzyZuJhHB4D7a6zgAT_NDBBsq55yP1afi3mmjfS8DHMSL5r6nR8MaVEVB0wJlRwnFCbqkfNjhRAKaevKft_AqfDdQ5cTcfUpRiNsf-gSI1rWDt4fxdvTdSPNla-9B3T3MnfvTOh11zBGK4HFWBbAFAVMR&type=thumb";
            //HttpClient httpClient = new HttpClient();
            //var multipartFormDataContent = new MultipartFormDataContent();
            //multipartFormDataContent.Add(new ByteArrayContent(System.IO.File.ReadAllBytes(@"E:\1.png")), "media", "22.png");

            DateTime vipTime = DateTime.Now;
            DateTime endTime = DateTime.Now;
            int nowCount = 2;
            GetVipTime(ref endTime, nowCount);

            Console.WriteLine(endTime);
            Console.ReadKey();
        }

        private static void GetVipTime(ref DateTime endTime, int nowCount)
        {
            var obj1 = new A { GetCount = 1, AddMonth = 12, Memo = "追加1年" };
            var obj2 = new A { GetCount = 2, AddMonth = 24, Memo = "追加2年" };
            var obj3 = new A { GetCount = 3, AddMonth = 2401, Memo = "无线有效期" };

            var objArr = new A[3] { obj1, obj2, obj3 };
            nowCount++;
            var rule = objArr.Where(c => c.GetCount == nowCount).FirstOrDefault();
            if (rule != null)
            {
                if (rule.AddMonth > 200 * 12)
                {
                    endTime = DateTime.MaxValue;
                }
                else
                {
                    endTime = endTime.AddMonths(rule.AddMonth);
                }

            }
        }

        /// <summary>
        /// 当前次数
        /// </summary>
        /// <param name="addYear"></param>
        /// <param name="getVipCount"></param>
        /// <param name="nowCount"></param>
        /// <returns></returns>
        //public static DateTime AddVipTime(int addYear, int getVipCount, int nowCount)
        //{

        //}
          


        public static string HttpClientPost(string url, string datajson)
        {
            HttpClient httpClient = new HttpClient();//http对象
            //表头参数
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            //转为链接需要的格式
            HttpContent httpContent = new StringContent(datajson);
            //请求
            HttpResponseMessage response = httpClient.PostAsync(url, httpContent).Result;
            if (response.IsSuccessStatusCode)
            {
                Task<string> t = response.Content.ReadAsStringAsync();
                if (t != null)
                {
                    return t.Result;
                }
            }
            return "";
        }


        public static string GetStr(byte[] fileByte, string url)
        {
            // 设置参数
            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
            CookieContainer cookieContainer = new CookieContainer();
            request.CookieContainer = cookieContainer;
            request.AllowAutoRedirect = true;
            request.Method = "POST";
            string boundary = DateTime.Now.Ticks.ToString("X"); // 随机分隔线
            request.ContentType = "multipart/form-data;charset=utf-8;boundary=" + boundary;
            byte[] itemBoundaryBytes = Encoding.UTF8.GetBytes("\r\n--" + boundary + "\r\n");
            byte[] endBoundaryBytes = Encoding.UTF8.GetBytes("\r\n--" + boundary + "--\r\n");
            //请求头部信息
            string sbHeader = string.Format("Content-Disposition:form-data;name=\"media\";filename=\"{0}\"\r\nContent-Type:application/octet-stream\r\n\r\n", "1.png");
            byte[] postHeaderBytes = Encoding.UTF8.GetBytes(sbHeader);
            Stream postStream = request.GetRequestStream();
            postStream.Write(itemBoundaryBytes, 0, itemBoundaryBytes.Length);
            postStream.Write(postHeaderBytes, 0, postHeaderBytes.Length);
            postStream.Write(fileByte, 0, fileByte.Length);
            postStream.Write(endBoundaryBytes, 0, endBoundaryBytes.Length);
            postStream.Close();
            //发送请求并获取相应回应数据
            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            Stream instream = response.GetResponseStream();
            StreamReader sr = new StreamReader(instream, Encoding.UTF8);
            string content = sr.ReadToEnd();
            return content;
        }


        public class A
        {
            public int GetCount { get; set; }
            public int AddMonth { get; set; }
            public string Memo { get; set; }
        }

    }
}
