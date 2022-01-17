using Xunit.Abstractions;
using System.Text.Json;
using RestSharp;
using System;
using AutomacaoPetStore.Models;

namespace AutomacaoPetStore.Helpers.APIActions
{
    internal class StoreAPIActions
    {
        private readonly ITestOutputHelper testOutput;
        public StoreAPIActions(ITestOutputHelper testOutput)
        {
            this.testOutput = testOutput;
        }

        /// <summary>
        /// 
        /// POST Store Order
        /// 
        /// </summary>
        /// <param name="requestObject"></param>
        /// <returns></returns>
        public PostStoreOrder_Request PostStoreOrder(PostStoreOrder_Request requestObject)
        {
            RestClient restClient = new RestClient();
            RestRequest restRequest = new RestRequest(Method.POST);
            IRestResponse restResponse;

            restClient.BaseUrl = new Uri(APIMethodsUrls.Store + "order");
            restRequest.AddJsonBody(JsonSerializer.Serialize(requestObject));
            restResponse = restClient.Execute(restRequest);

            if (restResponse.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return JsonSerializer.Deserialize<PostStoreOrder_Request>(restResponse.Content);
            }
            else
            {
                testOutput.WriteLine("Waiting POST Status Code OK, but returned:" + restResponse.StatusCode);
                return null;
            }
        }

        /// <summary>
        /// 
        /// GET Store Order By Id
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public PostStoreOrder_Request GetStoreOrderById(long id)
        {
            RestClient restClient = new RestClient();
            RestRequest restRequest = new RestRequest(Method.GET);
            IRestResponse restResponse;

            restClient.BaseUrl = new Uri(APIMethodsUrls.Store + $"order/{id}");
            restResponse = restClient.Execute(restRequest);

            if (restResponse.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return JsonSerializer.Deserialize<PostStoreOrder_Request>(restResponse.Content);
            }
            else
            {
                testOutput.WriteLine("Waiting GET Status Code OK, but returned:" + restResponse.StatusCode);
                return null;
            }
        }

        /// <summary>
        /// 
        /// DELETE Store Order By Id
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteStoreOrder(long id)
        {
            RestClient restClient = new RestClient();
            RestRequest restRequest = new RestRequest(Method.DELETE);
            IRestResponse restResponse;

            restClient.BaseUrl = new Uri(APIMethodsUrls.Store + $"order/{id}");
            restResponse = restClient.Execute(restRequest);

            if (restResponse.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return true;
            }
            else
            {
                testOutput.WriteLine("Waiting DELETE Status Code OK, but returned:" + restResponse.StatusCode);
                return false;
            }
        }

        /// <summary>
        /// 
        /// GET Store Inventory
        /// 
        /// </summary>
        /// <returns></returns>
        public GetStoreInventory_Response GetStore_Inventory()
        {
            RestClient restClient = new RestClient();
            RestRequest restRequest = new RestRequest(Method.GET);
            IRestResponse restResponse;

            restClient.BaseUrl = new Uri(APIMethodsUrls.Store + "inventory");
            restResponse = restClient.Execute(restRequest);

            if (restResponse.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return JsonSerializer.Deserialize<GetStoreInventory_Response>(restResponse.Content);
            }
            else
            {
                testOutput.WriteLine("Waiting GET Status Code OK, but returned:" + restResponse.StatusCode);
                return null;
            }
        }
    }
}
