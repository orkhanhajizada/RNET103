namespace Interfaces.Enums;

[Flags]
public enum Izinler
{
    None = 0,
    Okuma = 1,
    Yazma = 2,
    Silme = 4,
    Duzenleme = 8,

    Guest = Okuma,
    User = Okuma | Yazma,
    SuperUser = Okuma | Yazma | Silme,
    Admin = Okuma | Yazma | Silme | Duzenleme,
}