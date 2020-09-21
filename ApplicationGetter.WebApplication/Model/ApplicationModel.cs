namespace ApplicationGetter.WebApplication.Model
{
    public sealed class ApplicationModel
    {
        public int Id{ get; set; }
        public string Url { get; set; }
        public string PathLocal { get; set; }
        public bool DebuggingMode { get; set; }

        public ApplicationModel() { }

        public ApplicationModel(Domain.Application.Application application)
        {
            this.Id = application.Id;
            this.Url = application.Url;
            this.PathLocal = application.PathLocal;
            this.DebuggingMode = application.DebuggingMode;
        }
    }
}
