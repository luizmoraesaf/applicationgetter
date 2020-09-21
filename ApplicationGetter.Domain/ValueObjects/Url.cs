namespace ApplicationGetter.Domain.ValueObjects
{
    public sealed class Url
    {
        private string _text;

        public Url(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                throw new UrlShouldNotBeEmptyException("The 'Url' field is required");

            this._text = text;
        }

        public override string ToString()
        {
            return _text.ToString();
        }

        public static implicit operator Url(string text)
        {
            return new Url(text);
        }

        public static implicit operator string(Url name)
        {
            return name._text;
        }
    }
}
