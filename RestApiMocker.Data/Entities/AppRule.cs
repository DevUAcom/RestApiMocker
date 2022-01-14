namespace RestApiMocker.Data.Entities
{
    public class AppRule
    {
        public int Id { get; set; }
        public string Method { get; set; }
        public string Path { get; set; }
        public int ResponseStatus { get; set; }
        public IList<ResponseHeader> ResponseHeaders { get; set; }
        public string ResponseBody { get; set; }
    }
}
