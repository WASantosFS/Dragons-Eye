using DragonsEye.Data;
using RestSharp;
using RestSharp.Extensions;
using System;
using System.Collections.Generic;
using System.Net;
using System.Web;
using System.Text;

namespace DragonsEye.APIClient
{
    public class CryptoService
    {
        
        private const string API_URL = "http://localhost:52979/crypto";
        private readonly IRestClient client = new RestClient();


        public string CipherMessage(string message)
        {
            

            RestRequest request = new RestRequest(API_URL);
            

            MessageInfo_Client messageInfo = new MessageInfo_Client();
            messageInfo.DayOfYear = DateTime.UtcNow.DayOfYear;
            messageInfo.Hour = DateTime.UtcNow.Hour;
            messageInfo.Message = message;
            

            request.AddJsonBody(messageInfo);

            IRestResponse<string> response = client.Post<string>(request);

            return response.Data;
        }

        /*public string DecipherMessage(string message)
        {
            RestRequest request = new RestRequest(API_URL);

            MessageInfo_Client messageInfo = new MessageInfo_Client();
            messageInfo.DayOfYear = DateTime.UtcNow.DayOfYear;
            messageInfo.Hour = DateTime.UtcNow.Hour;
            messageInfo.Message = message;

            request.AddJsonBody(messageInfo);

            IRestResponse<string> response = client.Put<string>(request);

            return response.Data;
        }*/
    }
}
