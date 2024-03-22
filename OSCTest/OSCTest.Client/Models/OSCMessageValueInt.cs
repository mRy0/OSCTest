namespace OSCTest.Client.Models
{
    public class OSCMessageValueInt : OSCMessageValue
    {
        public int Value { get; set; }

        public OSCMessageValueInt(int value)
        {
            Value = value;
        }
    }
}
