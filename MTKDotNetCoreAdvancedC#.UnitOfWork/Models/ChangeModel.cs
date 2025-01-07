namespace MTKDotNetCoreAdvancedC_.UnitOfWork.Models;

public static class ChangeModel
{
    public static TblBlog Change(this BlogRequestModel requestModel)
    {
        return new TblBlog
        {
            BlogTitle = requestModel.BlogTitle,
            BlogAuthor = requestModel.BlogAuthor,
            BlogContent = requestModel.BlogContent,
        };
    }
}
