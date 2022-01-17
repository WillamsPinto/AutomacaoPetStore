namespace AutomacaoPetStore.Helpers
{
    public class APIMethodsUrls
    {
        public static string Pet
        {
            get { return $"{CustomConfigurationProvider.GetKey("petStoreService-baseUrl")}pet"; }
        }

        public static string Store
        {
            get { return $"{CustomConfigurationProvider.GetKey("petStoreService-baseUrl")}store/"; }
        }

        public static string User
        {
            get { return $"{CustomConfigurationProvider.GetKey("petStoreService-baseUrl")}user/"; }
        }
    }
}
