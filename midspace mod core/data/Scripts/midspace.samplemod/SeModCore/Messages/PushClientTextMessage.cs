namespace MidSpace.MySampleMod.SeModCore.Messages
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

        [ProtoMember(203)]
        public SerializableArgument[] Arguments;

        public override void ProcessClient()
        {
            MyAPIGateway.Utilities.ShowMessage(Localize.SubstituteTexts(Prefix), Localize.SubstituteTexts(Content, Arguments));
        }

        public static void SendMessage(ulong steamId, string prefix, string content, params object[] args)
        {
            ConnectionHelper.SendMessageToPlayer(steamId, new PushClientTextMessage { Prefix = prefix, Content = content, Arguments = SerializableArgument.ToSerializableArguments(args) });
        }
    }
}
