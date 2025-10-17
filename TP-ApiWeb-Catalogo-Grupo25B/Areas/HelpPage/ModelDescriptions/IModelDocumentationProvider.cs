using System;
using System.Reflection;

namespace TP_ApiWeb_Catalogo_Grupo25B.Areas.HelpPage.ModelDescriptions
{
    public interface IModelDocumentationProvider
    {
        string GetDocumentation(MemberInfo member);

        string GetDocumentation(Type type);
    }
}