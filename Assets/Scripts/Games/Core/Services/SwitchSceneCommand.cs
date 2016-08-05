using uFrame.Kernel;
using SLua;

[CustomLuaClass]
public class SwitchSceneCommand {
	public string FromSceneName {get;set;}
	public string ToSceneName {get;set;}
	public string TranslateEffectName {get;set;}
	public ISceneSettings Settings { get; set; }
	public bool RestrictToSingleScene { get; set; }
}
