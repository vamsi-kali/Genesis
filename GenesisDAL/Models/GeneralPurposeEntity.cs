using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson.Serialization.Attributes;
namespace GenesisDAL.Models
{
        [BsonIgnoreExtraElements]
        public class GeneralPurposeEntity
        {
            [BsonElement]
            public string Brand { get; set; }
            [BsonElement]
            public string Product { get; set; }
            [BsonElement]
            public string Channel { get; set; }
            [BsonElement]
            public string Engine { get; set; }
        }
    

}
