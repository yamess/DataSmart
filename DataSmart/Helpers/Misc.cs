using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataSmart.Helpers
{
    public class Misc
    {
        public static object DeepCopy(object objSource)
        {
            // Get the type of the source object and create a new instance of that type
            Type typeSource = objSource.GetType();
            object objTarget = Activator.CreateInstance(typeSource);

            // Get all the properties of source object type
            PropertyInfo[] propertyInfo = typeSource.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

            // Assign all source property to target object's properties
            foreach (var property in propertyInfo)
            {
                // Check wether property can be written to
                if (property.CanWrite)
                {
                    // Check wether property type is value type, enum or string type
                    if(property.PropertyType.IsValueType || property.PropertyType.IsEnum || property.PropertyType.Equals(typeof(System.String)))
                    {
                        property.SetValue(objTarget, property.GetValue(objSource, null), null);
                    }
                    else // Else property type is object/complex types, so need to recursively call this method until the end of the tree is reached
                    {
                        object objPropertyValue = property.GetValue(objSource, null);

                        if (objPropertyValue == null)
                        {
                            property.SetValue(objTarget, null, null);
                        }
                        else
                        {
                            property.SetValue(objTarget, DeepCopy(objPropertyValue), null);
                        }
                    }
                }
            }
            return objTarget;
        }
    }
}
