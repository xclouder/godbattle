/*************************************************************************
 *  FileName: ICache.cs
 *  Author: xClouder
 *  Create Time: 06/21/2016
 *  Description:
 *
 *************************************************************************/

using System;
using System.Collections;

public interface ICache <TKey, TVal>
{
	bool Contains(TKey key);
	void Add(TKey key, TVal val);
	TVal Get(TKey key);
	void Remove(TKey key);
}