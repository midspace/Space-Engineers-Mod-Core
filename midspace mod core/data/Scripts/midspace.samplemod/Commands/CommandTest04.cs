namespace MidSpace.MySampleMod.Commands
{
    using System;
    using Messages;
    using Sandbox.ModAPI;
    using SeModCore;
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
            MySessionComponentBase mySessionComponentBase;

            //var something = (IMyComponentOwner<MyDataBroadcaster>)MyAPIGateway.Session;

            //MyAPIGateway.Session.componen
            //MyAPIGateway.Session.comp.m_sessionComponents.TryGetValue(typeof(T), out mySessionComponentBase);
            //return mySessionComponentBase as T;

            return true;
        }
    }
}
