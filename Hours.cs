namespace Oxide.Plugins
{
    [Info("500 hrs", "ALLiDoizCode", 0.1)]
    [Description("Plugin that only allows players with less the 500 hrs")]
    public class HoursPlugin : RustPlugin
    {
        void Init(){

        }

        void OnPlayerConnected(Network.Message packet)
        {
            Puts("OnPlayerConnected works!");
            Puts(packet);
        }

        object OnUserApprove(Network.Connection connection)
        {
            Puts("OnUserApprove works!");
            Puts(connection);
            return null;
        }
    }
}