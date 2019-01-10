using System;

namespace Oxide.Plugins
{
    [Info("500 hrs", "ALLiDoizCode", 0.1)]
    [Description("Plugin that only allows players with less the 500 hrs")]
    public class Hours : RustPlugin
    {
        void Init(){

        }

        void OnPlayerConnected(Network.Message packet)
        {
            PrintToChat("OnPlayerConnected works!");
            Puts("OnPlayerConnected works!");
            Puts(packet);
        }

        object OnUserApprove(Network.Connection connection)
        {
            PrintToChat("OnUserApprove works!");
            Puts(connection);
            return null;
        }

        void Loaded()
        {
            PrintToChat("Loaded works!");
            Puts("Loaded works!");
        }
    }
}