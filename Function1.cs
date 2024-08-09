using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

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

        [Function("Function1")]
        public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] 
        HttpRequest req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            var message = new Message(new string[] { "ryabushenko.serhiy@gmail.com" }, 
                "Test email async", 
                "This is the content from our async email.", null);

            await _emailSender.SendEmailAsync(message);

            return new OkObjectResult("Welcome to Azure Functions!");
        }
    }
}
