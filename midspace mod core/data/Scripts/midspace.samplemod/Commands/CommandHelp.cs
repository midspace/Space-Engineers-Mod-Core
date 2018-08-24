namespace MidSpace.MySampleMod.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    using Sandbox.ModAPI;
    using SeModCore;

    public class CommandHelp : ChatCommand
    {
        public CommandHelp()
            : base(ChatCommandSecurity.User, ChatCommandAccessibility.Client, "help", new[] { "/help", "/?" })
        {
        }

        public override void Help(ulong steamId, bool brief)
        {
            if (brief)
                MyAPIGateway.Utilities.SendMessage(steamId, "/help <name>", "Displays help on the specified command <name>.");
            else
                Sandbox.Game.MyVisualScriptLogicProvider.OpenSteamOverlay(@"http://steamcommunity.com/sharedfiles/filedetails/?id=554313772");
        }

        public override bool Invoke(ChatData chatData)
        {
            var brief = chatData.TextCommand.StartsWith("/?", StringComparison.InvariantCultureIgnoreCase);

            var match = Regex.Match(chatData.TextCommand, @"(/help|/?)\s{1,}(?<Key>[^\s]+)", RegexOptions.IgnoreCase);
            if (match.Success)
            {
                var ret = ChatCommandService.Help(chatData.SenderSteamId, match.Groups["Key"].Value, brief);
                if (!ret)
                    MyAPIGateway.Utilities.ShowMessage("help", "could not find specified command.");
                return true;
            }

            if (ChatCommandService.UserSecurity == ChatCommandSecurity.User)
            {
                // Split help details. Regular users, get one list.
                var commands = new List<string>(ChatCommandService.GetUserListCommands(chatData.SenderSteamId));
                commands.Sort();

                if (brief)
                    MyAPIGateway.Utilities.ShowMessage("help", string.Join(", ", commands));
                else
                    MyAPIGateway.Utilities.ShowMissionScreen($"{MySampleModConsts.ModTitle} Commands", "Help : Available commands", " ", "Commands: " + string.Join(", ", commands), null, "OK");
            }
            else
            {
                // Split help details. Admins users, get two lists.
                var commands = new List<string>(ChatCommandService.GetUserListCommands(chatData.SenderSteamId));
                commands.Sort();

                var nonUserCommands = new List<string>(ChatCommandService.GetNonUserListCommands(chatData.SenderSteamId));
                nonUserCommands.Sort();

                if (brief)
                {
                    MyAPIGateway.Utilities.ShowMessage("user help", string.Join(", ", commands));
                    MyAPIGateway.Utilities.ShowMessage("help", string.Join(", ", nonUserCommands));
                }
                else
                {
                    MyAPIGateway.Utilities.ShowMissionScreen($"{MySampleModConsts.ModTitle} Commands", "Help : Available commands", " ",
                        $"User commands:\r\n{string.Join(", ", commands)}\r\n\r\nAdmin commands:\r\n{string.Join(", ", nonUserCommands)}"
                        , null, "OK");
                }
            }

            return true;
        }
    }
}
