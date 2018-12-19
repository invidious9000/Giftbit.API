namespace Giftbit.API.Model
{
    public class ResponseInfo
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Message { get; set; }

        public override string ToString()
        {
            return $"{nameof(Code)}: {Code}, {nameof(Message)}: {Message}, {nameof(Name)}: {Name}";
        }
    }
}