

ReferenceCopy();
ShallowCopy();
DeepCopy();

Console.ReadKey();

void ReferenceCopy()
{
    var root1 = new Root()
    {
        Id = 1,
        Child = new Child
        {
            Id = 1
        }
    };

    var root2 = root1;
    root2.Id = 2;
    root2.Child.Id = 2;

    //root1.Id = 2, root1.Child.Id = 2
    //root2.Id = 2, root2.Child.Id = 2
}

void ShallowCopy()
{
    var root1 = new Root()
    {
        Id = 1,
        Child = new Child
        {
            Id = 1
        }
    };

    var root2 = root1.ShallowCopy();
    root2.Id = 2;
    root2.Child.Id = 2;

    //root1.Id = 1, root1.Child.Id = 2
    //root2.Id = 2, root2.Child.Id = 2
}

void DeepCopy()
{
    var root1 = new Root()
    {
        Id = 1,
        Child = new Child
        {
            Id = 1
        }
    };

    var root2 = root1.DeepCopy();
    root2.Id = 2;
    root2.Child.Id = 2;

    //root1.Id = 1, root1.Child.Id = 1
    //root2.Id = 2, root2.Child.Id = 2
}