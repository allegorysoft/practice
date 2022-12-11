namespace Sample.StackVsHeap.HeapTopic;

internal class HeapSample
{
    delegate void MyDelegate();

    public static void Do()
    {
        ReferenceTypes();
        MethodParameterConvention();
    }

    static void ReferenceTypes()
    {
        object _object; //Tüm türlerin atasıdır
        dynamic _dynamic; //object'e benzer ama tür dönüşümü yapma ihtiyacı duyulmaz
        string _string; //Metinsel ifadeleri tutar davranış bakımından değer tipleri gibidir
        MyClass myClass; //İhtiyaca göre tanımladığımız sınıflar
        IInterface _interface; //İhtiyaca göre tanımladığımız arayüzler
        Array array; //Diziler
        MyDelegate myDelegate; //Delegeler
    }
    static void MethodParameterConvention()
    {
        var instance = new MyClass
        {
            Number = 1,
            Number2 = 2
        };
        TakeMyClass(instance);
        Console.WriteLine(instance.Number);
        Console.WriteLine(instance.Number2);
    }

    static void TakeMyClass(MyClass myClass)
    {
        myClass.Number = 10;
        myClass.Number2 = 10;
    }
}
