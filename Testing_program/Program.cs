using System;
using GenesisDAL;
using GenesisDAL.Models;
namespace Testing_program
{
    class Program
    {
        static void Main(string[] args)
        {
            IGenesis i = new GenesisImp();
            /*var res = i.GetAllData();
            foreach (var m in res)
                Console.WriteLine(m.Brand + "," + m.Channel + "," + m.Engine + "," + m.Product);*/

            Console.WriteLine("*********");
            string[] a = new string[3];
            a[0] = "";
            a[1] = "";
            a[2] = "";
            var res2 = i.FetchSpecificData(a);
            foreach(var m in res2)
                Console.WriteLine(m.Brand + "," + m.Channel + "," + m.Engine + "," + m.Product);

            Console.WriteLine("*********\n Testing Updations\n");
            GeneralPurposeEntity[] d = { new GeneralPurposeEntity { Brand = "NGO", Product = "NGOTier2", Engine = "OPPO", Channel = "ITA" } };

            var dis = i.UpdateRecords(d);
            Console.WriteLine(dis);

        }
    }
}
