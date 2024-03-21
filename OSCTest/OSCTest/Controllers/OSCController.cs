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
            using var udpClient = new System.Net.Sockets.UdpClient(oSCMessage.Server, oSCMessage.ServerPort);

            CoreOSC.OscMessage msg;

            if (oSCMessage.Value.HasValue)
                msg = new CoreOSC.OscMessage(new CoreOSC.Address(oSCMessage.Address), new object[] { oSCMessage.Value.Value });
            else
                msg = new CoreOSC.OscMessage(new CoreOSC.Address(oSCMessage.Address));


            await udpClient.SendMessageAsync(msg);

            return Ok();

        }



    }
}
