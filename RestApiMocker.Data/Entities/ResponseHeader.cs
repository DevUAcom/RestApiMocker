namespace RestApiMocker.Data.Entities
{
    public class ResponseHeader
    {
        public string Key { get; set; }
        public string Value { get; set; }
        public AppRule AppRule { get; set; }
        public int AppRuleId { get; set; }
    }
}