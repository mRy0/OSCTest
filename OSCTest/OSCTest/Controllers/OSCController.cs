using Microsoft.AspNetCore.Mvc;
using CoreOSC;
using CoreOSC.IO;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using OSCTest.Client.Models;
using System.Text.Json;
using Newtonsoft.Json.Linq;
using System.Runtime.InteropServices.JavaScript;

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

            if(oSCMessage.ValueType == typeof(string).Name)
                msg = new CoreOSC.OscMessage(new CoreOSC.Address(oSCMessage.Address), new object[] { Convert.ToString(oSCMessage.Value) });
            else if (oSCMessage.ValueType == typeof(float).Name)
                msg = new CoreOSC.OscMessage(new CoreOSC.Address(oSCMessage.Address), new object[] { Convert.ToSingle(oSCMessage.Value) });
            else if (oSCMessage.ValueType == typeof(double).Name)
                msg = new CoreOSC.OscMessage(new CoreOSC.Address(oSCMessage.Address), new object[] { Convert.ToDouble(oSCMessage.Value) });
            else
                msg = new CoreOSC.OscMessage(new CoreOSC.Address(oSCMessage.Address));


            await udpClient.SendMessageAsync(msg);

            return Ok();

        }

    }


}
