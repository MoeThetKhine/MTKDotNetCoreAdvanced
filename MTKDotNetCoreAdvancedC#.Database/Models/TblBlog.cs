using System;
using System.Collections.Generic;

namespace MTKDotNetCoreAdvancedC_.Database.Models;

public partial class TblBlog
{
    public long BlogId { get; set; }

    public string BlogTitle { get; set; } = null!;

    public string BlogAuthor { get; set; } = null!;

    public string BlogContent { get; set; } = null!;

    public bool IsActive { get; set; }
}
