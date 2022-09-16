﻿namespace FirstApi2.Classes
{
    public interface IGenerator
    {
        int GenerateValue();
    }

    public interface IReader
    {
        int ReadValue();
    }

    public class GeneratorMiddleware
    {
        RequestDelegate next;
        IGenerator generator;

        public GeneratorMiddleware(RequestDelegate next, IGenerator generator)
        {
            this.next = next;
            this.generator = generator;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            if (context.Request.Path == "/generate")
                await context.Response.WriteAsync($"New Value: {generator.GenerateValue()}");
            else
                await next.Invoke(context);
        }
    }

    class ReaderMiddleware
    {
        IReader reader;

        public ReaderMiddleware(RequestDelegate _, IReader reader) => this.reader = reader;

        public async Task InvokeAsync(HttpContext context)
        {
            await context.Response.WriteAsync($"Current Value: {reader.ReadValue()}");
        }
    }

    class ValueStorage : IGenerator, IReader
    {
        int value;
        public int GenerateValue()
        {
            value = new Random().Next();
            return value;
        }

        public int ReadValue() => value;
    }
}
