﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http.ValueProviders;

namespace UnderstandConneg.Tech
{
    public class HeaderValueProvider : IValueProvider
    {
        private readonly HttpRequestHeaders headers;

        private Func<KeyValuePair<string, IEnumerable<string>>, string, bool> predicate =
            (header, key) =>
            {
                return header.Key.Replace("-", String.Empty)
                    .Equals(key, StringComparison.OrdinalIgnoreCase);
            };

        public HeaderValueProvider(HttpRequestHeaders headers)
        {
            this.headers = headers;
        }

        public bool ContainsPrefix(string prefix)
        {
            return headers.Any(h => predicate(h, prefix));
        }

        public ValueProviderResult GetValue(string key)
        {
            var header = headers.FirstOrDefault(h => predicate(h, key));

            if (!String.IsNullOrEmpty(header.Key))
            {
                key = header.Key; // Replace the passed-in key with the header name

                var values = headers.GetValues(key);

                if (values.Count() > 1) // We got a list of values
                    return new ValueProviderResult(values, null, CultureInfo.CurrentCulture);
                else
                {
                    // We could receive multiple value (comma separated) or just one value
                    string value = values.First();
                    values = value.Split(',').Select(x => x.Trim()).ToArray();
                    if (values.Count() > 1)
                        return new ValueProviderResult(values, null, CultureInfo.CurrentCulture);
                    else
                        return new ValueProviderResult(value, value, CultureInfo.CurrentCulture);
                }
            }

            return null;
        }
    }
}