using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TesinaServer.Helpers;
using TesinaServer.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TesinaServer.Views.GameAPI {
    [Route("GameAPI")]
    public class GameAPIController : Controller {
        // GET: api/values
        [HttpGet]
        public IEnumerable<string> Get() {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("prova/{uuid}")]
        public string Get(string uuid) {
            return uuid;
        }

        // GET api/values/5
        [HttpGet("Match/{MatchID?}")]
        public string GetMatchInfo(int MatchID = -1) {
            string response = "";
            if (MatchID == -1) {
                foreach (Match m in MatchManager.GetAllMatches()) {
                    response += Environment.NewLine + m;
                }
            } else {
                response += MatchManager.GetMatchByID(MatchID);
            }

            return "Getting info from " + (MatchID == 0 ? "all matches" : "match with ID") + ": " + (response != "" ? response : "Got nothing!");
        }

        // GET api/values/5
        [HttpGet("GetAllPlayers/{uuid}")]
        public string GetAllPlayers(string uuid) {
            Console.WriteLine(uuid + "ALLPLAYERS");
            return uuid + "ALLPLAYERS";
        }

        // POST api/values
        [HttpPut]
        public void Put([FromBody]string value) {
            Console.WriteLine("PROVAPROVAPROVA: " + value);
        }

        // POST GameAPI/Match/New
        [HttpPost("Match/New")]
        public string PostNewMatch([FromBody] string value) {
            string response = "NEW MATCH REQUEST WITH NAME " + value + "AND ID ";
            int mID = MatchManager.CreateNewMatch(value);
            response += mID + "!";
            Console.WriteLine(response);
            return response;
        }

        // DELETE api/values/5
        [HttpDelete("Match/Delete/{id}")]
        public string DeleteMatch(int id) {
            MatchManager.DeleteMatch(id);
            return "Deleted match with ID " + id;
        }
    }
}
