using MarkdownSharp;
using Sitecore.Data;
using Sitecore.Diagnostics;
using Sitecore.Pipelines.RenderField;
using Sitecore.WordOCX;

namespace SCUG.MarkdownField
{
    public class MarkdownFieldRender
    {
        public void Process(RenderFieldArgs args)
        {
            Assert.ArgumentNotNull(args, "args");

            if (!string.IsNullOrEmpty(args.FieldValue))
            {
                args.Result.FirstPart = args.FieldValue;
            }
            else
            {
                args.Result.FirstPart = args.Item[args.FieldName];
            }

            if (args.FieldTypeKey == "rich text")
            {
                WordFieldValue wordFieldValue = WordFieldValue.Parse(args.Result.FirstPart);
                if (wordFieldValue.BlobId != ID.Null)
                {
                    args.Result.FirstPart = wordFieldValue.GetHtmlWithStyles();
                }
            }

            if (args.FieldTypeKey == "markdownfield")
            {
                var markdown = new Markdown();

                args.Result.FirstPart = markdown.Transform(args.FieldValue);
            }
        }
    }
}