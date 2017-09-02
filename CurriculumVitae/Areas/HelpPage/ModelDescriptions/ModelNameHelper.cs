namespace CurriculumVitae.Areas.HelpPage.ModelDescriptions
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Reflection;

    internal static class ModelNameHelper
    {
        public static string GetModelName(Type type)
        {
            var modelNameAttribute = type.GetCustomAttribute<ModelNameAttribute>();
            if (!string.IsNullOrEmpty(modelNameAttribute?.Name))
            {
                return modelNameAttribute.Name;
            }

            var modelName = type.Name;
            if (!type.IsGenericType)
            {
                return modelName;
            }

            var genericType = type.GetGenericTypeDefinition();
            var genericArguments = type.GetGenericArguments();
            var genericTypeName = genericType?.Name;

            // Trim the generic parameter counts from the name
            genericTypeName = genericTypeName?.Substring(0, genericTypeName.IndexOf('`'));
            var argumentTypeNames = genericArguments.Select(GetModelName).ToArray();

            modelName = string.Format(
                CultureInfo.InvariantCulture,
                "{0}Of{1}",
                genericTypeName,
                string.Join("And", argumentTypeNames));

            return modelName;
        }
    }
}