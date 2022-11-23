using System.Web.Mvc;
using Models.Models;

namespace Lab3.Views.Helpers
{
    public static class FormHelper
    {
        public static MvcHtmlString RecordForm(this HtmlHelper html)
        {
            var tb = new TagBuilder("strong");

            return MvcHtmlString.Create(tb.InnerHtml = "Hello");
        }
    }
}