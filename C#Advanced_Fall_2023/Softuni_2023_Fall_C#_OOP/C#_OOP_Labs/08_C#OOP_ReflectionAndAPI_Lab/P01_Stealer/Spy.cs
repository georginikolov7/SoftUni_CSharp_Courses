using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace P01_Stealer
{
    public class Spy
    {
        public string StealFieldInfo(string investigatedClassName, params string[] fieldsToInvestigate)
        {
            Type classType = Type.GetType(investigatedClassName);
            FieldInfo[] classFields = classType.GetFields((BindingFlags)60);

            Object classInstance = Activator.CreateInstance(classType, new object[] { });
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Class under investigation: {classType.FullName}");
            foreach (FieldInfo field in classFields.Where(f => fieldsToInvestigate.Contains(f.Name)))
            {
                sb.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");
            }
            return sb.ToString().Trim();
        }
        public string AnalyzeAccessModifiers(string className)
        {
            StringBuilder sb = new StringBuilder();

            Type classType = Type.GetType(className);

            FieldInfo[] fields = classType.GetFields((BindingFlags)60);
            foreach (var field in fields)
            {
                if (!field.IsPrivate)
                {
                    sb.AppendLine($"{field.Name} must be private!");
                }
            }

            MethodInfo[] publicMethods = classType.GetMethods((BindingFlags.Public | BindingFlags.Instance));
            MethodInfo[] nonPublicMethods = classType.GetMethods((BindingFlags.NonPublic | BindingFlags.Instance));
            foreach (var method in nonPublicMethods.Where(m => m.Name.StartsWith("get")))
            {
                sb.AppendLine($"{method.Name} have to be public!");
            }
            foreach (var method in publicMethods.Where(m => m.Name.StartsWith("set")))
            {
                sb.AppendLine($"{method.Name} have to be private!");
            }
            return sb.ToString().Trim();
        }

        public string RevealPrivateMethods(string className)
        {
            Type classType = Type.GetType(className);

            StringBuilder sb = new StringBuilder();
            string baseClassName = classType.BaseType.Name;
            sb.AppendLine($"All Private Methods of Class: {classType.FullName}");
            sb.AppendLine($"Base Class: {baseClassName}");
            MethodInfo[] privateMethods = classType.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);
            foreach (var method in privateMethods)
            {
                sb.AppendLine(method.Name);
            }

            return sb.ToString().Trim();
        }
        public string CollectGettersAndSetters(string className)
        {
            Type classType = Type.GetType(className);
            StringBuilder sb = new StringBuilder();

            MethodInfo[] methods=classType.GetMethods(BindingFlags.Instance| BindingFlags.Public|BindingFlags.NonPublic);
            foreach(var method in methods)
            {
                if (method.Name.StartsWith("get"))
                {
                    sb.AppendLine($"{method.Name} will return {method.ReturnType}");
                }
                else if(method.Name.StartsWith("set"))
                {
                    sb.AppendLine($"{method.Name} will set field of {method.GetParameters().FirstOrDefault().ParameterType}");
                }
            }

            return sb.ToString().Trim();
        }
    }
}
