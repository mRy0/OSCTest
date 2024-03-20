namespace OSCTest.Client.Models
{
    public class OSCControlElement
    {
        public int Size { get; set; } = 3;

        public string Text { get; set; }

        public string? Color { get; set; }

        public string Type { get; set; } //button, fader, number

        public string OSCAddress { get; set; }

        public float? DefaultValue { get; set; }

        public string? Server { get; set; }
        public int? ServerPort { get; set; }



    }
}
