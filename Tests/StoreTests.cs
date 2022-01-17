using Xunit.Abstractions;
using Xunit;
using AutomacaoPetStore.Services;

namespace AutomacaoPetStore.Tests
{
    public class StoreTests
    {
        private readonly ITestOutputHelper output;
        public StoreTests(ITestOutputHelper output)
        {
            this.output = output;
        }

        /// <summary>
        /// 
        /// POST Store Order
        /// 
        /// </summary>
        [Fact(DisplayName ="Validate POST Store Order")]
        public void Validate_PostStoreOrder()
        {
            new StoreServiceWorkFlow(output).Validate_PostStoreOrder(CustomConfigurationProvider.GetSection("postStoreOrder"));
        }

        /// <summary>
        /// 
        /// GET Store Order By Id
        /// 
        /// </summary>
        /// <param name="id"></param>
        [Theory(DisplayName = "Validate GET Store Order By Id")]
        [InlineData(1)]
        public void Validate_GetStoreOrderById(int id)
        {
            new StoreServiceWorkFlow(output).Validate_GetStoreOrderById(id);
        }

        /// <summary>
        /// 
        /// DELETE Store Order By Id
        /// 
        /// </summary>
        /// <param name="id"></param>
        [Fact(DisplayName = "Validate DELETE Store Order By Id")]
        public void Validate_DeleteStoreOrderById()
        {
            new StoreServiceWorkFlow(output).Validate_DeleteStoreOrder(CustomConfigurationProvider.GetSection("postStoreOrder"));
        }

        /// <summary>
        /// 
        /// GET Store Inventory
        /// 
        /// </summary>
        [Fact(DisplayName = "Validate GET Store All Inventory")]
        public void Validate_GetStore_Inventory()
        {
            new StoreServiceWorkFlow(output).Validate_GetStore_Inventory();
        }
    }
}
