using System.ComponentModel.DataAnnotations;

namespace WordSquare.Options;
public class DawgOption
{
    [Required] public string Path { get; set; } = default!;
}
