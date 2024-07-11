namespace NGPD.Manager.CrossCutting.Extensions;

public static class ListExtensions
{
    public static void Add<T>(this IList<T> list, IList<T> items)
    {
        foreach (var item in items)
        {
            list.Add(item);
        }
    }

    public static void Remove<T>(this IList<T> list, IList<T> items)
    {
        foreach (var item in items)
        {
            list.Remove(item);
        }
    }

    public static string ToParameterList(this IList<int> list)
    {
        string value = "(";
        for (var i = 0; i < list.Count; i++)
        {
            value += list.ElementAt(i).ToString();
            if (i != list.Count - 1)
            {
                value += ",";
            }
        }
        value += ")";
        return value;
    }
}