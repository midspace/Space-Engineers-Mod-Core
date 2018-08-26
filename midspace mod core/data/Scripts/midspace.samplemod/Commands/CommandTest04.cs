namespace MidSpace.MySampleMod.Commands
{
    using System;
    using System.IO;
    using System.Text;
    using Messages;
    using Sandbox.ModAPI;
    using SeModCore;
    using VRage;
    using VRage.Game.Components;

    public class CommandTest04 : ChatCommand
    {
        public CommandTest04()
            : base(ChatCommandSecurity.User, ChatCommandAccessibility.Server, "test04", new[] { "/test04" })
        {
        }

        public override void Help(ulong steamId, bool brief)
        {
            MyAPIGateway.Utilities.SendMessage(steamId, "/test04", "Test 04 short description. Server Command.");
        }

        public override bool Invoke(ChatData chatData)
        {
            StringBuilder msg = new StringBuilder();

            msg.AppendLine(@"Server string. Client Localized: ""{LOC:WorldSaved}""");
            msg.AppendLine(@"Server string. Client Localized: ""{LOC:DisplayName_Item_GoldIngot}""");
            msg.AppendLine();

            MyAPIGateway.Utilities.SendMessage(chatData.SenderSteamId, "Server", msg.ToString(), MyAPIGateway.Session.Name);

            MyAPIGateway.Utilities.SendMissionScreen(chatData.SenderSteamId, "/Test03", null, " ", msg.ToString(), null, "OK", MyAPIGateway.Session.Name);

            return true;
        }
    }
}
