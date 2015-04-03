using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Mvc;
using Raspberry.IO.GeneralPurpose;
using System.Threading;

namespace rpi_aspnet_leds.Controllers
{
    [Route("api/[controller]")]
    public class LedsController : Controller
    {
        private static Dictionary<ushort, OutputPinConfiguration> pins;
        private GpioConnection connection;

        public LedsController()
        {
            pins = new Dictionary<ushort, OutputPinConfiguration> {
                { 23, ProcessorPin.Pin23.Output() },
                { 24, ProcessorPin.Pin24.Output() }
            };

            connection = new GpioConnection(pins[23], pins[24]);
        }

        // POST api/leds/23
        [HttpPost("{id}")]
        public void Put(ushort id)
        {
            connection.Blink(pins[id], 500);
            Thread.Sleep(500);
            connection.Blink(pins[id], 500);
        }
    }
}
