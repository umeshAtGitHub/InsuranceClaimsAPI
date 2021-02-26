using Microsoft.AspNetCore.Mvc;
using InsuranceClaimsAPI.Models;
using System.Collections.Generic;
using System;
using System.Linq;
using CsvHelper.Configuration;
using System.Globalization;
using System.IO;
using CsvHelper;

namespace InsuranceClaimsAPI.Controllers
{
    // This attribute makes sure that the type and all the derived types
    //is used to server HTTP API responses.
    //Additionally, it enables several API specific features like attribute routing and automatic 400 responses if soemting
    // is wrong with the model
    [ApiController]
    //Add attribute rout
    [Route("api/[controller]")] //This means that controller can be accessed by its name. i.e class name that come before controller
    public class claimsController : ControllerBase
    {
        // private static List<Claims> claims = new List<Claims>(){
        //     new Claims{MemberID=1123,ClaimDate=new DateTime(2020,6,10).Date,ClaimAmount=1112.56},
        //     new Claims{MemberID=1245,ClaimDate=new DateTime(2020,5,12).Date,ClaimAmount=67.54}
        // };

        //  [Route("[Get]")] 
        public IActionResult Get()
        {
            // return Ok(claims);
            return BadRequest("Bad Request");
        }

        [HttpGet("{id}")] // Paramter name should match the parameter name in the method
        public IEnumerable<Claims> GetClaimsbyMemberID(int id)
        {

           var csvread = GetCsvReader();

            var records = csvread.GetRecords<Claims>().ToList().Where(x => x.MemberID == id);

            return records.ToList().ToArray();

            //return Ok(claims[0]);
            // return Ok(claims.FirstOrDefault(c => c.MemberID == id));
        }

        [HttpGet("{memId}/{dt}")] // Paramter name should match the parameter name in the method
        public IEnumerable<Claims> GetClaims(int memId, DateTime dt)
        {
             var csvread = GetCsvReader();

            var records = csvread.GetRecords<Claims>().ToList().Where(x => x.MemberID == memId && x.ClaimDate<=dt.Date);

            return records.ToList().ToArray();
            //return Ok(claims[0]);
            //return Ok(claims.FirstOrDefault(c=> c.ClaimId==id && c.MemberId==memId && c.ClaimDate == Convert.ToDateTime(dt).Date));
            // return Ok(claims.FirstOrDefault(c => c.MemberID == memId && c.ClaimDate == dt.Date));
        }

        private static CsvReader GetCsvReader()

        {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = true,
            };

            var reader = new StreamReader(@"C:\Users\umesh\source\repos\ClaimsAPI\resource\Claim.csv");

           var csvreader = new CsvReader(reader, config);


            return csvreader;
        }
    }


}

