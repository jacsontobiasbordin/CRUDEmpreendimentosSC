using System.Net;
using System.Text.Json;

namespace CRUDEmpreendimentosSC.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (KeyNotFoundException ex)
            {
                await HandleExceptionAsync(context, HttpStatusCode.NotFound, "Recurso não encontrado", ex.Message);
            }
            catch (ArgumentException ex)
            {
                await HandleExceptionAsync(context, HttpStatusCode.BadRequest, "Erro de validação", ex.Message);
            }
            catch (Exception)
            {
                await HandleExceptionAsync(context, HttpStatusCode.InternalServerError, "Erro interno", "Ocorreu um erro inesperado");
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, HttpStatusCode statusCode, string erro, string mensagem)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)statusCode;

            var response = new
            {
                status = (int)statusCode,
                erro,
                mensagem
            };

            var json = JsonSerializer.Serialize(response);

            return context.Response.WriteAsync(json);
        }
    }
}
