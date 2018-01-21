// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

using System.Globalization;
using System.IO;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Html;

namespace System.Web.WebPages
{
    public class HelperResult : IHtmlContent
    {
        private readonly Action<TextWriter> _action;

        public HelperResult(Action<TextWriter> action)
        {
            if (action == null)
            {
                throw new ArgumentNullException("action");
            }
            _action = action;
        }

        public string ToHtmlString()
        {
            return ToString();
        }

        public override string ToString()
        {
            using (var writer = new StringWriter(CultureInfo.InvariantCulture))
            {
                _action(writer);
                return writer.ToString();
            }
        }

        public void WriteTo(TextWriter writer)
        {
            _action(writer);
        }

        public void WriteTo(TextWriter writer, HtmlEncoder encoder)
        {
            _action(writer);
        }
    }
}
