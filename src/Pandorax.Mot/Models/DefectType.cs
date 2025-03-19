namespace Pandorax.Mot.Models;

public enum DefectType
{
    Advisory,
    Dangerous,
    Fail,
    Major,
    Minor,
    NonSpecific,
    SystemGenerated,
    UserEntered,

    /// <summary>
    /// Pass after Rectification at Station.
    /// </summary>
    Prs,
}
