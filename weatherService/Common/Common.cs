using System.Text.Json;

namespace Common;

public static class Common
{
    public static string ToJson<T>(this T obj)
    {
        return JsonSerializer.Serialize(obj);
    }
}