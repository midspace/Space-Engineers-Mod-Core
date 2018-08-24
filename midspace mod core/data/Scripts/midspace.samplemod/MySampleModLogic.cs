namespace MidSpace.MySampleMod
{
    using Commands;
    using Entities;
    using SeModCore;
    using System.Collections.Generic;
    using VRage.Game.Components;

    /// <summary>
    /// Adds special chat commands, allowing the player to get their position, date, time, change their location on the map.
    /// Author: Midspace. AKA Screaming Angels.
    /// 
    /// My other Steam workshop items:
    /// http://steamcommunity.com/id/ScreamingAngels/myworkshopfiles/?appid=244850
    /// </summary>
    /// <example>
    /// To use, simply open the chat window, and enter "/command", where command is one of the specified.
    /// Enter "/help" or "/help command" for more detail on individual commands.
    /// Chat commands do not have to start with "/". This model allows practically any text to become a command.
    /// Each ChatCommand can determine what it's own allowable command is.
    /// </example>

    [MySessionComponentDescriptor(MyUpdateOrder.BeforeSimulation)]
    public class MySampleModLogic : MainChatCommandLogic
    {
        public ScanServerEntity ServerData;

        public override void InitModSettings(out int modCommunicationVersion, out ushort serverConnectionId, out LogEventType serverLoggingLevel, out string serverLogFileName, out ushort clientConnectionId, out LogEventType clientLoggingLevel, out string clientLogFileName, out string modName, out string modTitle, out ulong[] experimentalCreatorList)
        {
            modCommunicationVersion = MySampleModConsts.ModCommunicationVersion;
            serverConnectionId = MySampleModConsts.ServerConnectionId;
            serverLoggingLevel = MySampleModConsts.ServerLoggingLevel;
            serverLogFileName = MySampleModConsts.ServerLogFileName;
            clientConnectionId = MySampleModConsts.ClientConnectionId;
            clientLoggingLevel = MySampleModConsts.ClientLoggingLevel;
            clientLogFileName = MySampleModConsts.ClientLogFileName;
            modName = MySampleModConsts.ModName;
            modTitle = MySampleModConsts.ModTitle;
            experimentalCreatorList = MySampleModConsts.ExperimentalCreatorList;
        }

        // TODO: create an interface for MainChatCommandLogic and this to implement it.
        public override List<ChatCommand> GetAllChatCommands()
        {
            return new List<ChatCommand>
            {
                // New command classes must be added in here.
                new CommandHelp(),
                new CommandTest01(),
                new CommandTest02(),
                new CommandTest03(),
                new CommandTest04(),
                new CommandTest05(),
                new CommandTest06(),
                new CommandTest10(),
            };
        }

        public override void ServerLoad()
        {
            ServerData = ScanDataManager.LoadData();
        }

        public override void ServerSave()
        {
            if (ServerData != null)
            {
                ScanDataManager.SaveData(ServerData);
            }
        }

        public override ClientConfigBase GetConfig()
        {
            return MidSpace.MySampleMod.ClientConfig.FetchClientResponse();
        }
    }
}
