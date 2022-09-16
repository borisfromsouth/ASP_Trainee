namespace FirstApi2.Classes
{
    public interface IHelloService
    {
        string Message { get; }
    }

    public class HelloMiddleware
    {
        readonly IEnumerable<IHelloService> helloServices; // коллекция сервисов с несколькими реализациями на один интерфейс

        public HelloMiddleware(RequestDelegate _, IEnumerable<IHelloService> helloServices)
        {
            this.helloServices = helloServices;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            context.Response.ContentType = "text/html; charset=utf-8";
            string responseText = "";
            foreach (var service in helloServices)
            {
                responseText += $"<h3>{service.Message}</h3>";
            }
            await context.Response.WriteAsync(responseText);
        }
    }
    
    public class RuHelloService : IHelloService
    {
        public string Message => "Привет METANIT.COM";
    }

    public class EnHelloService : IHelloService
    {
        public string Message => "Hello METANIT.COM";
    }
}
