using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Ukeess.Models.ViewModels;

namespace Ukeess.Infrastructure
{
    [HtmlTargetElement("div", Attributes = "page-model")]
    public class PageLinkTagHelper : TagHelper
    {
        IUrlHelperFactory urlHelperFactory;

        public PageLinkTagHelper(IUrlHelperFactory helperFactory)
        {
            urlHelperFactory = helperFactory;
        }

        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext ViewContext { get; set; }

        public PagingInfo PageModel { get; set; }

        public string PageAction { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var startPage = PageModel.CurrentPage - 5;
            var endPage = PageModel.CurrentPage + 4;

            if (startPage <= 0)
            {
                endPage -= (startPage - 1);
                startPage = 1;
            }

            if (endPage > PageModel.TotalPages)
            {
                endPage = PageModel.TotalPages;
                if (endPage > 10)
                {
                    startPage = endPage - 9;
                }
            }

            var urlHelper = urlHelperFactory.GetUrlHelper(ViewContext);
            var result = new TagBuilder("div");

            if (endPage > 1)
            {
                if (PageModel.CurrentPage > 1)
                {
                    TagBuilder firstLink = new TagBuilder("a");
                    firstLink.Attributes["href"] = urlHelper.Action(PageAction, new { employeePage = 1 });
                    firstLink.InnerHtml.Append("<<");
                    result.InnerHtml.AppendHtml(firstLink);

                    TagBuilder prevLink = new TagBuilder("a");
                    prevLink.Attributes["href"] = urlHelper.Action(PageAction, new { employeePage = PageModel.CurrentPage - 1 });
                    prevLink.InnerHtml.Append(" <");
                    result.InnerHtml.AppendHtml(prevLink);
                }

                for (int i = startPage; i <= endPage; i++)
                {
                    TagBuilder tag = new TagBuilder("a");
                    tag.Attributes["href"] = urlHelper.Action(PageAction, new { employeePage = i });
                    tag.InnerHtml.Append(i.ToString());
                    result.InnerHtml.AppendHtml(tag);
                }

                if (PageModel.CurrentPage < PageModel.TotalPages)
                {
                    TagBuilder nextLink = new TagBuilder("a");
                    nextLink.Attributes["href"] = urlHelper.Action(PageAction, new { employeePage = PageModel.CurrentPage + 1 });
                    nextLink.InnerHtml.Append("> ");
                    result.InnerHtml.AppendHtml(nextLink);

                    TagBuilder lastLink = new TagBuilder("a");
                    lastLink.Attributes["href"] = urlHelper.Action(PageAction, new { employeePage = PageModel.TotalPages });
                    lastLink.InnerHtml.Append(">>");
                    result.InnerHtml.AppendHtml(lastLink);
                }
            }
            output.Content.AppendHtml(result.InnerHtml);
        }
            
    }
}
