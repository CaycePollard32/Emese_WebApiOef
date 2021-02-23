using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace _210223_Syntra_NETCORE_opdracht.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetalController : ControllerBase
    {
        [HttpGet]

        public ActionResult<int> LeesHetGetal()
        {
            string text = System.IO.File.ReadLines(@"C:\Users\emese\source\repos\210223_Syntra_NETCORE_opdracht\210223_Syntra_NETCORE_opdracht\TextFile\getal.txt").First();

            if (text == null)
            {
                return NotFound();

            }
            return Ok(Convert.ToInt32(text));


        }



        [HttpPost("Post1")]

        public ActionResult<int> SchrijfHetGetal(string aText)
        {
            // Store the path of the textfile in your system 
            string file = @"C:\Users\emese\source\repos\210223_Syntra_NETCORE_opdracht\210223_Syntra_NETCORE_opdracht\TextFile\getal.txt";

            // To write all of the text to the file
            System.IO.File.WriteAllText(file, aText);
            return Ok(Convert.ToInt32(aText));
        }



        [HttpPost("Post2")]

        public ActionResult<int> schrijfRandomGetal()
        {
            var random = new Random();
            int randomnumber = random.Next(10);

            // Store the path of the textfile in your system 
            string file = @"C:\Users\emese\source\repos\210223_Syntra_NETCORE_opdracht\210223_Syntra_NETCORE_opdracht\TextFile\getal.txt";

            // To write all of the text to the file
            System.IO.File.WriteAllText(file, Convert.ToString(randomnumber));
            return Ok(randomnumber);
        }






    }
}
