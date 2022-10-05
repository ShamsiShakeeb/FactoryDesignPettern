#pragma checksum "C:\Users\BS483\source\repos\ADP\ADP\Views\Shared\Components\Report\Report.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9e080a526c0f68eb6cefc53f69fde72c840e3762"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_Report_Report), @"mvc.1.0.view", @"/Views/Shared/Components/Report/Report.cshtml")]
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
#line 1 "C:\Users\BS483\source\repos\ADP\ADP\Views\_ViewImports.cshtml"
using ADP;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\BS483\source\repos\ADP\ADP\Views\_ViewImports.cshtml"
using ADP.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\BS483\source\repos\ADP\ADP\Views\_ViewImports.cshtml"
using ViewModel;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9e080a526c0f68eb6cefc53f69fde72c840e3762", @"/Views/Shared/Components/Report/Report.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"db7f3c34218c0987c28c1ce0996e3f7e68f41618", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_Report_Report : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ReportViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"
<h1> My Report </h1>

<style>
    table, th, td {
        border: solid 1px #ddd;
        border-collapse: collapse;
        padding: 2px 3px;
        text-align: center;
    }

    th {
        font-weight: bold;
    }
</style>



<p id=""showData""></p>
<script src=""https://ajax.googleapis.com/ajax/libs/jquery/3.6.0/jquery.min.js""></script>
<script>

    function changeReport(path) {
        Table(path);
    }

    function Table(path) {

        if (path == '' || !path)
            return;

        var settings = {
            ""url"": ""https://localhost:44375/"" + path,
            ""method"": ""GET"",
            ""timeout"": 0,
        };
        $.ajax(settings).done(function (response) {

            // the json data.
            const myBooks = response.result;

            // Extract value from table header.
            // ('Book ID', 'Book Name', 'Category' and 'Price')
            let col = [];
            for (let i = 0; i < myBooks.length; i++) {
              ");
            WriteLiteral(@"  for (let key in myBooks[i]) {
                    if (col.indexOf(key) === -1) {
                        col.push(key);
                    }
                }
            }

            // Create table.
            const table = document.createElement(""table"");

            // Create table header row using the extracted headers above.
            let tr = table.insertRow(-1);                   // table row.

            for (let i = 0; i < col.length; i++) {
                let th = document.createElement(""th"");      // table header.
                th.innerHTML = col[i];
                tr.appendChild(th);
            }

            // add json data to the table as rows.
            for (let i = 0; i < myBooks.length; i++) {

                tr = table.insertRow(-1);

                for (let j = 0; j < col.length; j++) {
                    let tabCell = tr.insertCell(-1);
                    tabCell.innerHTML = myBooks[i][col[j]];
                }
            }

          ");
            WriteLiteral(@"  // Now, add the newly created table with json data, to a container.
            const divShowData = document.getElementById('showData');
            divShowData.innerHTML = """";
            divShowData.appendChild(table);

        });
    }



</script>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ReportViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591