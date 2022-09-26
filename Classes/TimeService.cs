namespace FirstApi2.Classes
{
    public interface ITimeService
    {
        string GetTime();
    }

    public interface ITimer
    {
        string Time { get; }
    }

    public class TimeService
    {
        //public string Time { get; }
        private ITimer timer;
        public TimeService(ITimer timer)
        {
            this.timer = timer;
        }

        //public TimeService()
        //{
        //    Time = DateTime.Now.ToLongTimeString();
        //}

        public string GetTime() => timer.Time;
    }

    public class TimeService2
    {
        public string Time => DateTime.Now.ToLongTimeString();
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

    public class TimeMessage
    {
        ITimeService timeService;
        public TimeMessage(ITimeService timeService)
        {
            this.timeService = timeService;
        }
        public string GetTime() => $"Time: {timeService.GetTime()}";
    }

    public class TimeMessageMiddleware
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

    public class TimerMiddleware
    {
        //RequestDelegate next;
        ////TimeService timeService; 

        //public TimerMiddleware(RequestDelegate next/*, TimeService timeService*/) // так как в сервисы подключен TimeService то его объет передастся сюда
        //{
        //    this.next = next;
        //    //this.timeService = timeService;
        //}

        //public async Task InvokeAsync(HttpContext context, TimeService timeService) // для получения свежих данных надо передавать объект во входные параметры 
        //{
        //    if (context.Request.Path == "/time")
        //    {
        //        context.Response.ContentType = "text/html; charset=utf-8";
        //        await context.Response.WriteAsync($"Текущее время: {timeService?.Time}");  // время будет одно и то же при повторном запросе, так как объект timeService закидывается сюда единожды
        //    }
        //    else
        //    {
        //        await next.Invoke(context);
        //    }
        //}

        ///// Другая реализация ///////

        TimeService timeService;
        public TimerMiddleware(RequestDelegate next, TimeService timeService)
        {
            this.timeService = timeService;
        }

        public async Task Invoke(HttpContext context)
        {
            await context.Response.WriteAsync($"Time: {timeService?.GetTime()}");
        }
    }

    public class Timer : ITimer
    { 
        public string Time { get; }

        public Timer()
        {
            Time = DateTime.Now.ToLongTimeString();
        }
    }
}
