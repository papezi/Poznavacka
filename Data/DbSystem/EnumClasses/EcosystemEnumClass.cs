using Poznavacka.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Poznavacka.Data.DbSystem.Taxons;

namespace Poznavacka.Data.DbSystem.EnumClasses
{
    public class EcosystemEnumClass
    {
        [Key]
        public int EcosystemID { get; set; }
        public EcosystemEnum Ecosystem { get; set; }
        public SpeciesT SpeciesT { get; set; }
    }
}
