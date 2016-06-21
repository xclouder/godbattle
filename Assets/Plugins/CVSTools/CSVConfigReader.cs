using UnityEngine;
using System.IO;
using ReadWriteCsv;

public class CSVConfigReader {

	public ICSVIterator<T> ReadConfigFile<T>(string fileName, 
											 ICSVIterator<T> iterator, 
											 string path = "Configs", 
											 int ignoreLine=1){

		ICSVIterator<T> csvIterator = iterator;

		string filePath = Path.Combine(path, fileName);

		TextAsset tAsset = Resources.Load(filePath, typeof(TextAsset)) as TextAsset;

		if(tAsset != null){

			Stream byteStream = new MemoryStream(tAsset.bytes);

			CsvFileReader cfr = new CsvFileReader(byteStream);

			CsvRow row = new CsvRow();

			int LineNum = 0;
			while(cfr.ReadRow(row)){

				if(LineNum >= ignoreLine){

					csvIterator.ParseCsvRow(row);

				}
				
				LineNum++;
			}

			byteStream.Dispose();
			cfr.Dispose();

		}else{

			Debug.LogWarning("Not find config file! File path: " + filePath);
		}

		return csvIterator;

	}
}
