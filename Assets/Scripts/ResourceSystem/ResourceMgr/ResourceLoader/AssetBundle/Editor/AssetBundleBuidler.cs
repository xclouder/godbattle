/*************************************************************************
 *  FileName: AssetBundleBuidler.cs
 *  Author: xClouder
 *  Create Time: 07/19/2016
 *  Description:
 *
 *************************************************************************/
using UnityEngine;
using UnityEditor;
using System.IO;

public class AssetBundleBuidler
{
    /// <summary>
    /// 这里后续可以支持：选择不同打包策略
    /// 自Unity3D 5.3以后版本，支持了ChunkBasedCompression方式压缩（LZ4格式），它是基于对每个asset做单独的压缩，并且加载时只在内存中驻留一个bundle头部结构，从而允许运行时不需要将整个bundle全部解压也能随机读取asset。
    /// 相比默认的LZMA压缩方式，LZ4压缩大大的降低了内存占用，可以放心地让可能被多次使用的AssetBundle常驻内存。但LZ4压缩比相对要小一点，也就是说打出来的AssetBundle包会大一点。
    /// </summary>
    [MenuItem ("Assets/AssetBundles/Build AssetBundles")]
	public static void BuildAssetBundles()
    {
        // Choose the output path according to the build target.
        string outputPath = Path.Combine(BundleUtility.AssetBundlesOutputPath,  BundleUtility.GetPlatformName());
        if (!Directory.Exists(outputPath) )
            Directory.CreateDirectory (outputPath);

        BuildPipeline.BuildAssetBundles (outputPath, BuildAssetBundleOptions.None, EditorUserBuildSettings.activeBuildTarget);
    }

    [MenuItem("Assets/AssetBundles/Deploy to StreamingAssets")]
    public static void CopyCurrentPlatformBundleFilesToStreamingAssets()
    {
        var platformName = BundleUtility.GetPlatformName();
        
        // Setup the destination folder for assetbundles.
        
        var streamingAssetsPathInEditor = Path.Combine(Path.Combine(System.Environment.CurrentDirectory, "Assets"), "StreamingAssets");
        streamingAssetsPathInEditor = Path.Combine(streamingAssetsPathInEditor, platformName);
        Debug.Log("dest:" + streamingAssetsPathInEditor);
        
        if (Directory.Exists(streamingAssetsPathInEditor))
            FileUtil.DeleteFileOrDirectory(streamingAssetsPathInEditor);

        Directory.CreateDirectory(streamingAssetsPathInEditor);

        string outputPath = Path.Combine(BundleUtility.AssetBundlesOutputPath,  platformName);

        // Setup the source folder for assetbundles.
        var source = Path.Combine(Path.Combine(System.Environment.CurrentDirectory, BundleUtility.AssetBundlesOutputPath), platformName);
        Debug.Log("source:" + source);
        if (!System.IO.Directory.Exists(source))
        {
            throw new System.InvalidOperationException("No assetBundle output folder, try to build the assetBundles first.");
        }

        FileUtil.CopyFileOrDirectory(source, streamingAssetsPathInEditor);
    }
}