using FirstApi2.Classes;
using Microsoft.Extensions.FileProviders;
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

//builder.Services.AddRouting(options => options.ConstraintMap.Add("secretcode" /*ключ ограничения*/, typeof(SecretCodeConstraint)/*класс ограничения*/)); // сервис по проверка маршрута; ConstraintMap - коллекция ограничений 

//builder.Services.AddRouting(options => options.ConstraintMap.Add("invalidnames" , typeof(InvalidNamesConstraint)));

//builder.Services.AddTransient<TimeService2>();

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

//app.Map(
//    "/users/{name}/{token:int:secretcode(123466)}",  // передача значения 123466 по ключу secretcode в конструктор класса SecretCodeConstraint
//    (string name, int token) => $"User Name:{name} \nToken:{token}"
//);
//app.Map(
//    "/users/{name:invalidnames}",  // передача значения 123466 по ключу secretcode в конструктор класса SecretCodeConstraint
//    (string name) => $"User Name:{name}"
//);

//app.Map("/time",(TimeService2 timeService) => $"Time: {timeService.Time}");
//app.Map("/", () => "Hello");

//app.Map("/hello", () => "Hello METANIT.COM");                       // если ввести /hello то подойдут оба шаблона, но первый статичный, а второй общий динамический, поэтому приоритет за первым, он и отработает 
//app.Map("/{message}", (string message) => $"Message: {message}");

//app.Map("/{message?}", (string? message) => $"Message: {message}"); // такая же ситуация как и с прошлым, на пустой шаблон отработает второй так как он статичесий 
//app.Map("/", () => "Index Page");

//app.Map("/{controller}/Index/5", (string controller) => $"Controller: {controller}"); // преимущество будет у шаблона с первым статичесим сегментом то есть второй случай
//app.Map("/Home/{action}/{id}", (string action) => $"Action: {action}");

/////////////////////////////////////////////////////////

//app.Use(async (context, next) =>
//{
//    Console.WriteLine("First middleware starts");
//    await next.Invoke();
//    Console.WriteLine("First middleware ends");
//});
//app.Map("/", () =>
//{
//    Console.WriteLine("Index endpoint starts and ends");
//    return "Index Page";
//});
//app.Use(async (context, next) =>
//{
//    Console.WriteLine("Second middleware starts");
//    await next.Invoke();
//    Console.WriteLine("Second middleware ends");
//});
//app.Map("/about", () =>
//{
//    Console.WriteLine("About endpoint starts and ends");
//    return "About Page";
//});

// Итог выполнения будет:   "Index endpoint starts and ends"
// В консоль выведется:     "First middleware starts"        
//                          "Second middleware starts"
//                          "Index endpoint starts and ends"     конечная точка выполняется тольок когда начнется выполнение всех middleware
//                          "Second middleware ends"
//                          "First middleware ends"

/////////////////////////////////////////////////////////

//app.Use(async (context, next) =>   // в компонентах middleware также можно обрабатывать запросы по определенным адресам
//{
//    if (context.Request.Path == "/date")
//        await context.Response.WriteAsync($"Date: {DateTime.Now.ToShortDateString()}");
//    else
//        await next.Invoke();
//});

//app.Use(async (context, next) =>
//{
//    await next.Invoke();

//    if (context.Response.StatusCode == 404)                 // кейс для  постдействия - выполнения некоторых действий,когда ни одна из конечных точек не обработала запрос, и в middleware мы можем обработать эту ситуацию
//        await context.Response.WriteAsync("Resource Not Found");
//});

/////////////////////////////////////////////////////////

//app.Map("/", () => "Index Page");
//app.Map("/about", () => "About Page");

//app.Run(async context =>  // если в конце конвейера располагается терминальный компонент, то он будет выполняться даже если конечная точка соответствует запрошенному пути
//{
//    context.Response.StatusCode = 404;
//    await context.Response.WriteAsync("Resource not found");
//});

/////////////////////////////////////////////////////////

app.UseStaticFiles();   // добавляем поддержку статических файлов  // теперь если мы обратимся по адресу /index.html то авктивируется этот файл (лежит в папке wwwroot)
                        // если бы файл еще лежал в папке html то мы бы обращались к нему по адресу /html/index.html
                        // если хотим поменять корневую папку: var builder = WebApplication.CreateBuilder(new WebApplicationOptions { WebRootPath = "static" });  // изменяем папку для хранения статики через свойство WebRootPath на папку с именем static
app.Run(async (context) => await context.Response.WriteAsync("Hello World"));

/////////////////////////////////////////////////////////

app.UseDefaultFiles();  // поддержка страниц html по умолчанию    // при отправке запроса к корню типа http://localhost:xxxx/ приложение будет искать в  wwwroot  файлы : default.htm, default.html, index.htm, index.html

// если же мы хотим использовать файл, название которого отличается от вышеперечисленных
DefaultFilesOptions options = new DefaultFilesOptions();
options.DefaultFileNames.Clear(); // удаляем имена файлов по умолчанию
options.DefaultFileNames.Add("hello.html"); // добавляем новое имя файла   // в качестве страницы по умолчанию будет использоваться файл hello.html, который должен располагаться в папке wwwroot
app.UseDefaultFiles(options); // установка параметров

app.UseStaticFiles();

app.Run(async (context) => await context.Response.WriteAsync("Hello World"));

/////////////////////////////////////////////////////////

app.UseDirectoryBrowser(); // позволяет пользователям просматривать содержимое каталогов на сайте

//  +

app.UseDirectoryBrowser(new DirectoryBrowserOptions()  // вариант с перегрузкой (ввел путь => получил определенный файл на жестком диске (задается в теле метода))
{
    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\html")),  // путь к файлу который надо получить 

    RequestPath = new PathString("/pages")  // необходимый вводимый путь для получения файла  //путь типа http://localhost:xxxx/pages/ будет сопоставляться с каталогом "wwwroot\html"
});

/////////////////////////////////////////////////////////

app.UseStaticFiles();  // обрабатывает запросы к файлам в папке wwwroot

app.UseStaticFiles(new StaticFileOptions()  // а этот уже обрабатывает запросы по пути http://localhost:xxxx/pages к каталогу wwwroot/html
{
    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\html")),  // путь к файлу который надо получить 

    RequestPath = new PathString("/pages")  // необходимый вводимый путь для получения файла
});

/////////////////////////////////////////////////////////

app.UseFileServer(); // объединяет функциональность UseStaticFiles, UseDefaultFiles и UseDirectoryBrowser;  позволяет обрабатывать статические файлы и отправлять файлы по умолчанию типа index.html

app.UseFileServer(enableDirectoryBrowsing: true); // подключение через свойства просмотра каталогов

app.UseFileServer(new FileServerOptions  // более точное опеределение параметров
{
    EnableDirectoryBrowsing = true,
    EnableDefaultFiles = false
});

app.UseFileServer(new FileServerOptions  // настройка сопоставления путей запроса с каталогами  //разрешен обзор каталога по пути http://localhost:xxxx/pages/, но при этом путь http://localhost:xxxx/html/ работать не будет
{
    EnableDirectoryBrowsing = true,
    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\html")), // тут
    RequestPath = new PathString("/pages"),                                                                  // и тут
    EnableDefaultFiles = false
});

/////////////////////////////////////////////////////////

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