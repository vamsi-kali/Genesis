using Microsoft.VisualStudio.TestTools.UnitTesting;
using GenesisDAL;
using GenesisDAL.Models;
using System;
using Moq;

namespace Genesis_UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        IGenesis i = new GenesisImp();
       
        [TestMethod]
        public void Get_GeneralPurpose_Data_TestMethod()
        {
            GeneralPurposeEntity attributes = new GeneralPurposeEntity { Brand = "", Product = "2", Channel = "i" };
            var res = i.GeneralPurpose_FetchSpecificData(attributes);
           
            Assert.IsNotNull(res);
        }

        [TestMethod]
        public void Update_GeneralPurpose_Data_TestMethod()
        {
            GeneralPurposeEntity p = new GeneralPurposeEntity { Brand = "NGO", Product = "NGOTier2", Channel = "ITA", Engine="Interconnect"};

            var res = i.GeneralPurpose_UpdateRecords(p);
            Assert.IsTrue(res);
        }



        // The below part is for PrivateLabel

        [TestMethod]
        public void Get_PrivateLabel_TestMethod()
        {
            /* string[] attributes = {  "","", "", "","","", "","IC","" };*/
            PrivateLabelEntity attributes = new PrivateLabelEntity { AdjudicationEngine = "", BrandingCode = "", BrandingCodeId = "", Classification = "", EquifexProgramType = "", Orchestration = "", Organisation = null, Program = "", UWEngine = null };
            var res = i.PrivateLabel_FetchSpecificData(attributes);
            int c = 0;
            foreach (var m in res)
                c++;
            //Assert.AreEqual(2, c);
            Assert.IsNotNull(res);
        }

        [TestMethod]
        public void Update_PrivateLabel_TestMethod()
        {
            PrivateLabelEntity p =  new PrivateLabelEntity{ BrandingCodeId = "17",                                                           BrandingCode = "Litman-Jewellers",                                               Classification = "GCP",                                                          Organisation = "HealthCare",                                                     Orchestration = "PermissiblePurpose.MABT",                                       Program = "GeneralMedical4tier",                                                 EquifexProgramType = "PermissiblePurpose",                                       AdjudicationEngine = "IC",                                                       UWEngine = "Interconnect"       
            };
            var res = i.PrivateLabel_UpdateRecords(p);
            Assert.IsTrue(res);
        }

    }
}
