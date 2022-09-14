namespace FirstApi2.Classes
{
    public interface ICounter
    {
        int Value { get; }
    }
    
    public class CounterService
    {
        public ICounter Counter { get; }
        public CounterService(ICounter counter)  // 2
        {
            Counter = counter;
        }
    }
    
    public class RandomCounter : ICounter   // 1
    {
        static Random rnd = new Random();
        private int _value;

        public RandomCounter()
        {
            _value = rnd.Next(0, 1000000);
        }

        public int Value => _value;
    }

    public class CounterMiddleware
    {
        RequestDelegate next;
        int i = 0; // счетчик запросов

        public CounterMiddleware(RequestDelegate next)  // 3
        {
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext, ICounter counter, CounterService counterService)  // 3  // для counter и counterService создаются разные объекты RandomCounter
        {
            i++;
            httpContext.Response.ContentType = "text/html;charset=utf-8";
            await httpContext.Response.WriteAsync($"Запрос {i}; Counter: {counter.Value}; Service: {counterService.Counter.Value}");
        }
    }
}
