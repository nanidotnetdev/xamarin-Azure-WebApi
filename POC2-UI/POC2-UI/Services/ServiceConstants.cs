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
            public const string GetUserEntity = "https://enterprizepoc.azure-api.net/api/UserApi/GetUserEntity?id={0}";
            public const string GetAllUsers = "";
        }

        public sealed class SubscriptionKeys
        {
            public const string PrimaryKey = "6284fcd340df45e594a1b3451dd0261f";
        }


    }
}
