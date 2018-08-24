namespace MidSpace.MySampleMod.Commands
{
    using System.IO;
    using Sandbox.ModAPI;
    using SeModCore;
    using System.Text;
    using VRage;
    using VRage.Utils;

    public class CommandTest02 : ChatCommand
    {
        public CommandTest02()
            : base(ChatCommandSecurity.User, ChatCommandAccessibility.Server, "test02", new[] { "/test02" })
        {
        }

        public override void Help(ulong steamId, bool brief)
        {
            MyAPIGateway.Utilities.SendMessage(steamId, "/test02", "Test 02 short description. Server Command.");
        }

        public override bool Invoke(ChatData chatData)
        {
            StringBuilder msg = new StringBuilder();
            msg.AppendLine($"Server Culture {MyAPIGateway.Session.Config.Language}");

            MyTexts.LanguageDescription serverLanguage = MyTexts.Languages[MyAPIGateway.Session.Config.Language];
            msg.AppendLine($"Server Culture {serverLanguage.CultureName}-{serverLanguage.SubcultureName}");
            msg.AppendLine($@"Server Localized string: ""{Localize.GetResource(Localize.WorldSaved, MyAPIGateway.Session.Name)}""");
            msg.AppendLine($@"Server Localized string: ""{Localize.GetResource("DisplayName_Item_GoldIngot")}""");

            MyTexts.LanguageDescription clientLanguage = MyTexts.Languages[chatData.Language];
            msg.AppendLine();
            msg.AppendLine($"Client Culture {chatData.Language}");
            msg.AppendLine($"Client Culture {clientLanguage.CultureName}-{clientLanguage.SubcultureName}");
            msg.AppendLine();
            msg.AppendLine($@"Client Localized string cannot be done, as the other resources cannot loaded without switching the entire server/client.");

            MyAPIGateway.Utilities.SendMissionScreen(chatData.SenderSteamId, " /Test02", null, " ", msg.ToString(), null, "OK");

            return true;
        }
    }
}
