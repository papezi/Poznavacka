using Poznavacka.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Poznavacka.Data.DbSystem.Taxons;

namespace Poznavacka.Data.DbSystem.EnumClasses
{
    public class OccurenceWorldEnumClass
    {
        [Key]
        public int OccurenceWID { get; set; }
        public OccurenceWorldEnum OccurenceWorld { get; set; }
        public SpeciesT SpeciesT { get; set; }
    }
}
