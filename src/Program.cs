// From 5 to 10
Console.WriteLine("From 5 to 10");
foreach (var i in 5..10)
{
    Console.WriteLine(i);
}

// From 0 to 6
Console.WriteLine("From 0 to 6");
foreach (var i in 6)
{
    Console.WriteLine(i);
}

// From 0 to 7
Console.WriteLine("From 0 to 7");
foreach (var i in ..7)
{
    Console.WriteLine(i);
}


// From 15 to infinity -> Should throw an exception
Console.WriteLine("From 15 to infinity -> Should throw an exception");
foreach (var i in 15..)
{
    Console.WriteLine(i);
}

static class Extensions
{
    public static IntEnumerator GetEnumerator(this Range range)
    {
        return new IntEnumerator(range);
    }

    public static IntEnumerator GetEnumerator(this int number)
    {
        return new IntEnumerator(0..number);
    }
}


// Duck typing
ref struct IntEnumerator
{
    public int Current { get; private set; }

    private readonly int _end;

    public IntEnumerator(Range range)
    {
        if (range.End.IsFromEnd)
        {
            throw new NotSupportedException("Only ranges with end defined is supported");
        }

        Current = range.Start.Value - 1;
        _end = range.End.Value;
    }

    public bool MoveNext()
    {
        Current++;
        return Current <= _end;
    }
}
