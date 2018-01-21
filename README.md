ASP.NET Core WebGrid replacement
=================

This package trying to be in-place replacement for the WebGrid usage.
But I don't yet manage to make this happens 100%.

Changes which should be done
Add following lines in the `_ViewImports.cshtml`

    @using AndreyKurdiumov.AspNetCore.Helpers
    @inject Microsoft.AspNetCore.Http.IHttpContextAccessor HttpContextAccessor

Where WebGrid constructed should be add contructor parameter HttpContextAccessor

     var grid = new WebGrid(HttpContextAccessor, source: this.Model.Tables,
                 defaultSort: "TableName",
                 rowsPerPage: 30);
