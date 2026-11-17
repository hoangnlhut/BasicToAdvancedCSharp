namespace Middleware.Middeware
{
    public class Middleware1
    {
        private readonly RequestDelegate _next;
        public Middleware1(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            Console.WriteLine("Middleware1: Before next middleware");
            await _next(context);
            Console.WriteLine("Middleware1: After next middleware");
        }
    }

    public class Middleware2
    {
        private readonly RequestDelegate _next;
        public Middleware2(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            Console.WriteLine("Middleware222222: Before next middleware");
            await _next(context);
            Console.WriteLine("Middleware222222: After next middleware");
        }
    }

    public class Middleware3
    {
        private readonly RequestDelegate _next;
        public Middleware3(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            Console.WriteLine("Middleware333333: Before next middleware");
            await _next(context);        
            Console.WriteLine("Middleware333333: After next middleware");
        }
    }

    public class Middleware4
    {
        private readonly RequestDelegate _next;
        public Middleware4(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            Console.WriteLine("Middleware444444: Before next middleware");
            await _next(context);        
            Console.WriteLine("Middleware444444: After next middleware");
        }
    }

    public class Middleware5
    {
        private readonly RequestDelegate _next;
        public Middleware5(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            Console.WriteLine("Middleware55555: Before next middleware");
            await _next(context);        
            Console.WriteLine("Middleware55555: After next middleware");
        }
    }
}
