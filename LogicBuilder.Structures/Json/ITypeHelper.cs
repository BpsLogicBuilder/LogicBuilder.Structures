using System;
using System.Collections.Generic;
using System.Reflection;

namespace LogicBuilder.Expressions.Utils.Json
{
    internal interface ITypeHelper
    {
        /// <summary>
        /// Builds the list of allowed types
        /// </summary>
        /// <typeparam name="T">The base class being converted</typeparam>
        /// <param name="types">List of types to filter</param>
        /// <returns></returns>
        IReadOnlyDictionary<string, Type> BuildKnownTypes<T>(IEnumerable<Type> types);
        IEnumerable<Type> LoadTypesFromAssembly(Assembly assembly);
        Type? ResolveType(string typeString, IReadOnlyDictionary<string, Type> knownTypes);
    }
}
