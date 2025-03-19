namespace Pandorax.Mot.Models;

/// <summary>
/// Whether or not the odometer was read during the MOT test. <see cref="NoOdometer"/> means that a value is not available.
/// </summary>
public enum OdometerResultType
{
    Read = 1,
    Unreadable = 2,
    NoOdometer = 3
}
