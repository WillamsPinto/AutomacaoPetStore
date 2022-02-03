using AutomacaoPetStore.Helpers.APIActions;
using AutomacaoPetStore.Models.Pet;
using Xunit.Abstractions;
using System.Text.Json;
using Xunit;

namespace AutomacaoPetStore.Services
{
    internal class PetServiceWorkFlow
    {
        private readonly ITestOutputHelper testOutput;

        public PetServiceWorkFlow(ITestOutputHelper testOutput)
        {
            this.testOutput = testOutput;
        }

        public void Validate_PostPet(object jsonInput)
        {
            //Arrange
            PostPet_Request requestObject = JsonSerializer.Deserialize<PostPet_Request>(jsonInput.ToString(), new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });

            //Act
            var response = new PetAPIActions(testOutput).PostPet(requestObject);

            //Assert
            Assert.NotNull(response);
            Assert.True(response.category.id == requestObject.category.id, "Returned id differs from entered.");
            Assert.True(response.category.name == requestObject.category.name, "Returned name differs from entered.");
            Assert.True(response.name == requestObject.name);
            Assert.Contains(response.tags, r=>r.id == requestObject.tags[0].id);
            Assert.Contains(response.tags, r=>r.name == requestObject.tags[0].name);
            Assert.True(response.status == requestObject.status, "Returned status differs from entered.");
        }

        public void Validate_PostUploadImage_ByPetId(long petId, string additionalMetadata)
        {
            //Act
            var response = new PetAPIActions(testOutput).PostUploadImage_ByPetId(petId, additionalMetadata);

            //Assert
            Assert.NotNull(response);
            Assert.True(response.code == 200, "Returned code differs from code 200");
            Assert.Contains("dogImg.jpg", response.message);
        }

        public void Validate_PutPet(long petId, object jsonInput)
        {
            //Arrange
            PostPet_Request requestObject = JsonSerializer.Deserialize<PostPet_Request>(jsonInput.ToString(), new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
            requestObject.id = petId;

            //Act
            var response = new PetAPIActions(testOutput).PutPet(requestObject);

            //Assert
            Assert.NotNull(response);
            Assert.True(response.category.id == requestObject.category.id, "Returned id differs from entered.");
            Assert.True(response.category.name == requestObject.category.name, "Returned name differs from entered.");
            Assert.True(response.name == requestObject.name);
            Assert.Contains(response.tags, r => r.id == requestObject.tags[0].id);
            Assert.Contains(response.tags, r => r.name == requestObject.tags[0].name);
            Assert.True(response.status == requestObject.status, "Returned status differs from entered.");
        }

        public void Validate_GetPet_FindByStatus(string status)
        {
            //Act
            var response = new PetAPIActions(testOutput).GetPet_FindByStatus(status);

            //Assert
            Assert.NotNull(response);
            Assert.Contains(response, r => r.status == status);
        }

        public void Validate_GetPet(long petId)
        {
            //Act
            var response = new PetAPIActions(testOutput).GetPet(petId);

            //Assert
            Assert.NotNull(response);
            Assert.True(response.id == petId, "Returned id differs from entered.");
        }

        public void Validate_PostUpadtePet(long petId, string name, string status)
        {
            //Act
            var response = new PetAPIActions(testOutput).PostUpdatePet(petId, name, status);

            //Assert
            Assert.NotNull(response);
            Assert.True(response.code == 200, "Returned code differs from code 200.");
            Assert.True(response.message == petId.ToString(), "Returned id differs from entered.");
        }
    }
}
