#pragma checksum "/Users/BumbleBee/Documents/csye/Info6250/Gomoku/Gomoku/Views/Home/help.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2ed9b37ce25d8287a09ff1491ebbb224ef753d27"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_help), @"mvc.1.0.view", @"/Views/Home/help.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/help.cshtml", typeof(AspNetCore.Views_Home_help))]
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
#line 1 "/Users/BumbleBee/Documents/csye/Info6250/Gomoku/Gomoku/Views/_ViewImports.cshtml"
using Gomoku;

#line default
#line hidden
#line 2 "/Users/BumbleBee/Documents/csye/Info6250/Gomoku/Gomoku/Views/_ViewImports.cshtml"
using Gomoku.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2ed9b37ce25d8287a09ff1491ebbb224ef753d27", @"/Views/Home/help.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"feef37e9fff632dd4df7ba10e5e8e5e805ad79aa", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_help : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 1 "/Users/BumbleBee/Documents/csye/Info6250/Gomoku/Gomoku/Views/Home/help.cshtml"
  
    ViewData["Title"] = "Rule";

#line default
#line hidden
            BeginContext(40, 4, true);
            WriteLiteral("<h1>");
            EndContext();
            BeginContext(45, 17, false);
#line 4 "/Users/BumbleBee/Documents/csye/Info6250/Gomoku/Gomoku/Views/Home/help.cshtml"
Write(ViewData["Title"]);

#line default
#line hidden
            EndContext();
            BeginContext(62, 793, true);
            WriteLiteral(@"</h1>
<p>
    <a href=""https://en.wikipedia.org/wiki/Gomoku"">Gomoku</a> is an abstract strategy board game. Also called Gobang or Five in a Row, it is traditionally played with Go pieces (black and white stones) on a go board with 15x15 intersections.
</p>
<p>Black plays first if white did not just win, and players alternate in placing a stone of their color on an empty intersection. The winner is the first player to get an unbroken row of five stones horizontally, vertically, or diagonally.</p>
<p>Enable <a href=""https://en.wikipedia.org/wiki/List_of_Go_terms#Gote,_sente_and_tenuki"">""Sente""</a> to make the first move against Computer. The player who makes the first move was long known to have a big advantage. Disable it to let computer move first will be much more harder. </p>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
