using FirstApi2.Classes;
using System.Text;
using System.Text.RegularExpressions;
using Timer = FirstApi2.Classes.Timer;

//List<Person> users = new List<Person>
//{
//    new() { Id = Guid.NewGuid().ToString(), Name = "Tom", Age = 37},// Guid.NewGuid().ToString() получение уникального идентификатора, например "2e752824-1657-4c7f-844b-6ec2e168e99c".
//    new() { Id = Guid.NewGuid().ToString(), Name = "Bob", Age = 41},
//    new() { Id = Guid.NewGuid().ToString(), Name = "Sam", Age = 24}
//};

var builder = WebApplication.CreateBuilder();
//builder.Services.AddTransient<ITimeService, LongTimeService>();  // на место объектов интерфейса ITimeService будет передаваться экземпляры класса LongTimeService
//var services = builder.Services;  // коллекция сервисов (по умолчанию уже содержит 81 сервис)

//builder.Services.AddTransient<TimeService>();

//builder.Services.AddTimeService();

//builder.Services.AddTransient<ITimeService, ShortTimeService>();
//builder.Services.AddTransient<TimeMessage>();  // прошлый сервис действует на все последующие

//builder.Services.AddTransient<ICounter, RandomCounter>();  // AddTransient создает transient-объекты которые создаются при каждом обращении к ним
//builder.Services.AddTransient<CounterService>();

//builder.Services.AddScoped<ICounter, RandomCounter>();  // AddScoped создает один экземпляр объекта для всего запроса
//builder.Services.AddScoped<CounterService>();

//builder.Services.AddSingleton<ICounter, RandomCounter>(); // AddSingleton создает один объект для всех последующих запросов, но создается только тогда, когда он непосредственно необходим
//builder.Services.AddSingleton<CounterService>();

// builder.Services.AddTransient<TimeService>(); // добавляем сервис

//builder.Services.AddTransient<ITimer, Timer>(); // для корректной работы не должно быть жизненного цикла scopedl, он активируется тольок при вызове 
//builder.Services.AddScoped<TimeService>();

//builder.Services.AddScoped<ITimer, Timer>(); // для корректной работы не должно быть жизненного цикла scopedl, он активируется тольок при вызове 
//builder.Services.AddSingleton<TimeService>();

//builder.Services.AddTransient<IHelloService, RuHelloService>();
//builder.Services.AddTransient<IHelloService, EnHelloService>();

//builder.Services.AddSingleton<IGenerator, ValueStorage>(); // два отдельных синглетона одного класска на разные интерфейсы 
//builder.Services.AddSingleton<IReader, ValueStorage>();

//builder.Services.AddSingleton<ValueStorage>(); // определяем один объект в сервисы
//builder.Services.AddSingleton<IGenerator>(serv => serv.GetRequiredService<ValueStorage>()); // находим объект в сервисах и устанавливаем для реализации на два интерфейса, таким образом мы используем один и тот же оъект в двух местах гыыгыгыыыг
//builder.Services.AddSingleton<IReader>(serv => serv.GetRequiredService<ValueStorage>());

builder.Services.AddRouting(options => options.ConstraintMap.Add("secretcode" /*ключ ограничения*/, typeof(SecretCodeConstraint)/*класс ограничения*/)); // сервис по проверка маршрута; ConstraintMap - коллекция ограничений 

builder.Services.AddRouting(options => options.ConstraintMap.Add("invalidnames" , typeof(InvalidNamesConstraint)));

var app = builder.Build();

//app.UseMiddleware<TimeMessageMiddleware>();

//app.UseMiddleware<CounterMiddleware>();

//app.UseMiddleware<TimerMiddleware>();

//app.UseMiddleware<HelloMiddleware>();

//app.UseMiddleware<GeneratorMiddleware>();
//app.UseMiddleware<ReaderMiddleware>();

//app.Map("/", () => "Index Page");  // выводит текст
//app.Map("/about", () => "About Page");
//app.Map("/contact", () => "Contacts Page");

//app.Map("/contact", () => new Person("1", "Tom", 37));  // выводит данные класса а формате json

//app.Map("/", IndexHandler);  // выводит текст
//app.Map("/user", () => Console.WriteLine("Request Path: /user"));
//app.Map("/about", async (context) => await context.Response.WriteAsync("About Page"));  // вариант для получения полного доступа к контексту

//app.Map("/", () => "Index Page");
//app.Map("/about", () => "About Page");
//app.Map("/contact", () => "Contacts Page");

//app.MapGet("/routes", (IEnumerable<EndpointDataSource> endpointSources) =>
//        string.Join("\n", endpointSources.SelectMany(source => source.Endpoints)));  // получение сводки по вем конечным точкам 

//app.MapGet("/routes", (IEnumerable<EndpointDataSource> endpointSources) => // типо подробная инфа по конечным точкам 
//{
//    var sb = new StringBuilder();
//    var endpoints = endpointSources.SelectMany(es => es.Endpoints); // получаем весь список конечных точек 
//    foreach (var endpoint in endpoints)
//    {
//        sb.AppendLine(endpoint.DisplayName);

//        // получим конечную точку как RouteEndpoint
//        if (endpoint is RouteEndpoint routeEndpoint)
//        {
//            sb.AppendLine(routeEndpoint.RoutePattern.RawText);
//        }

//        //var routeNameMetadata = endpoint.Metadata.OfType<Microsoft.AspNetCore.Routing.RouteNameMetadata>().FirstOrDefault(); // получение метаданных
//        //var routeName = routeNameMetadata?.RouteName; // данные маршрутизации

//        //var httpMethodsMetadata = endpoint.Metadata.OfType<HttpMethodMetadata>().FirstOrDefault();
//        //var httpMethods = httpMethodsMetadata?.HttpMethods; // [GET, POST, ...]   // данные http - поддерживаемые типы запросов
//    }
//    return sb.ToString();
//});

//app.Map("/users/{id}", (string id) => $"User Id: {id}");
//app.Map("/users/{id}/{name}", (string id, string name) => $"User Id: {id}   User Name: {name}");
//app.Map("/users/{id}-{name}", (string id, string name) => $"User Id: {id}   User Name: {name}"); // "/users/{id}{name}" такая запись работать не будет 
//app.Map("/users/{id}and{name}", (string id, string name) => $"User Id: {id}   User Name: {name}");
//app.Map("/users/{id}-{name}", HandleRequest);  // отдельным методом
//app.Map("/users/{id?}", (string? id) => $"User Id: {id ?? "Undefined"}"); // для необязательных параметров ставится знак ? (много знаков ?)  // ?? проверка на null справа
//app.Map("/users", () => "Users Page");
//app.Map("/", () => "Index Page");

//app.Map( "{controller=Home}/{action=Index}/{id?}", (string controller, string action, string? id) =>  // значения по умолчанию работают если ничего не введено
//        $"Controller: {controller} \nAction: {action} \nId: {id}"
//);

//app.Map("users/{**info}", (string info) => $"User Info: {info}");  // **info множетсвенные параметры (любое количество сегментов в запросе)

//app.Map("/users/{id}", (int id) => $"User Id: {id}");  // если на месте {id} мы введем текст то путь пройдет нормально, но обработчик полетит c исключением "BadHttpRequest"
//app.Map("/users/{id:int}", (int id) => $"User Id: {id}"); // тут же путь не сможет сопоставиться с шаблоном если id не является int-овым, выкинет исключение 404

//app.Map(
//    "/users/{name:alpha:minlength(2)}/{age:int:range(1, 110)}",
//    (string name, int age) => $"User Age: {age} \nUser Name:{name}"
//);
//app.Map(
//    "/phonebook/{phone:regex(^7-\\d{{3}}-\\d{{3}}-\\d{{4}}$)}/",  // формат 7-111-222-3333
//    (string phone) => $"Phone: {phone}"
//);

app.Map(
    "/users/{name}/{token:int:secretcode(123466)}",  // передача значения 123466 по ключу secretcode в конструктор класса SecretCodeConstraint
    (string name, int token) => $"User Name:{name} \nToken:{token}"
);
app.Map(
    "/users/{name:invalidnames}",  // передача значения 123466 по ключу secretcode в конструктор класса SecretCodeConstraint
    (string name) => $"User Name:{name}"
);



//app.Run(async context =>
//{
//var timeService = app.Services.GetService<TimeService>();  // получаем интерфейс
//await context.Response.WriteAsync($"Time: {timeService?.GetTime()}");  // поскольку выше мы добавили краткое время

//var timeService = app.Services.GetService<TimeService>();
//context.Response.ContentType = "text/html; charset=utf-8";
//await context.Response.WriteAsync($"Текущее время: {timeService?.GetTime()}");

//// для получения сервисов можно использовать контекст
//var timeService2 = context.RequestServices.GetService<ITimeService>();  // или .GetService<ITimeService>(); но тогда если сервис не будет найден будет выкинуто исключение
//await context.Response.WriteAsync($"Time: {timeService?.GetTime()}");

//var timeMessage = context.RequestServices.GetService<TimeMessage>();
//context.Response.ContentType = "text/html;charset=utf-8";
//await context.Response.WriteAsync($"<h2>{timeMessage?.GetTime()}</h2>");
//});

//app.Map("/home", appBuilder =>  // создание ветки
//{
//    appBuilder.Map("/index", Index); // middleware для "/home/index"
//    appBuilder.Map("/about", About); // middleware для "/home/about"

//    appBuilder.Run(async (context) => await context.Response.WriteAsync("Home Page"));  // middleware для "/home"
//});

//app.Run(async (context) => await context.Response.WriteAsync("Page Not Found"));  //  middleware для всего остального

//app.Run(WorkApi);

//app.Run(SendFile);

//app.UseMiddleware<TokenMiddleware>();

//app.UseToken("555");

//app.UseMiddleware<ErrorHandlingMiddleware>();  // согласно представленной логике сначала мы ставим проверку на статус после перехода к следующему middleware
//app.UseMiddleware<AuthenticationMiddleware>();  // используем класс авторизации, если норм - идем дальше
//app.UseMiddleware<RoutingMiddleware>();

//app.Environment.EnvironmentName = "Production";  // можем менять имя окружения на любое (Также мия можно менять напрямую в файле launchSettings.json)
//if (app.Environment.IsEnvironment("Test")) { }  // чек окружения на имя тест


//if (app.Environment.IsDevelopment())
//{
//    app.Run(async(context) => await context.Response.WriteAsync("In Development Stage"));
//}
//else
//{
//    app.Run(async (context) => await context.Response.WriteAsync("In Product Stage"));
//}

//app.Run(async (context) => await context.Response.WriteAsync("Hello METANIT.COM"));

//app.Run(async context => {
//    var sb = new StringBuilder();
//    sb.Append("<h1>Все сервисы</h1>");
//    sb.Append("<table>");
//    sb.Append("<tr><th>Тип</th><th>Lifetime</th><th>Реализация</th></tr>");
//    foreach (var svc in services)
//    {
//        sb.Append("<tr>");
//        sb.Append($"<td>{svc.ServiceType.FullName}</td>");
//        sb.Append($"<td>{svc.Lifetime}</td>");
//        sb.Append($"<td>{svc.ImplementationType?.FullName}</td>");
//        sb.Append("</tк>");
//    }
//    sb.Append("</table>");
//    context.Response.ContentType = "text/html; charset=utf-8";
//    await context.Response.WriteAsync(sb.ToString());
//});

app.Run();

string HandleRequest(string id, string name)
{
    return $"User Id: {id}   User Name: {name}";
}

string IndexHandler()
{
    return "Index Page";
}
//async Task WorkApi(HttpContext context)
//{
//    //string expressionForNumber = "^/api/users/([0 - 9]+)$";   // если id представляет число

//    // 2e752824-1657-4c7f-844b-6ec2e168e99c
//    string expressionForGuid = @"^/api/users/\w{8}-\w{4}-\w{4}-\w{4}-\w{12}$";  // \w{4} - 4 элемента
//    if (context.Request.Path == "/api/users" && context.Request.Method == "GET")
//    {
//        await GetAllPeople(context.Response);
//    }
//    else if (Regex.IsMatch(context.Request.Path, expressionForGuid) && context.Request.Method == "GET")
//    {
//        string? id = context.Request.Path.Value?.Split("/")[3];  // получаем id из адреса url
//        await GetPerson(id, context.Response);
//    }
//    else if (context.Request.Path == "/api/users" && context.Request.Method == "POST")
//    {
//        await CreatePerson(context.Response, context.Request);
//    }
//    else if (context.Request.Path == "/api/users" && context.Request.Method == "PUT")
//    {
//        await UpdatePerson(context.Response, context.Request);
//    }
//    else if (Regex.IsMatch(context.Request.Path, expressionForGuid) && context.Request.Method == "DELETE")
//    {
//        string? id = context.Request.Path.Value?.Split("/")[3];
//        await DeletePerson(id, context.Response);
//    }
//    else
//    {
//        context.Response.ContentType = "text/html; charset=utf-8";
//        await context.Response.SendFileAsync("html/index.html");
//    }
//}


//async Task GetAllPeople(HttpResponse response)  // получение всех пользователей
//{
//    await response.WriteAsJsonAsync(users);
//}

//async Task GetPerson(string? id, HttpResponse response)  // получение одного пользователя по id
//{
//    Person? user = users.FirstOrDefault((u) => u.Id == id);
//    if (user != null)
//        await response.WriteAsJsonAsync(user);
//    else
//    {
//        response.StatusCode = 404;
//        await response.WriteAsJsonAsync(new { message = "Пользователь не найден" });
//    }
//}

//async Task DeletePerson(string? id, HttpResponse response)
//{
//    Person? user = users.FirstOrDefault((u) => u.Id == id);
//    if (user != null)
//    {
//        users.Remove(user);
//        await response.WriteAsJsonAsync(user);
//    }
//    else
//    {
//        response.StatusCode = 404;
//        await response.WriteAsJsonAsync(new { message = "Пользователь не найден" });
//    }
//}

//async Task CreatePerson(HttpResponse response, HttpRequest request)
//{
//    try
//    {
//        var user = await request.ReadFromJsonAsync<Person>();  // получаем данные пользователя
//        if (user != null)
//        {
//            user.Id = Guid.NewGuid().ToString();  // устанавливаем id для нового пользователя
//            users.Add(user);                      // добавляем пользователя в список
//            await response.WriteAsJsonAsync(user);
//        }
//        else
//        {
//            throw new Exception("Некорректные данные");
//        }
//    }
//    catch (Exception)
//    {
//        response.StatusCode = 400;
//        await response.WriteAsJsonAsync(new { message = "Некорректные данные" });
//    }
//}

//async Task UpdatePerson(HttpResponse response, HttpRequest request)
//{
//    try
//    {
//        Person? userData = await request.ReadFromJsonAsync<Person>();  // получаем данные пользователя
//        if (userData != null)
//        {
//            var user = users.FirstOrDefault(u => u.Id == userData.Id);
//            if (user != null)
//            {
//                user.Age = userData.Age;
//                user.Name = userData.Name;
//                await response.WriteAsJsonAsync(user);
//            }
//            else
//            {
//                response.StatusCode = 404;
//                await response.WriteAsJsonAsync(new { message = "Пользователь не найден" });
//            }
//        }
//        else
//        {
//            throw new Exception("Некорректные данные");
//        }
//    }
//    catch (Exception)
//    {
//        response.StatusCode = 400;
//        await response.WriteAsJsonAsync(new { message = "Некорректные данные" });
//    }
//}

//async Task SendFile(HttpContext context)
//{
//    context.Response.ContentType = "text/html; charset=utf-8";

//    if (context.Request.Path == "/upload" && context.Request.Method == "POST")
//    {
//        IFormFileCollection files = context.Request.Form.Files;  //путь к папке, где будут храниться файлы
//        var uploadPath = $"{Directory.GetCurrentDirectory()}/uploads";  // создаем папку для хранения файлов
//        Directory.CreateDirectory(uploadPath);

//        foreach (var file in files)
//        {
//            string fullPath = $"{uploadPath}/{file.FileName}";  // путь к папке uploads
//            using (var fileStream = new FileStream(fullPath, FileMode.Create))
//            {
//                await file.CopyToAsync(fileStream);
//            }
//        }
//        await context.Response.WriteAsync("Файлы успешно загружены");
//    }
//    else
//    {
//        await context.Response.SendFileAsync("html/index2.html");
//    }
//}

//void Index(IApplicationBuilder appBuilder)
//{
//    appBuilder.Run(async context => await context.Response.WriteAsync("Index Page"));
//}

//void About(IApplicationBuilder appBuilder)
//{
//    appBuilder.Run(async context => await context.Response.WriteAsync("About Page"));
//}