using Oxide.Core.Libraries.Covalence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Oxide.Plugins
{
    [Info("500 hrs", "ALLiDoizCode", 0.1)]
    [Description("Plugin that only allows players with less the 500 hrs")]
    public class Hours : RustPlugin
    {
        void Init(){

        }

        object OnPlayerSpawn(BasePlayer player)
        {
            Puts("OnPlayerSpawn works!");
            PrintToChat("OnPlayerSpawn works!");
            Puts(player.userID.ToString());
            PrintToChat(player.userID.ToString());
            player.Kick("Over 500 Hrs");
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
            PrintToChat("OnPlayerRespawn works!");
            Puts(player.userID.ToString());
            PrintToChat(player.userID.ToString());
            //player.Kick("Over 500 Hrs");
            
            webrequest.Enqueue("http://api.steampowered.com/IPlayerService/GetOwnedGames/v0001/?key=F4DF0760BBC9094DA0F403432CEE8B31&steamid=76561197987094705&format=json", null, (code, response) =>
            {
                if (code != 200 || response == null)
                {
                    Puts($"Couldn't get an answer from Google!");
                    return;
                }
                Puts($"Google answered: {response.game_count}");
            }, this, RequestMethod.GET);

            return null;
        }
        void Loaded()
        {
            PrintToChat("Loaded works!");
            Puts("Loaded works!");
        }
    }
}