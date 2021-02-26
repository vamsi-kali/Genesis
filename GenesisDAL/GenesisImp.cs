using MongoDB.Driver;
using System.Collections.Generic;
using System;
using GenesisDAL.Models;

namespace GenesisDAL
{
    public class GenesisImp:IGenesis
    {
        public IMongoDatabase GetConn()
        {
            return new MongoClient("mongodb://localhost:27017").GetDatabase("Genesis");
        }

        public void Purify(GeneralPurposeEntity ob)
        {
            if (ob.Brand == null)
                ob.Brand = "";
            if (ob.Product== null)
                ob.Product = "";
            if (ob.Channel == null)
                ob.Channel = "";
            if (ob.Engine == null)
                ob.Engine = "";
        }
        public IEnumerable<GeneralPurposeEntity> GeneralPurpose_FetchSpecificData(GeneralPurposeEntity attributes)
        {
            Purify(attributes);
            var res = GetConn().GetCollection<GeneralPurposeEntity>("GeneralPurpose").Find(x => (string.IsNullOrEmpty(attributes.Brand) || x.Brand.ToLower().Contains(attributes.Brand.ToLower())) && (string.IsNullOrEmpty(attributes.Product) || x.Product.ToLower().Contains(attributes.Product.ToLower())) && (string.IsNullOrEmpty(attributes.Channel) || x.Channel.ToLower().Contains(attributes.Channel.ToLower())) && (string.IsNullOrEmpty(attributes.Engine) || x.Engine.ToLower().Contains(attributes.Engine.ToLower()))).ToList();
 
            return res;
        }

        public bool GeneralPurpose_UpdateRecords(GeneralPurposeEntity p, string DB) //individual save
        {
            var conn = GetConn();
            var res = conn.GetCollection<GeneralPurposeEntity>(DB).UpdateOne(x => x.Brand == p.Brand && x.Product == p.Product && x.Channel == p.Channel, Builders<GeneralPurposeEntity>.Update.Set("Engine", p.Engine));
            if (res.ModifiedCount <= 0)
                return false;
            return true;
        }

        public void Purify(PrivateLabelEntity pl)
        {
            if (pl.AdjudicationEngine == null)
                pl.AdjudicationEngine = "";
            if (pl.BrandingCodeId == null)
                pl.BrandingCodeId = "";
            if (pl.BrandingCode == null)
                pl.BrandingCode = "";
            if (pl.Classification == null)
                pl.Classification = "";
            if (pl.EquifexProgramType == null)
                pl.EquifexProgramType = "";
            if (pl.Orchestration == null)
                pl.Orchestration = "";
            if (pl.Organisation == null)
                pl.Organisation = "";
            if (pl.Program == null)
                pl.Program = "";
            if (pl.UWEngine == null)
                pl.UWEngine = "";
        }

        public IEnumerable<PrivateLabelEntity> PrivateLabel_FetchSpecificData(PrivateLabelEntity attributes)
        {
            Purify(attributes);

            return GetConn().GetCollection<PrivateLabelEntity>("Privatelabel").Find(x => (string.IsNullOrEmpty(attributes.BrandingCodeId) || x.BrandingCodeId.Contains(attributes.BrandingCodeId)) && (string.IsNullOrEmpty(attributes.BrandingCode) || x.BrandingCode.ToLower().Contains(attributes.BrandingCode.ToLower())) && ( string.IsNullOrEmpty(attributes.Classification) || x.Classification.ToLower().Contains(attributes.Classification.ToLower())) && ( string.IsNullOrEmpty(attributes.EquifexProgramType) || x.EquifexProgramType.ToLower().Contains(attributes.EquifexProgramType)) && (string.IsNullOrEmpty(attributes.AdjudicationEngine) || x.AdjudicationEngine.ToLower().Contains(attributes.AdjudicationEngine.ToLower())) && (string.IsNullOrEmpty(attributes.Orchestration) || x.Orchestration.ToLower().Contains(attributes.Orchestration.ToLower())) && (string.IsNullOrEmpty(attributes.Organisation) || x.Organisation.ToLower().Contains(attributes.Organisation.ToLower())) && (string.IsNullOrEmpty(attributes.Program) || x.Program.ToLower().Contains(attributes.Program.ToLower())) && (string.IsNullOrEmpty(attributes.UWEngine) || x.UWEngine.ToLower().Contains(attributes.UWEngine.ToLower()))).ToList();
            
        }
        public bool PrivateLabel_UpdateRecords(PrivateLabelEntity v, string DB)
        {
            var conn = GetConn();
            Purify(v);
            /*foreach (var v in p)
            {
                var res = conn.GetCollection<PrivateLabelEntity>("Privatelabel").UpdateOne(x => x.BrandingCodeId == v.BrandingCodeId && x.BrandingCode == v.BrandingCode && x.Classification == v.Classification && x.Orchestration == v.Orchestration && x.Program == v.Program && x.Organisation == v.Organisation && x.EquifexProgramType == v.EquifexProgramType && x.AdjudicationEngine == v.AdjudicationEngine, Builders<PrivateLabelEntity>.Update.Set("UWEngine", v.UWEngine));
                if (res.ModifiedCount <= 0)
                    return false;
            }*/
            var res = conn.GetCollection<PrivateLabelEntity>(DB).UpdateOne(x => x.BrandingCodeId == v.BrandingCodeId, Builders<PrivateLabelEntity>.Update.Set("UWEngine", v.UWEngine));
            if (res.ModifiedCount <= 0)
                return false;
            return true;
        }

        public bool Sync_GeneralPurpose()
        {
            var conn = GetConn();

            var res_gen_dum = conn.GetCollection<GeneralPurposeEntity>("GeneralPurpose").Find(FilterDefinition<GeneralPurposeEntity>.Empty).ToList();
            bool sync_status = false;
            foreach(var m in res_gen_dum)
            {
                var res_gen = conn.GetCollection<GeneralPurposeEntity>("GeneralPurposeDum").Find(x => x.Brand == m.Brand && x.Channel == m.Channel && x.Product == m.Product).SingleOrDefault();
                if(res_gen.Engine!=m.Engine)
                    sync_status = GeneralPurpose_UpdateRecords(new GeneralPurposeEntity { Brand = m.Brand, Channel=m.Channel, Product=m.Product, Engine=m.Engine}, "GeneralPurposeDum");
            }
            return sync_status;
        }

        public bool Sync_PrivateLabel()
        {
            var conn = GetConn();
            var res_pri_dum = conn.GetCollection<PrivateLabelEntity>("Privatelabel").Find(FilterDefinition<PrivateLabelEntity>.Empty).ToList();
            bool sync_status = false;
            foreach(var m in res_pri_dum)
            {
                var res_priv = conn.GetCollection<PrivateLabelEntity>("PrivatelabelDum").Find(x => x.BrandingCodeId == m.BrandingCodeId).SingleOrDefault();
                if (res_priv.UWEngine != m.UWEngine)
                    sync_status = PrivateLabel_UpdateRecords(new PrivateLabelEntity { UWEngine = m.UWEngine, BrandingCodeId = m.BrandingCodeId  }, "PrivatelabelDum");
            }
            return sync_status;
        }

    }
}
