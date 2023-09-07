namespace API_QuanLyKho.Hepper
{
    public class WebEndpoint
    {
        public const string AreaName = "api";
        public static class Home
        {
            private const string BaseEndpoint = "~/" + AreaName + "/home";
            public const string GetHome = BaseEndpoint + "/get-all";
        }
    }
}
