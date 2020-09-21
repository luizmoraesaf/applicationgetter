namespace ApplicationGetter.Domain.ValueObjects
{
    public sealed class PathLocal
    {
        private string _text;

        public PathLocal(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                throw new PathLocalShouldNotBeEmptyException("The 'PathLocal' field is required");

            this._text = text;
        }

        public override string ToString()
        {
            return _text.ToString();
        }

        public static implicit operator PathLocal(string text)
        {
            return new PathLocal(text);
        }

        public static implicit operator string(PathLocal name)
        {
            return name._text;
        }
    }
}
