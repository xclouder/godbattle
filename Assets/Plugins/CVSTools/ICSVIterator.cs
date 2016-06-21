using System.Collections.Generic;
using ReadWriteCsv;

public interface ICSVIterator<T> {

	void ParseCsvRow(CsvRow row);

	List<T> GetData();
}
