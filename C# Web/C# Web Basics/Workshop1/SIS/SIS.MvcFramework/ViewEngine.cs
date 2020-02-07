using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using System;

namespace SIS.MvcFramework
{
    public class ViewEngine : IViewEngine
    {
        public string GetHtml(string templateHtml, object model)
        {
            var methodCode = PrepareCSharpCode(templateHtml);
            var code = $@"using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using SIS.MvcFramework;
namespace AppViewNamespace
{{
    public class AppViewCode : IView
    {{
        public string GetHtml(object model)
        {{
            var html = new StringBuilder();

            {methodCode}

            return html.ToString();
        }}
    }}
}}";

            IView view = GetInstanceFromCode(code, model);
            string html = view.GetHtml(model);
            return html;
        }

        private IView GetInstanceFromCode(string code, object model)
        {
            CSharpCompilation.Create("AppViewAssembly")
                .WithOptions(new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary))
                .AddReferences(MetadataReference.CreateFromFile(typeof(IView).Assembly.Location))
                .AddReferences(MetadataReference.CreateFromFile(typeof(object).Assembly.Location))
                .AddReferences(MetadataReference.CreateFromFile(model.GetType().Assembly.Location));
        }

        private string PrepareCSharpCode(string templateHtml)
        {
            return string.Empty;
        }
    }
}
