using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace modul_15
{
    class Program
    {
        static void Main()
        {
            // Задача 1
            PrintConsoleMethods();

            // Задача 2
            SampleClass instance = InitializeSampleClass();
            PrintPropertiesAndValues(instance);

            // Задача 3
            InvokeStringSubstring();

            // Задача 4
            PrintListConstructors();
        }

        private static void PrintListConstructors()
        {
            throw new NotImplementedException();
        }

        // Задача 1: Получение списка методов класса Console и вывод на экран
        static void PrintConsoleMethods()
        {
            Type consoleType = typeof(Console);
            MethodInfo[] methods = consoleType.GetMethods();

            Console.WriteLine("Методы класса Console:");
            foreach (MethodInfo method in methods)
            {
                Console.WriteLine(method.Name);
            }

            Console.WriteLine();
        }

        // Задача 2: Работа с классом с несколькими свойствами
        static SampleClass InitializeSampleClass()
        {
            SampleClass instance = new SampleClass { Id = 1, Name = "Example" };
            return instance;
        }

        static void PrintPropertiesAndValues(object obj)
        {
            Type type = obj.GetType();
            PropertyInfo[] properties = type.GetProperties();

            Console.WriteLine("Свойства и их значения:");
            foreach (PropertyInfo property in properties)
            {
                object value = property.GetValue(obj);
                Console.WriteLine($"{property.Name}: {value}");
            }

            Console.WriteLine();
        }

        // Задача 3: Вызов метода Substring класса String с использованием рефлексии
        static void InvokeStringSubstring()
        {
            string originalString = "Hello, Reflection!";
            int startIndex = 7;
            int length = 10;

            Type stringType = typeof(string);
            MethodInfo substringMethod = stringType.GetMethod("Substring", new Type[] { typeof(int), typeof(int) });

            if (substringMethod != null)
            {
                object[] parameters = { startIndex, length };
                object result = substringMethod.Invoke(originalString, parameters);

                Console.WriteLine("Извлеченная подстрока: " + result);
                Console.WriteLine();
            }
        }
    }
}
