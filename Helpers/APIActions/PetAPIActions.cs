using AutomacaoPetStore.Models.Pet;
using Xunit.Abstractions;
using System.Text.Json;
using System;
using RestSharp;
using AutomacaoPetStore.Models;
using System.IO;
using System.Collections.Generic;

namespace AutomacaoPetStore.Helpers.APIActions
{
    internal class PetAPIActions
    {
        private readonly ITestOutputHelper testOutput;

        public PetAPIActions(ITestOutputHelper testOutput)
        {
            this.testOutput = testOutput;
        }

        /// <summary>
        /// 
        /// POST PET
        /// 
        /// </summary>
        /// <param name="requestBody"></param>
        /// <returns></returns>
        public PostPet_Request PostPet(PostPet_Request requestBody)
        {
            RestClient restClient = new RestClient();
            RestRequest restRequest = new RestRequest(Method.POST);
            IRestResponse restResponse;

            restClient.BaseUrl = new Uri(APIMethodsUrls.Pet);
            restRequest.AddJsonBody(JsonSerializer.Serialize(requestBody));
            restResponse = restClient.Execute(restRequest);

            if (restResponse.StatusCode == System.Net.HttpStatusCode.OK)
            {
                testOutput.WriteLine("Endpoint executed successfully");
                return JsonSerializer.Deserialize<PostPet_Request>(restResponse.Content, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase});
            }
            else
            {
                testOutput.WriteLine("Waiting POST Response: OK, but returned:"+restResponse.StatusCode);
                return null;
            }
        }

        /// <summary>
        /// 
        /// POST Upload Image
        /// 
        /// </summary>
        /// <param name="petId"></param>
        /// <param name="additionalMetadata"></param>
        /// <returns></returns>
        public GenericResponse PostUploadImage_ByPetId(long petId, string additionalMetadata)
        {
            RestClient restClient = new RestClient();
            RestRequest restRequest = new RestRequest(Method.POST);
            IRestResponse restResponse;

            restClient.BaseUrl = new Uri(APIMethodsUrls.Pet + $"/{petId}/uploadImage");

            string filePatch = $"{Directory.GetCurrentDirectory()}/Data/dogImg.jpg";

            restRequest.AddHeader("Content-Type", "multipart/form-data");
            restRequest.AddParameter("additionalMetadata", additionalMetadata);
            restRequest.AddFile("file", filePatch);
            restRequest.AlwaysMultipartFormData = true;
            restResponse = restClient.Execute(restRequest);

            if (restResponse.StatusCode == System.Net.HttpStatusCode.OK)
            {
                testOutput.WriteLine("Endpoint executed successfully");
                return JsonSerializer.Deserialize<GenericResponse>(restResponse.Content, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
            }
            else
            {
                testOutput.WriteLine("Waiting POST Response: OK, but returned:" + restResponse.StatusCode);
                return null;
            }
        }

        /// <summary>
        /// 
        /// PUT Pet
        /// 
        /// </summary>
        /// <param name="requestBody"></param>
        /// <returns></returns>
        public PostPet_Request PutPet(PostPet_Request requestBody)
        {
            RestClient restClient = new RestClient();
            RestRequest restRequest = new RestRequest(Method.PUT);
            IRestResponse restResponse;

            restClient.BaseUrl = new Uri(APIMethodsUrls.Pet);
            restRequest.AddJsonBody(JsonSerializer.Serialize(requestBody));
            restResponse = restClient.Execute(restRequest);

            if (restResponse.StatusCode == System.Net.HttpStatusCode.OK)
            {
                testOutput.WriteLine("Endpoint executed successfully");
                return JsonSerializer.Deserialize<PostPet_Request>(restResponse.Content, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
            }
            else
            {
                testOutput.WriteLine("Waiting PUT Response: OK, but returned:" + restResponse.StatusCode);
                return null;
            }
        }

        /// <summary>
        /// 
        /// GET Pet List By Status
        /// 
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        public List<GetPet_Response> GetPet_FindByStatus(string status)
        {
            RestClient restClient = new RestClient();
            RestRequest restRequest = new RestRequest(Method.GET);
            IRestResponse restResponse;

            restClient.BaseUrl = new Uri(APIMethodsUrls.Pet+ $"/findByStatus?status={status}");
            restResponse = restClient.Execute(restRequest);

            if (restResponse.StatusCode == System.Net.HttpStatusCode.OK)
            {
                testOutput.WriteLine("Endpoint executed successfully");
                return JsonSerializer.Deserialize<List<GetPet_Response>>(restResponse.Content, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
            }
            else
            {
                testOutput.WriteLine("Waiting GET Response: OK, but returned:" + restResponse.StatusCode);
                return null;
            }
        }

        /// <summary>
        /// 
        /// GET Pet By Id
        /// 
        /// </summary>
        /// <param name="petId"></param>
        /// <returns></returns>
        public GetPet_Response GetPet(long petId)
        {
            RestClient restClient = new RestClient();
            RestRequest restRequest = new RestRequest(Method.GET);
            IRestResponse restResponse;

            restClient.BaseUrl = new Uri(APIMethodsUrls.Pet + $"/{petId}");
            restResponse = restClient.Execute(restRequest);

            if (restResponse.StatusCode == System.Net.HttpStatusCode.OK)
            {
                testOutput.WriteLine("Endpoint executed successfully");
                return JsonSerializer.Deserialize<GetPet_Response>(restResponse.Content, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
            }
            else
            {
                testOutput.WriteLine("Waiting GET Response: OK, but returned:" + restResponse.StatusCode);
                return null;
            }
        }

        public GenericResponse PostUpdatePet(long petId, string name, string status)
        {
            RestClient restClient = new RestClient();
            RestRequest restRequest = new RestRequest(Method.POST);
            IRestResponse restResponse;

            restClient.BaseUrl = new Uri(APIMethodsUrls.Pet + $"/{petId}");

            restRequest.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            restRequest.AddParameter("name", name);
            restRequest.AddParameter("status", status);
            restResponse = restClient.Execute(restRequest);

            if (restResponse.StatusCode == System.Net.HttpStatusCode.OK)
            {
                testOutput.WriteLine("Endpoint executed successfully");
                return JsonSerializer.Deserialize<GenericResponse>(restResponse.Content, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
            }
            else
            {
                testOutput.WriteLine("Waiting GET Response: OK, but returned:" + restResponse.StatusCode);
                return null;
            }
        }
    }
}
