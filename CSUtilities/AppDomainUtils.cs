using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Diagnostics.CodeAnalysis;

namespace CSUtilities;

#if PUBLIC
public
#else
internal
#endif
	static class AppDomainUtils
{
	[RequiresUnreferencedCode("Scans the types of every loaded assembly, which trimming may have removed.")]
	public static IEnumerable<Type> GetTypesOfInterface<T>()
	{
		return AppDomain.CurrentDomain.GetAssemblies()
			.SelectMany(getLoadableTypes)
			.Where(p => p.GetInterface(typeof(T).FullName) != null);
	}

	[RequiresUnreferencedCode("Scans the types of every loaded assembly, which trimming may have removed.")]
	public static IEnumerable<Type> GetTypesWithAttribute<T>() where T : Attribute
	{
		return AppDomain.CurrentDomain.GetAssemblies()
			.SelectMany(getLoadableTypes)
			.Where(p => p.GetCustomAttribute<T>() != null);
	}

	[RequiresUnreferencedCode("Scans the types of every loaded assembly, which trimming may have removed.")]
	private static IEnumerable<Type> getLoadableTypes(Assembly assembly)
	{
		try
		{
			return assembly.GetTypes();
		}
		catch (ReflectionTypeLoadException ex)
		{
			return ex.Types.Where(t => t != null);
		}
	}
}