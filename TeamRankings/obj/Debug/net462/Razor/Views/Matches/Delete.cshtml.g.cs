#pragma checksum "C:\Users\WidowSwitch\Source\Repos\TeamRankings\TeamRankings\Views\Matches\Delete.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7104ebe48a06f819540cff61af1df181b019aa3c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Matches_Delete), @"mvc.1.0.view", @"/Views/Matches/Delete.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Matches/Delete.cshtml", typeof(AspNetCore.Views_Matches_Delete))]
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
#line 1 "C:\Users\WidowSwitch\Source\Repos\TeamRankings\TeamRankings\Views\_ViewImports.cshtml"
using TeamRankings;

#line default
#line hidden
#line 2 "C:\Users\WidowSwitch\Source\Repos\TeamRankings\TeamRankings\Views\_ViewImports.cshtml"
using TeamRankings.ViewModel;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7104ebe48a06f819540cff61af1df181b019aa3c", @"/Views/Matches/Delete.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bc38f12d32b0313e68f51de6227b330b2c878999", @"/Views/_ViewImports.cshtml")]
    public class Views_Matches_Delete : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<TeamRankings.ViewModel.MatchViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("match-Id"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", "hidden", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(46, 673, true);
            WriteLiteral(@"
<div id=""match-delete-modal"" class=""modal fade"" role=""dialog"">
    <div class=""modal-dialog"">
        <!-- Modal content-->
        <div class=""modal-content"">
            <div class=""modal-header"">
                <h5 class=""modal-title"">Delete</h5>
                <button type=""button"" class=""close"" data-dismiss=""modal"">&times;</button>
            </div>
            <div class=""modal-body"">

                <h3>Are you sure you want to delete this?</h3>
                <div>
                    <h4>Team</h4>
                    <hr />
                    <dl class=""row"">
                        <dt class=""col-sm-2"">
                            ");
            EndContext();
            BeginContext(720, 49, false);
#line 19 "C:\Users\WidowSwitch\Source\Repos\TeamRankings\TeamRankings\Views\Matches\Delete.cshtml"
                       Write(Html.DisplayNameFor(model => model.MatchDateTime));

#line default
#line hidden
            EndContext();
            BeginContext(769, 109, true);
            WriteLiteral("\r\n                        </dt>\r\n                        <dd class=\"col-sm-10\">\r\n                            ");
            EndContext();
            BeginContext(879, 37, false);
#line 22 "C:\Users\WidowSwitch\Source\Repos\TeamRankings\TeamRankings\Views\Matches\Delete.cshtml"
                       Write(Html.DisplayFor(model => model.TeamA));

#line default
#line hidden
            EndContext();
            BeginContext(916, 108, true);
            WriteLiteral("\r\n                        </dd>\r\n                        <dt class=\"col-sm-2\">\r\n                            ");
            EndContext();
            BeginContext(1025, 41, false);
#line 25 "C:\Users\WidowSwitch\Source\Repos\TeamRankings\TeamRankings\Views\Matches\Delete.cshtml"
                       Write(Html.DisplayNameFor(model => model.TeamB));

#line default
#line hidden
            EndContext();
            BeginContext(1066, 109, true);
            WriteLiteral("\r\n                        </dt>\r\n                        <dd class=\"col-sm-10\">\r\n                            ");
            EndContext();
            BeginContext(1176, 42, false);
#line 28 "C:\Users\WidowSwitch\Source\Repos\TeamRankings\TeamRankings\Views\Matches\Delete.cshtml"
                       Write(Html.DisplayFor(model => model.TeamAScore));

#line default
#line hidden
            EndContext();
            BeginContext(1218, 108, true);
            WriteLiteral("\r\n                        </dd>\r\n                        <dt class=\"col-sm-2\">\r\n                            ");
            EndContext();
            BeginContext(1327, 46, false);
#line 31 "C:\Users\WidowSwitch\Source\Repos\TeamRankings\TeamRankings\Views\Matches\Delete.cshtml"
                       Write(Html.DisplayNameFor(model => model.TeamAScore));

#line default
#line hidden
            EndContext();
            BeginContext(1373, 62, true);
            WriteLiteral("\r\n                        </dt>\r\n                    </dl>\r\n\r\n");
            EndContext();
#line 35 "C:\Users\WidowSwitch\Source\Repos\TeamRankings\TeamRankings\Views\Matches\Delete.cshtml"
                     using (Html.BeginForm(null, null, FormMethod.Post, new { id = "delete-match-form" }))
                    {

#line default
#line hidden
            BeginContext(1566, 78, true);
            WriteLiteral("                        <div class=\"form-group\">\r\n                            ");
            EndContext();
            BeginContext(1644, 50, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "7104ebe48a06f819540cff61af1df181b019aa3c7463", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
#line 38 "C:\Users\WidowSwitch\Source\Repos\TeamRankings\TeamRankings\Views\Matches\Delete.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.Id);

#line default
#line hidden
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1694, 150, true);
            WriteLiteral("\r\n                            <input id=\"match-delete-submit\" type=\"submit\" value=\"Delete\" class=\"btn btn-danger\" />\r\n                        </div>\r\n");
            EndContext();
#line 41 "C:\Users\WidowSwitch\Source\Repos\TeamRankings\TeamRankings\Views\Matches\Delete.cshtml"
                    }

#line default
#line hidden
            BeginContext(1867, 80, true);
            WriteLiteral("                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<TeamRankings.ViewModel.MatchViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
