using System.Linq;

namespace LinqToObject
{
    static class ObjectExtension
    {
        public static void CopyTo(this object source, object destination)
        {
            foreach (var sourceObj in source.GetType().GetProperties().Where(p => p.CanRead))
            {
                var property = destination.GetType().GetProperty(sourceObj.Name);
                if (property?.CanWrite == true && property.PropertyType == sourceObj.PropertyType)
                {
                    property.SetValue(destination, sourceObj.GetValue(source, null), null);
                }
            }
        }
    }
}
