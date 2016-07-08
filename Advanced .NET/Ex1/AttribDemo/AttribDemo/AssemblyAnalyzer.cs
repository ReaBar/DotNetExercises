using System;
using System.Reflection;

namespace AttribDemo
{
    class AssemblyAnalyzer
    {
        public bool AnalyzeAssembly(Assembly assembly)
        {
            bool result = true;
            Type[] asmType = assembly.GetTypes();
            foreach (var type in asmType)
            {
                object[] attributesInType = type.GetCustomAttributes(typeof(CodeReviewAttribute), false);
                if (attributesInType.Length > 0)
                {
                    foreach (var codeRevewAttribute in attributesInType)
                    {
                        CodeReviewAttribute att = (CodeReviewAttribute)codeRevewAttribute;
                        Console.WriteLine($"Reviewer name: {att.ReviewrName}, Review date: {att.ReviewDate}, Code Approved: {att.CodeApproved}");
                        if (att.CodeApproved == false)
                        {
                            result = false;
                        }
                    }
                }
            }

            if (asmType == null || asmType.Length == 0)
            {
                return false;
            }

            return result;
        }
    }
}
