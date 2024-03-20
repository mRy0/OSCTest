namespace OSCTest.Client.Models
{
    public class OSCControl
    {
        public string Name { get; set; }
        public string Server { get; set; }
        public int ServerPort { get; set; }

        public string? Color { get; set; }

        public OSCControlElement[][] Elements { get; set; }


    }
}
