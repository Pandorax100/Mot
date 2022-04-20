using System.Text.Json.Serialization;
using Pandorax.Mot.Converters;

namespace Pandorax.Mot.Models;

/// <summary>
/// The type of comment.
/// </summary>
[JsonConverter(typeof(CommentTypeConverter))]
public enum CommentType
{
    /// <summary>
    /// Represents an advisory comment.
    /// </summary>
    Advisory,

    /// <summary>
    /// Represents a comment which caused the vehicle to fail the test.
    /// </summary>
    Fail,

    /// <summary>
    /// Represents a minor infraction.
    /// </summary>
    Minor,
    Prs,

    /// <summary>
    /// Represents a user entered comment.
    /// </summary>
    UserEntered,
}
