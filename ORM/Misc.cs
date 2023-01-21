using Azure.Core;
using ORM.Attributes;
using System.Data;
using System.Reflection;

namespace ORM
{
    internal static class Misc
    {
        public static string GetTableName<T>()
        {
            var type = typeof(T);

            var attribute = type.GetCustomAttribute<TableNameAttribute>();

            if (attribute != null)
            {
                return attribute.TableName;
            }

            var tableName = typeof(T).Name;

            return type.Name;
        }

        public static T Initialize<T>(DataRow row) where T : new()
        {
            var newItem = new T();

            var type = typeof (T);

            var properties = type.GetProperties(
                BindingFlags.Public | BindingFlags.Instance);

            foreach ( var property in properties ) 
            {
                var name = property.Name.ToLower();
                var value = row[name];

                property.SetValue(newItem, value);
            }
            return newItem;
        }
    }
}