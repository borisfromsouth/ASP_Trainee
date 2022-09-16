namespace FirstApi2.Classes
{
    public class SecretCodeConstraint : IRouteConstraint
    {
        string secretCode;    // допустимый код

        public SecretCodeConstraint(string secretCode)
        {
            this.secretCode = secretCode;
        }

        public bool Match(HttpContext? httpContext, IRouter? route, string routeKey /*название параметра маршрута, параметр берется из условия в маршруте*/,
            RouteValueDictionary values /*набор параметров маршрута*/, RouteDirection routeDirection)
        {
            return values[routeKey]?.ToString() == secretCode; // ок если значение из набор параметров маршрута
        }
    }
}
