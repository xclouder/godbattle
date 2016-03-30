using UnityEngine;
using System.Collections;

public class SDKInfo {

	public string Id {get;set;}
	public string Name {get;set;}
	public string Dir {get;set;}
	public bool Enabled {get;set;}
	public string Version {get;set;}

	public bool IsDuplicateSDK(SDKInfo sdk)
	{
		return Id == sdk.Id;
	}

	public override int GetHashCode()
	{
		return Id.GetHashCode() + Id.Length;
	}

	public override bool Equals(System.Object o)
	{
		SDKInfo sdk = o as SDKInfo;
		if (sdk == null)
		{
			return false;
		}

		return base.Equals(o) && Id == sdk.Id;
	}
}
