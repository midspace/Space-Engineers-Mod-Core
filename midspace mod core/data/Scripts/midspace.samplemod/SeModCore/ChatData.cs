namespace MidSpace.MySampleMod.SeModCore
{
    using VRage;

    public class ChatData
    {
        public ChatData(ulong senderSteamId, string senderDisplayName, int senderLanguage, long identityId, string textCommand)
        {
            SenderSteamId = senderSteamId;
            SenderDisplayName = senderDisplayName;
            SenderLanguage = senderLanguage;
            IdentityId = identityId;
            TextCommand = textCommand;
        }

        /// <summary>
        /// SteamId of the player that invoked the command.
        /// </summary>
        public ulong SenderSteamId;

        /// <summary>
        /// The current displayed name of the player that invoked the command.
        /// The name can be changed in Steam whilst in game play.
        /// </summary>
        public string SenderDisplayName;

        /// <summary>
        /// The Display Language of the player that invoked the command.
        /// This is limited by: <see cref="VRage.MyLanguagesEnum"/>.
        /// </summary>
        public int SenderLanguage;

        public MyLanguagesEnum Language => (MyLanguagesEnum)SenderLanguage;

        /// <summary>
        /// PlayerId/IdentityId of the player that invoked the command.
        /// </summary>
        public long IdentityId;

        /// <summary>
        /// The command text.
        /// </summary>
        public string TextCommand;
    }
}
