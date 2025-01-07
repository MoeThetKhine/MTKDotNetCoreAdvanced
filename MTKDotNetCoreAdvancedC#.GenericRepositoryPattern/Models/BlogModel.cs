﻿namespace MTKDotNetCoreAdvancedC_.GenericRepositoryPattern.Models;

public class BlogModel
{
    public long BlogId { get; set; }

    public string BlogTitle { get; set; } = null!;

    public string BlogAuthor { get; set; } = null!;

    public string BlogContent { get; set; } = null!;

    public bool IsActive { get; set; }
}
