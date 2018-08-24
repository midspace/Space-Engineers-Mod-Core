namespace MidSpace.MySampleMod.Commands
{
    using Sandbox.ModAPI;
    using SeModCore;
    using System.Text;
    using VRage;

    public class CommandTest01 : ChatCommand
    {
        public CommandTest01()
            : base(ChatCommandSecurity.User, ChatCommandAccessibility.Client, "test01", new[] { "/test01" })
        {
        }

        public override void Help(ulong steamId, bool brief)
        {
            MyAPIGateway.Utilities.SendMessage(steamId, "/test01", "Test 01 short description. Client Command.");
        }

        public override bool Invoke(ChatData chatData)
        {
            StringBuilder msg = new StringBuilder();
            msg.AppendLine($"Client Culture {MyAPIGateway.Session.Config.Language}");

            MyTexts.LanguageDescription clientLanguage = MyTexts.Languages[MyAPIGateway.Session.Config.Language];

            msg.AppendLine($"Client Culture {clientLanguage.CultureName}-{clientLanguage.SubcultureName}");
            msg.AppendLine($@"Client Localized string: ""{Localize.GetResource(Localize.WorldSaved, MyAPIGateway.Session.Name)}""");
            msg.AppendLine($@"Client Localized string: ""{Localize.GetResource("DisplayName_Item_GoldIngot")}""");
            msg.AppendLine($@"Client Substitute string: ""{MyTexts.SubstituteTexts("{LOC:DisplayName_Item_GoldIngot}")}""");
            msg.AppendLine($@"Client Substitute strings: ""{Localize.SubstituteTexts("{LOC:DisplayName_Item_GoldIngot}{LOC:DisplayName_Item_SilverIngot}")}""");
            msg.AppendLine($@"Client Substitute strings: ""{Localize.SubstituteTexts("Some {LOC:DisplayName_Item_GoldIngot} and {LOC:DisplayName_Item_SilverIngot}.")}""");
            int count1 = 10;
            int count2 = 20;
            int count3 = 30;
            int count4 = 40;
            msg.AppendResourceLine(@"Client Substitute strings: ""{0}x {LOC:DisplayName_Item_PlatinumIngot}. {1}x {LOC:DisplayName_Item_GoldIngot}. {2}x {LOC:DisplayName_Item_SilverIngot}. {3}x {LOC:DisplayName_Item_IronIngot}.""", count1, count2, count3, count4);
            msg.AppendResourceLine(@"Client Substitute strings: ""{LOC:NotificationHintTurnPowerOff}""", "XXX");

            MyAPIGateway.Utilities.SendMissionScreen(chatData.SenderSteamId, "/Test01", null, " ", msg.ToString(), null, "OK");

            return true;
        }
    }
}
