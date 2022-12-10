
Stack();
Heap();

void Stack()
{
    bool _bool; //0-1 mantıksal değer tutar (1 bit)
    char _char; //Tek karakter tutar (2 byte 16 bit)

    byte _byte; //0 ile 255 arasında (1 byte 8 bit)
    sbyte _sbyte; //-128 ile 127 arası (1 byte 8 bit)
    short _short; //-32.768 ile 32.767 arası (2 byte 16 bit)
    ushort _ushort; //0 ile 65.535 arası (2 byte 16 bit)
    int _int; //-2.147.483.648 ile 2.147.483.647 arası (4 byte 32 bit)
    uint _uint; //0 ile 4.294.967.295 arası (4 byte 32 bit)
    long _long; //-9.223.372.036.854.775.808 ile 9.223.372.036.854.775.807 (8 byte 64 bit)
    ulong _ulong; //0 ile 18,446,744,073,709,551,615 (8 byte 64 bit)

    float _float; //±1,5 x 10−45 ila ±3,4 x 1038 (4 byte 32 bit)
    double _double; //±5,0 × 10−324 ile ±1,7 ×10 308 (8 byte 64 bit
    decimal _decimal; //±1,0 x 10-28 ile ±7,9228 x 1028 (16 byte 128 bit)

    MyStruct myStruct = new MyStruct();
    unsafe
    {
        Console.WriteLine(sizeof(MyStruct));
    }

    Days days;
    unsafe
    {
        Console.WriteLine(sizeof(Days));
    }
}

void Heap()
{

}
