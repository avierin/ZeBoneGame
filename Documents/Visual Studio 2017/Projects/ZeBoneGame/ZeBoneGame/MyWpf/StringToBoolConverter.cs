namespace ZeBoneGame.MyWpf
{
    public class StringToBoolConverter : ToBoolConverter<string>
    {
        protected StringToBoolConverter(string trueValue, string falseValue)
            : base(trueValue, falseValue, (a, b) => a.ToLower() == b.ToLower())
        {

        }
    }


}
