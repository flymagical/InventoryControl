#pragma checksum "D:\KULIAH\Skripsi\Project\InventoryControl\Areas\INV\Views\MovingAverage\_PartialPredictedItem.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3073f9fdf296e2663e512ea1e58d3aba30c3f4ab"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_INV_Views_MovingAverage__PartialPredictedItem), @"mvc.1.0.view", @"/Areas/INV/Views/MovingAverage/_PartialPredictedItem.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3073f9fdf296e2663e512ea1e58d3aba30c3f4ab", @"/Areas/INV/Views/MovingAverage/_PartialPredictedItem.cshtml")]
    public class Areas_INV_Views_MovingAverage__PartialPredictedItem : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<InventoryControl.Data.Views.vw_PredictedItem>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"
<table>
    <thead>
        <tr>
            <th>Bulan</th>
            <th>Tahun</th>
            <th>Bidang</th>
            <th>Nama Barang</th>
            <th>Satuan</th>
            <th>Jumlah</th>
        </tr>
    </thead>
    <tbody>
");
#nullable restore
#line 15 "D:\KULIAH\Skripsi\Project\InventoryControl\Areas\INV\Views\MovingAverage\_PartialPredictedItem.cshtml"
         if (Model.Count() > 0)
        {
            

#line default
#line hidden
#nullable disable
#nullable restore
#line 17 "D:\KULIAH\Skripsi\Project\InventoryControl\Areas\INV\Views\MovingAverage\_PartialPredictedItem.cshtml"
             foreach (var iItem in Model)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td>");
#nullable restore
#line 20 "D:\KULIAH\Skripsi\Project\InventoryControl\Areas\INV\Views\MovingAverage\_PartialPredictedItem.cshtml"
                   Write(iItem.Bulan);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 21 "D:\KULIAH\Skripsi\Project\InventoryControl\Areas\INV\Views\MovingAverage\_PartialPredictedItem.cshtml"
                   Write(iItem.Tahun);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 22 "D:\KULIAH\Skripsi\Project\InventoryControl\Areas\INV\Views\MovingAverage\_PartialPredictedItem.cshtml"
                   Write(iItem.NamaBidang);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 23 "D:\KULIAH\Skripsi\Project\InventoryControl\Areas\INV\Views\MovingAverage\_PartialPredictedItem.cshtml"
                   Write(iItem.NamaItem);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 24 "D:\KULIAH\Skripsi\Project\InventoryControl\Areas\INV\Views\MovingAverage\_PartialPredictedItem.cshtml"
                   Write(iItem.NamaSatuan);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 25 "D:\KULIAH\Skripsi\Project\InventoryControl\Areas\INV\Views\MovingAverage\_PartialPredictedItem.cshtml"
                   Write(iItem.Jumlah);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                </tr>\r\n");
#nullable restore
#line 27 "D:\KULIAH\Skripsi\Project\InventoryControl\Areas\INV\Views\MovingAverage\_PartialPredictedItem.cshtml"
            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 27 "D:\KULIAH\Skripsi\Project\InventoryControl\Areas\INV\Views\MovingAverage\_PartialPredictedItem.cshtml"
             
        }
        else
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td style=\"width:20%;height:50px\" class=\"_center\" colspan=\"6\"><span class=\"text-danger\">Tidak Ada Data</span> </td>\r\n\r\n            </tr>\r\n");
#nullable restore
#line 35 "D:\KULIAH\Skripsi\Project\InventoryControl\Areas\INV\Views\MovingAverage\_PartialPredictedItem.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </tbody>\r\n\r\n</table>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<InventoryControl.Data.Views.vw_PredictedItem>> Html { get; private set; }
    }
}
#pragma warning restore 1591