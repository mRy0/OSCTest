using Newtonsoft.Json;

namespace OSCTest.Client.Models
{
    public class OSCControlElement
    {
        public int Size { get; set; } = 3;

        public string Text { get; set; }

        public string? Color { get; set; }

        public string Type { get; set; } //button, fader, number, text

        public string OSCAddress { get; set; }

        public float? DefaultValue { get; set; }
        public float Min { get; set; } = 0;
        public float Max { get; set; } = 100;
        public float Steps { get; set; } = 1;


        public string? Server { get; set; }
        public int? ServerPort { get; set; }



    }
}
