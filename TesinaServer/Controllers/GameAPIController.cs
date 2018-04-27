using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TesinaServer.Helpers;
using TesinaServer.Models;
using Newtonsoft.Json;

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
		/* [HttpGet("Matches/{MatchID?}")]
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
		} */

		// GET api/values/5
		[HttpGet("Match/{id}")]
		public string GetAllPlayers(string mID) {
			Console.WriteLine(mID + "ALLPLAYERS");
			return mID + "ALLPLAYERS";
		}

		// POST api/values
		[HttpPut]
		public void Put([FromBody]string value) {
			Console.WriteLine("PROVAPROVAPROVA: " + value);
		}


		[HttpPost("players/{id}/position")]
		public string UpdatePlayerPosition([FromBody] Player player) {

			return "";
		}





		/*
		 * NEW API
		 */


		// MATCHES

		[HttpGet("matches/{id?}")]
		public string GetMatch(int id = -1) {
			List<Match> MatchList = new List<Match>();
			if (id == -1) {
				foreach (Match m in MatchManager.GetAllMatches()) {
					MatchList.Add(m);
				}
			} else {
				MatchList.Add(MatchManager.GetMatchByID(id));
			}

			// return "Getting info from " + (id == 0 ? "all matches" : "match with ID") + ": " + (response != "" ? response : "Got nothing!");
			return JsonConvert.SerializeObject(MatchList);
		}

		// POST GameAPI/Match/New
		[HttpPost("Matches")]
		public string PostNewMatch([FromBody] Match value) {
			string response = "NEW MATCH REQUEST WITH NAME " + value.Name;// + "AND ID " + value.ID;
			int mID = MatchManager.CreateNewMatch(value.Name);
			response = mID.ToString();
			//Console.WriteLine(value.ID);
			//response += mID + "!";
			//Console.WriteLine(response);
			return response;
		}

		[HttpPut("matches/{id}")]
		public string UpdateMatch([FromBody] Match match) {
			return "Not yet implemented";
		}

		// DELETE api/values/5
		[HttpDelete("Matches/{id}")]
		public string DeleteMatch(int id) {
			MatchManager.DeleteMatch(id);
			return "Deleted match with ID " + id;
		}

		// Players



	}
}
