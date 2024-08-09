using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace FlexTweak.Functions
{
    public class Function1
    {
        private readonly ILogger<Function1> _logger;
        private readonly IEmailSender _emailSender;

        public Function1(ILogger<Function1> logger, IEmailSender emailSender)
        {
            _logger = logger;
            _emailSender = emailSender; 
        }

        [Function("email")]
        public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] 
        HttpRequest req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            var data = JsonConvert.DeserializeObject(await new StreamReader(req.Body).ReadToEndAsync()).ToString();

            var message = new Message(new string[] { "ryabushenko.serhiy@gmail.com" }, 
                "NEW REQUEST",
                data, 
                null);

            await _emailSender.SendEmailAsync(message);

            return new OkObjectResult("Welcome to Azure Functions!");
        }
    }
}
