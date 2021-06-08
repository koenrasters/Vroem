#pragma checksum "C:\Users\koenr\source\repos\Vroem\Vroem.MVC\Views\Autos\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "52d0c13d9ef632dccce766d83f0c4f8ce1ea640b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Autos_Index), @"mvc.1.0.view", @"/Views/Autos/Index.cshtml")]
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
#line 1 "C:\Users\koenr\source\repos\Vroem\Vroem.MVC\Views\_ViewImports.cshtml"
using Vroem.MVC;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\koenr\source\repos\Vroem\Vroem.MVC\Views\_ViewImports.cshtml"
using Vroem.MVC.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\koenr\source\repos\Vroem\Vroem.MVC\Views\Autos\Index.cshtml"
using Vroem.LOGIC;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\koenr\source\repos\Vroem\Vroem.MVC\Views\Autos\Index.cshtml"
using Vroem.DAL;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"52d0c13d9ef632dccce766d83f0c4f8ce1ea640b", @"/Views/Autos/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8210ad2eac27427fb350e3f2bc17cc28e9d8ea7e", @"/Views/_ViewImports.cshtml")]
    public class Views_Autos_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Vroem.MODELS.Car>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Auto", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#nullable restore
#line 4 "C:\Users\koenr\source\repos\Vroem\Vroem.MVC\Views\Autos\Index.cshtml"
  
    ViewData["Title"] = "Autos";
    UserManager _userManager = new UserManager(new DataAccess("db"));
    CarManager _carManager = new CarManager(new DataAccess("db"));

#line default
#line hidden
#nullable disable
            WriteLiteral("<h1>");
#nullable restore
#line 9 "C:\Users\koenr\source\repos\Vroem\Vroem.MVC\Views\Autos\Index.cshtml"
Write(ViewData["Title"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n\r\n");
#nullable restore
#line 11 "C:\Users\koenr\source\repos\Vroem\Vroem.MVC\Views\Autos\Index.cshtml"
 foreach (var auto in Model)
{
    var afbeelding = _carManager.GetFirstImage(auto.Id);
    string image;
    try
    {
        image = "data:image/png;base64," + Convert.ToBase64String(@afbeelding.Bestand, 0, @afbeelding.Bestand.Length);
    }
    catch (Exception e)
    {
        image = "/images/404.gif";
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"row\" style=\"border: 1px solid black; margin-bottom: 15px; box-shadow: 0 4px 8px 0 rgba(0, 0, 0, 0.2), 0 6px 20px 0 rgba(0, 0, 0, 0.19);\">\r\n        <img class=\"col-3\"");
            BeginWriteAttribute("src", " src=\"", 796, "\"", 808, 1);
#nullable restore
#line 24 "C:\Users\koenr\source\repos\Vroem\Vroem.MVC\Views\Autos\Index.cshtml"
WriteAttributeValue("", 802, image, 802, 6, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" width=\"100%\" style=\"padding: 15px;\"/>\r\n        <div class=\"col-9 row\">\r\n            <div class=\"col-6\" style=\"padding-top: 15px;\">\r\n                <p class=\"col\" >");
#nullable restore
#line 27 "C:\Users\koenr\source\repos\Vroem\Vroem.MVC\Views\Autos\Index.cshtml"
                           Write(auto.Titel);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n               \r\n");
#nullable restore
#line 29 "C:\Users\koenr\source\repos\Vroem\Vroem.MVC\Views\Autos\Index.cshtml"
                 if (auto.Bieden)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <p class=\"col\" style=\"font-weight: bold;\">Bieden vanaf: €");
#nullable restore
#line 31 "C:\Users\koenr\source\repos\Vroem\Vroem.MVC\Views\Autos\Index.cshtml"
                                                                        Write(auto.Prijs);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n");
#nullable restore
#line 32 "C:\Users\koenr\source\repos\Vroem\Vroem.MVC\Views\Autos\Index.cshtml"
                }
                else
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <p class=\"col\" style=\"font-weight: bold;\">Prijs is: €");
#nullable restore
#line 35 "C:\Users\koenr\source\repos\Vroem\Vroem.MVC\Views\Autos\Index.cshtml"
                                                                    Write(auto.Prijs);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n");
#nullable restore
#line 36 "C:\Users\koenr\source\repos\Vroem\Vroem.MVC\Views\Autos\Index.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </div>\r\n            <div class=\"col-6\" style=\" padding-top: 15px;\">\r\n                <p>De kilometerstand is: ");
#nullable restore
#line 39 "C:\Users\koenr\source\repos\Vroem\Vroem.MVC\Views\Autos\Index.cshtml"
                                    Write(auto.Kilometerstand);

#line default
#line hidden
#nullable disable
            WriteLiteral(" KM</p>\r\n                <p>Bouwjaar van deze auto: ");
#nullable restore
#line 40 "C:\Users\koenr\source\repos\Vroem\Vroem.MVC\Views\Autos\Index.cshtml"
                                      Write(auto.Bouwjaar);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                <br/>\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "52d0c13d9ef632dccce766d83f0c4f8ce1ea640b8484", async() => {
                WriteLiteral("Meer info");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 42 "C:\Users\koenr\source\repos\Vroem\Vroem.MVC\Views\Autos\Index.cshtml"
                                                              WriteLiteral(auto.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n            </div>\r\n             \r\n        </div>\r\n\r\n    </div>\r\n");
#nullable restore
#line 48 "C:\Users\koenr\source\repos\Vroem\Vroem.MVC\Views\Autos\Index.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Vroem.MODELS.Car>> Html { get; private set; }
    }
}
#pragma warning restore 1591