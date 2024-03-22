
namespace OSCTest.Client.Models
{
    public class OSCMessageValueString : OSCMessageValue
    {


        public string Value { get; set; }

        //public override string ValueType => "string";

        public OSCMessageValueString(string value)
        {
            Value = value;
        }
    }
}
