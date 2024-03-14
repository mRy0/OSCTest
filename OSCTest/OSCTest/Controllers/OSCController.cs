using Microsoft.AspNetCore.Mvc;
using CoreOSC;
using CoreOSC.IO;

namespace OSCTest.Controllers
{
    [Route("/api/osc")]
    public class OSCController : Controller
    {
        [HttpPost]
        public async Task<IActionResult> SendOSCMessage([FromBody] Client.Models.OSCMessage oSCMessage)
        {

            using var udpClient = new System.Net.Sockets.UdpClient("192.168.178.62", 21600);

            CoreOSC.OscMessage msg;

            if (oSCMessage.Value is not null)
                msg = new CoreOSC.OscMessage(new CoreOSC.Address(oSCMessage.Address), new object[] { (float)oSCMessage.Value});
            else
                msg = new CoreOSC.OscMessage(new CoreOSC.Address(oSCMessage.Address));

            await udpClient.SendMessageAsync(msg);

            return Ok();

        }



    }
}
