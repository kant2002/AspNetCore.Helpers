// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

using System.Collections.Generic;

namespace AndreyKurdiumov.AspNetCore.Helpers
{
    internal interface IWebGridDataSource
    {
        int TotalRowCount { get; }

        IList<WebGridRow> GetRows(SortInfo sortInfo, int pageIndex);
    }
}
