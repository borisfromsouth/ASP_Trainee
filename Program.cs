using FirstApi2.Classes;
using System.Text;
using System.Text.RegularExpressions;

List<Person> users = new List<Person>
{
    new() { Id = Guid.NewGuid().ToString(), Name = "Tom", Age = 37},// Guid.NewGuid().ToString() ��������� ����������� ��������������, �������� "2e752824-1657-4c7f-844b-6ec2e168e99c".
    new() { Id = Guid.NewGuid().ToString(), Name = "Bob", Age = 41},
    new() { Id = Guid.NewGuid().ToString(), Name = "Sam", Age = 24}
};

var builder = WebApplication.CreateBuilder();
//builder.Services.AddTransient<ITimeService, LongTimeService>();  // �� ����� �������� ���������� ITimeService ����� ������������ ���������� ������ LongTimeService
//var services = builder.Services;  // ��������� �������� (�� ��������� ��� �������� 81 ������)

//builder.Services.AddTransient<TimeService>();

//builder.Services.AddTimeService();

//builder.Services.AddTransient<ITimeService, ShortTimeService>();
//builder.Services.AddTransient<TimeMessage>();  // ������� ������ ��������� �� ��� �����������

//builder.Services.AddTransient<ICounter, RandomCounter>();  // AddTransient ������� transient-������� ������� ��������� ��� ������ ��������� � ���
//builder.Services.AddTransient<CounterService>();

//builder.Services.AddScoped<ICounter, RandomCounter>();  // AddScoped ������� ���� ��������� ������� ��� ����� �������
//builder.Services.AddScoped<CounterService>();

//builder.Services.AddSingleton<ICounter, RandomCounter>(); // AddSingleton ������� ���� ������ ��� ���� ����������� ��������, �� ��������� ������ �����, ����� �� ��������������� ���������
//builder.Services.AddSingleton<CounterService>();

builder.Services.AddTransient<TimeService>(); // ��������� ������

var app = builder.Build();

//app.UseMiddleware<TimeMessageMiddleware>();

//app.UseMiddleware<CounterMiddleware>();

app.UseMiddleware<TimerMiddleware>();

app.Run(async context =>
{
    //var timeService = app.Services.GetService<TimeService>();  // �������� ���������
    //await context.Response.WriteAsync($"Time: {timeService?.GetTime()}");  // ��������� ���� �� �������� ������� �����

    //var timeService = app.Services.GetService<TimeService>();
    //context.Response.ContentType = "text/html; charset=utf-8";
    //await context.Response.WriteAsync($"������� �����: {timeService?.GetTime()}");

    //// ��� ��������� �������� ����� ������������ ��������
    //var timeService2 = context.RequestServices.GetService<ITimeService>();  // ��� .GetService<ITimeService>(); �� ����� ���� ������ �� ����� ������ ����� �������� ����������
    //await context.Response.WriteAsync($"Time: {timeService?.GetTime()}");

    //var timeMessage = context.RequestServices.GetService<TimeMessage>();
    //context.Response.ContentType = "text/html;charset=utf-8";
    //await context.Response.WriteAsync($"<h2>{timeMessage?.GetTime()}</h2>");
});

//app.Map("/home", appBuilder =>  // �������� �����
//{
//    appBuilder.Map("/index", Index); // middleware ��� "/home/index"
//    appBuilder.Map("/about", About); // middleware ��� "/home/about"

//    appBuilder.Run(async (context) => await context.Response.WriteAsync("Home Page"));  // middleware ��� "/home"
//});

//app.Run(async (context) => await context.Response.WriteAsync("Page Not Found"));  //  middleware ��� ����� ����������

//app.Run(WorkApi);

//app.Run(SendFile);

//app.UseMiddleware<TokenMiddleware>();

//app.UseToken("555");

//app.UseMiddleware<ErrorHandlingMiddleware>();  // �������� �������������� ������ ������� �� ������ �������� �� ������ ����� �������� � ���������� middleware
//app.UseMiddleware<AuthenticationMiddleware>();  // ���������� ����� �����������, ���� ���� - ���� ������
//app.UseMiddleware<RoutingMiddleware>();

//app.Environment.EnvironmentName = "Production";  // ����� ������ ��� ��������� �� ����� (����� ��� ����� ������ �������� � ����� launchSettings.json)
//if (app.Environment.IsEnvironment("Test")) { }  // ��� ��������� �� ��� ����


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
//    sb.Append("<h1>��� �������</h1>");
//    sb.Append("<table>");
//    sb.Append("<tr><th>���</th><th>Lifetime</th><th>����������</th></tr>");
//    foreach (var svc in services)
//    {
//        sb.Append("<tr>");
//        sb.Append($"<td>{svc.ServiceType.FullName}</td>");
//        sb.Append($"<td>{svc.Lifetime}</td>");
//        sb.Append($"<td>{svc.ImplementationType?.FullName}</td>");
//        sb.Append("</t�>");
//    }
//    sb.Append("</table>");
//    context.Response.ContentType = "text/html; charset=utf-8";
//    await context.Response.WriteAsync(sb.ToString());
//});

app.Run();

async Task WorkApi(HttpContext context)
{
    //string expressionForNumber = "^/api/users/([0 - 9]+)$";   // ���� id ������������ �����

    // 2e752824-1657-4c7f-844b-6ec2e168e99c
    string expressionForGuid = @"^/api/users/\w{8}-\w{4}-\w{4}-\w{4}-\w{12}$";  // \w{4} - 4 ��������
    if (context.Request.Path == "/api/users" && context.Request.Method == "GET")
    {
        await GetAllPeople(context.Response);
    }
    else if (Regex.IsMatch(context.Request.Path, expressionForGuid) && context.Request.Method == "GET")
    {
        string? id = context.Request.Path.Value?.Split("/")[3];  // �������� id �� ������ url
        await GetPerson(id, context.Response);
    }
    else if (context.Request.Path == "/api/users" && context.Request.Method == "POST")
    {
        await CreatePerson(context.Response, context.Request);
    }
    else if (context.Request.Path == "/api/users" && context.Request.Method == "PUT")
    {
        await UpdatePerson(context.Response, context.Request);
    }
    else if (Regex.IsMatch(context.Request.Path, expressionForGuid) && context.Request.Method == "DELETE")
    {
        string? id = context.Request.Path.Value?.Split("/")[3];
        await DeletePerson(id, context.Response);
    }
    else
    {
        context.Response.ContentType = "text/html; charset=utf-8";
        await context.Response.SendFileAsync("html/index.html");
    }
}


async Task GetAllPeople(HttpResponse response)  // ��������� ���� �������������
{
    await response.WriteAsJsonAsync(users);
}

async Task GetPerson(string? id, HttpResponse response)  // ��������� ������ ������������ �� id
{
    Person? user = users.FirstOrDefault((u) => u.Id == id);
    if (user != null)
        await response.WriteAsJsonAsync(user);
    else
    {
        response.StatusCode = 404;
        await response.WriteAsJsonAsync(new { message = "������������ �� ������" });
    }
}

async Task DeletePerson(string? id, HttpResponse response)
{
    Person? user = users.FirstOrDefault((u) => u.Id == id);
    if (user != null)
    {
        users.Remove(user);
        await response.WriteAsJsonAsync(user);
    }
    else
    {
        response.StatusCode = 404;
        await response.WriteAsJsonAsync(new { message = "������������ �� ������" });
    }
}

async Task CreatePerson(HttpResponse response, HttpRequest request)
{
    try
    {
        var user = await request.ReadFromJsonAsync<Person>();  // �������� ������ ������������
        if (user != null)
        {
            user.Id = Guid.NewGuid().ToString();  // ������������� id ��� ������ ������������
            users.Add(user);                      // ��������� ������������ � ������
            await response.WriteAsJsonAsync(user);
        }
        else
        {
            throw new Exception("������������ ������");
        }
    }
    catch (Exception)
    {
        response.StatusCode = 400;
        await response.WriteAsJsonAsync(new { message = "������������ ������" });
    }
}

async Task UpdatePerson(HttpResponse response, HttpRequest request)
{
    try
    {
        Person? userData = await request.ReadFromJsonAsync<Person>();  // �������� ������ ������������
        if (userData != null)
        {
            var user = users.FirstOrDefault(u => u.Id == userData.Id);
            if (user != null)
            {
                user.Age = userData.Age;
                user.Name = userData.Name;
                await response.WriteAsJsonAsync(user);
            }
            else
            {
                response.StatusCode = 404;
                await response.WriteAsJsonAsync(new { message = "������������ �� ������" });
            }
        }
        else
        {
            throw new Exception("������������ ������");
        }
    }
    catch (Exception)
    {
        response.StatusCode = 400;
        await response.WriteAsJsonAsync(new { message = "������������ ������" });
    }
}

async Task SendFile(HttpContext context)
{
    context.Response.ContentType = "text/html; charset=utf-8";

    if (context.Request.Path == "/upload" && context.Request.Method == "POST")
    {
        IFormFileCollection files = context.Request.Form.Files;  //���� � �����, ��� ����� ��������� �����
        var uploadPath = $"{Directory.GetCurrentDirectory()}/uploads";  // ������� ����� ��� �������� ������
        Directory.CreateDirectory(uploadPath);

        foreach (var file in files)
        {
            string fullPath = $"{uploadPath}/{file.FileName}";  // ���� � ����� uploads
            using (var fileStream = new FileStream(fullPath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }
        }
        await context.Response.WriteAsync("����� ������� ���������");
    }
    else
    {
        await context.Response.SendFileAsync("html/index2.html");
    }
}

void Index(IApplicationBuilder appBuilder)
{
    appBuilder.Run(async context => await context.Response.WriteAsync("Index Page"));
}

void About(IApplicationBuilder appBuilder)
{
    appBuilder.Run(async context => await context.Response.WriteAsync("About Page"));
}