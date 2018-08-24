namespace MidSpace.MySampleMod.Commands
{
    using System.IO;
    using Sandbox.ModAPI;
    using SeModCore;
    using System.Text;
    using VRage;
    using VRage.Utils;

    public class CommandTest03 : ChatCommand
    {
        public CommandTest03()
            : base(ChatCommandSecurity.User, ChatCommandAccessibility.Server, "test03", new[] { "/test03" })
        {
        }

        public override void Help(ulong steamId, bool brief)
        {
            MyAPIGateway.Utilities.SendMessage(steamId, "/test03", "Test 03 short description. Server Command.");
        }

        public override bool Invoke(ChatData chatData)
        {
            StringBuilder msg = new StringBuilder();

            MyTexts.LanguageDescription languageRu = MyTexts.Languages[MyLanguagesEnum.Russian];
            MyTexts.Clear();
            MyTexts.LoadTexts(Path.Combine(MyAPIGateway.Utilities.GamePaths.ContentPath, "Data", "Localization"), languageRu.CultureName, languageRu.SubcultureName);
            msg.AppendLine($"Server Culture: {languageRu.Name}: {languageRu.CultureName}-{languageRu.SubcultureName}");
            msg.AppendLine($@"Server Localized string: ""{Localize.GetResource(Localize.WorldSaved, MyAPIGateway.Session.Name)}""");
            msg.AppendLine($@"Server Localized string: ""{Localize.GetResource("DisplayName_Item_GoldIngot")}""");
            msg.AppendLine();

            MyTexts.LanguageDescription languageEn = MyTexts.Languages[MyLanguagesEnum.German];
            MyTexts.Clear();
            MyTexts.LoadTexts(Path.Combine(MyAPIGateway.Utilities.GamePaths.ContentPath, "Data", "Localization"), languageEn.CultureName, languageRu.SubcultureName);
            msg.AppendLine($"Server Culture: {languageEn.Name}: {languageEn.CultureName}-{languageEn.SubcultureName}");
            msg.AppendLine($@"Server Localized string: ""{Localize.GetResource(Localize.WorldSaved, MyAPIGateway.Session.Name)}""");
            msg.AppendLine($@"Server Localized string: ""{Localize.GetResource("DisplayName_Item_GoldIngot")}""");
            msg.AppendLine();

            MyTexts.LanguageDescription languageOriginal = MyTexts.Languages[MyAPIGateway.Session.Config.Language];
            MyTexts.Clear();
            MyTexts.LoadTexts(Path.Combine(MyAPIGateway.Utilities.GamePaths.ContentPath, "Data", "Localization"), languageOriginal.CultureName, languageOriginal.SubcultureName);
            msg.AppendLine($"Server Culture: {languageOriginal.Name}: {languageOriginal.CultureName}-{languageOriginal.SubcultureName}");
            msg.AppendLine($@"Server Localized string: ""{Localize.GetResource(Localize.WorldSaved, MyAPIGateway.Session.Name)}""");
            msg.AppendLine($@"Server Localized string: ""{Localize.GetResource("DisplayName_Item_GoldIngot")}""");
            msg.AppendLine();

            MyAPIGateway.Utilities.SendMissionScreen(chatData.SenderSteamId, "/Test03", null, " ", msg.ToString(), null, "OK");

            return true;
        }
    }
}
