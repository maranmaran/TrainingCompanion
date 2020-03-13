using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Backend.API.Extensions
{
    public static class AssemblyHelper
    {
        public static Assembly[] LoadAllAssemblies(string condition = null)
        {
            var result = new List<Assembly>();

            foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                result.AddRange(assembly.LoadReferencedAssembly());
            }

            if (condition != null)
            {
                result = result.Where(x => x.FullName.Contains(condition)).ToList();
            }

            return result.ToArray();
        }

        public static List<Assembly> LoadReferencedAssembly(this Assembly assembly)
        {
            var result = new List<Assembly>();

            foreach (var name in assembly.GetReferencedAssemblies())
            {
                if (AppDomain.CurrentDomain.GetAssemblies().All(a => a.FullName != name.FullName))
                {
                    result.AddRange(Assembly.Load(name).LoadReferencedAssembly());
                }
            }

            return result;
        }
    }
}
