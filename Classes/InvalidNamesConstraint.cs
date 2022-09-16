namespace FirstApi2.Classes
{
    public class InvalidNamesConstraint : IRouteConstraint
    {
        string[] names = new[] { "Tom", "Sam", "Bob" };

        public bool Match(HttpContext? httpContext, IRouter? route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
        {
            return !names.Contains(values[routeKey]?.ToString());  // если список не содержит
        }
    }
}
