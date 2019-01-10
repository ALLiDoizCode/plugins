using Oxide.Core.Libraries.Covalence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using System.Net;
using Newtonsoft.Json;

namespace Oxide.Plugins
{
    [Info("Hours", "ALLiDoizCode", 0.1)]
    [Description("Plugin that only allows players with less then 100 hrs")]
    public class Hours : RustPlugin
    {
        void Init(){

        }

        public class GetOwnedGamesResponse
        {
            [JsonProperty("response")]
            public Content Response { get; set; }

            public class Content
            {
                [JsonProperty("game_count")]
                public int GameCount { get; set; }

                [JsonProperty("games")]
                public Game[] Games { get; set; }
            }

            public class Game
            {
                [JsonProperty("appid")]
                public int Appid { get; set; }

                [JsonProperty("playtime_forever")]
                public int PlaytimeForever { get; set; }

                [JsonProperty("playtime_2weeks")]
                public int? Playtime2weeks { get; set; }
            }

        }

        object OnPlayerSpawn(BasePlayer player)
        {
            Puts("OnPlayerSpawn works!");
            Puts(player.userID.ToString());
            webrequest.EnqueueGet("http://api.steampowered.com/IPlayerService/GetOwnedGames/v0001/?key=F4DF0760BBC9094DA0F403432CEE8B31&steamid=76561197987094705&format=json", (code, response) => GetCallback(code, response, player), this);
            return null;
        }

        /* object OnPlayerTick(BasePlayer player, PlayerTick msg, bool wasPlayerStalled)
        {
            Puts("OnPlayerTick works!");
            PrintToChat("OnPlayerTick works!");
            Puts(player.userID.ToString());
            PrintToChat(player.userID.ToString());
            return null;
        }*/


        object OnPlayerRespawn(BasePlayer player)
        {
            Puts("OnPlayerRespawn works!");
            Puts(player.userID.ToString());
            var currentPlayer = player.userID.ToString();
            webrequest.EnqueueGet($"http://api.steampowered.com/IPlayerService/GetOwnedGames/v0001/?key=F4DF0760BBC9094DA0F403432CEE8B31&steamid={currentPlayer}&format=json", (code, response) => GetCallback(code, response, player), this);
            return null;
        }
        void Loaded()
        {
            Puts("Loaded works!");
        }

        private void GetCallback(int code, string response, BasePlayer player)
        {
            var currentPlayer = player.userID.ToString();
            Puts(code.ToString());
            if (response == null || code != 200)
            {
                Puts("Error");
                return;
            }
            var json = JsonConvert.DeserializeObject<GetOwnedGamesResponse>(response);
            var gametime = (json.Response.Games.Single(x => x.Appid == 252490).PlaytimeForever)/60;
            if((gametime >= 100)){
                player.Kick("Over 100 Hrs");
            }
            var gametimeString = gametime.ToString();
            Puts($"The player played {gametimeString} hours of rust!");
        }
    }
}