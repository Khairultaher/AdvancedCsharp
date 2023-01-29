/*
 * In computer science, reflection is the ability of a program to examine and modify its own structure and behavior at runtime. This allows for introspection, the ability to inspect the types, methods, and properties of an object at runtime, as well as the ability to manipulate those elements. Reflection is a powerful tool that can be used to create more flexible and dynamic software, but it can also make code more difficult to understand and maintain.
*/

using System.Reflection;
using System.Reflection.Emit;

class Example
{
    public int MyProperty { get; set; }
    public void MyMethod() { }
}

class Program
{
    static void Main(string[] args)
    {
        Type type = typeof(Example);

        Console.WriteLine("Properties:");
        foreach (PropertyInfo prop in type.GetProperties())
        {
            Console.WriteLine(prop.Name);
        }

        Console.WriteLine("Methods:");
        foreach (var method in type.GetMethods())
        {
            Console.WriteLine(method.Name);
        }

        // new examle
        AssemblyName assemblyName = new AssemblyName("Reflection");
        AssemblyBuilder assemblyBuilder = AssemblyBuilder.DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.Run);
        ModuleBuilder moduleBuilder = assemblyBuilder.DefineDynamicModule("MyModule");
        TypeBuilder typeBuilder = moduleBuilder.DefineType("MyType", TypeAttributes.Public);

        // Define a new property
        PropertyBuilder propertyBuilder = typeBuilder.DefineProperty("NewProperty", PropertyAttributes.HasDefault, typeof(string), null);

        // Create a new getter method for the property
        MethodBuilder getMethodBuilder = typeBuilder.DefineMethod("get_NewProperty", MethodAttributes.Public | MethodAttributes.SpecialName | MethodAttributes.HideBySig, typeof(string), Type.EmptyTypes);
        ILGenerator getIL = getMethodBuilder.GetILGenerator();
        getIL.Emit(OpCodes.Ldstr, "Hello, Reflection!");
        getIL.Emit(OpCodes.Ret);

        // Create a new setter method for the property
        MethodBuilder setMethodBuilder = typeBuilder.DefineMethod("set_NewProperty", MethodAttributes.Public | MethodAttributes.SpecialName | MethodAttributes.HideBySig, null, new Type[] { typeof(string) });
        ILGenerator setIL = setMethodBuilder.GetILGenerator();
        setIL.Emit(OpCodes.Ret);

        // Assign the getter and setter methods to the new property
        propertyBuilder.SetGetMethod(getMethodBuilder);
        propertyBuilder.SetSetMethod(setMethodBuilder);

        // Create the new type
        Type newType = typeBuilder.CreateType();

        // Create an instance of the new type
        var obj = Activator.CreateInstance(newType);

        // Get the value of the new property
        PropertyInfo property = newType.GetProperty("NewProperty");
        Console.WriteLine(property.GetValue(obj));
    }
}
//class Example
//{
//    public int MyProperty { get; set; }
//    public void MyMethod() { }
//}

//class Program
//{
//    static void Main(string[] args)
//    {
//        Type type = typeof(Example);

//        Console.WriteLine("Properties:");
//        foreach (var property in type.GetProperties())
//        {
//            Console.WriteLine(property.Name);
//        }

//        Console.WriteLine("Methods:");
//        foreach (var method in type.GetMethods())
//        {
//            Console.WriteLine(method.Name);
//        }
//    }
//}
