namespace MidSpace.MySampleMod.Commands
{
    using Entities;
    using Helpers;
    using Messages;
    using Sandbox.ModAPI;
    using SeModCore;
    using System;
    using System.Text.RegularExpressions;
    using VRage.Game;
    using VRage.Game.ModAPI;
    using VRage.Game.ModAPI.Interfaces;

    public class CommandTest05 : ChatCommand
    {

        public CommandTest05()
            : base(ChatCommandSecurity.User, ChatCommandAccessibility.Client, "test05", new[] { "/test05" })
        {
        }

        public override void Help(ulong steamId, bool brief)
        {
            MyAPIGateway.Utilities.SendMessage(steamId, "/test05", "Test 05 short description. Client Command.");
        }

        public override bool Invoke(ChatData chatData)
        {
            IMyPlayer player = MyAPIGateway.Session.Player;

            return true;
        }
    }
}
