﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace ASP
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Web;
    using System.Web.Helpers;
    using System.Web.Mvc;
    using System.Web.Mvc.Ajax;
    using System.Web.Mvc.Html;
    using System.Web.Optimization;
    using System.Web.Routing;
    using System.Web.Security;
    using System.Web.UI;
    using System.Web.WebPages;
    
    #line 1 "..\..\Views\P_BM_DocImageDetail\_Partial_index_1.cshtml"
    using CES.Core.Models;
    
    #line default
    #line hidden    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/P_BM_DocImageDetail/_Partial_index_1.cshtml")]
    public partial class _Views_P_BM_DocImageDetail__Partial_index_1_cshtml : System.Web.Mvc.WebViewPage<PageInfo>
    {
        public _Views_P_BM_DocImageDetail__Partial_index_1_cshtml()
        {
        }
        public override void Execute()
        {
WriteLiteral("<div");

WriteLiteral(" class=\"ap-order-header\"");

WriteLiteral(" id=\"ap-order-header\"");

WriteLiteral(">\r\n    <div");

WriteLiteral(" class=\"ap-order-title\"");

WriteLiteral(">\r\n        <span");

WriteLiteral(" class=\"ap-order-type ap-underline\"");

WriteLiteral(">");

            
            #line 5 "..\..\Views\P_BM_DocImageDetail\_Partial_index_1.cshtml"
                                            Write(Model.prgName);

            
            #line default
            #line hidden
WriteLiteral("</span>\r\n        <span");

WriteLiteral(" class=\"ap-order-quicklink am-icon-share\"");

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 254), Tuple.Create("\"", 304)
, Tuple.Create(Tuple.Create("", 264), Tuple.Create("_menu.quickSettingClick1(\'", 264), true)
            
            #line 6 "..\..\Views\P_BM_DocImageDetail\_Partial_index_1.cshtml"
           , Tuple.Create(Tuple.Create("", 290), Tuple.Create<System.Object, System.Int32>(Model.prgID
            
            #line default
            #line hidden
, 290), false)
, Tuple.Create(Tuple.Create("", 302), Tuple.Create("\')", 302), true)
);

WriteLiteral("></span>\r\n    </div>\r\n    <div");

WriteLiteral(" class=\"ap-wtf-btns\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"ap-btn ap-btn-white\"");

WriteLiteral(" onclick=\"query(1)\"");

WriteLiteral(">");

            
            #line 9 "..\..\Views\P_BM_DocImageDetail\_Partial_index_1.cshtml"
                                                       Write(CES.Core.Common.CommonSupport.GetLanguageByCode("public_btn_query"));

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n        <div");

WriteLiteral(" class=\"ap-btn ap-btn-blue\"");

WriteLiteral(" id=\"btnPageConfig\"");

WriteLiteral(" onclick=\"_menu.pageConfigClick();\"");

WriteLiteral(">");

            
            #line 10 "..\..\Views\P_BM_DocImageDetail\_Partial_index_1.cshtml"
                                                                                         Write(CES.Core.Common.CommonSupport.GetLanguageByCode("public_btn_pagelayout"));

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n        <div");

WriteLiteral(" class=\"ap-btn ap-btn-white\"");

WriteLiteral(" onclick=\"_menu.exportClick()\"");

WriteLiteral(">");

            
            #line 11 "..\..\Views\P_BM_DocImageDetail\_Partial_index_1.cshtml"
                                                                  Write(CES.Core.Common.CommonSupport.GetLanguageByCode("bmis15_excel_output"));

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n        <div");

WriteLiteral(" class=\"ap-btn ap-btn-blue\"");

WriteLiteral(" onclick=\"_menu.filterClick()\"");

WriteLiteral(">");

            
            #line 12 "..\..\Views\P_BM_DocImageDetail\_Partial_index_1.cshtml"
                                                                 Write(CES.Core.Common.CommonSupport.GetLanguageByCode("public_btn_filter"));

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n    </div>\r\n</div>\r\n");

        }
    }
}
#pragma warning restore 1591
