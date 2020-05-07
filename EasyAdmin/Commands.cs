using PlakMP.DotNet.Commands;
using PlakMP.DotNet.Interfaces;
using System;

namespace EasyAdmin
{
    public class Commands
    {
        [PlayerCommand]
        public void MyLevelCommand(IPlayer player, IServer server)
        {
            player.SendChat("Your level is 5");
        }

        [PlayerCommand]
        public void KickCommand(IPlayer player, IServer server, string target, string reason)
        {
            server.LogWrite($"{player.Name} kicked {target}. Reason: {reason}");
        }

        [PlayerCommand("bruh")]
        public void Kek(IPlayer player)
        {
            player.SendChat("Bruh");
        }
    }
}
