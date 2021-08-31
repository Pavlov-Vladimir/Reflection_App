using System;
using System.Reflection;
using System.IO;

namespace TempConvViaReflaction_App
{
    class Program
    {
        static void Main()
        {
            Console.SetWindowSize(120, 60);
            string path = @"C:\Users\Vladimir\source\repos\Reflection_App\TemperatureConverterLibrary\bin\Debug\net5.0\TemperatureConverterLibrary.dll";
            Assembly assembly;
            try
            {
                assembly = Assembly.LoadFrom(path);
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }

            Console.WriteLine(assembly.FullName);
            Console.WriteLine(new string('-', 50));

            #region Info about types
            Type[] types = assembly.GetTypes();
            foreach (Type type in types)
            {
                Console.WriteLine("Type: " + type.Name);
                FieldInfo[] fields = type.GetFields(BindingFlags.DeclaredOnly | BindingFlags.Public
                                                    | BindingFlags.Static | BindingFlags.Instance);
                foreach (FieldInfo field in fields)
                {
                    Console.WriteLine("  Field: " + field.Name);
                }
                ConstructorInfo[] constructors = type.GetConstructors();
                foreach (ConstructorInfo constructor in constructors)
                {
                    Console.Write("  Constructor: " + type.Name);
                    ParameterInfo[] parameters = constructor.GetParameters();
                    string prms = "(";
                    for (int i = 0; i < parameters.Length; i++)
                    {
                        prms += parameters[i].ParameterType.Name + " " + parameters[i].Name;
                        if (i < parameters.Length - 1)
                            prms += ", ";
                    }
                    Console.WriteLine(prms + ")");
                }
                MethodInfo[] methods = type.GetMethods(BindingFlags.DeclaredOnly | BindingFlags.Public
                                                    | BindingFlags.Static | BindingFlags.Instance);
                foreach (MethodInfo method in methods)
                {
                    Console.Write("  Method: " + method.Name);
                    ParameterInfo[] parameters = method.GetParameters();
                    string prms = "(";
                    for (int i = 0; i < parameters.Length; i++)
                    {
                        prms += parameters[i].ParameterType.Name + " " + parameters[i].Name;
                        if (i < parameters.Length - 1)
                            prms += ", ";
                    }
                    Console.WriteLine(prms + ")");
                }
            }
            Console.WriteLine(new string('-', 50));
            #endregion

            Type Scale = assembly.GetType("TemperatureConverterLibrary.Scale", true, false);
            Array prop = Scale.GetEnumValues();

            Type Tempetature = assembly.GetType("TemperatureConverterLibrary.Temperature", true, true);
            object temp1 = Activator.CreateInstance(Tempetature);
            object temp2 = Activator.CreateInstance(Tempetature, new object[] { 33, prop.GetValue(1) });
            object temp3 = Activator.CreateInstance(Tempetature, new object[] { 77, prop.GetValue(2) });

            Console.WriteLine("Temperature via reflection:");
            Console.WriteLine(temp1);
            Console.WriteLine(temp2);
            Console.WriteLine(temp3);
            Console.WriteLine(new string('-', 50));

            Type Converter = assembly.GetType("TemperatureConverterLibrary.TemperatureConverter", true, false);
            MethodInfo convertToKelvin = Converter.GetMethod("ToKelvin");
            MethodInfo convertToFahrenheit = Converter.GetMethod("ToFahrenheit");
            object temp4 = convertToKelvin.Invoke(Converter, new object[] { temp1 });
            object temp5 = convertToFahrenheit.Invoke(Converter, new object[] { temp2 });
            Console.WriteLine("Convert via reflection:");
            Console.WriteLine(temp1 + " = " + temp4);
            Console.WriteLine(temp2 + " = " + temp5);

            //tempConverter.
        }
    }
}
