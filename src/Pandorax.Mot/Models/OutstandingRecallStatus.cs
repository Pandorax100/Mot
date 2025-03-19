namespace Pandorax.Mot.Models;

public enum OutstandingRecallStatus
{
    /// <summary>
    /// There is at least one recall which has not yet been fixed.
    /// </summary>
    Yes,

    /// <summary>
    /// There were one or more recalls which have all been fixed.
    /// </summary>
    No,

    /// <summary>
    /// No known recalls have been found in the available data.
    /// </summary>
    Unknown,

    /// <summary>
    /// Unable to retrieve data from the Recalls service due to an error.
    /// </summary>
    Unavailable,
}
