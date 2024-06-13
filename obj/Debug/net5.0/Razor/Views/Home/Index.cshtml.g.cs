#pragma checksum "C:\Users\DTech\source\repos\DepartmentReminderApp\DepartmentReminderApp\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c6960ebdfb089c088622aa9d154b61d732b2931b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
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
#line 1 "C:\Users\DTech\source\repos\DepartmentReminderApp\DepartmentReminderApp\Views\_ViewImports.cshtml"
using DepartmentReminderApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\DTech\source\repos\DepartmentReminderApp\DepartmentReminderApp\Views\_ViewImports.cshtml"
using DepartmentReminderApp.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c6960ebdfb089c088622aa9d154b61d732b2931b", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1db715902ec22b35b12af496e03ce51fc7f8858c", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\DTech\source\repos\DepartmentReminderApp\DepartmentReminderApp\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Home";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<h2 class=""text-center mb-4"">Welcome to DepartmentReminder</h2>

<div class=""row"">
    <div class=""col-md-6"">
        <div class=""card bg-light"">
            <div class=""card-body"">
                <h5 class=""card-title"">Departments</h5>
                <p class=""card-text"">Total Departments: <span class=""font-weight-bold"">");
#nullable restore
#line 12 "C:\Users\DTech\source\repos\DepartmentReminderApp\DepartmentReminderApp\Views\Home\Index.cshtml"
                                                                                  Write(ViewData["DepartmentCount"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span></p>\r\n                <a");
            BeginWriteAttribute("href", " href=\"", 433, "\"", 474, 1);
#nullable restore
#line 13 "C:\Users\DTech\source\repos\DepartmentReminderApp\DepartmentReminderApp\Views\Home\Index.cshtml"
WriteAttributeValue("", 440, Url.Action("Index", "Department"), 440, 34, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" class=""btn btn-primary"">View Departments</a>
            </div>
        </div>
    </div>
    <div class=""col-md-6"">
        <div class=""card bg-light"">
            <div class=""card-body"">
                <h5 class=""card-title"">Reminders</h5>
                <p class=""card-text"">Total Reminders: <span class=""font-weight-bold"">");
#nullable restore
#line 21 "C:\Users\DTech\source\repos\DepartmentReminderApp\DepartmentReminderApp\Views\Home\Index.cshtml"
                                                                                Write(ViewData["ReminderCount"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span></p>\r\n                <a");
            BeginWriteAttribute("href", " href=\"", 869, "\"", 908, 1);
#nullable restore
#line 22 "C:\Users\DTech\source\repos\DepartmentReminderApp\DepartmentReminderApp\Views\Home\Index.cshtml"
WriteAttributeValue("", 876, Url.Action("Index", "Reminder"), 876, 32, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-primary\">View Reminders</a>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n");
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
