#pragma checksum "D:\GitHub Bash\MMS\MealManagementSytem\MealManagementSytem\Views\PreviousAccount\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a4ab9f0088906d2b0d2370058ac4e05cf81b7359"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_PreviousAccount_Index), @"mvc.1.0.view", @"/Views/PreviousAccount/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a4ab9f0088906d2b0d2370058ac4e05cf81b7359", @"/Views/PreviousAccount/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"40d483ef90318bd996d551e8b23acc48c5bf4e96", @"/Views/_ViewImports.cshtml")]
    public class Views_PreviousAccount_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/PreviousAmount/PreviousAmount.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("text/javascript"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/jquery/dist/jquery.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "0", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<style type=\"text/css\">\r\n    .dialogWithDropShadow {\r\n        -webkit-box-shadow: 0px 0px 10px rgba(0, 0, 0, 0.5);\r\n        -moz-box-shadow: 0px 0px 10px rgba(0, 0, 0, 0.5);\r\n        font-weight: bold;\r\n    }\r\n</style>\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a4ab9f0088906d2b0d2370058ac4e05cf81b73594932", async() => {
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
            WriteLiteral(@"

<link rel=""stylesheet"" href=""https://cdnjs.cloudflare.com/ajax/libs/jqueryui/1.12.1/jquery-ui.min.css"" />
<link rel=""stylesheet"" href=""https://cdn.datatables.net/buttons/1.6.2/css/buttons.dataTables.min.css"" />
<link rel=""stylesheet"" href=""https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css"">
");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a4ab9f0088906d2b0d2370058ac4e05cf81b73596312", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
<script type=""text/javascript"" src=""https://cdn.datatables.net/1.12.1/js/jquery.dataTables.js""></script>

<script type=""text/javascript"" src=""https://cdn.datatables.net/buttons/2.2.3/js/dataTables.buttons.min.js""></script>
<script type=""text/javascript"" src=""https://cdnjs.cloudflare.com/ajax/libs/jszip/3.1.3/jszip.min.js""></script>
<script type=""text/javascript"" src=""https://cdnjs.cloudflare.com/ajax/libs/pdfmake/0.1.53/pdfmake.min.js""></script>
<script type=""text/javascript"" src=""https://cdnjs.cloudflare.com/ajax/libs/jszip/3.1.3/jszip.min.js""></script>
<script type=""text/javascript"" src=""https://cdnjs.cloudflare.com/ajax/libs/pdfmake/0.1.53/vfs_fonts.js""></script>
<script type=""text/javascript"" src=""https://cdn.datatables.net/buttons/2.2.3/js/buttons.html5.min.js""></script>
<script type=""text/javascript"" src=""https://cdn.datatables.net/buttons/2.2.3/js/buttons.print.min.js""></script>
<script type=""text/javascript"" src=""https://cdn.datatables.net/plug-ins/1.10.15/dataRender/datetime.js""></script>");
            WriteLiteral(@"
<script type=""text/javascript"" src=""https://cdn.datatables.net/searchpanes/2.0.2/css/searchPanes.dataTables.min.css""></script>
<script type=""text/javascript"" src=""https://cdn.datatables.net/select/1.4.0/css/select.dataTables.min.css""></script>

<script type=""text/javascript"" src=""https://cdnjs.cloudflare.com/ajax/libs/moment.js/2.29.2/moment.min.js""></script>
<script type=""text/javascript"" src=""https://cdn.datatables.net/datetime/1.1.2/js/dataTables.dateTime.min.js""></script>
<script type=""text/javascript"" src=""https://editor.datatables.net/extensions/Editor/js/dataTables.editor.min.js""></script>
<script type=""text/javascript"" src=""https://cdn.datatables.net/select/1.4.0/js/dataTables.select.min.js""></script>

<script type=""text/javascript"" src=""https://cdn.datatables.net/plug-ins/1.10.24/dataRender/datetime.js""></script>
<script type=""text/javascript"" src=""https://cdn.datatables.net/datetime/1.0.3/js/dataTables.dateTime.js""></script>
<script type=""text/javascript"" src=""https://cdn.datatables.net/p");
            WriteLiteral(@"lug-ins/1.10.24/sorting/datetime-moment.js""></script>


<script type=""text/javascript"" src=""https://cdnjs.cloudflare.com/ajax/libs/moment.js/2.8.4/moment.min.js""></script>
<script type=""text/javascript"" src=""https://cdn.datatables.net/plug-ins/1.10.24/dataRender/datetime.js""></script>


<link rel=""stylesheet"" href=""https://cdn.datatables.net/1.10.16/css/jquery.dataTables.min.css"" />
<link rel=""stylesheet"" href=""https://cdnjs.cloudflare.com/ajax/libs/jqueryui/1.12.1/jquery-ui.min.css"" />
<link rel=""stylesheet"" href=""https://cdnjs.cloudflare.com/ajax/libs/toastr.js/latest/css/toastr.min.css"" />

<script type=""text/javascript"" src=""https://cdnjs.cloudflare.com/ajax/libs/toastr.js/latest/js/toastr.min.js""></script>
<script src=""https://unpkg.com/sweetalert/dist/sweetalert.min.js""></script>
<script src=""https://kit.fontawesome.com/e19c476714.js""></script>

<div style=""float:right;margin-bottom:15px;"">
    <a id=""popup"" class=""btn btn-sm btn-success text-white"" onclick=""showPopup()""><i class=""fa fa-");
            WriteLiteral(@"plus text-white"" aria-hidden=""true""></i>New</a>
</div>

<div id=""popupDiv"" style=""display:none"">
    <div>
        <div>
            <input id=""inputFieldForPreviousAccountId"" class='form-control' type=""hidden"" />
            <label>Name</label>
            <select style=""width:100%"" class=""form-control"" id=""ddlNameList"">
                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a4ab9f0088906d2b0d2370058ac4e05cf81b735911074", async() => {
                WriteLiteral("Select Name");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n            </select>\r\n        </div>\r\n        <br>\r\n        <label>Previous Amount</label>\r\n        <input id=\"inputFieldForPreviousAmount\" class=\'form-control\' type=\"number\" />\r\n");
            WriteLiteral(@"        <br>
        <button type=""submit"" class=""btn btn-sm btn-primary"" onclick=""SavePreviousAmount()"">Confirm</button>
        <button type=""submit"" class=""btn btn-sm btn-danger"" onclick=""closePopup()"">Close</button>
    </div>
</div>

<div class=""p-4 border rounded"">
    <table id=""tblData"" class=""table table-striped table-bordered"" data-page-length='31'>
        <thead class=""thead-dark"">
            <tr class=""table-info"">
                <th>Date</th>
                <th>Member Id</th>
                <th>Member Name</th>
                <th>Amount</th>
                <th>Action</th>
            </tr>
        </thead>
        <tbody></tbody>
    </table>
</div>");
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
