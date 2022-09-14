namespace FirstApi2.Classes
{
    interface ITimeService
    {
        string GetTime();
    }

    public class TimeService
    {
        public string Time { get; }

        public TimeService()
        {
            Time = DateTime.Now.ToLongTimeString();
        }

        //public string GetTime() => DateTime.Now.ToShortTimeString();
    }

    // время в формате hh:mm:ss
    public class LongTimeService : ITimeService
    {
        public string GetTime() => DateTime.Now.ToLongTimeString();
    }

    // время в формате hh::mm
    public class ShortTimeService : ITimeService
    {
        public string GetTime() => DateTime.Now.ToShortTimeString();
    }

    class TimeMessage
    {
        ITimeService timeService;
        public TimeMessage(ITimeService timeService)
        {
            this.timeService = timeService;
        }
        public string GetTime() => $"Time: {timeService.GetTime()}";
    }

    class TimeMessageMiddleware
    {
        private readonly RequestDelegate next;

        public TimeMessageMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext context, ITimeService timeService) // при использовании клдасса ка middlrware инвоук выполянется сразу же
        {
            context.Response.ContentType = "text/html;charset=utf-8";
            await context.Response.WriteAsync($"<h1>Time: {timeService.GetTime()}</h1>");
        }
    }

    class TimerMiddleware
    {
        RequestDelegate next;
        TimeService timeService;

        public TimerMiddleware(RequestDelegate next/*, TimeService timeService*/) // так как в сервисы подключен TimeService то его объет передастся сюда
        {
            this.next = next;
            //this.timeService = timeService;
        }

        public async Task InvokeAsync(HttpContext context, TimeService timeService) // для получения свежих данных надо передавать объект во входные параметры 
        {
            if (context.Request.Path == "/time")
            {
                context.Response.ContentType = "text/html; charset=utf-8";
                await context.Response.WriteAsync($"Текущее время: {timeService?.Time}");  // время будет одно и то же при повторном запросе, так как объект timeService создается единожды
            }
            else
            {
                await next.Invoke(context);
            }
        }
    }
}
