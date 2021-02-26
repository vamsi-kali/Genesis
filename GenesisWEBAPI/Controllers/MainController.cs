using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using GenesisDAL;
using GenesisDAL.Models;

namespace GenesisWEBAPI.Controllers
{
    [Route("api/Main")]
    [ApiController]
    [EnableCors("AllowOrigin")]
    public class MainController : ControllerBase
    {
        IGenesis IG;
        public MainController(IGenesis IG)
        {
            this.IG = IG;
        }

        [HttpGet]
        [Route("/api/Main/GetGeneralPurposePartial")]
        public IEnumerable<GeneralPurposeEntity> FetchGeneralPurposeData([FromQuery]GeneralPurposeEntity gqe )
        {
            return IG.GeneralPurpose_FetchSpecificData(gqe);
        }

        [HttpPut]
        [Route("/api/Main/UpdateGeneralPurposeRecords")]
        public bool UpdateGeneralPurposeRecords(GeneralPurposeEntity gpe)// individual save
        {
            return IG.GeneralPurpose_UpdateRecords(gpe, "GeneralPurpose");
        }


        [HttpGet]
        [Route("/api/Main/GetPrivateLabelPartial")]
        public IEnumerable<PrivateLabelEntity> FetchPrivateLabelData([FromQuery] PrivateLabelEntity pl)
        {
            return IG.PrivateLabel_FetchSpecificData(pl);
        }
        
        [HttpPut]
        [Route("/api/Main/UpdatePrivateLabelRecords")]
        public bool UpdatePrivateLabelRecords(PrivateLabelEntity pl)
        {
            return IG.PrivateLabel_UpdateRecords(pl, "Privatelabel");
        }

        [HttpGet]
        [Route("/api/Main/SyncGeneralPurposeDB")]
        public bool Sync_general()
        {
            return IG.Sync_GeneralPurpose();
        }

        [HttpGet]
        [Route("/api/Main/SyncPrivatePurposeDB")]
        public bool Sync_Private()
        {
            return IG.Sync_PrivateLabel();
        }
    }
}
