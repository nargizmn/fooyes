#pragma checksum "C:\Users\user\Desktop\FooYes\FooYes\Views\Order\SeeOrders.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "fdbf2237db9a25c5f426034848afd9fc93d104fb"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Order_SeeOrders), @"mvc.1.0.view", @"/Views/Order/SeeOrders.cshtml")]
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
#line 3 "C:\Users\user\Desktop\FooYes\FooYes\Views\_ViewImports.cshtml"
using FooYes.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\user\Desktop\FooYes\FooYes\Views\_ViewImports.cshtml"
using FooYes.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fdbf2237db9a25c5f426034848afd9fc93d104fb", @"/Views/Order/SeeOrders.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7e493b7a2b24c1030fa730370b34b374d2dd251b", @"/Views/_ViewImports.cshtml")]
    public class Views_Order_SeeOrders : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Order>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "detail", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("color:white;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("page-link"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "seeorders", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("tabindex", new global::Microsoft.AspNetCore.Html.HtmlString("-1"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("page-link "), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\user\Desktop\FooYes\FooYes\Views\Order\SeeOrders.cshtml"
  
    ViewBag.HeaderClass = "white-header";
    int prevPage = ViewBag.SelectedPage - 1;
    int nextPage = ViewBag.SelectedPage + 1;
    int count = (ViewBag.SelectedPage - 1) * 3 + 1;

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""container py-5 justify-content-center"">
    <h1 class=""py-2"" style=""color: #222;"">Your Recent Orders</h1>
    <table class=""table table-hover"">
        <thead>
            <tr>
                <th scope=""col"">#</th>
                <th scope=""col"">Restaurant</th>
                <th scope=""col"">Created At</th>
                <th scope=""col"">Status</th>
                <th scope=""col""></th>
            </tr>
        </thead>
        <tbody>
");
#nullable restore
#line 22 "C:\Users\user\Desktop\FooYes\FooYes\Views\Order\SeeOrders.cshtml"
             foreach (var item in Model)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <th scope=\"row\">");
#nullable restore
#line 25 "C:\Users\user\Desktop\FooYes\FooYes\Views\Order\SeeOrders.cshtml"
                                Write(count++);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                    <td>");
#nullable restore
#line 26 "C:\Users\user\Desktop\FooYes\FooYes\Views\Order\SeeOrders.cshtml"
                   Write(item.OrderItems.FirstOrDefault().Meal.Restaurant.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 27 "C:\Users\user\Desktop\FooYes\FooYes\Views\Order\SeeOrders.cshtml"
                   Write(item.CreatedAt.ToString("HH:mm dd MMM yyyy"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>\r\n");
#nullable restore
#line 29 "C:\Users\user\Desktop\FooYes\FooYes\Views\Order\SeeOrders.cshtml"
                         if (item.Status == null)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <span class=\"badge\" style=\"background-color: #ffc107;color: white;\">Pending</span>\r\n");
#nullable restore
#line 32 "C:\Users\user\Desktop\FooYes\FooYes\Views\Order\SeeOrders.cshtml"
                        }
                        else if (item.Status == true)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <span class=\"badge\" style=\"background-color: #198754;color: white;\">Accepted</span>\r\n");
#nullable restore
#line 36 "C:\Users\user\Desktop\FooYes\FooYes\Views\Order\SeeOrders.cshtml"
                        }
                        else
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <span class=\"badge\" style=\"background-color: #dc3545;color: white;\">Rejected</span>\r\n");
#nullable restore
#line 40 "C:\Users\user\Desktop\FooYes\FooYes\Views\Order\SeeOrders.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </td>\r\n                    <td>");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "fdbf2237db9a25c5f426034848afd9fc93d104fb8768", async() => {
                WriteLiteral("See Details");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 42 "C:\Users\user\Desktop\FooYes\FooYes\Views\Order\SeeOrders.cshtml"
                                                 WriteLiteral(item.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</td>\r\n                </tr>\r\n");
#nullable restore
#line 44 "C:\Users\user\Desktop\FooYes\FooYes\Views\Order\SeeOrders.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </tbody>\r\n    </table>\r\n    <div class=\"filter my-5\">\r\n        <nav aria-label=\"Page navigation example\">\r\n            <ul class=\"pagination justify-content-center\">\r\n                <li");
            BeginWriteAttribute("class", " class=\"", 2041, "\"", 2099, 2);
            WriteAttributeValue("", 2049, "page-item", 2049, 9, true);
#nullable restore
#line 51 "C:\Users\user\Desktop\FooYes\FooYes\Views\Order\SeeOrders.cshtml"
WriteAttributeValue(" ", 2058, ViewBag.SelectedPage==1?"disabled":"", 2059, 40, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "fdbf2237db9a25c5f426034848afd9fc93d104fb11993", async() => {
                WriteLiteral("Previous");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-page", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 52 "C:\Users\user\Desktop\FooYes\FooYes\Views\Order\SeeOrders.cshtml"
                                                                     WriteLiteral(ViewBag.SelectedPage-1);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["page"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-page", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["page"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                </li>\r\n");
#nullable restore
#line 54 "C:\Users\user\Desktop\FooYes\FooYes\Views\Order\SeeOrders.cshtml"
                 if (prevPage > 1)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <li>...</li>\r\n");
#nullable restore
#line 57 "C:\Users\user\Desktop\FooYes\FooYes\Views\Order\SeeOrders.cshtml"

                    for (int i = prevPage; i <= nextPage && i <= ViewBag.TotalPage; i++)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <li");
            BeginWriteAttribute("class", " class=\"", 2492, "\"", 2554, 2);
            WriteAttributeValue("", 2500, "page-item", 2500, 9, true);
#nullable restore
#line 60 "C:\Users\user\Desktop\FooYes\FooYes\Views\Order\SeeOrders.cshtml"
WriteAttributeValue(" ", 2509, ViewBag.SelectedPage == i ? "active" : "", 2510, 44, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "fdbf2237db9a25c5f426034848afd9fc93d104fb15415", async() => {
#nullable restore
#line 60 "C:\Users\user\Desktop\FooYes\FooYes\Views\Order\SeeOrders.cshtml"
                                                                                                                                                      Write(i);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-page", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 60 "C:\Users\user\Desktop\FooYes\FooYes\Views\Order\SeeOrders.cshtml"
                                                                                                                                           WriteLiteral(i);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["page"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-page", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["page"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</li>\r\n");
#nullable restore
#line 61 "C:\Users\user\Desktop\FooYes\FooYes\Views\Order\SeeOrders.cshtml"

                    }
                    if (nextPage < ViewBag.TotalPage)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <li>...</li>\r\n");
#nullable restore
#line 66 "C:\Users\user\Desktop\FooYes\FooYes\Views\Order\SeeOrders.cshtml"

                    }
                }
                else
                {
                    for (int i = 1; i <= 3 && i <= ViewBag.TotalPage; i++)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <li");
            BeginWriteAttribute("class", " class=\"", 2985, "\"", 3047, 2);
            WriteAttributeValue("", 2993, "page-item", 2993, 9, true);
#nullable restore
#line 73 "C:\Users\user\Desktop\FooYes\FooYes\Views\Order\SeeOrders.cshtml"
WriteAttributeValue(" ", 3002, ViewBag.SelectedPage == i ? "active" : "", 3003, 44, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "fdbf2237db9a25c5f426034848afd9fc93d104fb19168", async() => {
#nullable restore
#line 73 "C:\Users\user\Desktop\FooYes\FooYes\Views\Order\SeeOrders.cshtml"
                                                                                                                                                       Write(i);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-page", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 73 "C:\Users\user\Desktop\FooYes\FooYes\Views\Order\SeeOrders.cshtml"
                                                                                                                                            WriteLiteral(i);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["page"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-page", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["page"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</li>\r\n");
#nullable restore
#line 74 "C:\Users\user\Desktop\FooYes\FooYes\Views\Order\SeeOrders.cshtml"

                    }
                    if (ViewBag.TotalPage > 3)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <li>...</li>\r\n");
#nullable restore
#line 79 "C:\Users\user\Desktop\FooYes\FooYes\Views\Order\SeeOrders.cshtml"
                    }
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                <li");
            BeginWriteAttribute("class", " class=\"", 3322, "\"", 3396, 2);
            WriteAttributeValue("", 3330, "page-item", 3330, 9, true);
#nullable restore
#line 81 "C:\Users\user\Desktop\FooYes\FooYes\Views\Order\SeeOrders.cshtml"
WriteAttributeValue(" ", 3339, ViewBag.SelectedPage==ViewBag.TotalPage?"disabled":"", 3340, 56, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "fdbf2237db9a25c5f426034848afd9fc93d104fb22802", async() => {
                WriteLiteral("Next");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-page", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 82 "C:\Users\user\Desktop\FooYes\FooYes\Views\Order\SeeOrders.cshtml"
                                                                     WriteLiteral(ViewBag.SelectedPage+1);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["page"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-page", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["page"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                </li>\r\n            </ul>\r\n        </nav>\r\n    </div>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Order>> Html { get; private set; }
    }
}
#pragma warning restore 1591
