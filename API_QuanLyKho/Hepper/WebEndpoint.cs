namespace API_QuanLyKho.Hepper
{
    public class WebEndpoint
    {
        public const string AreaName = "api";
        public static class Home
        {
            private const string BaseEndpoint = "~/" + AreaName + "/home";
            public const string GETHOME = BaseEndpoint + "/get-all";
            public const string GETBYID = BaseEndpoint + "/get-by-id{id}";
            public const string REMOVE = BaseEndpoint + "/remove";
            public const string UPDATE = BaseEndpoint + "/update{id}";
        }
    }
}
