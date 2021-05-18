#pragma checksum "C:\Users\reosk\Documents\GitHub\web-app-for-data-recognizing-and-analysing\TrackAnalyser\TrackAnalyser\Views\Rank\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6f3777cb1226266900084ea711692be09da09fb4"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Rank_Index), @"mvc.1.0.view", @"/Views/Rank/Index.cshtml")]
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
#line 1 "C:\Users\reosk\Documents\GitHub\web-app-for-data-recognizing-and-analysing\TrackAnalyser\TrackAnalyser\Views\_ViewImports.cshtml"
using TrackAnalyser;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\reosk\Documents\GitHub\web-app-for-data-recognizing-and-analysing\TrackAnalyser\TrackAnalyser\Views\_ViewImports.cshtml"
using TrackAnalyser.Models.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\reosk\Documents\GitHub\web-app-for-data-recognizing-and-analysing\TrackAnalyser\TrackAnalyser\Views\Rank\Index.cshtml"
using TrackAnalyser.Utilities;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6f3777cb1226266900084ea711692be09da09fb4", @"/Views/Rank/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a185130b8eb82840515e46c8e46015034ee31bcd", @"/Views/_ViewImports.cshtml")]
    public class Views_Rank_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<TrackAnalyser.Models.ViewModels.RankViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<div>\r\n    <br />\r\n    <br />\r\n    <div class=\"text-center\">\r\n        <p style=\"font-size:xx-large\">This is the top ");
#nullable restore
#line 8 "C:\Users\reosk\Documents\GitHub\web-app-for-data-recognizing-and-analysing\TrackAnalyser\TrackAnalyser\Views\Rank\Index.cshtml"
                                                 Write(StaticDetails.RANK_MAX_TRACKS_AMOUNT);

#line default
#line hidden
#nullable disable
            WriteLiteral(@" tracks </p>
    </div>
    <br />
    <br />
    <div>
        <table class=""table"">
            <thead>
                <tr>
                    <th scope=""col"">No.</th>
                    <th scope=""col"">Track Name</th>
                    <th scope=""col"">Author</th>
                    <th scope=""col"">Number of Plays</th>
                </tr>
            </thead>
            <tbody>
");
#nullable restore
#line 23 "C:\Users\reosk\Documents\GitHub\web-app-for-data-recognizing-and-analysing\TrackAnalyser\TrackAnalyser\Views\Rank\Index.cshtml"
                 foreach (var element in Model.RankElements.Select((value, index) => (value, index)))
                {
                    int no = element.index + 1;


#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr>\r\n                        <th scope=\"row\">");
#nullable restore
#line 28 "C:\Users\reosk\Documents\GitHub\web-app-for-data-recognizing-and-analysing\TrackAnalyser\TrackAnalyser\Views\Rank\Index.cshtml"
                                   Write(no);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                        <td>");
#nullable restore
#line 29 "C:\Users\reosk\Documents\GitHub\web-app-for-data-recognizing-and-analysing\TrackAnalyser\TrackAnalyser\Views\Rank\Index.cshtml"
                       Write(element.value.TrackName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 30 "C:\Users\reosk\Documents\GitHub\web-app-for-data-recognizing-and-analysing\TrackAnalyser\TrackAnalyser\Views\Rank\Index.cshtml"
                       Write(element.value.TrackArtist);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 31 "C:\Users\reosk\Documents\GitHub\web-app-for-data-recognizing-and-analysing\TrackAnalyser\TrackAnalyser\Views\Rank\Index.cshtml"
                       Write(element.value.TotalPlayback);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    </tr>\r\n");
#nullable restore
#line 33 "C:\Users\reosk\Documents\GitHub\web-app-for-data-recognizing-and-analysing\TrackAnalyser\TrackAnalyser\Views\Rank\Index.cshtml"

                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </tbody>\r\n        </table>\r\n    </div>\r\n</div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<TrackAnalyser.Models.ViewModels.RankViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591