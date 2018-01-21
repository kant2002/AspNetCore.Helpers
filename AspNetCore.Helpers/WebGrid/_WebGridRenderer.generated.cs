﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.214
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using System.Web.WebPages;
//using System.Web.WebPages.Html;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace System.Web.Helpers
{
    //[GeneratedCode("RazorSingleFileGenerator", "1.0.0.0")]
    internal class WebGridRenderer //: HelperPage
    {
//#line hidden
//#line hidden
        public static HelperResult GridInitScript(WebGrid webGrid, HttpContext httpContext)
        {
            return new HelperResult(__razor_helper_writer =>
            {
                if (!webGrid.IsAjaxEnabled)
                {
                    return;
                }
                if (!IsGridScriptRendered(httpContext))
                {
                    SetGridScriptRendered(httpContext, true);

                    WriteLiteralTo(@__razor_helper_writer, "        <script type=\"text/javascript\">\r\n        (function($) {\r\n            $.fn" +
                                                           ".swhgLoad = function(url, containerId, callback) {\r\n                url = url + " +
                                                           "(url.indexOf(\'?\') == -1 ? \'?\' : \'&\') + \'__swhg=\' + new Date().getTime();\r\n\r\n    " +
                                                           "            $(\'<div/>\').load(url + \' \' + containerId, function(data, status, xhr" +
                                                           ") {\r\n                    $(containerId).replaceWith($(this).html());\r\n          " +
                                                           "          if (typeof(callback) === \'function\') {\r\n                        callba" +
                                                           "ck.apply(this, arguments);\r\n                    }\r\n                });\r\n        " +
                                                           "        return this;\r\n            }\r\n\r\n            $(function() {\r\n             " +
                                                           "   $(\'table[data-swhgajax=\"true\"],span[data-swhgajax=\"true\"]\').each(function() {" +
                                                           "\r\n                    var self = $(this);\r\n                    var containerId =" +
                                                           " \'#\' + self.data(\'swhgcontainer\');\r\n                    var callback = getFuncti" +
                                                           "on(self.data(\'swhgcallback\'));\r\n\r\n                    $(containerId).parent().de" +
                                                           "legate(containerId + \' a[data-swhglnk=\"true\"]\', \'click\', function() {\r\n         " +
                                                           "               $(containerId).swhgLoad($(this).attr(\'href\'), containerId, callba" +
                                                           "ck);\r\n                        return false;\r\n                    });\r\n          " +
                                                           "      })\r\n            });\r\n\r\n            function getFunction(code, argNames) {\r" +
                                                           "\n                argNames = argNames || [];\r\n                var fn = window, pa" +
                                                           "rts = (code || \"\").split(\".\");\r\n                while (fn && parts.length) {\r\n  " +
                                                           "                  fn = fn[parts.shift()];\r\n                }\r\n                if" +
                                                           " (typeof (fn) === \"function\") {\r\n                    return fn;\r\n               " +
                                                           " }\r\n                argNames.push(code);\r\n                return Function.constr" +
                                                           "uctor.apply(null, argNames);\r\n            }\r\n        })(jQuery);\r\n        </scri" +
                                                           "pt>\r\n");
                }
            });
        }

//#line hidden
        public static HelperResult Table(WebGrid webGrid,
                                         HttpContext httpContext,
                                         string tableStyle,
                                         string headerStyle,
                                         string footerStyle,
                                         string rowStyle,
                                         string alternatingRowStyle,
                                         string selectedRowStyle,
                                         string caption,
                                         bool displayHeader,
                                         bool fillEmptyRows,
                                         string emptyRowCellValue,
                                         IEnumerable<WebGridColumn> columns,
                                         IEnumerable<string> exclusions,
                                         Func<dynamic, object> footer,
                                         object htmlAttributes)
        {
            return new HelperResult(__razor_helper_writer =>
            {
                if (emptyRowCellValue == null)
                {
                    emptyRowCellValue = "&nbsp;";
                }

                WriteTo(@__razor_helper_writer, GridInitScript(webGrid, httpContext));

                var htmlAttributeDictionary = Microsoft.AspNetCore.Mvc.ViewFeatures.HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);
                if (webGrid.IsAjaxEnabled)
                {
                    htmlAttributeDictionary["data-swhgajax"] = "true";
                    htmlAttributeDictionary["data-swhgcontainer"] = webGrid.AjaxUpdateContainerId;
                    htmlAttributeDictionary["data-swhgcallback"] = webGrid.AjaxUpdateCallback;
                }

                WriteLiteralTo(@__razor_helper_writer, "    <table");

                WriteTo(@__razor_helper_writer, tableStyle.IsEmpty() ? null : Raw(" class=\"" + HttpUtility.HtmlAttributeEncode(tableStyle) + "\""));

                WriteTo(@__razor_helper_writer, PrintAttributes(htmlAttributeDictionary));

                WriteLiteralTo(@__razor_helper_writer, ">\r\n");

                if (!caption.IsEmpty())
                {
                    WriteLiteralTo(@__razor_helper_writer, "        <caption>");

                    WriteTo(@__razor_helper_writer, caption);

                    WriteLiteralTo(@__razor_helper_writer, "</caption>\r\n");
                }

                if (displayHeader)
                {
                    WriteLiteralTo(@__razor_helper_writer, "    <thead>\r\n        <tr");

                    WriteTo(@__razor_helper_writer, CssClass(headerStyle));

                    WriteLiteralTo(@__razor_helper_writer, ">\r\n");

                    foreach (var column in columns)
                    {
                        WriteLiteralTo(@__razor_helper_writer, "            <th scope=\"col\">\r\n");

                        if (ShowSortableColumnHeader(webGrid, column))
                        {
                            var text = column.Header.IsEmpty() ? column.ColumnName : column.Header;

                            WriteTo(@__razor_helper_writer, GridLink(webGrid, webGrid.GetSortUrl(column.ColumnName), text));
                        }
                        else
                        {
                            WriteTo(@__razor_helper_writer, column.Header ?? column.ColumnName);
                        }

                        WriteLiteralTo(@__razor_helper_writer, "            </th>\r\n");
                    }

                    WriteLiteralTo(@__razor_helper_writer, "        </tr>\r\n    </thead>\r\n");
                }

                if (footer != null)
                {
                    WriteLiteralTo(@__razor_helper_writer, "    <tfoot>\r\n        <tr ");

                    WriteTo(@__razor_helper_writer, CssClass(footerStyle));

                    WriteLiteralTo(@__razor_helper_writer, ">\r\n            <td colspan=\"");

                    WriteTo(@__razor_helper_writer, columns.Count().ToString());

                    WriteLiteralTo(@__razor_helper_writer, "\">");

                    WriteTo(@__razor_helper_writer, Format(footer, null));

                    WriteLiteralTo(@__razor_helper_writer, "</td>\r\n        </tr>\r\n    </tfoot>\r\n");
                }

                WriteLiteralTo(@__razor_helper_writer, "    <tbody>\r\n");

                int rowIndex = 0;

                foreach (var row in webGrid.Rows)
                {
                    string style = GetRowStyle(webGrid, rowIndex++, rowStyle, alternatingRowStyle, selectedRowStyle);

                    WriteLiteralTo(@__razor_helper_writer, "        <tr");

                    WriteTo(@__razor_helper_writer, CssClass(style));

                    WriteLiteralTo(@__razor_helper_writer, ">\r\n");

                    foreach (var column in columns)
                    {
                        var value = (column.Format == null) ? HttpUtility.HtmlEncode(row[column.ColumnName]) : Format(column.Format, row).ToString();

                        WriteLiteralTo(@__razor_helper_writer, "            <td");

                        WriteTo(@__razor_helper_writer, CssClass(column.Style));

                        WriteLiteralTo(@__razor_helper_writer, ">");

                        WriteTo(@__razor_helper_writer, Raw(value));

                        WriteLiteralTo(@__razor_helper_writer, "</td>\r\n");
                    }

                    WriteLiteralTo(@__razor_helper_writer, "        </tr>\r\n");
                }

                if (fillEmptyRows)
                {
                    rowIndex = webGrid.Rows.Count;
                    while (rowIndex < webGrid.RowsPerPage)
                    {
                        string style = GetRowStyle(webGrid, rowIndex++, rowStyle, alternatingRowStyle, null);

                        WriteLiteralTo(@__razor_helper_writer, "            <tr");

                        WriteTo(@__razor_helper_writer, CssClass(style));

                        WriteLiteralTo(@__razor_helper_writer, ">\r\n");

                        foreach (var column in columns)
                        {
                            WriteLiteralTo(@__razor_helper_writer, "                    <td");

                            WriteTo(@__razor_helper_writer, CssClass(column.Style));

                            WriteLiteralTo(@__razor_helper_writer, ">");

                            WriteTo(@__razor_helper_writer, Raw(emptyRowCellValue));

                            WriteLiteralTo(@__razor_helper_writer, "</td>\r\n");
                        }

                        WriteLiteralTo(@__razor_helper_writer, "            </tr>\r\n");
                    }
                }

                WriteLiteralTo(@__razor_helper_writer, "    </tbody>\r\n    </table>\r\n");
            });
        }

//#line hidden
        public static HelperResult Pager(
            WebGrid webGrid,
            HttpContext httpContext,
            WebGridPagerModes mode,
            string firstText,
            string previousText,
            string nextText,
            string lastText,
            int numericLinksCount,
            bool renderAjaxContainer)
        {
            return new HelperResult(__razor_helper_writer =>
            {
                int currentPage = webGrid.PageIndex;
                int totalPages = webGrid.PageCount;
                int lastPage = totalPages - 1;

                WriteTo(@__razor_helper_writer, GridInitScript(webGrid, httpContext));

                if (renderAjaxContainer && webGrid.IsAjaxEnabled)
                {
                    WriteLiteralTo(@__razor_helper_writer, "        ");

                    WriteLiteralTo(@__razor_helper_writer, "<span data-swhgajax=\"true\" data-swhgcontainer=\"");

                    WriteTo(@__razor_helper_writer, webGrid.AjaxUpdateContainerId);

                    WriteLiteralTo(@__razor_helper_writer, "\" data-swhgcallback=\"");

                    WriteTo(@__razor_helper_writer, webGrid.AjaxUpdateCallback);

                    WriteLiteralTo(@__razor_helper_writer, "\">\r\n");
                }

                if (ModeEnabled(mode, WebGridPagerModes.FirstLast) && currentPage > 1)
                {
                    if (String.IsNullOrEmpty(firstText))
                    {
                        firstText = "<<";
                    }

                    WriteTo(@__razor_helper_writer, GridLink(webGrid, webGrid.GetPageUrl(0), firstText));

                    WriteTo(@__razor_helper_writer, Raw(" "));
                }

                if (ModeEnabled(mode, WebGridPagerModes.NextPrevious) && currentPage > 0)
                {
                    if (String.IsNullOrEmpty(previousText))
                    {
                        previousText = "<";
                    }

                    WriteTo(@__razor_helper_writer, GridLink(webGrid, webGrid.GetPageUrl(currentPage - 1), previousText));

                    WriteTo(@__razor_helper_writer, Raw(" "));
                }

                if (ModeEnabled(mode, WebGridPagerModes.Numeric) && (totalPages > 1))
                {
                    int last = currentPage + (numericLinksCount / 2);
                    int first = last - numericLinksCount + 1;
                    if (last > lastPage)
                    {
                        first -= last - lastPage;
                        last = lastPage;
                    }
                    if (first < 0)
                    {
                        last = Math.Min(last + (0 - first), lastPage);
                        first = 0;
                    }
                    for (int i = first; i <= last; i++)
                    {
                        var pageText = (i + 1).ToString(CultureInfo.InvariantCulture);
                        if (i == currentPage)
                        {
                            WriteTo(@__razor_helper_writer, pageText);
                        }
                        else
                        {
                            WriteTo(@__razor_helper_writer, GridLink(webGrid, webGrid.GetPageUrl(i), pageText));
                        }

                        WriteTo(@__razor_helper_writer, Raw(" "));
                    }
                }

                if (ModeEnabled(mode, WebGridPagerModes.NextPrevious) && (currentPage < lastPage))
                {
                    if (String.IsNullOrEmpty(nextText))
                    {
                        nextText = ">";
                    }

                    WriteTo(@__razor_helper_writer, GridLink(webGrid, webGrid.GetPageUrl(currentPage + 1), nextText));

                    WriteTo(@__razor_helper_writer, Raw(" "));
                }

                if (ModeEnabled(mode, WebGridPagerModes.FirstLast) && (currentPage < lastPage - 1))
                {
                    if (String.IsNullOrEmpty(lastText))
                    {
                        lastText = ">>";
                    }

                    WriteTo(@__razor_helper_writer, GridLink(webGrid, webGrid.GetPageUrl(lastPage), lastText));
                }

                if (renderAjaxContainer && webGrid.IsAjaxEnabled)
                {
                    WriteLiteralTo(@__razor_helper_writer, "        ");

                    WriteLiteralTo(@__razor_helper_writer, "</span>\r\n");
                }
            });
        }

        private static readonly object _gridScriptRenderedKey = new object();

        private static bool IsGridScriptRendered(HttpContext context)
        {
            if (context.Items.TryGetValue(_gridScriptRenderedKey, out var value))
            {
                return (bool)value;
            }

            return false;
        }

        private static void SetGridScriptRendered(HttpContext context, bool value)
        {
            context.Items[_gridScriptRenderedKey] = value;
        }

        private static bool ShowSortableColumnHeader(WebGrid grid, WebGridColumn column)
        {
            return grid.CanSort && column.CanSort && !column.ColumnName.IsEmpty();
        }

        public static IHtmlContent GridLink(WebGrid webGrid, string url, string text)
        {
            TagBuilder builder = new TagBuilder("a");
            builder.InnerHtml.SetContent(text);
            builder.MergeAttribute("href", url);
            if (webGrid.IsAjaxEnabled)
            {
                builder.MergeAttribute("data-swhglnk", "true");
            }

            builder.TagRenderMode = TagRenderMode.Normal;
            return builder;
        }

        private static IHtmlContent Raw(string text)
        {
            return new HtmlString(text);
        }

        private static IHtmlContent RawJS(string text)
        {
            return new HtmlString(HttpUtility.JavaScriptStringEncode(text));
        }

        private static IHtmlContent CssClass(string className)
        {
            return new HtmlString((!className.IsEmpty()) ? " class=\"" + HttpUtility.HtmlAttributeEncode(className) + "\"" : String.Empty);
        }

        private static string GetRowStyle(WebGrid webGrid, int rowIndex, string rowStyle, string alternatingRowStyle, string selectedRowStyle)
        {
            StringBuilder style = new StringBuilder();

            if (rowIndex % 2 == 0)
            {
                if (!String.IsNullOrEmpty(rowStyle))
                {
                    style.Append(rowStyle);
                }
            }
            else
            {
                if (!String.IsNullOrEmpty(alternatingRowStyle))
                {
                    style.Append(alternatingRowStyle);
                }
            }

            if (!String.IsNullOrEmpty(selectedRowStyle) && (rowIndex == webGrid.SelectedIndex))
            {
                if (style.Length > 0)
                {
                    style.Append(" ");
                }
                style.Append(selectedRowStyle);
            }
            return style.ToString();
        }

        private static HelperResult Format(Func<dynamic, object> format, dynamic arg)
        {
            var result = format(arg);
            return new HelperResult(tw =>
            {
                var helper = result as HelperResult;
                if (helper != null)
                {
                    helper.WriteTo(tw);
                    return;
                }
                IHtmlContent htmlString = result as IHtmlContent;
                if (htmlString != null)
                {
                    tw.Write(htmlString);
                    return;
                }
                if (result != null)
                {
                    tw.Write(HttpUtility.HtmlEncode(result));
                }
            });
        }

        private static IHtmlContent PrintAttributes(IDictionary<string, object> attributes)
        {
            var builder = new StringBuilder();
            foreach (var item in attributes)
            {
                var value = Convert.ToString(item.Value, CultureInfo.InvariantCulture);
                builder.Append(' ')
                    .Append(HttpUtility.HtmlEncode(item.Key))
                    .Append("=\"")
                    .Append(HttpUtility.HtmlAttributeEncode(value))
                    .Append('"');
            }
            return new HtmlString(builder.ToString());
        }

        private static bool ModeEnabled(WebGridPagerModes mode, WebGridPagerModes modeCheck)
        {
            return (mode & modeCheck) == modeCheck;
        }

        private static void WriteLiteralTo(System.IO.TextWriter writer, string content)
        {
            if (content != null)
            {
                writer.Write(content);
            }
        }

        private static void WriteTo(System.IO.TextWriter writer, string content)
        {
            if (content != null)
            {
                writer.Write(HttpUtility.HtmlEncode(content));
            }
        }

        private static void WriteTo(System.IO.TextWriter writer, IHtmlContent content)
        {
            if (content != null)
            {
                content.WriteTo(writer, Text.Encodings.Web.HtmlEncoder.Default);
            }
        }
    }
}