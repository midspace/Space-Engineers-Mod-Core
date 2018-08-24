﻿namespace MidSpace.MySampleMod.Entities
{
    using System.Collections.Generic;
    using System.Xml.Serialization;

    [XmlType("ScanServer")]
    public class ScanServerEntity
    {
        public List<ScanSettingsEntity> Clients;
    }
}
