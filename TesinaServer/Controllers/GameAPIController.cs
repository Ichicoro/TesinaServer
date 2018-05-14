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





		/*
		 * NEW API
		 */


		// MATCHES

		[HttpGet("matches/{id?}")]
		public string GetMatch(int id = -1) {
			if (id < 0) 
				return JsonConvert.SerializeObject(MatchManager.GetAllMatches());

			var MatchList = new List<Match> {MatchManager.GetMatchByID(id)};
			return JsonConvert.SerializeObject(MatchList);
		}

		// POST GameAPI/Matches
		[HttpPost("Matches")]
		public string PostNewMatch() {
			// + "AND ID " + value.ID;
			var mID = MatchManager.CreateNewMatch();
			//Console.WriteLine(value.ID);
			//response += mID + "!";
			//Console.WriteLine(response);
			return mID.ToString();
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

		[HttpGet("Matches/{mID?}/Players/{pid?}")]
		public string GetPlayerByID(int mid = -1, int pid = -1) {
			if (mid != -1 && pid != -1) {
				return JsonConvert.SerializeObject(MatchManager.GetPlayer(mid, pid));
			}
			return JsonConvert.SerializeObject(MatchManager.GetAllPlayers(mid));
		}

		[HttpPost("Matches/{mid}/Players/{username}")]
		public string AddPlayer(int mid, string username) {
			var p = MatchManager.AddPlayer(mid, username);
			return p.ToSerializedData();
		}
		
		[HttpPut("Matches/{mid}/Players")]
		public string UpdatePlayer(int mid, [FromBody]Player p) {
			MatchManager.UpdatePlayer(mid, p);
			return "ok";
		}

		[HttpDelete("Matches/{mid}/Players/{pid}")]
		public string DeletePlayer(int mid, int pid) {
			MatchManager.DeletePlayer(mid, pid);
			return "";
		}

	}
}
