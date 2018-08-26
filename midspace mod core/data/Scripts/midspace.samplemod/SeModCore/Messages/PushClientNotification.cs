namespace MidSpace.MySampleMod.SeModCore.Messages
{
    using ProtoBuf;
    using Sandbox.ModAPI;
    using VRage.Game;

    [ProtoContract]
    public class PushClientNotification : PushMessageBase
    {
        [ProtoMember(201)]
        public string Message;

        [ProtoMember(202)]
        public int DisappearTimeMs;

        [ProtoMember(203)]
        public string Font;

        [ProtoMember(204)]
        public SerializableArgument[] Arguments;

        public override void ProcessClient()
        {
            MyAPIGateway.Utilities.ShowNotification(Localize.SubstituteTexts(Message, Arguments), DisappearTimeMs, Font);
        }

        public static void SendMessage(ulong steamId, string message, int disappearTimeMs = 2000, params object[] args)
        {
            SendMessage(steamId, message, MyFontEnum.White, disappearTimeMs, args);
        }

        public static void SendMessage(ulong steamId, string message, string font, int disappearTimeMs = 2000, params object[] args)
        {
            ConnectionHelper.SendMessageToPlayer(steamId, new PushClientNotification { Message = message, DisappearTimeMs = disappearTimeMs, Font = font, Arguments = SerializableArgument.ToSerializableArguments(args) });
        }
    }
}