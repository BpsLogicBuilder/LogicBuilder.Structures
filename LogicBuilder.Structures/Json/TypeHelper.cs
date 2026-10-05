using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace LogicBuilder.Expressions.Utils.Json
{
    internal class TypeHelper(ITypeNameHelper typeNameHelper) : ITypeHelper
    {
        private readonly ITypeNameHelper typeNameHelper = typeNameHelper;

        /// <summary>
        /// Builds the list of allowed types
        /// </summary>
        /// <typeparam name="T">The base class being converted</typeparam>
        /// <param name="types">List of types to filter</param>
        /// <returns></returns>
        public IReadOnlyDictionary<string, Type> BuildKnownTypes<T>(IEnumerable<Type> types)
        {
            return types.Where(t => typeNameHelper.IsAllowedType<T>(t)).Aggregate
            (
                new Dictionary<string, Type>(StringComparer.Ordinal),
                (dictionary, type) =>
                {
                    string key = typeNameHelper.GetKey(type);
                    if (!dictionary.ContainsKey(key))
                        dictionary[key] = type;
                    return dictionary;
                }
            );
        }

        public IEnumerable<Type> LoadTypesFromAssembly(Assembly assembly)
        {
            try
            {
                return assembly.GetTypes();
            }
            catch (ReflectionTypeLoadException ex)
            {
                return ex.Types.Where(t => t != null)!;
            }
        }

        public Type? ResolveType(string typeString, IReadOnlyDictionary<string, Type> knownTypes)
        {
            string? key = typeNameHelper.GetKey(typeString);
            return key != null && knownTypes.TryGetValue(key, out Type? _) ? Type.GetType(typeString) : null;
        }
    }
}
