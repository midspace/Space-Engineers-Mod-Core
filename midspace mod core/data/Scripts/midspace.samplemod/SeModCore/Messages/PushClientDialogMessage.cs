namespace MidSpace.MySampleMod.SeModCore.Messages
{
    using ProtoBuf;
    using Sandbox.ModAPI;

    [ProtoContract]
    public class PushClientDialogMessage : PushMessageBase
    {
        [ProtoMember(201)]
        public string Title;

        [ProtoMember(202)]
        public string Prefix;

        [ProtoMember(203)]
        public string Content;

        [ProtoMember(204)]
        public SerializableArgument[] Arguments;

        public override void ProcessClient()
        {
            MyAPIGateway.Utilities.ShowMissionScreen(Localize.SubstituteTexts(Title), Localize.SubstituteTexts(Prefix), " ", Localize.SubstituteTexts(Content, Arguments));
        }

        public static void SendMessage(ulong steamId, string title, string prefix, string content, params object[] args)
        {
            ConnectionHelper.SendMessageToPlayer(steamId, new PushClientDialogMessage { Title = title, Prefix = prefix, Content = content, Arguments = SerializableArgument.ToSerializableArguments(args) });
        }
    }
}
