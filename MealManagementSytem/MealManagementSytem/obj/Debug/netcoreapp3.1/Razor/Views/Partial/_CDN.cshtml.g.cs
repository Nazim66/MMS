#pragma checksum "D:\GitHub Bash\MMS\MealManagementSytem\MealManagementSytem\Views\Partial\_CDN.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b03e20a6c3d4dd466827e8c20b20b81f87618081"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Partial__CDN), @"mvc.1.0.view", @"/Views/Partial/_CDN.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b03e20a6c3d4dd466827e8c20b20b81f87618081", @"/Views/Partial/_CDN.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"40d483ef90318bd996d551e8b23acc48c5bf4e96", @"/Views/_ViewImports.cshtml")]
    public class Views_Partial__CDN : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("text/javascript"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/jquery/dist/jquery.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<link rel=""stylesheet"" href=""https://cdnjs.cloudflare.com/ajax/libs/jqueryui/1.12.1/jquery-ui.min.css"" />
<link rel=""stylesheet"" href=""https://cdn.datatables.net/buttons/1.6.2/css/buttons.dataTables.min.css"" />
<link rel=""stylesheet"" href=""https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css"">
<style>
    #popupDiv {
        font-family: cursive;
    }
</style>
");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b03e20a6c3d4dd466827e8c20b20b81f876180814264", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
<script type=""text/javascript"" src=""https://cdn.datatables.net/1.12.1/js/jquery.dataTables.js""></script>
<script type=""text/javascript"" src=""https://cdn.datatables.net/responsive/2.3.0/js/dataTables.responsive.min.js""></script>
<script type=""text/javascript"" src=""https://cdn.datatables.net/1.12.1/js/dataTables.bootstrap.min.js""></script>

<script type=""text/javascript"" src=""https://cdn.datatables.net/buttons/2.2.3/js/dataTables.buttons.min.js""></script>
<script type=""text/javascript"" src=""https://cdnjs.cloudflare.com/ajax/libs/jszip/3.1.3/jszip.min.js""></script>
<script type=""text/javascript"" src=""https://cdnjs.cloudflare.com/ajax/libs/pdfmake/0.1.53/pdfmake.min.js""></script>
<script type=""text/javascript"" src=""https://cdnjs.cloudflare.com/ajax/libs/jszip/3.1.3/jszip.min.js""></script>
<script type=""text/javascript"" src=""https://cdnjs.cloudflare.com/ajax/libs/pdfmake/0.1.53/vfs_fonts.js""></script>
<script type=""text/javascript"" src=""https://cdn.datatables.net/buttons/2.2.3/js/buttons.html5.min.js""><");
            WriteLiteral(@"/script>
<script type=""text/javascript"" src=""https://cdn.datatables.net/buttons/2.2.3/js/buttons.print.min.js""></script>
<script type=""text/javascript"" src=""https://cdn.datatables.net/plug-ins/1.10.15/dataRender/datetime.js""></script>
<script type=""text/javascript"" src=""https://cdn.datatables.net/searchpanes/2.0.2/css/searchPanes.dataTables.min.css""></script>
<script type=""text/javascript"" src=""https://cdn.datatables.net/select/1.4.0/css/select.dataTables.min.css""></script>

<script type=""text/javascript"" src=""https://cdnjs.cloudflare.com/ajax/libs/moment.js/2.29.2/moment.min.js""></script>
<script type=""text/javascript"" src=""https://cdn.datatables.net/datetime/1.1.2/js/dataTables.dateTime.min.js""></script>
<script type=""text/javascript"" src=""https://editor.datatables.net/extensions/Editor/js/dataTables.editor.min.js""></script>
<script type=""text/javascript"" src=""https://cdn.datatables.net/select/1.4.0/js/dataTables.select.min.js""></script>

<script type=""text/javascript"" src=""https://cdn.datatables");
            WriteLiteral(@".net/plug-ins/1.10.24/dataRender/datetime.js""></script>
<script type=""text/javascript"" src=""https://cdn.datatables.net/datetime/1.0.3/js/dataTables.dateTime.js""></script>
<script type=""text/javascript"" src=""https://cdn.datatables.net/plug-ins/1.10.24/sorting/datetime-moment.js""></script>


<script type=""text/javascript"" src=""https://cdnjs.cloudflare.com/ajax/libs/moment.js/2.8.4/moment.min.js""></script>
<script type=""text/javascript"" src=""https://cdn.datatables.net/plug-ins/1.10.24/dataRender/datetime.js""></script>


<link rel=""stylesheet"" href=""https://cdn.datatables.net/1.10.16/css/jquery.dataTables.min.css"" />
<link rel=""stylesheet"" href=""https://cdnjs.cloudflare.com/ajax/libs/jqueryui/1.12.1/jquery-ui.min.css"" />
<link rel=""stylesheet"" href=""https://cdnjs.cloudflare.com/ajax/libs/toastr.js/latest/css/toastr.min.css"" />

<script type=""text/javascript"" src=""https://cdnjs.cloudflare.com/ajax/libs/toastr.js/latest/js/toastr.min.js""></script>
<script src=""https://unpkg.com/sweetalert/dist/sweetal");
            WriteLiteral("ert.min.js\"></script>\r\n<script src=\"https://kit.fontawesome.com/e19c476714.js\"></script>");
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