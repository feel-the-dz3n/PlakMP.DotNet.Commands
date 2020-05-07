using PlakMP.DotNet.Commands;
using PlakMP.DotNet.Interfaces;
using System;
using System.Reflection;

namespace MyGameMode
{
    public class MyGameMode : IPlakScript
    {
        CommandProcessor cmdProcessor = new CommandProcessor();

        public void OnScriptInit(IServer server)
        {
            cmdProcessor.Register<EasyAdmin.Commands>();
        }

        public void OnPlayerChatCmd(IPlayer player, string message)
        {
            cmdProcessor.ProcessCommand(player, message);
        }

        public void OnPlayerChatMessage(IPlayer player, string message)
        {
        }

        public void OnPlayerConnect(IPlayer player)
        {   
        }

        public void OnPlayerDespawn(IPlayer player)
        {
        }

        public void OnPlayerDisconnect(IPlayer player)
        {
        }

        public void OnPlayerSpawn(IPlayer player)
        {
        }

        public void OnPlayerUpdate(IPlayer player)
        {   
        }

        public void OnScriptShutdown()
        {
        }
    }
}
