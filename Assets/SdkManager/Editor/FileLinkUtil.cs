using UnityEngine;
using System.Collections;
using System.IO;

public static class FileLinkUtil {
	public static bool CreateSymbol(string source,string link){

        System.Uri fileURI = new System.Uri( source );
        System.Uri rootURI ;
        rootURI = new System.Uri(  link  );
//        if(link.EndsWith (Path.PathSeparator.ToString ())){
//            rootURI = new System.Uri(  link + "."  );
//        }else{
//            rootURI = new System.Uri( ( link + "/." ) );
//        }
        string relativeLinkPath = rootURI.MakeRelativeUri( fileURI ).ToString();

		System.Diagnostics.Process proc = new System.Diagnostics.Process();
		proc.StartInfo.UseShellExecute = false;
		proc.StartInfo.CreateNoWindow = true;

		proc.StartInfo.RedirectStandardError = true;
		proc.EnableRaisingEvents=false; 
		if (Application.platform == RuntimePlatform.WindowsEditor) {
            if(Directory.Exists (relativeLinkPath)){
				proc.StartInfo.FileName = "mklink";
                proc.StartInfo.Arguments = @"/D """ + link + "\" \"" + relativeLinkPath + "\"";
            }else if(File.Exists (relativeLinkPath)){
				proc.StartInfo.FileName = "mklink";
                proc.StartInfo.Arguments = "\"" + link + "\" \"" + relativeLinkPath + "\"";
			}else{
				Debug.LogWarning ("File not exist:"+source);
			}
		} else {
			proc.StartInfo.FileName = "ln";
            proc.StartInfo.Arguments = "-s \"" + relativeLinkPath + "\" \"" + link + "\"";
		}
		proc.Start();

		proc.StandardError.ReadToEnd();
		proc.WaitForExit();
		if (proc.ExitCode != 0) {
			return false;
		}else{
			return true;
		}
	}

	public static bool RemoveSymbol(string link){

		System.Diagnostics.Process proc = new System.Diagnostics.Process();
		proc.StartInfo.UseShellExecute = false;
		proc.StartInfo.CreateNoWindow = true;

		proc.StartInfo.RedirectStandardError = true;
		proc.EnableRaisingEvents=false; 
		if (Application.platform == RuntimePlatform.WindowsEditor) {
			proc.StartInfo.FileName = "rd";
			proc.StartInfo.Arguments = "\"" + link + "\"";
		} else {
			proc.StartInfo.FileName = "rm";
			proc.StartInfo.Arguments = "\"" + link + "\"";
		}
		proc.Start();

		proc.StandardError.ReadToEnd();
		proc.WaitForExit();
		if (proc.ExitCode != 0) {
			return false;
		}else{
			return true;
		}
	}

	public static bool ForceRemove(string link){

		System.Diagnostics.Process proc = new System.Diagnostics.Process();
		proc.StartInfo.UseShellExecute = false;
		proc.StartInfo.CreateNoWindow = true;

		proc.StartInfo.RedirectStandardError = true;
		proc.EnableRaisingEvents=false; 
		if (Application.platform == RuntimePlatform.WindowsEditor) {
			proc.StartInfo.FileName = "rd";
			proc.StartInfo.Arguments = " /S /Q \"" + link + "\"";
		} else {
			proc.StartInfo.FileName = "rm";
			proc.StartInfo.Arguments = " -rf \"" + link + "\"";
		}
		proc.Start();

		proc.StandardError.ReadToEnd();
		proc.WaitForExit();
		if (proc.ExitCode != 0) {
			return false;
		}else{
			return true;
		}
	}
}
