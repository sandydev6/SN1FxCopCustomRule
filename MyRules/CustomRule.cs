using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.FxCop.Sdk;

namespace MyRules
{
    public class CustomRule : BaseIntrospectionRule
    {
        public CustomRule() : base("CustomRule", "Performance.AvoidUsingVirtualMethods", typeof(CustomRule).Assembly)

        {

        }

        public override ProblemCollection Check(Member member)
        {
            Method method = member as Method;
            bool isVirtual = method.IsVirtual;

            if (isVirtual)
            {
                Resolution resolution = GetResolution(new string[] { method.ToString() });
                Problems.Add(new Problem(resolution));
            }

            return Problems;
        }
    }
}
