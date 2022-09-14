namespace FirstApi2.Classes
{
    public static class ServiceProviderExtensions
    {
        public static void AddTimeService(this IServiceCollection services)  // на входе сервисоы, поэтому можем использовать метод
        {
            services.AddTransient<TimeService>();
        }
    }
}
