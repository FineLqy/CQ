using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Web;

namespace CORSV2.cs
{
    public class HttpHelper
    {
        /// <summary>
        /// 获取或设置用于验证服务器证书的回调永远返回true
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="cert"></param>
        /// <param name="chain"></param>
        /// <param name="error"></param>
        /// <returns></returns>
        private static bool RemoteCertificateValidate(object sender, X509Certificate cert, X509Chain chain, SslPolicyErrors error)
        {
            //获取或设置用于验证服务器证书的回调”永远为true 即
            return true;
        }

        public static bool SendSMS(string apiUrl)
        {
            try
            {
                System.Net.HttpWebRequest request;
                // 创建一个HTTP请求
                request = (System.Net.HttpWebRequest)WebRequest.Create(apiUrl);
                //request.Method="get";
                System.Net.HttpWebResponse response;
                response = (System.Net.HttpWebResponse)request.GetResponse();
                System.IO.StreamReader myreader = new System.IO.StreamReader(response.GetResponseStream(), Encoding.UTF8);
                string responseText = myreader.ReadToEnd();
                myreader.Close();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }



        /// <summary>
        /// 模拟发送POST请求
        /// </summary>
        /// <param name="apiUrl"></param>
        /// <param name="data"></param>
        /// <param name="postHeaders"></param>
        /// <param name="contentType"></param>
        public static string SendPOST(string apiUrl, string data, Dictionary<string, string> postHeaders)
        {
            string result = string.Empty;
            int http_StatusCode = 0;
            string http_ResponseMessage = null;
            try
            {
                //注意提交的编码 这边是需要改变的 这边默认的是Default：系统当前编码
                byte[] postData = Encoding.UTF8.GetBytes(data);
                // 忽略SSL证书，防止“未能为 SSL/TLS 安全通道建立信任关系”的报错
                ServicePointManager.ServerCertificateValidationCallback += RemoteCertificateValidate;
                // 设置提交的相关参数 
                HttpWebRequest request = WebRequest.Create(apiUrl) as HttpWebRequest;
                //Encoding myEncoding = Encoding.UTF8;
                request.Method = "POST";
                request.KeepAlive = false;
                request.AllowAutoRedirect = false;
                //遍历字典
                foreach (KeyValuePair<string, string> header in postHeaders)
                {
                    request.Headers.Add(header.Key, header.Value);
                }
                request.ContentType = "application/json";

                // 提交请求数据 
                System.IO.Stream outputStream = request.GetRequestStream();
                outputStream.Write(postData, 0, postData.Length);
                outputStream.Close();

                HttpWebResponse response = null;
                Stream responseStream = null;
                StreamReader reader = null;
                string srcString;
                response = request.GetResponse() as HttpWebResponse;
                // Statuscode 为枚举类型，200为正常，其他输出异常，需要转为int型才会输出状态码
                http_StatusCode = Convert.ToInt32(response.StatusCode);
                http_ResponseMessage = response.StatusCode.ToString();

                if (200 == http_StatusCode)
                {
                    responseStream = response.GetResponseStream();
                    reader = new System.IO.StreamReader(responseStream, Encoding.GetEncoding("UTF-8"));
                    srcString = reader.ReadToEnd();
                    result = srcString;   //返回值赋值
                    reader.Close();
                }
                else
                {
                    throw new Exception("网络请求异常：HTTP响应码： " + http_StatusCode + ", HTTP响应信息： " + http_ResponseMessage);
                }
            }
            catch (WebException ex)
            {
                throw new Exception("网络请求时发生异常：" + ex.Message);
            }
            return result;
        }
    }
}