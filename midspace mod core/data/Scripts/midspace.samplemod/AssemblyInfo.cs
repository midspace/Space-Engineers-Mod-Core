using System.Reflection;

[assembly: AssemblyTitle("MidSpace Space Engineeers My Sample Mod script")]
[assembly: AssemblyDescription("Space Engineers Script")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("Mid-Space Productions")]
[assembly: AssemblyProduct("Space Engineers")]
[assembly: AssemblyCopyright("Copyright � MidSpace 2014-2018")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

[assembly: AssemblyVersion("1.0.0.0")]
[assembly: AssemblyFileVersion("1.0.0.0")]

// The AssemblyInfo isn't promoted by KeenSWH to be included in their 'script' mods.
// So it may not work in the future.
// Currently is does work, and it provides identifiable information in the compiled runtime 
// if anyone ever attempts to decompile it directly.

// I do not recommend changing the version. This will probably cause runtime issue if the version number
// is changed after Space Engineers is loaded. Set it at 1.0.0.0, and leave it like that.

// Version information of ModAPI scripts are displayed in the log file of the game when it loads the mod, like this:
// 2018-01-06 20:51:28.746 - Thread:   1 ->  Registered modules from: midspace.mytester.dev, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
