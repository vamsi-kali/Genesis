using System;
using System.Collections.Generic;
using System.Text;
using GenesisDAL.Models;
namespace GenesisDAL
{
    public interface IGenesis
    {
        //public IEnumerable<Data> GetAllData();
        public IEnumerable<GeneralPurposeEntity> GeneralPurpose_FetchSpecificData(GeneralPurposeEntity attributes);
        public bool GeneralPurpose_UpdateRecords(GeneralPurposeEntity p, string DB);

        public IEnumerable<PrivateLabelEntity> PrivateLabel_FetchSpecificData(PrivateLabelEntity pl);
        public bool PrivateLabel_UpdateRecords(PrivateLabelEntity p, string DB);
        public bool Sync_PrivateLabel();
        public bool Sync_GeneralPurpose();
    }
}
