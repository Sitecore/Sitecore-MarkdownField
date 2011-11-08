using System.Web;
using System.Web.UI;
using Sitecore;
using Sitecore.Diagnostics;
using Sitecore.Pipelines;
using Sitecore.StringExtensions;
using Page = Sitecore.Web.UI.HtmlControls.Page;

namespace SCUG.MarkdownField
{
    /// <summary>
    /// Inserts the 'showdown.js' reference into the HEAD tag of the content editor so that the live preview will work. 
    /// </summary>
    public class InjectScripts
    {
        public void Process(PipelineArgs args)
        {
            if (Context.ClientPage.IsEvent)
            {
                return;
            }

            var current = HttpContext.Current;

            if (current == null)
            {
                return;
            }

            var page = current.Handler as Page;

            if (page == null)
            {
                return;
            }

            Assert.IsNotNull(page.Header, "Content Editor <head> tag is missing runat='value'");

            var array = new []  { "/sitecore modules/Shell/MarkdownField/js/showdown.js" };

            foreach (var text in array)
            {
                page.Header.Controls.Add(new LiteralControl("<script type='text/javascript' language='javascript' src='{0}'></script>".FormatWith(new object[]{ text })));
            }
        }
    }
}