namespace MidSpace.MySampleMod.SeModCore
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Text;
    using VRage;
    using VRage.FileSystem;
    using VRage.Utils;

    public static class Localize
    {
        // TODO: Localize out our resources?

        // VRage.Game.Localization.MyLocalization
        private const string LOCALIZATION_TAG = "LOC";

        // VRage.MyTexts.MyTexts()
        private const string LOCALIZATION_TAG_GENERAL = "LOCG";
            

        // Cannot use namespace "Sandbox.Game.Localization", as it's not whitelisted.
        //MyStringId WorldSaved = MySpaceTexts.WorldSaved;

        // MySpaceTexts is not allowed in scripts. Last checked in version 01.100.024.
        //var test = MyTexts.GetString(Sandbox.Game.Localization.MySpaceTexts.WorldSettings_Description);

        // Game resources.
        public const string WorldSaved = "WorldSaved";

        public static string GetResource(string stringId, params object[] args)
        {
            if (args.Length == 0)
                return MyStringId.Get(stringId).GetString();
            
            return MyStringId.Get(stringId).GetStringFormat(args);
        }

        // kind of pointless without the Sandbox.Game.Localization namespace, unless we define our own.
        //public static string GetResource(MyStringId stringId, params object[] args)
        //{
        //    return stringId.GetStringFormat(args);
        //}

        public static string GetString(this MyStringId stringId)
        {
            return MyTexts.GetString(stringId);
        }

        public static string GetStringFormat(this MyStringId stringId, params object[] args)
        {
            return string.Format(MyTexts.GetString(stringId), args);
        }

        public static string SubstituteTexts(string text)
        {
            if (string.IsNullOrEmpty(text))
                return text;

            string[] tagReplace = { LOCALIZATION_TAG, LOCALIZATION_TAG_GENERAL, /* insert custom here. */ };

            foreach (string tag in tagReplace)
            {
                int startingIndex;
                do
                {
                    startingIndex = text.IndexOf("{" + tag, StringComparison.Ordinal);
                    if (startingIndex >= 0)
                    {
                        int keyIndex = startingIndex + tag.Length + 1;
                        int endingIndex = text.IndexOf("}", keyIndex, StringComparison.Ordinal) + 1;

                        var localizationKey = text.Substring(keyIndex, endingIndex - keyIndex - 1);
                        string replacement = MyTexts.GetString(MyStringId.GetOrCompute(localizationKey));
                        text = text.Substring(0, startingIndex) + replacement + text.Substring(endingIndex);
                    }
                } while (startingIndex >= 0);
            }

            return text;
        }

        public static string SubstituteTexts(string text, SerializableArgument[] args)
        {
            text = SubstituteTexts(text);

            //if (Arguments != null && Arguments.Length != 0)
            //    message = string.Format(message, Arguments);

            //string.Format(text, )

            return text;
        }

        public static void AppendResource(this StringBuilder stringBuilder, string resource, params object[] args)
        {
            string text = SubstituteTexts(resource);

            if (args == null || args.Length == 0)
                stringBuilder.Append(text);
            else
                stringBuilder.AppendFormat(text, args);
        }

        public static void AppendResourceLine(this StringBuilder stringBuilder, string resource, params object[] args)
        {
            string text = SubstituteTexts(resource);

            if (args == null || args.Length == 0)
                stringBuilder.AppendLine(text);
            else
            {
                stringBuilder.AppendFormat(text, args);
                stringBuilder.AppendLine();
            }
        }
    }
}
