using System.Text.Json.Serialization;

namespace Pandorax.Mot.Models;

/// <summary>
/// Represents a comment left by the MOT tester.
/// </summary>
public class RfrAndComment
{
    /// <summary>
    /// Gets or sets the text of the comment.
    /// </summary>
    [JsonPropertyName("text")]
    public string Text { get; set; } = null!;

    /// <summary>
    /// Gets or sets the type of comment.
    /// </summary>
    [JsonPropertyName("type")]
    public CommentType Type { get; set; }
}
