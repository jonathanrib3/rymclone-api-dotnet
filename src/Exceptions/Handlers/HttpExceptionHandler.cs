namespace RymCloneApi.src.Exceptions.Handlers
{
  interface IHttpExceptionHandler
  {
    string Handle(HttpContext context);
  }

  public class HttpExceptionHandler
  {
    private static readonly Dictionary<HttpException, Action<HttpException>> exceptionMapper;

    public static async Task<string> HandleAsync(HttpContext context)
    {
      exceptionMapper[context.Features<>]
      /*/ TODO:
       * Antes de continuar com isso aqui vou precisar voltar alguns passos pra implementar esse handler, segundo essas docs aqui https://learn.microsoft.com/en-us/aspnet/core/fundamentals/error-handling?view=aspnetcore-10.0#exception-handler-lambda
       * 1 - vou precisar criar handlers que implementem a interface IExceptionHandler de acordo com a documentação dessa interface
       * 2 - vou precisar registrar esses handlers no container DI lá no Program.cs
       * 3 - vou precisar dar um jeito de injetar o atributo erro no handler de forma com que eu capture, nessa interface de handler, qual o erro atrelado a esse handler pra então aí sim partir pro passo 4.
       * 4 - Daí sim nessa função aqui vou fazer um tratamento pra isso, pode ser com switch case ou dictionaries
       * Aqui a ideia é centralizar o tratamento de exceção de acordo com a interface do middleware UseExceptionHandler. A ideia até agora é basicament receber o context http, pegar a exceção que está contida dentro desse context, e usar o mapper pra mapear: exceção lançada -> tratador dessa exceção
       * De modo que
       * 1 - esse tratador vai precisar ser void porque ele vai invocar o método WriteAsync que vai escrever a resposta
       * 2 - ele vai ter que receber o contexto http também, porque ele vai escrever a resposta http nele 
       * 3 - ele vai ter que definir a mensagem de erro de acordo com a exceção levantada
       * 
       **/
    }
  }
}
