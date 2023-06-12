using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiBrokerRabbit.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrokerController : ControllerBase
    {
        
        public void SendEmail(string message) 
        {
            Send.Send sendEmail = new Send.Send();
            sendEmail.Publish("Hello");
        }
        public void ReceiveEmail() { }
    }
}
