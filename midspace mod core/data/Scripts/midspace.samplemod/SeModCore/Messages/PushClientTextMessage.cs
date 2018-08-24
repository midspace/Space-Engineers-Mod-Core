﻿namespace MidSpace.MySampleMod.SeModCore.Messages
{
    using ProtoBuf;
    using Sandbox.ModAPI;

    [ProtoContract]
    public class PushClientTextMessage : PushMessageBase
    {
        [ProtoMember(201)]
        public string Prefix;

        [ProtoMember(202)]
        public string Content;

        public override void ProcessClient()
        {
            MyAPIGateway.Utilities.ShowMessage(Prefix, Content);
        }

        public static void SendMessage(ulong steamId, string prefix, string content, params object[] args)
        {
            string message;
            if (args == null || args.Length == 0)
                message = content;
            else
                message = string.Format(content, args);

            ConnectionHelper.SendMessageToPlayer(steamId, new PushClientTextMessage { Prefix = prefix, Content = message });
        }
    }
}
