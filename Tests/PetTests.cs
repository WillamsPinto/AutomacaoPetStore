using AutomacaoPetStore.Services;
using Xunit.Abstractions;
using Xunit;

namespace AutomacaoPetStore.Tests
{
    public class PetTests
    {
        private readonly ITestOutputHelper output;

        public PetTests(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact(DisplayName = "Validate POST Pet")]
        public void Validate_PostPet()
        {
            new PetServiceWorkFlow(output).Validate_PostPet(CustomConfigurationProvider.GetSection("postPet"));
        }

        [Theory(DisplayName = "Validate POST Upload Image by PetId")]
        [InlineData(1, "02/02/2022")]
        public void Validate_PostUploadImage_ByPetId(long petId, string data)
        {
            new PetServiceWorkFlow(output).Validate_PostUploadImage_ByPetId(petId,data);
        }

        [Theory(DisplayName = "Validate PUT Pet")]
        [InlineData(1)]
        public void Validate_PutPet(long petId)
        {
            new PetServiceWorkFlow(output).Validate_PutPet(petId, CustomConfigurationProvider.GetSection("postPet"));
        }

        [Theory(DisplayName = "Validate GET Pet find by status")]
        [InlineData("available")]
        [InlineData("pending")]
        [InlineData("sold")]
        public void Validate_GetPet_FindByStatus(string status)
        {
            new PetServiceWorkFlow(output).Validate_GetPet_FindByStatus(status);
        }

        [Theory(DisplayName = "Validate GET Pet")]
        [InlineData(8)]
        public void Validate_GetPet(int petId)
        {
            new PetServiceWorkFlow(output).Validate_GetPet(petId);
        }

        [Theory(DisplayName = "Validate POST Update Pet")]
        [InlineData(8, "Teco", "sold")]
        public void Validate_PostUpadtePet(int petId, string name, string status)
        {
            new PetServiceWorkFlow(output).Validate_PostUpadtePet(petId, name, status);
        }
    }
}
