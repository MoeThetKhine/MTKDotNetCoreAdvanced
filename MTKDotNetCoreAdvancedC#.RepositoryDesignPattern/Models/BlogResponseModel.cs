namespace MTKDotNetCoreAdvancedC_.RepositoryDesignPattern.Models;

#region BlogResponseModel

public class BlogResponseModel
{
    public string BlogTitle { get; set; } = null!;

    public string BlogAuthor { get; set; } = null!;

    public string BlogContent { get; set; } = null!;

    public bool IsActive { get; set; }
}

#endregion
