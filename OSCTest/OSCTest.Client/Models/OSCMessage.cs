namespace OSCTest.Client.Models
{
    public class OSCMessage
    {
        public string Server { get; set; }
        public int ServerPort { get; set; }


        public string Address { get; set; }



        public string ValueType { get; set; } = "";
        public object? Value { get; set; }



    }
}
