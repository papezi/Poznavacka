using System.ComponentModel.DataAnnotations;

namespace Poznavacka.Data.Enums
{
    public enum OccurenceWorldEnum
    {
        Evropa,
        Asie,
        Afrika,
        [Display(Name = "Severní Amerika")]
        SAmerika,
        [Display(Name = "Jižní Amerika")]
        JAmerika,
        Austrálie,
        Arktida,
        Antarktida
    }
}
