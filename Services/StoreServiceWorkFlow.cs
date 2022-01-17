using AutomacaoPetStore.Helpers.APIActions;
using AutomacaoPetStore.Models;
using Xunit.Abstractions;
using System.Text.Json;
using Xunit;

namespace AutomacaoPetStore.Services
{
    internal class StoreServiceWorkFlow
    {
        private readonly ITestOutputHelper testOutput;
        public StoreServiceWorkFlow(ITestOutputHelper testOutput)
        {
            this.testOutput = testOutput;
        }

        /// <summary>
        /// 
        /// POST Store Order
        /// 
        /// </summary>
        /// <param name="jsonInput"></param>
        public void Validate_PostStoreOrder(object jsonInput)
        {
            //Arrange
            PostStoreOrder_Request requestObject = JsonSerializer.Deserialize<PostStoreOrder_Request>(jsonInput.ToString(), new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });

            //Act
            var response = new StoreAPIActions(testOutput).PostStoreOrder(requestObject);
            var responseGet = new StoreAPIActions(testOutput).GetStoreOrderById(requestObject.id);

            //Assert
            Assert.True(response != null, "POST Store Order Test: Failed");
            Assert.True(response.petId == requestObject.petId, "Returned Id differs from entered");
            Assert.True(response.quantity == requestObject.quantity, "Returned Quantity differs from entered");
            Assert.True(response.status == requestObject.status, "Returned Status differs from entered");
            Assert.True(response.complete == requestObject.complete, "Returned Complete differs from entered");
            Assert.True(responseGet.id == response.id, "Returned GET Id differs of POST Id response");
        }

        /// <summary>
        /// 
        /// GET Store Order By Id
        /// 
        /// </summary>
        /// <param name="id"></param>
        public void Validate_GetStoreOrderById(int id)
        {
            //Act
            var response = new StoreAPIActions(testOutput).GetStoreOrderById(id);

            //Assert
            Assert.True(response != null, "GET Store Order Test: Failed");
        }


        /// <summary>
        /// 
        /// DELETE Store Order By Id
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public void Validate_DeleteStoreOrder(object jsonInput)
        {
            //Arrange
            PostStoreOrder_Request requestObject = JsonSerializer.Deserialize<PostStoreOrder_Request>(jsonInput.ToString(), new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
            var responsePost = new StoreAPIActions(testOutput).PostStoreOrder(requestObject);

            //Act
            var responseDelete = new StoreAPIActions(testOutput).DeleteStoreOrder(responsePost.id);

            //Assert
            Assert.True(responseDelete, "DELETE Store Order Test: Failed");
        }

        /// <summary>
        /// 
        /// GET Store Inventory
        /// 
        /// </summary>
        /// <returns></returns>
        public void Validate_GetStore_Inventory()
        {
            //Act
            var response = new StoreAPIActions(testOutput).GetStore_Inventory();

            //Assert
            Assert.True(response != null,"GET Store Inventory Test: Failed");
        }
    }
}
