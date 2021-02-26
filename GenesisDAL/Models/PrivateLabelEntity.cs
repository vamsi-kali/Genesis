using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson.Serialization.Attributes;
namespace GenesisDAL.Models
{
    [BsonIgnoreExtraElements]
    public class PrivateLabelEntity
    {
            [BsonElement]
            public string BrandingCodeId { get; set; }
            [BsonElement]
            public string BrandingCode { get; set; }
            [BsonElement]
            public string Classification { get; set; }
            [BsonElement]
            public string Organisation { get; set; }
            [BsonElement]
            public string Orchestration { get; set; }
            [BsonElement]
            public string Program { get; set; }
            [BsonElement]
            public string EquifexProgramType { get; set; }
            [BsonElement]
            public string AdjudicationEngine { get; set; }
            [BsonElement]
            public string UWEngine { get; set; }
        
    }
}
