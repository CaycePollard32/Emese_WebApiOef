using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
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

        public ActionResult<int> ReadNumbersFromFile()
        {


            // If file exist, ReadAllLines and convert the data to int and add them to a int List
            if (System.IO.File.Exists(path))
            {
                var numbersFile = System.IO.File.ReadAllLines(path);
                getallenLijst = numbersFile.Select(int.Parse).ToList();
                return Ok(getallenLijst);

            }

            return NotFound("file not found");
        }



        [HttpPost("Add a number to the list in the file")]

        public ActionResult<int> AddNumberToListInTxt(string textNumberToInsert)
        {
            if (System.IO.File.Exists(path))
            {

                ArrayList numbers = new ArrayList();

                StreamReader reader = new StreamReader(path);


                string line;

                while ((line = reader.ReadLine()) != null)

                    numbers.Add(line);

                reader.Close();

                numbers.Add(textNumberToInsert);


                StreamWriter writer = new StreamWriter(path);

                foreach (string numberText in numbers)
                {
                    writer.WriteLine(numberText);

                }


                writer.Close();

                return Ok();


            }

            return NotFound("file not found");


        }



        [HttpDelete]

        public ActionResult DeleteHetEersteGetal()
        {
            if (System.IO.File.Exists(path))
            {
                getallenLijst.Remove(0);

                //ik heb geen manier gevonden om de List van integeres terugzetten naar string ( To.String() wou niet werken) daarom heb ik een niuewe Lijst aangemaakt met strings

                List<string> stringGetallen = System.IO.File.ReadAllLines(path).ToList();

                stringGetallen.RemoveAt(0);

                System.IO.File.WriteAllLines(path, stringGetallen.ToArray());

                return Ok();

            }

            return NotFound("file not found");

        }


        [HttpPut]

        public ActionResult InsertANewNumberAtASpecificPlace(int insertAtLineNumber, int numberToInsert)
        {
            if (System.IO.File.Exists(path))
            {
                ArrayList lines = new ArrayList();

                string textToInsert = Convert.ToString(numberToInsert);

                StreamReader reader = new StreamReader(path);

                string line;

                while ((line = reader.ReadLine()) != null)

                    lines.Add(line);

                reader.Close();

                if (lines.Count > insertAtLineNumber - 1)
                {
                    lines.Insert(insertAtLineNumber - 1, textToInsert);
                }

                if (lines.Count < insertAtLineNumber)
                {
                    lines.Add(textToInsert);
                }


                StreamWriter writer = new StreamWriter(path);

                foreach (string newLine in lines)
                {
                    writer.WriteLine(newLine);

                }


                writer.Close();

                return Ok();
            }

            return NotFound("file not found");
        }



        [HttpDelete("Delete a specific number")]

        public ActionResult DeleteSpecificNumber(int lineIndexNumber)
        {
            if (System.IO.File.Exists(path))
            {
                List<string> stringGetallen = System.IO.File.ReadAllLines(path).ToList();
                int allLines = stringGetallen.Count;

                if (lineIndexNumber - 1 < allLines)
                {
                    stringGetallen.RemoveAt(lineIndexNumber - 1);

                    System.IO.File.WriteAllLines(path, stringGetallen.ToArray());

                    return Ok();
                }

                return BadRequest("number out of scope");

                //the other possible solution is:
                //return StatusCode(400);
            }


            return NotFound("file not found");


        }







    }






}
