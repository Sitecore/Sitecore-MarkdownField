using Sitecore.Web.UI.HtmlControls;
using Sitecore.Web.UI.Sheer;

namespace SCUG.MarkdownField
{
    public class MarkdownField : Control
    {
        protected override void OnLoad(System.EventArgs e)
        {
            if (!Sitecore.Context.ClientPage.IsEvent)
            {
                //create the controls (one for typing the text into, the other for the live preview).
                var memoRawText = new Sitecore.Shell.Applications.ContentEditor.Memo();
                memoRawText.ID = GetID("memoRawText");
                memoRawText.Height = 100;

                //Uses Showdown to provide a live preview. (See 'InjectScripts.cs' for how we do this)
                memoRawText.Attributes.Add("onkeyup", string.Format("javascript: var converter = new Showdown.converter(); var ePreview = document.getElementById('{0}'); ePreview.innerHTML = converter.makeHtml(this.value);", GetID("previewLiteral")));
                memoRawText.Attributes.Add("onclick", string.Format("javascript: var converter = new Showdown.converter(); var ePreview = document.getElementById('{0}'); ePreview.innerHTML = converter.makeHtml(this.value);", GetID("previewLiteral")));
                Controls.Add(memoRawText);

                var previewLiteral = new Literal("<br /><br />");
                previewLiteral.ID = GetID("previewLiteral"); ;
                Controls.Add(previewLiteral);

                //If we have a value already then populate it.
                memoRawText.Value = Value;
            }
            else
            {
                //This is the save event so get the raw value and save it to the Value field.
                var memoRawText = FindControl(GetID("memoRawText")) as Sitecore.Shell.Applications.ContentEditor.Memo;

                if (memoRawText != null)
                {
                    Value = memoRawText.Value;
                }
            }

            base.OnLoad(e);
        }

        /// <summary>
        /// Handles any messages sent from the sitecore interface.
        /// </summary>
        /// <param name="message"></param>
        public override void HandleMessage(Message message)
        {
            base.HandleMessage(message);

            if (message["id"] != ID || message.Name == null) return;

            if (message.Name == "markdown:clear")
            {
                var memoRawText = FindControl(GetID("memoRawText")) as Sitecore.Shell.Applications.ContentEditor.Memo;

                if (memoRawText != null)
                {
                    memoRawText.Value = string.Empty;
                }
                return;
            }
        }
    }
}