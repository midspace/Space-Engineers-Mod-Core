﻿namespace MidSpace.MySampleMod.SeModCore
{
    using System;

    public enum MessageSide : byte
    {
        None = 0,
        ServerSide = 1,
        ClientSide = 2
    }

    //[Flags]
    //public enum ChatCommandSecurity
    //{
    //    /// <summary>
    //    /// Default state, uninitilized.
    //    /// </summary>
    //    None = 0x0,

    //    /// <summary>
    //    /// The normal average player can access these command
    //    /// </summary>
    //    User = 0x1,

    //    /// <summary>
    //    /// Player is Admin of game.
    //    /// </summary>
    //    Admin = 0x2,

    //    /// <summary>
    //    /// Player is designer or creator. Used for testing commands only.
    //    /// </summary>
    //    Experimental = 0x4
    //};

    public class ChatCommandSecurity
    {
        /// <summary>
        /// None one should have access to this command.
        /// </summary>
        public const byte None = 0;

        /// <summary>
        /// The normal average player can access these command
        /// </summary>
        public const byte User = 1;

        /// <summary>
        /// Can edit scripts when the scripter role is enabled
        /// </summary>
        public const byte Scripter = 50;

        /// <summary>
        /// Can kick and ban players, has access to 'Show All Players' option in Admin Tools menu
        /// </summary>
        public const byte Moderator = 80;

        /// <summary>
        /// Has access to Space Master tools
        /// </summary>
        public const byte SpaceMaster = 100;

        /// <summary>
        /// Has access to Admin tools
        /// </summary>
        public const byte Admin = 200;

        /// <summary>
        /// Admins listed in server config, cannot be demoted
        /// </summary>
        public const byte Owner = 255;
    }

    [Flags]
    public enum ChatCommandAccessibility : byte
    {
        /// <summary>
        /// No flag set for this command.
        /// </summary>
        None = 0x0,

        /// <summary>
        /// Shows that this command is not ready for use, thus only accessible for experimental users.
        /// </summary>
        Experimental = 0x1,

        /// <summary>
        /// Shows that this command can only be used in singleplayer.
        /// </summary>
        SingleplayerOnly = 0x2,

        /// <summary>
        /// Shows that this command can only be used in multiplayer.
        /// </summary>
        MultiplayerOnly = 0x4,

        /// <summary>
        /// Command runs Client side.
        /// </summary>
        Client = 0x8,

        /// <summary>
        /// Command runs Server side.
        /// </summary>
        Server = 0x10
    }

    /// <summary>
    /// Identifies the type of event that has caused the log item.
    /// </summary>
    public enum LogEventType
    {
        None = 0,

        /// <summary>
        /// Fatal error or application crash.
        /// </summary>
        Critical = 1,

        /// <summary>
        /// Recoverable error.
        /// </summary>
        Error = 2,

        /// <summary>
        /// Noncritical problem.
        /// </summary>
        Warning = 4,

        /// <summary>
        /// Informational message.
        /// </summary>
        Information = 8,

        /// <summary>
        /// Starting of a logical operation.
        /// </summary>
        Start = 128,

        /// <summary>
        /// Stopping of a logical operation.
        /// </summary>
        Stop = 256,

        /// <summary>
        /// Debugging trace.
        /// </summary>
        Verbose = 512,

        /// <summary>
        /// All details.
        /// </summary>
        All = 4096
    }
}
