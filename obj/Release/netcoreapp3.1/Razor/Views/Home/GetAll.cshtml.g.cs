#pragma checksum "C:\Users\bekak\source\repos\WebApplication5\WebApplication5\Views\Home\GetAll.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "fff1b4a34dcafb53f09aacb18cb510343301d862"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_GetAll), @"mvc.1.0.view", @"/Views/Home/GetAll.cshtml")]
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
#line 1 "C:\Users\bekak\source\repos\WebApplication5\WebApplication5\Views\_ViewImports.cshtml"
using WebApplication5;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\bekak\source\repos\WebApplication5\WebApplication5\Views\_ViewImports.cshtml"
using WebApplication5.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fff1b4a34dcafb53f09aacb18cb510343301d862", @"/Views/Home/GetAll.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7ac7a6a20369a094c1643b76f0e92e19ec3cef6a", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_GetAll : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<WebApplication5.Models.ScrapperModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("\r\n<p>\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "fff1b4a34dcafb53f09aacb18cb510343301d8623448", async() => {
                WriteLiteral("განახლება");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</p>\r\n\r\n<p style=\"color:green\">განცხადებების რაოდენობა : ");
#nullable restore
#line 7 "C:\Users\bekak\source\repos\WebApplication5\WebApplication5\Views\Home\GetAll.cshtml"
                                            Write(ViewBag.StatementCount);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </p>\r\n\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                ");
#nullable restore
#line 13 "C:\Users\bekak\source\repos\WebApplication5\WebApplication5\Views\Home\GetAll.cshtml"
           Write(Html.DisplayNameFor(model => model.WebSiteName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 16 "C:\Users\bekak\source\repos\WebApplication5\WebApplication5\Views\Home\GetAll.cshtml"
           Write(Html.DisplayNameFor(model => model.HouseId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 19 "C:\Users\bekak\source\repos\WebApplication5\WebApplication5\Views\Home\GetAll.cshtml"
           Write(Html.DisplayNameFor(model => model.SquareMeter));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 22 "C:\Users\bekak\source\repos\WebApplication5\WebApplication5\Views\Home\GetAll.cshtml"
           Write(Html.DisplayNameFor(model => model.PriceOneSquareMeter));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 25 "C:\Users\bekak\source\repos\WebApplication5\WebApplication5\Views\Home\GetAll.cshtml"
           Write(Html.DisplayNameFor(model => model.PriceInUsd));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 28 "C:\Users\bekak\source\repos\WebApplication5\WebApplication5\Views\Home\GetAll.cshtml"
           Write(Html.DisplayNameFor(model => model.Address));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 31 "C:\Users\bekak\source\repos\WebApplication5\WebApplication5\Views\Home\GetAll.cshtml"
           Write(Html.DisplayNameFor(model => model.CreateDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 34 "C:\Users\bekak\source\repos\WebApplication5\WebApplication5\Views\Home\GetAll.cshtml"
           Write(Html.DisplayNameFor(model => model.JobCreate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 40 "C:\Users\bekak\source\repos\WebApplication5\WebApplication5\Views\Home\GetAll.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>\r\n                    ");
#nullable restore
#line 44 "C:\Users\bekak\source\repos\WebApplication5\WebApplication5\Views\Home\GetAll.cshtml"
               Write(Html.DisplayFor(modelItem => item.WebSiteName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n");
#nullable restore
#line 47 "C:\Users\bekak\source\repos\WebApplication5\WebApplication5\Views\Home\GetAll.cshtml"
                     if (item.WebSiteName == "MYHOME.GE")
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <a");
            BeginWriteAttribute("href", " href=\"", 1442, "\"", 1490, 2);
            WriteAttributeValue("", 1449, "https://www.myhome.ge/ka/pr/", 1449, 28, true);
#nullable restore
#line 49 "C:\Users\bekak\source\repos\WebApplication5\WebApplication5\Views\Home\GetAll.cshtml"
WriteAttributeValue("", 1477, item.HouseId, 1477, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" target=\"_blank\">");
#nullable restore
#line 49 "C:\Users\bekak\source\repos\WebApplication5\WebApplication5\Views\Home\GetAll.cshtml"
                                                                                       Write(Html.DisplayFor(modelItem => item.HouseId));

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n");
#nullable restore
#line 50 "C:\Users\bekak\source\repos\WebApplication5\WebApplication5\Views\Home\GetAll.cshtml"
                    }
                    else if (item.WebSiteName == "SS.GE")
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <a");
            BeginWriteAttribute("href", " href=\"", 1688, "\"", 1740, 2);
            WriteAttributeValue("", 1695, "https://ss.ge/ka/udzravi-qoneba/", 1695, 32, true);
#nullable restore
#line 53 "C:\Users\bekak\source\repos\WebApplication5\WebApplication5\Views\Home\GetAll.cshtml"
WriteAttributeValue("", 1727, item.HouseId, 1727, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" target=\"_blank\">");
#nullable restore
#line 53 "C:\Users\bekak\source\repos\WebApplication5\WebApplication5\Views\Home\GetAll.cshtml"
                                                                                           Write(Html.DisplayFor(modelItem => item.HouseId));

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n");
#nullable restore
#line 54 "C:\Users\bekak\source\repos\WebApplication5\WebApplication5\Views\Home\GetAll.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 57 "C:\Users\bekak\source\repos\WebApplication5\WebApplication5\Views\Home\GetAll.cshtml"
               Write(Html.DisplayFor(modelItem => item.SquareMeter));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 60 "C:\Users\bekak\source\repos\WebApplication5\WebApplication5\Views\Home\GetAll.cshtml"
               Write(Html.DisplayFor(modelItem => item.PriceOneSquareMeter));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 63 "C:\Users\bekak\source\repos\WebApplication5\WebApplication5\Views\Home\GetAll.cshtml"
               Write(Html.DisplayFor(modelItem => item.PriceInUsd));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 66 "C:\Users\bekak\source\repos\WebApplication5\WebApplication5\Views\Home\GetAll.cshtml"
               Write(Html.DisplayFor(modelItem => item.Address));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 69 "C:\Users\bekak\source\repos\WebApplication5\WebApplication5\Views\Home\GetAll.cshtml"
               Write(Html.DisplayFor(modelItem => item.CreateDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 72 "C:\Users\bekak\source\repos\WebApplication5\WebApplication5\Views\Home\GetAll.cshtml"
               Write(Html.DisplayFor(modelItem => item.JobCreate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n            </tr>\r\n");
#nullable restore
#line 75 "C:\Users\bekak\source\repos\WebApplication5\WebApplication5\Views\Home\GetAll.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<WebApplication5.Models.ScrapperModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
