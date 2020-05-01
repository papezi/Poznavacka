using System.ComponentModel.DataAnnotations;

namespace Poznavacka.Data.Enums
{
    public enum ProtectionEnum
    {
        [Display(Name = "není chráněno")]
        není,
        [Display(Name = "ohrožený druh")]
        ohrožený,
        [Display(Name = "silně ohrožený druh")]
        silněOhrožený,
        [Display(Name = "kriticky ohrožený druh")]
        kritickyOhrožený,
        [Display(Name = "mezinárodně chráněný druh")]
        mezinárodněChránný
    }
}
