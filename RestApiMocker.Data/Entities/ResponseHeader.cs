﻿namespace RestApiMocker.Data.Entities
{
    public class ResponseHeader
    {
        public string Id { get; set; }
        public string Value { get; set; }
        public AppRule AppRule { get; set; }
        public int AppRuleId { get; set; }

    }
}