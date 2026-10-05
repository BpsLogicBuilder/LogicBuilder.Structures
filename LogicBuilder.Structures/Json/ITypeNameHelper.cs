using System;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
[assembly: InternalsVisibleTo("LogicBuilder.Structures.Tests, PublicKey=002400000480000094000000060200000024000052534131000400000100010059b59302e7303accd5cc84fd482cae54dea8d8b8de7faaef37abbac4b08e3d91283087f48ae04c4fdd117752a3fcafcda61cd2099e2d5432b9bce70e5fe083b15e43cd652617b06dc1422d347ffe7b2aeb7b466e567c6988f26dccbf9723b4b57b1aeaa0a2dbd00478d7135da9bb04a6138d5f29e54ac7e9ac9ae3b7956cf6c2")]
namespace LogicBuilder.Expressions.Utils.Json
{
    internal interface ITypeNameHelper
    {
        /// <summary>
        /// End index for the type name section of the assembly qualified type name.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="startIndex"></param>
        /// <returns></returns>
        int GetEndTypeNameIndex(string value, int startIndex);

        /// <summary>
        /// Key is "Namespace.TypeName, AssemblySimpleName" so that version, culture and public key token changes do not break persisted JSON.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        string GetKey(Type type);

        /// <summary>
        /// Gets the key "Namespace.TypeName, AssemblySimpleName" given the assembly qualified name.
        /// </summary>
        /// <param name="assemblyQualifiedName"></param>
        /// <returns></returns>
        string? GetKey(string assemblyQualifiedName);

        /// <summary>
        /// Ignores commas for generic type arguments e.g. in the following case the first comma will be two characters before "System.Linq.Expressions"
        /// System.Linq.IQueryable`1[[Enrollment.Domain.Entities.LookUpsModel, Enrollment.Domain, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]], System.Linq.Expressions, Version=4.1.1.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a
        /// </summary>
        /// <param name="value"></param>
        /// <param name="startIndex"></param>
        /// <returns></returns>
        int IndexOfTopLevelComma(string value, int startIndex);

        bool IsAllowedType<T>(Type? type);
    }
}
