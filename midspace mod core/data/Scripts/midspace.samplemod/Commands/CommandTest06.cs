namespace MidSpace.MySampleMod.Commands
{
    using Entities;
    using Helpers;
    using Messages;
    using Sandbox.ModAPI;
    using SeModCore;
    using System;
    using System.Text.RegularExpressions;
    using SeModCore.Messages;
    using VRage.Game;
    using VRage.Game.ModAPI;
    using VRage.Game.ModAPI.Interfaces;

    public class CommandTest06 : ChatCommand
    {
        public static CommandTest06 Instance;

        //private TrackDetailEntity _track;
        //private bool _isTracking;
        //private int _objectiveLine = 0;
        //private IMyControllableEntity _currentController;

        public CommandTest06()
            : base(ChatCommandSecurity.User, ChatCommandAccessibility.Client, "test06", new[] { "/test06" })
        {
            Instance = this;
        }

        public override void Help(ulong steamId, bool brief)
        {
            MyAPIGateway.Utilities.SendMessage(steamId, "/test06", "Test 06 short description. Client Command.");
        }

        public override bool Invoke(ChatData chatData)
        {
            IMyPlayer player = MyAPIGateway.Session.Player;

            return true;
        }
    }
}
