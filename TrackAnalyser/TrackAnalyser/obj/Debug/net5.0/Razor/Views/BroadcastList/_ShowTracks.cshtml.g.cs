#pragma checksum "C:\Users\reosk\Documents\GitHub\web-app-for-data-recognizing-and-analysing\TrackAnalyser\TrackAnalyser\Views\BroadcastList\_ShowTracks.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7313bb998ad9eeaf53e70425c422ee17fd916fc3"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_BroadcastList__ShowTracks), @"mvc.1.0.view", @"/Views/BroadcastList/_ShowTracks.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7313bb998ad9eeaf53e70425c422ee17fd916fc3", @"/Views/BroadcastList/_ShowTracks.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a185130b8eb82840515e46c8e46015034ee31bcd", @"/Views/_ViewImports.cshtml")]
    public class Views_BroadcastList__ShowTracks : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<TrackAnalyser.Models.ViewModels.BroadcastListViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "TrackDetails", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("list-group-item list-group-item-action"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("\r\n<div class=\"list-group\">\r\n");
#nullable restore
#line 4 "C:\Users\reosk\Documents\GitHub\web-app-for-data-recognizing-and-analysing\TrackAnalyser\TrackAnalyser\Views\BroadcastList\_ShowTracks.cshtml"
     foreach (var element in Model.TrackEmissions)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7313bb998ad9eeaf53e70425c422ee17fd916fc34686", async() => {
                WriteLiteral("\r\n            <div class=\"d-md-flex flex-md-row mb-1 mt-1\">\r\n                <div class=\"col-md-4\">\r\n                    <picture>\r\n                        <img");
                BeginWriteAttribute("src", " src=", 454, "", 484, 1);
#nullable restore
#line 10 "C:\Users\reosk\Documents\GitHub\web-app-for-data-recognizing-and-analysing\TrackAnalyser\TrackAnalyser\Views\BroadcastList\_ShowTracks.cshtml"
WriteAttributeValue("", 459, element.TrackPicturePath, 459, 25, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" class=\"rounded img-fluid img-thumbnail\" style=\"max-width:100%\">\r\n                    </picture>\r\n                </div>\r\n                <div class=\"row ml-1 flex-fill\">\r\n                    <div class=\"col-md-5 mt-2\"><p>");
#nullable restore
#line 14 "C:\Users\reosk\Documents\GitHub\web-app-for-data-recognizing-and-analysing\TrackAnalyser\TrackAnalyser\Views\BroadcastList\_ShowTracks.cshtml"
                                             Write(element.TrackDescription);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"</p></div>
                    <div class=""col-md-7 mt-2"">
                        <div class=""col"">
                            <p>
                                <svg xmlns=""http://www.w3.org/2000/svg"" width=""16"" height=""16"" fill=""currentColor"" class=""bi bi-music-note"" viewBox=""0 0 16 16"">
                                    <path d=""M9 13c0 1.105-1.12 2-2.5 2S4 14.105 4 13s1.12-2 2.5-2 2.5.895 2.5 2z"" />
                                    <path fill-rule=""evenodd"" d=""M9 3v10H8V3h1z"" />
                                    <path d=""M8 2.82a1 1 0 0 1 .804-.98l3-.6A1 1 0 0 1 13 2.22V4L8 5V2.82z"" />
                                </svg> Track: ");
#nullable restore
#line 22 "C:\Users\reosk\Documents\GitHub\web-app-for-data-recognizing-and-analysing\TrackAnalyser\TrackAnalyser\Views\BroadcastList\_ShowTracks.cshtml"
                                         Write(element.TrackName);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
                            </p>
                        </div>
                        <div class=""col"">
                            <p>
                                <svg xmlns=""http://www.w3.org/2000/svg"" width=""16"" height=""16"" fill=""currentColor"" class=""bi bi-person-fill"" viewBox=""0 0 16 16"">
                                    <path d=""M3 14s-1 0-1-1 1-4 6-4 6 3 6 4-1 1-1 1H3zm5-6a3 3 0 1 0 0-6 3 3 0 0 0 0 6z"" />
                                </svg> Artist: ");
#nullable restore
#line 29 "C:\Users\reosk\Documents\GitHub\web-app-for-data-recognizing-and-analysing\TrackAnalyser\TrackAnalyser\Views\BroadcastList\_ShowTracks.cshtml"
                                          Write(element.ArtistName);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
                            </p>
                        </div>
                        <div class=""col"">
                            <p>
                                <svg xmlns=""http://www.w3.org/2000/svg"" width=""16"" height=""16"" fill=""currentColor"" class=""bi bi-calendar-event"" viewBox=""0 0 16 16"">
                                    <path d=""M11 6.5a.5.5 0 0 1 .5-.5h1a.5.5 0 0 1 .5.5v1a.5.5 0 0 1-.5.5h-1a.5.5 0 0 1-.5-.5v-1z"" />
                                    <path d=""M3.5 0a.5.5 0 0 1 .5.5V1h8V.5a.5.5 0 0 1 1 0V1h1a2 2 0 0 1 2 2v11a2 2 0 0 1-2 2H2a2 2 0 0 1-2-2V3a2 2 0 0 1 2-2h1V.5a.5.5 0 0 1 .5-.5zM1 4v10a1 1 0 0 0 1 1h12a1 1 0 0 0 1-1V4H1z"" />
                                </svg> Start at: ");
#nullable restore
#line 37 "C:\Users\reosk\Documents\GitHub\web-app-for-data-recognizing-and-analysing\TrackAnalyser\TrackAnalyser\Views\BroadcastList\_ShowTracks.cshtml"
                                            Write(element.EmissionDate);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
                            </p>
                        </div>
                        <div class=""col"">
                            <p>
                                <svg xmlns=""http://www.w3.org/2000/svg"" width=""16"" height=""16"" fill=""currentColor"" class=""bi bi-broadcast"" viewBox=""0 0 16 16"">
                                    <path d=""M3.05 3.05a7 7 0 0 0 0 9.9.5.5 0 0 1-.707.707 8 8 0 0 1 0-11.314.5.5 0 0 1 .707.707zm2.122 2.122a4 4 0 0 0 0 5.656.5.5 0 1 1-.708.708 5 5 0 0 1 0-7.072.5.5 0 0 1 .708.708zm5.656-.708a.5.5 0 0 1 .708 0 5 5 0 0 1 0 7.072.5.5 0 1 1-.708-.708 4 4 0 0 0 0-5.656.5.5 0 0 1 0-.708zm2.122-2.12a.5.5 0 0 1 .707 0 8 8 0 0 1 0 11.313.5.5 0 0 1-.707-.707 7 7 0 0 0 0-9.9.5.5 0 0 1 0-.707zM10 8a2 2 0 1 1-4 0 2 2 0 0 1 4 0z"" />
                                </svg> Canal: ");
#nullable restore
#line 44 "C:\Users\reosk\Documents\GitHub\web-app-for-data-recognizing-and-analysing\TrackAnalyser\TrackAnalyser\Views\BroadcastList\_ShowTracks.cshtml"
                                         Write(element.CanalName);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
                            </p>
                        </div>
                        <div class=""col"">
                            <p>
                                <svg xmlns=""http://www.w3.org/2000/svg"" width=""16"" height=""16"" fill=""currentColor"" class=""bi bi-clock"" viewBox=""0 0 16 16"">
                                    <path d=""M8 3.5a.5.5 0 0 0-1 0V9a.5.5 0 0 0 .252.434l3.5 2a.5.5 0 0 0 .496-.868L8 8.71V3.5z"" />
                                    <path d=""M8 16A8 8 0 1 0 8 0a8 8 0 0 0 0 16zm7-8A7 7 0 1 1 1 8a7 7 0 0 1 14 0z"" />
                                </svg> Duration: ");
#nullable restore
#line 52 "C:\Users\reosk\Documents\GitHub\web-app-for-data-recognizing-and-analysing\TrackAnalyser\TrackAnalyser\Views\BroadcastList\_ShowTracks.cshtml"
                                            Write(element.EmissionTime);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                            </p>\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-trackId", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 6 "C:\Users\reosk\Documents\GitHub\web-app-for-data-recognizing-and-analysing\TrackAnalyser\TrackAnalyser\Views\BroadcastList\_ShowTracks.cshtml"
                                                                   WriteLiteral(element.TrackId);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["trackId"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-trackId", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["trackId"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 59 "C:\Users\reosk\Documents\GitHub\web-app-for-data-recognizing-and-analysing\TrackAnalyser\TrackAnalyser\Views\BroadcastList\_ShowTracks.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<TrackAnalyser.Models.ViewModels.BroadcastListViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
