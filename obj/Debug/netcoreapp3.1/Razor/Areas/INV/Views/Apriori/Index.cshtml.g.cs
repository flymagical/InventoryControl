#pragma checksum "D:\i-Works\i-Projects\InventoryControl\Areas\INV\Views\Apriori\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "dfaa97db4650289f168fc2ee749ec66b766b5453"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_INV_Views_Apriori_Index), @"mvc.1.0.view", @"/Areas/INV/Views/Apriori/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"dfaa97db4650289f168fc2ee749ec66b766b5453", @"/Areas/INV/Views/Apriori/Index.cshtml")]
    public class Areas_INV_Views_Apriori_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<InventoryControl.Models.Components.PaginatedList<InventoryControl.Data.Views.vw_Request>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 3 "D:\i-Works\i-Projects\InventoryControl\Areas\INV\Views\Apriori\Index.cshtml"
  
    ViewData["Title"] = "Proses Apriori";
    Layout = "~/Views/Shared/_MainLayout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1><i class=\"fa fa-cog fa-spin\"></i> ");
#nullable restore
#line 8 "D:\i-Works\i-Projects\InventoryControl\Areas\INV\Views\Apriori\Index.cshtml"
                                 Write(ViewData["Title"]);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h1>

<div class=""card"">
    <div class=""card-body"">
        <div class=""card-form"">
            <div class=""card-label _20"">Min Support </div>
            <div class=""form-control _80"">
                : <input type=""text"" id=""txt-minsupport"" />
            </div>
        </div>
        <div class=""card-form"">
            <div class=""card-label _20"">Min Confidence </div>
            <div class=""form-control _80"">
                : <input type=""text"" id=""txt-minconfidence"" />
            </div>
        </div>
        <div class=""card-form"">
            <div class=""card-label _20"">Bidang </div>
            <div class=""form-control _80"">
                : ");
#nullable restore
#line 27 "D:\i-Works\i-Projects\InventoryControl\Areas\INV\Views\Apriori\Index.cshtml"
             Write(Html.DropDownList("KdOrg", new SelectList(ViewBag.SelectBidang, "Id", "Nama")));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
            </div>
        </div>
        <div class=""card-form"">
            <div class=""card-label _20""></div>
            <div class=""card-label _80"">
                <button type=""button"" class=""btn"" id=""btn-proses"">Proses Dengan Apriori</button>
            </div>
        </div>
    </div>
</div>
<div class=""card"" id=""card-request"">
    <div class=""card-body"">
        <table style=""width:100%;table-layout:fixed;"" >
            <thead>
                <tr>
                    <th style=""width:20%;"">Tanggal Permintaan</th>
                    <th style=""width:80%;"">Item yang diminta</th>
                </tr>

");
#nullable restore
#line 47 "D:\i-Works\i-Projects\InventoryControl\Areas\INV\Views\Apriori\Index.cshtml"
                 foreach (var item in Model.OrderByDescending(x => x.CreatedDate))
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr>\r\n                        <td style=\"width:20%;\" class=\"_center\">");
#nullable restore
#line 50 "D:\i-Works\i-Projects\InventoryControl\Areas\INV\Views\Apriori\Index.cshtml"
                                                          Write(item.StrCreatedDate);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td style=\"width:80%;\">");
#nullable restore
#line 51 "D:\i-Works\i-Projects\InventoryControl\Areas\INV\Views\Apriori\Index.cshtml"
                                          Write(item.ItemList);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    </tr>\r\n");
#nullable restore
#line 53 "D:\i-Works\i-Projects\InventoryControl\Areas\INV\Views\Apriori\Index.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </thead>\r\n        </table>\r\n");
#nullable restore
#line 56 "D:\i-Works\i-Projects\InventoryControl\Areas\INV\Views\Apriori\Index.cshtml"
          
            var prevDisabled = !Model.HasPreviousPage ? "disabled" : "";
            var nextDisabled = !Model.HasNextPage ? "disabled" : "";
        

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"pager\">\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "dfaa97db4650289f168fc2ee749ec66b766b54536833", async() => {
                WriteLiteral("Previous");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-pageNumber", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 61 "D:\i-Works\i-Projects\InventoryControl\Areas\INV\Views\Apriori\Index.cshtml"
                                             WriteLiteral(Model.PageIndex - 1);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["pageNumber"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-pageNumber", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["pageNumber"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "class", 3, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 2369, "btn", 2369, 3, true);
            AddHtmlAttributeValue(" ", 2372, "btn-default", 2373, 12, true);
#nullable restore
#line 61 "D:\i-Works\i-Projects\InventoryControl\Areas\INV\Views\Apriori\Index.cshtml"
AddHtmlAttributeValue(" ", 2384, prevDisabled, 2385, 13, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n            <span class=\"devider\"></span>\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "dfaa97db4650289f168fc2ee749ec66b766b54539694", async() => {
                WriteLiteral("\r\n                Next\r\n            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-pageNumber", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 64 "D:\i-Works\i-Projects\InventoryControl\Areas\INV\Views\Apriori\Index.cshtml"
                          WriteLiteral(Model.PageIndex + 1);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["pageNumber"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-pageNumber", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["pageNumber"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "class", 3, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 2576, "btn", 2576, 3, true);
            AddHtmlAttributeValue(" ", 2579, "btn-default", 2580, 12, true);
#nullable restore
#line 65 "D:\i-Works\i-Projects\InventoryControl\Areas\INV\Views\Apriori\Index.cshtml"
AddHtmlAttributeValue(" ", 2591, nextDisabled, 2592, 13, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n        </div>\r\n\r\n    </div>\r\n</div>\r\n<div class=\"card\">\r\n    <div class=\"card-body\">\r\n        <table id=\"tbl-support\">\r\n        </table>\r\n    </div>\r\n</div>\r\n\r\n");
            DefineSection("Styles", async() => {
                WriteLiteral(@"
    <style>
        .card-form {
            display: flex;
            margin-bottom: 10px;
        }

        ._20 {
            width: 20%;
        }

        .form-control {
            display: block;
            width: 100%;
        }

        .btn {
            height: 40px;
            color: #ffffff;
            background-color: #86134c;
            padding: 5px 10px 5px 10px;
            border-color: #86134c;
            border-radius: 25px;
        }

        .pager {
            margin-top: 40px;
        }

        .devider {
            margin-left: 20px;
        }
    </style>
");
            }
            );
            WriteLiteral("\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
    <script type=""text/javascript"">

        $(""#btn-proses"").click(function () {
            var minsupport = $(""#txt-minsupport"").val();
            var minconfidence = $(""#txt-minconfidence"").val();
            var kdOrg = $(""#KdOrg"").val();

            console.log(minsupport);
            if (minsupport == null || minsupport == """" || minconfidence == null || minconfidence == """" || kdOrg == null || kdOrg == """") {
                alert(""Minimum Support, Minimum Confidence, dan Bidang harus diisi!"");
            } else {
                console.log(""Silakan tunggu..........."");
                //showLoadPanel();
                showBusyIndicator(""body"");
                $.ajax({
                    url: '/INV/ApiApriori/ProsesApriori/',
                    method: ""POST"",
                    data:
                    {
                        minsupport: minsupport,
                        minconfidence: minconfidence,
                        kdOrg: kdOrg
                    }
     ");
                WriteLiteral(@"           })
                .done(function (result) {
                    //hideLoadPanel();
                    console.log(result);
                    result.forEach(function (item) {
                        $(""#tbl-support"").append(""<tr><td>"" + item.namaItemSet + ""</td></tr>"");
                    })
                });
            }

        });

        $(""#");
#nullable restore
#line 150 "D:\i-Works\i-Projects\InventoryControl\Areas\INV\Views\Apriori\Index.cshtml"
       Write(ViewBag.ActiveClass);

#line default
#line hidden
#nullable disable
                WriteLiteral("\").addClass(\"active\");\r\n\r\n\r\n    </script>\r\n");
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<InventoryControl.Models.Components.PaginatedList<InventoryControl.Data.Views.vw_Request>> Html { get; private set; }
    }
}
#pragma warning restore 1591
