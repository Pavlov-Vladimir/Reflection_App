using System;
using System.IO;
using System.Reflection;

namespace ConsoleReflector
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(80, 50);

            Console.WriteLine("Enter full path to the assembly:");
            string path = Console.ReadLine();
            Console.WriteLine(new string('_', 50));
            
            Assembly assembly = null;
            try
            {
                assembly = Assembly.LoadFile(path);
                Console.WriteLine($"\nASSEMBLY  \"{assembly.GetName().Name}\"  HAS BEEN LOADED.\n");
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("FULL NAME OF THE ASSEMBLY :\n" + assembly.FullName);
            Console.WriteLine("\nLIST OF ALL TYPES IN THE ASSEMBLY :\n");

            Type[] types = assembly.GetTypes();
            foreach (Type type in types)
            {
                Console.WriteLine(" TYPE: " + type);
                Console.WriteLine("   Base class: " + type.BaseType);

                ShowFields(type);
                ShowMethods(type);
            }
        }

        private static void ShowFields(Type type)
        {
            FieldInfo[] fields = type.GetFields(BindingFlags.DeclaredOnly
                                                | BindingFlags.Public | BindingFlags.NonPublic
                                                | BindingFlags.Instance | BindingFlags.Static);
            if (fields != null)
            {
                foreach (FieldInfo field in fields)
                {
                    Console.WriteLine("   Field: " + field.Name);
                }
            }
        }

        private static void ShowMethods(Type type)
        {
            MethodInfo[] methods = type.GetMethods(BindingFlags.DeclaredOnly
                                                   | BindingFlags.Public | BindingFlags.NonPublic
                                                   | BindingFlags.Instance | BindingFlags.Static);
            if (methods != null)
            {
                foreach (MethodInfo method in methods)
                {
                    string methodInfo = "   Method: " + method.ReturnType.Name + " " + method.Name + "(";
                    methodInfo = ShowParameters(method, methodInfo);
                    methodInfo += ")";
                    Console.WriteLine(methodInfo);
                }
            }
        }

        private static string ShowParameters(MethodInfo method, string methodInfo)
        {
            ParameterInfo[] parameters = method.GetParameters();
            if (parameters != null)
            {
                for (int i = 0; i < parameters.Length; i++)
                {
                    methodInfo += parameters[i].ParameterType.Name + " " + parameters[i].Name;
                    if (i < parameters.Length - 1)
                        methodInfo += ", ";
                }
            }
            return methodInfo;
        }
    }
}
