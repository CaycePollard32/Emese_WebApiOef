using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace _210223_Syntra_NETCORE_opdracht.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetallenController : ControllerBase
    {
        public List<int> getallenLijst = new List<int>();
        // Store the path of the textfile 
        public string path = @"C:\Users\emese\source\repos\210223_Syntra_NETCORE_opdracht\210223_Syntra_NETCORE_opdracht\TextFile\getallen.txt";

        [HttpGet]

        public ActionResult<int> LeesDeGetallenUitEenFile()
        {


            // If file exist, ReadAllLines and convert the data to int and add them to a int List
            if (System.IO.File.Exists(path))
            {
                var getallenFile = System.IO.File.ReadAllLines(path);
                getallenLijst = getallenFile.Select(int.Parse).ToList();
                return Ok(getallenLijst);

            }

            return NotFound();
        }



        [HttpPost("Voeg een getal toe de lijst")]

        public ActionResult<int> VoegGetalToeDeLijst(string aText)
        {
            getallenLijst.Add(Convert.ToInt16(aText));

            
            return Ok();


        }



        [HttpDelete]

        public ActionResult DeleteHetEersteGetal()
        {
            getallenLijst.Remove(0);

             //ik heb geen manier gevonden om de List van integeres terugzetten naar string ( To.String() wou niet werken) daarom heb ik een niuewe Lijst aangemaakt met strings

            List<string> stringGetallen = System.IO.File.ReadAllLines(path).ToList();

            stringGetallen.RemoveAt(0);

            System.IO.File.WriteAllLines(path, stringGetallen.ToArray());

            return Ok();
        }






    }






}
