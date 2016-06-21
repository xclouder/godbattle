using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UnityEditor;
using UnityEngine;

namespace Assets.Editor.CsvModelEditor
{
    public static class UpdateOrCreateCsvFingerprintFile
    {
        //相对 Application.dataPath 的路径
        private static readonly String[] CsvConfigDirs = { "Resources/Configs/", "Scenes/Maps/Resources/Configs" };

        [MenuItem("UsefulTools/CsvModel Tools/Update Csv Fingerprint")]
        public static void Run()
        {
            RunOnCIEnv();
            EditorUtility.DisplayDialog("提示", "fingerprint.txt 更新成功。", "确定");
        }

        public static void RunOnCIEnv()
        {
            CsvFileVerificator.ForceUpdate();
            var preFingerprints = CsvFileVerificator.GetAllVCodes();
            var currentFingerprints = GenerateFingerprint();
            var fileCodes = currentFingerprints.Select(p => String.Format("{0}{1}{2}", p.Key, CsvFileVerificator.NameAndCodeSeparator, p.Value));

            var plaintext = String.Join(new String(new[] { CsvFileVerificator.FileCodeSeparator }), fileCodes.ToArray());
            var ciphertext = CsvFileVerificator.EncryptFingerprintContent(plaintext);

            using (var sw = new StreamWriter(Path.Combine(Application.dataPath, "Resources/Configs/fingerprint.txt"), false, new UTF8Encoding(false)))
            {
                sw.Write(ciphertext);
            }

            AssetDatabase.Refresh();
            LogCompareFingerprintResult(preFingerprints, currentFingerprints);
            Debug.Log("fingerprint updated");
        }

        public static void LogCompareFingerprintResult(Dictionary<String, String> preFingerprints, Dictionary<String, String> currentFingerprints)
        {
            foreach (var fingerprints in preFingerprints.Where(fingerprints => currentFingerprints.ContainsKey(fingerprints.Key) && currentFingerprints[fingerprints.Key] != fingerprints.Value))
            {
                Debug.LogWarning(String.Format("FINGERPRINT CHANGED {0}: {1}  TO  {2}", fingerprints.Key, fingerprints.Value, currentFingerprints[fingerprints.Key]));
            }

            foreach (var fingerprints in preFingerprints.Where(fingerprints => !currentFingerprints.ContainsKey(fingerprints.Key)))
            {
                Debug.LogWarning(String.Format("FINGERPRINT DELETED {0}: {1}", fingerprints.Key, fingerprints.Value));
            }

            foreach (var fingerprints in currentFingerprints.Where(fingerprints => !preFingerprints.ContainsKey(fingerprints.Key)))
            {
                Debug.LogWarning(String.Format("FINGERPRINT ADDED {0}: {1}", fingerprints.Key, fingerprints.Value));
            }
        }

        public static Dictionary<String, String> GenerateFingerprint()
        {
            return CsvConfigDirs.Select(f => Path.Combine(Application.dataPath, f))
				.SelectMany(configDir => Directory.GetFiles(configDir, "*.*").Where(file => file.ToLower().EndsWith("csv") || file.ToLower().EndsWith("json"))
				    .Select(csvFile => Path.GetFileNameWithoutExtension(csvFile))
                    .ToDictionary(csvFile => csvFile, csvFile => CsvFileVerificator.EncryptHashCode(
                        Resources.Load<TextAsset>(
                            Path.Combine("Configs", csvFile).Replace(Path.DirectorySeparatorChar, '/'))
                            .bytes.ComputeHashToHexString()))).ToDictionary(p => p.Key, p => p.Value);
        }
    }
}