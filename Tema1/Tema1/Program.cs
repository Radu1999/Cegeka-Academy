
Set<int> set = new Set<int>();
set.Insert(12);
set.Insert(13);
set.Insert(14);

try
{
    set.Insert(12);
} catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}

Console.WriteLine(set);

Set<int> set2 = set.Filter(x => x % 2 == 0);

Console.WriteLine(set2);

set2.Insert(7);
set2.Insert(8);

Set<int> set3 = set2.Merge(set);
Console.WriteLine(set3);

