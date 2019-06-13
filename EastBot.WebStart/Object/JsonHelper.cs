using EastBot.Core.Interfaces;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Text;

namespace ConsoleApp3
{
    public class JsonHelper : IJsonHelper
    {
        private ILogHelper logHelper;

        public JsonHelper(ILogHelper logHelper)
        {
            this.logHelper = logHelper;
        }

        public T SendGetRequest<T>(string address, string token = null)
        {
            HttpWebRequest request = WebRequest.Create(address) as HttpWebRequest;

            request.Method = "GET";
            request.ContentType = "application/json";
            if (token != null)
            {
                request.Headers.Add("authorization", "bearer " + token);
            }
            request.Accept = "application/json";
            request.Proxy = null;

            try
            {
                HttpWebResponse httpWebResponse = (HttpWebResponse)request.GetResponse();
                string responseString = new StreamReader(httpWebResponse.GetResponseStream()).ReadToEnd();
                return JsonConvert.DeserializeObject<T>(responseString);
            }
            catch (Exception exc)
            {
                logHelper.Error(exc, null);
                logHelper.Info(null, exc);
            }
            return default(T);
        }

        public T SendPostRequest<T>(object objToSend, string address)
        {
            HttpWebRequest request = WebRequest.Create(address) as HttpWebRequest;
            string jsonString = JsonConvert.SerializeObject(objToSend);
            byte[] data = Encoding.UTF8.GetBytes(jsonString);

            request.Method = "POST";
            request.ContentType = "application/json";
            request.ContentLength = data.Length;
            request.Accept = "application/json";
            request.Proxy = null;

            using (Stream stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }
            try
            {
                HttpWebResponse httpresponse = (HttpWebResponse)request.GetResponse();
                string responseString = new StreamReader(httpresponse.GetResponseStream()).ReadToEnd();

                return JsonConvert.DeserializeObject<T>(responseString);
            }
            catch (Exception exc)
            {
                logHelper.Error(exc, null);
                logHelper.Info(null, exc);
            }

            return default(T);
        }

        public void SendPostRequest(object objToSend, string address, string token = null)
        {
            HttpWebRequest request = WebRequest.Create(address) as HttpWebRequest;
            string jsonString = JsonConvert.SerializeObject(objToSend);
            byte[] data = Encoding.UTF8.GetBytes(jsonString);

            request.Method = "POST";
            request.ContentType = "application/json";
            if (token != null)
            {
                request.Headers.Add("authorization", "bearer " + token);
            }
            request.ContentLength = data.Length;
            request.Accept = "application/json";
            request.Proxy = null;

            using (Stream stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }
            try
            {
                HttpWebResponse httpresponse = (HttpWebResponse)request.GetResponse();
                string responseString = new StreamReader(httpresponse.GetResponseStream()).ReadToEnd();
            }
            catch (Exception exc)
            {
                logHelper.Error(exc, null);
                logHelper.Info(null, exc);
            }
        }

        public HttpWebResponse SendPostRequest(object objToSend, string address)
        {
            HttpWebRequest request = WebRequest.Create(address) as HttpWebRequest;
            string jsonString = JsonConvert.SerializeObject(objToSend);
            byte[] data = Encoding.UTF8.GetBytes(jsonString);

            request.Method = "POST";
            request.ContentType = "application/json";
            request.ContentLength = data.Length;
            request.Accept = "application/json";
            request.Proxy = null;

            using (Stream stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }
            try
            {
                HttpWebResponse httpresponse = (HttpWebResponse)request.GetResponse();

                return httpresponse;
            }
            catch (Exception exc)
            {
                logHelper.Error(exc, null);
                logHelper.Info(null, exc);
            }

            return new HttpWebResponse();
        }
    }
}
