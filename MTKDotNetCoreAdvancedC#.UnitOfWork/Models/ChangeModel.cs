namespace MTKDotNetCoreAdvancedC_.UnitOfWork.Models;

#region ChangeModel

public static class ChangeModel
{

    #region TblBlog Change

    public static TblBlog Change(this BlogRequestModel requestModel)
    {
        return new TblBlog
        {
            BlogTitle = requestModel.BlogTitle,
            BlogAuthor = requestModel.BlogAuthor,
            BlogContent = requestModel.BlogContent,
        };
    }

    #endregion

}

#endregion