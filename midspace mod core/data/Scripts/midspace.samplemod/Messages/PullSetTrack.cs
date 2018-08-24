﻿namespace MidSpace.MySampleMod.Messages
{
    using Entities;
    using ProtoBuf;
    using Sandbox.ModAPI;
    using SeModCore;

    /// <summary>
    /// This will fetch the data required to track a scan detection, for the player to display
    /// </summary>
    [ProtoContract]
    public class PullSetTrack : PullMessageBase
    {
        #region properties

        /// <summary>
        /// The name of the ship or hotlist number.
        /// </summary>
        [ProtoMember(201)]
        public string ShipName;

        #endregion

        public static void SendMessage(string shipName)
        {
            ConnectionHelper.SendMessageToServer(new PullSetTrack { ShipName = shipName });
        }

        public override void ProcessServer()
        {
            ScanSettingsEntity scanSettings = ScanDataManager.GetPlayerScanData(SenderSteamId);
            TrackDetailEntity detail = null;

            if (!string.IsNullOrEmpty(ShipName))
            {
                int index;
                if (ShipName.Substring(0, 1) == "#" && int.TryParse(ShipName.Substring(1), out index) && index > 0 && index <= scanSettings.ScanHostList.Count)
                {
                    detail = scanSettings.ScanHostList[index - 1];
                }

                if (detail == null)
                {
                    MyAPIGateway.Utilities.SendMessage(SenderSteamId, "Track failed", "Object '{0}' not found.", ShipName);
                    return;
                }
            }

            // send an empty TrackEntity if no shipname is provided. This Action should clear any current tracking.
            ConnectionHelper.SendMessageToPlayer(SenderSteamId, new PushSetTrack { TrackEntity = detail });
        }
    }
}
