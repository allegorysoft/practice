using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Auto)]
public struct MyStruct
{
    public bool MyProperty { get; set; }
    public int MyProperty2 { get; set; }
    public short MyProperty3 { get; set; }
}