#pragma checksum "C:\Users\user\Desktop\FooYes\FooYes\Areas\Manage\Views\Restaurant\CommentDetails.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "785ad73c329b91ff9e0161150ca62e8ed5e4909a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Manage_Views_Restaurant_CommentDetails), @"mvc.1.0.view", @"/Areas/Manage/Views/Restaurant/CommentDetails.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 3 "C:\Users\user\Desktop\FooYes\FooYes\Areas\Manage\Views\_ViewImports.cshtml"
using FooYes.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\user\Desktop\FooYes\FooYes\Areas\Manage\Views\_ViewImports.cshtml"
using FooYes.Areas.Manage.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"785ad73c329b91ff9e0161150ca62e8ed5e4909a", @"/Areas/Manage/Views/Restaurant/CommentDetails.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0eaf02206599606dde6acadf555e540d635aed53", @"/Areas/Manage/Views/_ViewImports.cshtml")]
    public class Areas_Manage_Views_Restaurant_CommentDetails : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Comment>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "acceptcomment", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-success comment-accept-button"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "rejectcomment", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-danger comment-reject-button"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\user\Desktop\FooYes\FooYes\Areas\Manage\Views\Restaurant\CommentDetails.cshtml"
  
    ViewData["Title"] = "Comment Details";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"container\">\r\n    <div class=\"card\">\r\n        <div class=\"card-body\">\r\n            <h1 class=\"mb-3\">");
#nullable restore
#line 9 "C:\Users\user\Desktop\FooYes\FooYes\Areas\Manage\Views\Restaurant\CommentDetails.cshtml"
                        Write(Model.AppUser.UserName);

#line default
#line hidden
#nullable disable
            WriteLiteral("\'s review for ");
#nullable restore
#line 9 "C:\Users\user\Desktop\FooYes\FooYes\Areas\Manage\Views\Restaurant\CommentDetails.cshtml"
                                                             Write(Model.Restaurant.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n            <h6 class=\"card-title\">Title: ");
#nullable restore
#line 10 "C:\Users\user\Desktop\FooYes\FooYes\Areas\Manage\Views\Restaurant\CommentDetails.cshtml"
                                     Write(Model.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h6>\r\n            <h6 class=\"card-title\">Text: ");
#nullable restore
#line 11 "C:\Users\user\Desktop\FooYes\FooYes\Areas\Manage\Views\Restaurant\CommentDetails.cshtml"
                                    Write(Model.Text);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </h6>\r\n            <h6 class=\"card-title\">Rate: ");
#nullable restore
#line 12 "C:\Users\user\Desktop\FooYes\FooYes\Areas\Manage\Views\Restaurant\CommentDetails.cshtml"
                                    Write(Model.Rate);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </h6>\r\n            <h6 class=\"card-title\">Created At: ");
#nullable restore
#line 13 "C:\Users\user\Desktop\FooYes\FooYes\Areas\Manage\Views\Restaurant\CommentDetails.cshtml"
                                          Write(Model.CreatedAt.ToString("HH:mm dd MMM, yyyy"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</h6>\r\n");
#nullable restore
#line 14 "C:\Users\user\Desktop\FooYes\FooYes\Areas\Manage\Views\Restaurant\CommentDetails.cshtml"
             if (Model.Status != null)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <h6 class=\"card-title\">Admin note: ");
#nullable restore
#line 16 "C:\Users\user\Desktop\FooYes\FooYes\Areas\Manage\Views\Restaurant\CommentDetails.cshtml"
                                              Write(Model.AdminNote);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h6>\r\n");
#nullable restore
#line 17 "C:\Users\user\Desktop\FooYes\FooYes\Areas\Manage\Views\Restaurant\CommentDetails.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("            <h6 class=\"card-title\">\r\n                Status:\r\n");
#nullable restore
#line 20 "C:\Users\user\Desktop\FooYes\FooYes\Areas\Manage\Views\Restaurant\CommentDetails.cshtml"
                 if (Model.Status == null)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <span class=\"badge badge-warning\">Pending</span>\r\n");
#nullable restore
#line 23 "C:\Users\user\Desktop\FooYes\FooYes\Areas\Manage\Views\Restaurant\CommentDetails.cshtml"
                }
                else if (Model.Status == true)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <span class=\"badge badge-success\">Accepted</span>\r\n");
#nullable restore
#line 27 "C:\Users\user\Desktop\FooYes\FooYes\Areas\Manage\Views\Restaurant\CommentDetails.cshtml"
                }
                else
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <span class=\"badge badge-danger\">Rejected</span>\r\n");
#nullable restore
#line 31 "C:\Users\user\Desktop\FooYes\FooYes\Areas\Manage\Views\Restaurant\CommentDetails.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </h6>\r\n");
#nullable restore
#line 33 "C:\Users\user\Desktop\FooYes\FooYes\Areas\Manage\Views\Restaurant\CommentDetails.cshtml"
             if (Model.Status == null)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "785ad73c329b91ff9e0161150ca62e8ed5e4909a9463", async() => {
                WriteLiteral(@"
                    <div class=""form-row"">
                        <div class=""form-group col-md-6"">
                            <label for=""note"">Note</label>
                            <textarea name=""note"" class=""form-control admin-note""></textarea>
                            <span class=""text-danger admin-note-validation""></span>
                        </div>
                    </div>
                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "785ad73c329b91ff9e0161150ca62e8ed5e4909a11140", async() => {
                WriteLiteral(" Accept");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-commentId", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 44 "C:\Users\user\Desktop\FooYes\FooYes\Areas\Manage\Views\Restaurant\CommentDetails.cshtml"
                                                       WriteLiteral(Model.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["commentId"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-commentId", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["commentId"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "785ad73c329b91ff9e0161150ca62e8ed5e4909a13443", async() => {
                WriteLiteral("Reject");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-commentId", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 45 "C:\Users\user\Desktop\FooYes\FooYes\Areas\Manage\Views\Restaurant\CommentDetails.cshtml"
                                                       WriteLiteral(Model.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["commentId"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-commentId", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["commentId"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 46 "C:\Users\user\Desktop\FooYes\FooYes\Areas\Manage\Views\Restaurant\CommentDetails.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </div>\r\n    </div>\r\n</div>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public Microsoft.AspNetCore.Identity.UserManager<AppUser> userManager { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Comment> Html { get; private set; }
    }
}
#pragma warning restore 1591
