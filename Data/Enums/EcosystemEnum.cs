using System.ComponentModel.DataAnnotations;

namespace Poznavacka.Data.Enums
{
    public enum EcosystemEnum
    {
        [Display(Name = "sladká voda")]
        SladkáVoda,
        [Display(Name = "slaná voda")]
        SlanáVoda,
        [Display(Name = "okolí vod")]
        OkolíVod,
        [Display(Name = "moře")]
        Moře,
        [Display(Name = "les")]
        Les,
        [Display(Name = "rumiště")]
        Rumiště,
        [Display(Name = "pouště, polopouště")]
        PouštěPolopouště,
        [Display(Name = "pole")]
        Pole,
        [Display(Name = "louka, step")]
        LoukaStep,
        [Display(Name = "tělo člověka")]
        TěloČlověka,
        [Display(Name = "město, vesnice")]
        MěstoVesnice,
        [Display(Name = "lidské obydlí")]
        LidskéObydlí,
        [Display(Name = "zahrada, sad")]
        ZahradaSad,
        [Display(Name = "skály")]
        Skály,
        [Display(Name = "hory")]
        Hory
    }
}
