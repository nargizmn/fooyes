#pragma checksum "C:\Users\user\Desktop\FooYes\FooYes\Areas\Manage\Views\Order\Detail.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "04c2830327b1bbedfb13819491d5997ee400c464"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Manage_Views_Order_Detail), @"mvc.1.0.view", @"/Areas/Manage/Views/Order/Detail.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"04c2830327b1bbedfb13819491d5997ee400c464", @"/Areas/Manage/Views/Order/Detail.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0eaf02206599606dde6acadf555e540d635aed53", @"/Areas/Manage/Views/_ViewImports.cshtml")]
    public class Areas_Manage_Views_Order_Detail : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Order>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-control"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("overflow:scroll;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "orderaccept", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-success order-accept-button"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "orderreject", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-danger order-reject-button"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.SelectTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\user\Desktop\FooYes\FooYes\Areas\Manage\Views\Order\Detail.cshtml"
  
    ViewData["Title"] = "Detail";
    Restaurant restaurant = ViewBag.Restaurant;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"container-fluid\">\r\n    <div class=\"card\">\r\n        <h1 style=\"padding:.5em;\">Order Details</h1>\r\n        <div class=\"card-body\">\r\n            <h6 class=\"card-title\"><strong style=\"padding-right:1em;\">User:</strong>");
#nullable restore
#line 11 "C:\Users\user\Desktop\FooYes\FooYes\Areas\Manage\Views\Order\Detail.cshtml"
                                                                                Write(Model.AppUser.Name+" "+Model.AppUser.LastName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" - ");
#nullable restore
#line 11 "C:\Users\user\Desktop\FooYes\FooYes\Areas\Manage\Views\Order\Detail.cshtml"
                                                                                                                                  Write(Model.AppUser.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h6>\r\n            <h6 class=\"card-title\"><strong style=\"padding-right:1em;\">Address:</strong>");
#nullable restore
#line 12 "C:\Users\user\Desktop\FooYes\FooYes\Areas\Manage\Views\Order\Detail.cshtml"
                                                                                  Write(Model.City);

#line default
#line hidden
#nullable disable
            WriteLiteral(" / ");
#nullable restore
#line 12 "C:\Users\user\Desktop\FooYes\FooYes\Areas\Manage\Views\Order\Detail.cshtml"
                                                                                                Write(Model.Address);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h6>\r\n            <h6 class=\"card-title\"><strong style=\"padding-right:1em;\">Phone number:</strong>");
#nullable restore
#line 13 "C:\Users\user\Desktop\FooYes\FooYes\Areas\Manage\Views\Order\Detail.cshtml"
                                                                                       Write(Model.Phone);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h6>\r\n            <h6 class=\"card-title\"><strong style=\"padding-right:1em;\">Postal Code: </strong>");
#nullable restore
#line 14 "C:\Users\user\Desktop\FooYes\FooYes\Areas\Manage\Views\Order\Detail.cshtml"
                                                                                       Write(Model.PostalCode);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h6>\r\n            <h6 class=\"card-title\"><strong style=\"padding-right:1em;\">Delivery Type:</strong>");
#nullable restore
#line 15 "C:\Users\user\Desktop\FooYes\FooYes\Areas\Manage\Views\Order\Detail.cshtml"
                                                                                        Write(Model.DeliveryType);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h6>\r\n");
#nullable restore
#line 16 "C:\Users\user\Desktop\FooYes\FooYes\Areas\Manage\Views\Order\Detail.cshtml"
             if (Model.DeliveryDate != null && Model.DeliveryTime != null)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <h6 class=\"card-title\"><strong style=\"padding-right:1em;\">Delivery Date: </strong>");
#nullable restore
#line 18 "C:\Users\user\Desktop\FooYes\FooYes\Areas\Manage\Views\Order\Detail.cshtml"
                                                                                             Write(Model.DeliveryDate);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h6>\r\n                <h6 class=\"card-title\"><strong style=\"padding-right:1em;\">Delivery Time: </strong>");
#nullable restore
#line 19 "C:\Users\user\Desktop\FooYes\FooYes\Areas\Manage\Views\Order\Detail.cshtml"
                                                                                             Write(Model.DeliveryTime);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h6>\r\n");
#nullable restore
#line 20 "C:\Users\user\Desktop\FooYes\FooYes\Areas\Manage\Views\Order\Detail.cshtml"
            }
            else
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <h6 class=\"card-title\"><strong style=\"padding-right:1em;\">Delivery Time: </strong>Now</h6>\r\n");
#nullable restore
#line 24 "C:\Users\user\Desktop\FooYes\FooYes\Areas\Manage\Views\Order\Detail.cshtml"
            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 25 "C:\Users\user\Desktop\FooYes\FooYes\Areas\Manage\Views\Order\Detail.cshtml"
             if (Model.Status != null)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <h6 class=\"card-title\"><strong style=\"padding-right:1em;\">Admin note: </strong>");
#nullable restore
#line 27 "C:\Users\user\Desktop\FooYes\FooYes\Areas\Manage\Views\Order\Detail.cshtml"
                                                                                          Write(Model.AdminNote);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h6>\r\n");
#nullable restore
#line 28 "C:\Users\user\Desktop\FooYes\FooYes\Areas\Manage\Views\Order\Detail.cshtml"
            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 29 "C:\Users\user\Desktop\FooYes\FooYes\Areas\Manage\Views\Order\Detail.cshtml"
             if (Model.Status == true)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <h6 class=\"card-title\"><strong style=\"padding-right:1em;\">Rider: </strong>");
#nullable restore
#line 31 "C:\Users\user\Desktop\FooYes\FooYes\Areas\Manage\Views\Order\Detail.cshtml"
                                                                                     Write(Model.Rider.Fullname);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h6>\r\n");
#nullable restore
#line 32 "C:\Users\user\Desktop\FooYes\FooYes\Areas\Manage\Views\Order\Detail.cshtml"
            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 33 "C:\Users\user\Desktop\FooYes\FooYes\Areas\Manage\Views\Order\Detail.cshtml"
             if (Model.DeliveryType == "Delivery")
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div class=\"form-group col-6 p-0\">\r\n                    <label for=\"exampleFormControlSelect1\"><strong style=\"padding-right:1em;\">Choose a rider for order</strong></label>\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("select", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "04c2830327b1bbedfb13819491d5997ee400c46412449", async() => {
                WriteLiteral("\r\n                    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.SelectTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
#nullable restore
#line 37 "C:\Users\user\Desktop\FooYes\FooYes\Areas\Manage\Views\Order\Detail.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.RiderId);

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 37 "C:\Users\user\Desktop\FooYes\FooYes\Areas\Manage\Views\Order\Detail.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Items = (new SelectList(ViewBag.Riders,"Id","Fullname"));

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-items", __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Items, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                    <span class=\"text-danger rider-validation\"></span>\r\n                </div>\r\n");
#nullable restore
#line 41 "C:\Users\user\Desktop\FooYes\FooYes\Areas\Manage\Views\Order\Detail.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("            <h6 class=\"card-title\">\r\n                <strong style=\"padding-right:1em;\">Status:</strong>\r\n");
#nullable restore
#line 44 "C:\Users\user\Desktop\FooYes\FooYes\Areas\Manage\Views\Order\Detail.cshtml"
                 if (Model.Status == null)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <span class=\"badge badge-warning\">Pending</span>\r\n");
#nullable restore
#line 47 "C:\Users\user\Desktop\FooYes\FooYes\Areas\Manage\Views\Order\Detail.cshtml"
                }
                else if (Model.Status == true)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <span class=\"badge badge-success\">Accepted</span>\r\n");
#nullable restore
#line 51 "C:\Users\user\Desktop\FooYes\FooYes\Areas\Manage\Views\Order\Detail.cshtml"
                }
                else
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <span class=\"badge badge-danger\">Rejected</span>\r\n");
#nullable restore
#line 55 "C:\Users\user\Desktop\FooYes\FooYes\Areas\Manage\Views\Order\Detail.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </h6>\r\n\r\n\r\n            <h5 class=\"card-title\"><strong style=\"padding-right:1em;\">Products: </strong></h5>\r\n            <ul>\r\n");
#nullable restore
#line 61 "C:\Users\user\Desktop\FooYes\FooYes\Areas\Manage\Views\Order\Detail.cshtml"
                 foreach (var item in Model.OrderItems)
                {


#line default
#line hidden
#nullable disable
            WriteLiteral("                    <li class=\"pb-3\">\r\n                        <h6 class=\"card-title mb-0\">");
#nullable restore
#line 65 "C:\Users\user\Desktop\FooYes\FooYes\Areas\Manage\Views\Order\Detail.cshtml"
                                               Write(item.Meal.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(" X ");
#nullable restore
#line 65 "C:\Users\user\Desktop\FooYes\FooYes\Areas\Manage\Views\Order\Detail.cshtml"
                                                                 Write(item.Count);

#line default
#line hidden
#nullable disable
            WriteLiteral(" - Total: ");
#nullable restore
#line 65 "C:\Users\user\Desktop\FooYes\FooYes\Areas\Manage\Views\Order\Detail.cshtml"
                                                                                       Write(Math.Round(item.Count*(restaurant.CampaignId!=null && restaurant.Campaign.ExpireDate>=DateTime.Now?(double)item.Meal.DiscountedPrice:item.Meal.Price),1));

#line default
#line hidden
#nullable disable
            WriteLiteral("$ </h6>\r\n");
#nullable restore
#line 66 "C:\Users\user\Desktop\FooYes\FooYes\Areas\Manage\Views\Order\Detail.cshtml"
                         if (item.SizeId != null)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <small class=\"card-title\">");
#nullable restore
#line 68 "C:\Users\user\Desktop\FooYes\FooYes\Areas\Manage\Views\Order\Detail.cshtml"
                                                 Write(item.Meal.MealSizes.Select(x => x.Size).FirstOrDefault(x => x.Id == item.Size.Id).Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(" - + $");
#nullable restore
#line 68 "C:\Users\user\Desktop\FooYes\FooYes\Areas\Manage\Views\Order\Detail.cshtml"
                                                                                                                                               Write(item.Count*item.Meal.MealSizes.Select(x => x.Size).FirstOrDefault(x => x.Id == item.Size.Id).ExtraCharge);

#line default
#line hidden
#nullable disable
            WriteLiteral("</small>\r\n");
#nullable restore
#line 69 "C:\Users\user\Desktop\FooYes\FooYes\Areas\Manage\Views\Order\Detail.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </li>\r\n");
#nullable restore
#line 71 "C:\Users\user\Desktop\FooYes\FooYes\Areas\Manage\Views\Order\Detail.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </ul>\r\n            <h5>Total Price : ");
#nullable restore
#line 73 "C:\Users\user\Desktop\FooYes\FooYes\Areas\Manage\Views\Order\Detail.cshtml"
                         Write(Model.TotalPrice);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n\r\n");
#nullable restore
#line 75 "C:\Users\user\Desktop\FooYes\FooYes\Areas\Manage\Views\Order\Detail.cshtml"
             if (Model.Status == null)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "04c2830327b1bbedfb13819491d5997ee400c46419847", async() => {
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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "04c2830327b1bbedfb13819491d5997ee400c46421525", async() => {
                WriteLiteral(" Accept");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 86 "C:\Users\user\Desktop\FooYes\FooYes\Areas\Manage\Views\Order\Detail.cshtml"
                                              WriteLiteral(Model.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "04c2830327b1bbedfb13819491d5997ee400c46423778", async() => {
                WriteLiteral("Reject");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 87 "C:\Users\user\Desktop\FooYes\FooYes\Areas\Manage\Views\Order\Detail.cshtml"
                                              WriteLiteral(Model.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 88 "C:\Users\user\Desktop\FooYes\FooYes\Areas\Manage\Views\Order\Detail.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Order> Html { get; private set; }
    }
}
#pragma warning restore 1591
