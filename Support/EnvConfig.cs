namespace AutomationEcommerce.Support
{
    public static class EnvConfig
    {
        public static string BaseUrl =>
            Environment.GetEnvironmentVariable("BASE_URL") ?? "https://automationexercise.com";

        public static string LoginEmail =>
            Environment.GetEnvironmentVariable("LOGIN_EMAIL") ?? "default@test.com";

        public static string ValidEmail =>
            Environment.GetEnvironmentVariable("VALID_EMAIL")
            ?? "migixe6555@bitfami.com";

        public static string ValidPassword =>
            Environment.GetEnvironmentVariable("VALID_PASSWORD")
            ?? "123456789";
            
        public static string CardName =>
            Environment.GetEnvironmentVariable("CARD_NAME") 
            ?? "Teste Usuario";

        public static string CardNumber =>
            Environment.GetEnvironmentVariable("CARD_NUMBER") 
            ?? "5552324588490628";

        public static string CardCVC =>
            Environment.GetEnvironmentVariable("CARD_CVC") 
            ?? "630";

        public static string CardMonth =>
            Environment.GetEnvironmentVariable("CARD_MONTH") 
            ?? "11";

        public static string CardYear =>
            Environment.GetEnvironmentVariable("CARD_YEAR") 
            ?? "2026";
    }
}
