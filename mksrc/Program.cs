using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

internal partial class Program
{
	[CmdArg(Ordinal=0,Required = true,ItemName ="folder",Description ="The directory to search")]
	static DirectoryInfo Input = null;
	[CmdArg(Ordinal = 1)]
	static TextWriter Output = Console.Out;
	[CmdArg(Name ="prefix",Description = "The path to prepend",ItemName ="path")]
	static string Prefix = "";
	static void Run()
	{
		if(!Input.Exists)
		{
			throw new DirectoryNotFoundException("The specified folder does not exist.");
		}
		var fsia = Input.GetFiles("*.c", SearchOption.AllDirectories);
		var len = Input.FullName.Length;
		foreach(var fsi in fsia )
		{
			Output.WriteLine(string.Concat(Prefix, fsi.FullName.Substring(len).Replace(Path.DirectorySeparatorChar,Path.AltDirectorySeparatorChar)," \\"));
		}
	}
}

