#pragma checksum "D:\Projects\C#\MVC1\Views\Home\Buy.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "dedc922a5386f48b686bbe182e27816cd6622c32"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Buy), @"mvc.1.0.view", @"/Views/Home/Buy.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"dedc922a5386f48b686bbe182e27816cd6622c32", @"/Views/Home/Buy.cshtml")]
    public class Views_Home_Buy : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "D:\Projects\C#\MVC1\Views\Home\Buy.cshtml"
  
    ViewData["Title"] = "Оформление заказа";

#line default
#line hidden
#nullable disable
            WriteLiteral("<h2>Форма оформления покупки</h2>\r\n\r\n<form method=\"post\" class=\"form-horizontal\" role=\"form\">\r\n    <input type=\"hidden\"");
            BeginWriteAttribute("value", " value=\"", 172, "\"", 196, 1);
#nullable restore
#line 7 "D:\Projects\C#\MVC1\Views\Home\Buy.cshtml"
WriteAttributeValue("", 180, ViewBag.PhoneId, 180, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" name=""PhoneId"" />
    <p>Для оформления покупки заполните следующие поля:</p>
    <div class=""form-group"">
        <label for=""User"" class=""col-md-2 control-label"">Имя:</label>
        <div class=""col-md-4"">
            <input type=""text"" name=""User"" class=""form-control"" />
        </div>
    </div>
    <div class=""form-group"">
        <label for=""Address"" class=""col-md-2 control-label"">Адрес:</label>
        <div class=""col-md-4"">
            <input type=""text"" name=""Address"" class=""form-control"" />
        </div>
    </div>
    <div class=""form-group"">
        <label class=""col-md-2 control-label"">Телефон:</label>
        <div class=""col-md-4"">
            <input type=""text"" name=""ContactPhone"" class=""form-control"" />
        </div>
    </div>
    <div class=""form-group"">
        <div class=""col-md-offset-2 col-md-10"">
            <input type=""submit"" class=""btn btn-default"" value=""Отправить"" />
        </div>
    </div>
</form>");
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