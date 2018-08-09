namespace POC2_UI.Services
{
    public static class ServiceConstants
    {
        public sealed class Defaults
        {
            public const int ServiceTimeoutInSecs = 30;
        }

        public sealed class Urls
        {
            //User Api URLs
            public const string GetUserEntity = "https://enterprizepoc.azure-api.net/api/UserApi/GetUserEntity?id={0}";
            public const string GetAllUserEntities = "https://enterprizepoc.azure-api.net/api/UserApi/GetUserEntities";
            public const string DeleteUserEntity = "https://enterprizepoc.azure-api.net/api/UserApi/DeleteUserEntity?id={0}";
            public const string SAveUserEntity = "https://enterprizepoc.azure-api.net/api/UserApi/PostUserEntity";

        }

        public sealed class SubscriptionKeys
        {
            public const string PrimaryKey = "6284fcd340df45e594a1b3451dd0261f";
        }


    }
}
