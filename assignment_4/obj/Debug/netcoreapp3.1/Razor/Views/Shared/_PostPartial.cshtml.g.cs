#pragma checksum "/home/henriette/studie/semester_4/dat219g20v/assignments/solutions/assignment_4/Views/Shared/_PostPartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "75f0370e283e6c2ee22d9fcced3f09e0497e3782"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__PostPartial), @"mvc.1.0.view", @"/Views/Shared/_PostPartial.cshtml")]
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
#line 1 "/home/henriette/studie/semester_4/dat219g20v/assignments/solutions/assignment_4/Views/_ViewImports.cshtml"
using assignment_4;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/home/henriette/studie/semester_4/dat219g20v/assignments/solutions/assignment_4/Views/_ViewImports.cshtml"
using assignment_4.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"75f0370e283e6c2ee22d9fcced3f09e0497e3782", @"/Views/Shared/_PostPartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8e06f1f201729b32a9dbbe88b2e24a0d655162cb", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__PostPartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Post>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n<div id=\"Nickname\" class=\"Nickname\">\n ");
#nullable restore
#line 4 "/home/henriette/studie/semester_4/dat219g20v/assignments/solutions/assignment_4/Views/Shared/_PostPartial.cshtml"
Write(Model.Account.Nickname);

#line default
#line hidden
#nullable disable
            WriteLiteral(" \n</div>\n\n<div  id=\"Title\" class=\"Title\">\n  ");
#nullable restore
#line 8 "/home/henriette/studie/semester_4/dat219g20v/assignments/solutions/assignment_4/Views/Shared/_PostPartial.cshtml"
Write(Model.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("   \n</div>\n\n\n<div  id = \"Summary\" class=\"Summary\">\n ");
#nullable restore
#line 13 "/home/henriette/studie/semester_4/dat219g20v/assignments/solutions/assignment_4/Views/Shared/_PostPartial.cshtml"
Write(Model.Summary);

#line default
#line hidden
#nullable disable
            WriteLiteral("\n</div>\n\n\n<div  id = \"Content\" class=\"Content\">\n ");
#nullable restore
#line 18 "/home/henriette/studie/semester_4/dat219g20v/assignments/solutions/assignment_4/Views/Shared/_PostPartial.cshtml"
Write(Model.Content);

#line default
#line hidden
#nullable disable
            WriteLiteral("   \n</div>\n\n<div  id = \"Time\" class=\"Time\">  \n");
#nullable restore
#line 22 "/home/henriette/studie/semester_4/dat219g20v/assignments/solutions/assignment_4/Views/Shared/_PostPartial.cshtml"
Write(Model.Time.ToString("dd.MM.yyyy"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Post> Html { get; private set; }
    }
}
#pragma warning restore 1591
