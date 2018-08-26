namespace MidSpace.MySampleMod.Commands
{
    using Sandbox.ModAPI;
    using SeModCore;

    public class CommandTest05 : ChatCommand
    {
        public CommandTest05()
            : base(ChatCommandSecurity.User, ChatCommandAccessibility.Server, "test05", new[] { "/test05" })
        {
        }

        public override void Help(ulong steamId, bool brief)
        {
            MyAPIGateway.Utilities.SendMessage(steamId, "/test05", "Test 05 short description. Client Command.");
        }

        public override bool Invoke(ChatData chatData)
        {
            MyAPIGateway.Utilities.SendMessage(chatData.SenderSteamId, "Server", "Sending message to console.");
            VRage.Utils.MyLog.Default.WriteLineToConsole("Writting message to Console only.");

            return true;
        }
    }
}
