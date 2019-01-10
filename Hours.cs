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
            PrintToChat("Loaded works!");
            Puts(player.Name);
            Puts(player.userID);
            PrintToChat(player.Name);
            PrintToChat(player.userID);
            return null;
        }

        void Loaded()
        {
            PrintToChat("Loaded works!");
            Puts("Loaded works!");
        }
    }
}