#pragma checksum "C:\Users\hrist\source\repos\CandidatesManager\CandidatesManager\Views\Candidates\CandidatesCK.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2d503dd78552a2ac632bca585af1d067b4311c54"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Candidates_CandidatesCK), @"mvc.1.0.view", @"/Views/Candidates/CandidatesCK.cshtml")]
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
#line 1 "C:\Users\hrist\source\repos\CandidatesManager\CandidatesManager\Views\_ViewImports.cshtml"
using CandidatesManager;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\hrist\source\repos\CandidatesManager\CandidatesManager\Views\_ViewImports.cshtml"
using CandidatesManager.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2d503dd78552a2ac632bca585af1d067b4311c54", @"/Views/Candidates/CandidatesCK.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"518c9fe9371750bdef4e7920e59cecfa133fb839", @"/Views/_ViewImports.cshtml")]
    public class Views_Candidates_CandidatesCK : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<CandidatesManager.ViewModels.CandidateCKViewModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\hrist\source\repos\CandidatesManager\CandidatesManager\Views\Candidates\CandidatesCK.cshtml"
  
    ViewData["Title"] = "CandidatesCK";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<h1>?????????????????? ???? ?????????? ??????????, ???????????? ???????? 1990 ??.</h1>

<div class=""container"">
    <div class=""row"">
        <div class=""col-12 col-md-8 col-lg-12 mx-auto mt-5"">
            <table class=""table"">
                <thead>
                    <tr>
                        <th scope=""col"">?????????????? ??????????</th>
                        <th scope=""col"">??????</th>
                        <th scope=""col"">??????????</th>
                        <th scope=""col"">??????????????????????</th>
                        <th scope=""col"">??????????</th>
                        <th scope=""col"">???????? ???? ??????????????</th>
                        <th scope=""col"">??????</th>
                    </tr>
                </thead>
                <tbody>
");
#nullable restore
#line 26 "C:\Users\hrist\source\repos\CandidatesManager\CandidatesManager\Views\Candidates\CandidatesCK.cshtml"
                     foreach (var candidate in Model)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <tr>\r\n                            <td>");
#nullable restore
#line 29 "C:\Users\hrist\source\repos\CandidatesManager\CandidatesManager\Views\Candidates\CandidatesCK.cshtml"
                           Write(candidate.Number);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <th scope=\"row\">");
#nullable restore
#line 30 "C:\Users\hrist\source\repos\CandidatesManager\CandidatesManager\Views\Candidates\CandidatesCK.cshtml"
                                       Write(candidate.FirstName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 30 "C:\Users\hrist\source\repos\CandidatesManager\CandidatesManager\Views\Candidates\CandidatesCK.cshtml"
                                                            Write(candidate.MiddleInitial);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 30 "C:\Users\hrist\source\repos\CandidatesManager\CandidatesManager\Views\Candidates\CandidatesCK.cshtml"
                                                                                     Write(candidate.LastName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                            <td>");
#nullable restore
#line 31 "C:\Users\hrist\source\repos\CandidatesManager\CandidatesManager\Views\Candidates\CandidatesCK.cshtml"
                           Write(candidate.Department);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 32 "C:\Users\hrist\source\repos\CandidatesManager\CandidatesManager\Views\Candidates\CandidatesCK.cshtml"
                           Write(candidate.Education);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 33 "C:\Users\hrist\source\repos\CandidatesManager\CandidatesManager\Views\Candidates\CandidatesCK.cshtml"
                           Write(candidate.Score);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 34 "C:\Users\hrist\source\repos\CandidatesManager\CandidatesManager\Views\Candidates\CandidatesCK.cshtml"
                           Write(candidate.Birthdate);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 35 "C:\Users\hrist\source\repos\CandidatesManager\CandidatesManager\Views\Candidates\CandidatesCK.cshtml"
                           Write(candidate.Code);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        </tr>\r\n");
#nullable restore
#line 37 "C:\Users\hrist\source\repos\CandidatesManager\CandidatesManager\Views\Candidates\CandidatesCK.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </tbody>\r\n            </table>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<CandidatesManager.ViewModels.CandidateCKViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
