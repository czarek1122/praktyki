using System.Net;

namespace EastBot.Core.Interfaces
{
    public interface IJsonHelper
    {
        T SendPostRequest<T>(object objToSend, string address);
        void SendPostRequest(object objToSend, string address, string token);
        T SendGetRequest<T>(string address, string token);
        HttpWebResponse SendPostRequest(object objToSend, string addres);
    }
}
