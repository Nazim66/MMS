#pragma checksum "D:\GitHub Bash\MMS\MealManagementSytem\MealManagementSytem\Views\OverallCalculation\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6ccb7baea232564850e0e474312ea973831a36f8"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_OverallCalculation_Index), @"mvc.1.0.view", @"/Views/OverallCalculation/Index.cshtml")]
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
#line 1 "D:\GitHub Bash\MMS\MealManagementSytem\MealManagementSytem\Views\_ViewImports.cshtml"
using MealManagementSytem;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\GitHub Bash\MMS\MealManagementSytem\MealManagementSytem\Views\_ViewImports.cshtml"
using MealManagementSytem.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6ccb7baea232564850e0e474312ea973831a36f8", @"/Views/OverallCalculation/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"40d483ef90318bd996d551e8b23acc48c5bf4e96", @"/Views/_ViewImports.cshtml")]
    public class Views_OverallCalculation_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/OverallCalculation/OverallCalculation.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "~/Views/Partial/_CDN.cshtml", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n\r\n<style type=\"text/css\">\r\n    .dialogWithDropShadow {\r\n        -webkit-box-shadow: 0px 0px 10px rgba(0, 0, 0, 0.5);\r\n        -moz-box-shadow: 0px 0px 10px rgba(0, 0, 0, 0.5);\r\n        font-weight: bold;\r\n    }\r\n    ");
            WriteLiteral("@media (max-width: 320px) {\r\n\r\n        .table-responsive {\r\n            margin-top: 20px !important;\r\n        }\r\n    }\r\n\r\n    ");
            WriteLiteral("@media (max-width: 768px) {\r\n        .table-margin {\r\n            margin-top: 200px !important;\r\n        }\r\n    }\r\n</style>\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6ccb7baea232564850e0e474312ea973831a36f84598", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "6ccb7baea232564850e0e474312ea973831a36f85637", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"

<br/><br /><br /><br /><br />
<div class=""row"">
    <div class=""col-xs-12 col-sm-12 col-lg-12 table-margin"">
        <div class=""mt-5"">
            <div class=""row"">
                <div class=""col-4"">
                    <b>Total Expenses Of Current Month</b><input id=""overallExpenses"" style=""width:100px;"" class=""form-control"" type=""text"" />
                </div>
                <div class=""col-4"">
                    <b>Total Meal Of Current Month</b><input id=""overallMeals"" style=""width:100px;"" class=""form-control"" type=""text"" />
                </div>
                <div class=""col-4"">
                    <b>Total Meal Rate Of Current Month</b><input id=""overallmealRates"" style=""width:100px;"" class=""form-control"" type=""text"" />
                </div>
            </div>
            <br />
            <button type=""button"" onclick=""makeReport()"" class=""btn btn-sm btn-success"">Report</button>
            <br />
            <br />
            <div class=""table table-responsive"">
    ");
            WriteLiteral(@"            <table id=""tblData"" class=""table table-striped table-bordered"" data-page-length='31'>
                    <thead style=""background:#008080!important"">
                        <tr class=""table-info"">
                            <th>Id</th>
                            <th>Name</th>
                            <th>Total Deposit</th>
                            <th>Total Meals</th>
                            <th>Previous Amount</th>
                            <th>Total Cost</th>
                            <th>Current Balance</th>
                        </tr>
                    </thead>
");
#nullable restore
#line 59 "D:\GitHub Bash\MMS\MealManagementSytem\MealManagementSytem\Views\OverallCalculation\Index.cshtml"
                     foreach (var info in Model.DepoistCalculation)
                    {
                        

#line default
#line hidden
#nullable disable
#nullable restore
#line 61 "D:\GitHub Bash\MMS\MealManagementSytem\MealManagementSytem\Views\OverallCalculation\Index.cshtml"
                         foreach (var tiktok in Model.MealCalculation)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <tr>\r\n");
#nullable restore
#line 64 "D:\GitHub Bash\MMS\MealManagementSytem\MealManagementSytem\Views\OverallCalculation\Index.cshtml"
                                 if (info.MemberId == tiktok.MemberId)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <td>");
#nullable restore
#line 66 "D:\GitHub Bash\MMS\MealManagementSytem\MealManagementSytem\Views\OverallCalculation\Index.cshtml"
                                   Write(info.MemberId);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td>");
#nullable restore
#line 67 "D:\GitHub Bash\MMS\MealManagementSytem\MealManagementSytem\Views\OverallCalculation\Index.cshtml"
                                   Write(info.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td>");
#nullable restore
#line 68 "D:\GitHub Bash\MMS\MealManagementSytem\MealManagementSytem\Views\OverallCalculation\Index.cshtml"
                                   Write(info.TotalDeposit);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td>");
#nullable restore
#line 69 "D:\GitHub Bash\MMS\MealManagementSytem\MealManagementSytem\Views\OverallCalculation\Index.cshtml"
                                   Write(tiktok.TotalMeal);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td>");
#nullable restore
#line 70 "D:\GitHub Bash\MMS\MealManagementSytem\MealManagementSytem\Views\OverallCalculation\Index.cshtml"
                                   Write(info.PreviousAmount);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td>");
#nullable restore
#line 71 "D:\GitHub Bash\MMS\MealManagementSytem\MealManagementSytem\Views\OverallCalculation\Index.cshtml"
                                   Write(tiktok.TotalCost);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td>\r\n");
#nullable restore
#line 73 "D:\GitHub Bash\MMS\MealManagementSytem\MealManagementSytem\Views\OverallCalculation\Index.cshtml"
                                           double currentBalance = (info.TotalDeposit - tiktok.TotalCost + info.PreviousAmount);
                                            double convertedValue = (double)System.Math.Round(currentBalance, 2);
                                        

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <span>");
#nullable restore
#line 76 "D:\GitHub Bash\MMS\MealManagementSytem\MealManagementSytem\Views\OverallCalculation\Index.cshtml"
                                         Write(convertedValue);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                                    </td>\r\n");
#nullable restore
#line 78 "D:\GitHub Bash\MMS\MealManagementSytem\MealManagementSytem\Views\OverallCalculation\Index.cshtml"
                                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                            </tr>\r\n");
#nullable restore
#line 80 "D:\GitHub Bash\MMS\MealManagementSytem\MealManagementSytem\Views\OverallCalculation\Index.cshtml"
                        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 80 "D:\GitHub Bash\MMS\MealManagementSytem\MealManagementSytem\Views\OverallCalculation\Index.cshtml"
                         
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </table>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
