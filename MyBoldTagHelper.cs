using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarAndGo.TagHelpers
{
    public class MyBoldTagHelper : TagHelper
    {
        public string Address { get; set; }
        public string Content { get; set; }

        public void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "b";
        }
    }
}