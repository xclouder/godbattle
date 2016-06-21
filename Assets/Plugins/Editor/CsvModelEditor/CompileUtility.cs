using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using UnityEngine;

namespace Assets.Editor.CsvModelEditor
{
    /// <summary>
    /// 编译工具
    /// </summary>
    public static class CompileUtility
    {
#if UNITY_EDITOR_OSX
        private const string MonoLocation = "/Applications/Unity/MonoDevelop.app/Contents/Frameworks/Mono.framework/Versions/Current/";
#else
        private const string MonoLocation = @"C:\Program Files\Unity\Editor\Data\Mono";
#endif

        private static readonly String[] DefaultReferences = { "lib/mono/4.5/System.dll", "lib/mono/4.5/System.Core.dll" };

        private static readonly String TempCompilePath = Path.Combine(Directory.GetParent(Application.dataPath).FullName, ".TempCompile/").ToConsistentPath();

        /// <summary>
        /// 编译时用的临时目录
        /// </summary>
        public static String TempCompileDir
        {
            get
            {
                if (!Directory.Exists(TempCompilePath))
                {
                    Directory.CreateDirectory(TempCompilePath);
                }

                return TempCompilePath;
            }
        }

        /// <summary>
        /// 编译指定目录下的文件
        /// </summary>
        /// <param name="root">源代码目录</param>
        /// <param name="outputDllName">编译输出的dll名称</param>
        /// <param name="references">编译时需要的引用程序集</param>
        public static void Compile(String root, String outputDllName, params String[] references)
        {
            var args = BuildCompileArgs(root, outputDllName, references);
            var cmd = Path.Combine(MonoLocation, "bin/mcs").ToConsistentPath();

            UnityEngine.Debug.Log(String.Format("{0} {1}", cmd, args));

#if UNITY_EDITOR_OSX
            var proc = new Process
            {
                StartInfo =
                {
                    FileName = cmd,
                    Arguments = args,
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    RedirectStandardInput = true
                }
            };
#else
            var proc = new Process
            {
                StartInfo =
                {
                    FileName = cmd,
                    Arguments = args,
                    UseShellExecute = true
                }
            };
#endif
            proc.Start();
            proc.WaitForExit();
            proc.Close();
        }

        /// <summary>
        /// 遍历指定目录下的所有文件
        /// </summary>
        /// <param name="root">目录</param>
        /// <param name="searchPattern">文件搜索匹配</param>
        /// <returns></returns>
        public static IEnumerable<String> WalkDirectoryTree(String root, String searchPattern = null)
        {
            if (!Directory.Exists(root))
            {
                throw new ArgumentException();
            }

            var dirs = new Stack<String>(20);
            dirs.Push(root);

            while (dirs.Count > 0)
            {
                var currentDir = dirs.Pop();
                String[] currentSubDirs;

                if (TryGet(() => Directory.GetDirectories(currentDir), out currentSubDirs))
                {
                    foreach (var str in currentSubDirs)
                    {
                        dirs.Push(str);
                    }

                    String[] currentFiles;
                    if (TryGet(() => Directory.GetFiles(currentDir, searchPattern ?? "*"), out currentFiles))
                    {
                        foreach (var file in currentFiles)
                        {
                            yield return file;
                        }
                    }
                }
            }
        }

        private static Boolean TryGet(Func<String[]> func, out String[] values)
        {
            values = null;
            try
            {
                values = func();
                return true;
            }
            catch (UnauthorizedAccessException exception)
            {
				UnityEngine.Debug.LogException(exception);
                return false;
            }
            catch (DirectoryNotFoundException exception)
            {
				UnityEngine.Debug.LogException(exception);
                return false;
            }
        }

        private static string BuildCompileArgs(string root, string outputDllName, IEnumerable<string> references)
        {
            var currentAllReferences = new List<String>();
            currentAllReferences.AddRange(DefaultReferences.Select(r => Path.Combine(MonoLocation, r).ToConsistentPath()));
            currentAllReferences.AddRange(references.Select(r => r.ToConsistentPath()));

            var referenceArgs = String.Join(" ",
                currentAllReferences.Select(r => String.Format("\"-r:{0}\"", r)).ToArray());
            var csFileArgs = String.Join(" ", WalkDirectoryTree(root, "*.cs").Select(f => String.Format("\"{0}\"", f.ToConsistentPath())).ToArray());

            var args =
                String.Format(
                    "/noconfig \"/out:{0}\" {1} /nologo /warn:4 /optimize- /codepage:utf8 /t:library {2}",
                    outputDllName.ToConsistentPath(), referenceArgs, csFileArgs);
            return args;
        }

        private static String ToConsistentPath(this String path)
        {
#if UNITY_EDITOR_OSX
            return path.Replace("\\", "/");
#else
            return path.Replace("/", "\\");
#endif
        }
    }
}