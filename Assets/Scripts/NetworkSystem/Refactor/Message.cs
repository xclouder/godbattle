using System;
using ProtoBuf;

[ProtoContract]
public class Message {

	[ProtoMember(1)]    
	public int ID;

	[ProtoMember(2)]
	public string Content;

}
