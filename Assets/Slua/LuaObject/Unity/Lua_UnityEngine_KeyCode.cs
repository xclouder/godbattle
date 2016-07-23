using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UnityEngine_KeyCode : LuaObject {
	static public void reg(IntPtr l) {
		getEnumTable(l,"UnityEngine.KeyCode");
		addMember(l,0,"None");
		addMember(l,8,"Backspace");
		addMember(l,9,"Tab");
		addMember(l,12,"Clear");
		addMember(l,13,"Return");
		addMember(l,19,"Pause");
		addMember(l,27,"Escape");
		addMember(l,32,"Space");
		addMember(l,33,"Exclaim");
		addMember(l,34,"DoubleQuote");
		addMember(l,35,"Hash");
		addMember(l,36,"Dollar");
		addMember(l,38,"Ampersand");
		addMember(l,39,"Quote");
		addMember(l,40,"LeftParen");
		addMember(l,41,"RightParen");
		addMember(l,42,"Asterisk");
		addMember(l,43,"Plus");
		addMember(l,44,"Comma");
		addMember(l,45,"Minus");
		addMember(l,46,"Period");
		addMember(l,47,"Slash");
		addMember(l,48,"Alpha0");
		addMember(l,49,"Alpha1");
		addMember(l,50,"Alpha2");
		addMember(l,51,"Alpha3");
		addMember(l,52,"Alpha4");
		addMember(l,53,"Alpha5");
		addMember(l,54,"Alpha6");
		addMember(l,55,"Alpha7");
		addMember(l,56,"Alpha8");
		addMember(l,57,"Alpha9");
		addMember(l,58,"Colon");
		addMember(l,59,"Semicolon");
		addMember(l,60,"Less");
		addMember(l,61,"Equals");
		addMember(l,62,"Greater");
		addMember(l,63,"Question");
		addMember(l,64,"At");
		addMember(l,91,"LeftBracket");
		addMember(l,92,"Backslash");
		addMember(l,93,"RightBracket");
		addMember(l,94,"Caret");
		addMember(l,95,"Underscore");
		addMember(l,96,"BackQuote");
		addMember(l,97,"A");
		addMember(l,98,"B");
		addMember(l,99,"C");
		addMember(l,100,"D");
		addMember(l,101,"E");
		addMember(l,102,"F");
		addMember(l,103,"G");
		addMember(l,104,"H");
		addMember(l,105,"I");
		addMember(l,106,"J");
		addMember(l,107,"K");
		addMember(l,108,"L");
		addMember(l,109,"M");
		addMember(l,110,"N");
		addMember(l,111,"O");
		addMember(l,112,"P");
		addMember(l,113,"Q");
		addMember(l,114,"R");
		addMember(l,115,"S");
		addMember(l,116,"T");
		addMember(l,117,"U");
		addMember(l,118,"V");
		addMember(l,119,"W");
		addMember(l,120,"X");
		addMember(l,121,"Y");
		addMember(l,122,"Z");
		addMember(l,127,"Delete");
		addMember(l,256,"Keypad0");
		addMember(l,257,"Keypad1");
		addMember(l,258,"Keypad2");
		addMember(l,259,"Keypad3");
		addMember(l,260,"Keypad4");
		addMember(l,261,"Keypad5");
		addMember(l,262,"Keypad6");
		addMember(l,263,"Keypad7");
		addMember(l,264,"Keypad8");
		addMember(l,265,"Keypad9");
		addMember(l,266,"KeypadPeriod");
		addMember(l,267,"KeypadDivide");
		addMember(l,268,"KeypadMultiply");
		addMember(l,269,"KeypadMinus");
		addMember(l,270,"KeypadPlus");
		addMember(l,271,"KeypadEnter");
		addMember(l,272,"KeypadEquals");
		addMember(l,273,"UpArrow");
		addMember(l,274,"DownArrow");
		addMember(l,275,"RightArrow");
		addMember(l,276,"LeftArrow");
		addMember(l,277,"Insert");
		addMember(l,278,"Home");
		addMember(l,279,"End");
		addMember(l,280,"PageUp");
		addMember(l,281,"PageDown");
		addMember(l,282,"F1");
		addMember(l,283,"F2");
		addMember(l,284,"F3");
		addMember(l,285,"F4");
		addMember(l,286,"F5");
		addMember(l,287,"F6");
		addMember(l,288,"F7");
		addMember(l,289,"F8");
		addMember(l,290,"F9");
		addMember(l,291,"F10");
		addMember(l,292,"F11");
		addMember(l,293,"F12");
		addMember(l,294,"F13");
		addMember(l,295,"F14");
		addMember(l,296,"F15");
		addMember(l,300,"Numlock");
		addMember(l,301,"CapsLock");
		addMember(l,302,"ScrollLock");
		addMember(l,303,"RightShift");
		addMember(l,304,"LeftShift");
		addMember(l,305,"RightControl");
		addMember(l,306,"LeftControl");
		addMember(l,307,"RightAlt");
		addMember(l,308,"LeftAlt");
		addMember(l,309,"RightApple");
		addMember(l,309,"RightCommand");
		addMember(l,310,"LeftCommand");
		addMember(l,310,"LeftApple");
		addMember(l,311,"LeftWindows");
		addMember(l,312,"RightWindows");
		addMember(l,313,"AltGr");
		addMember(l,315,"Help");
		addMember(l,316,"Print");
		addMember(l,317,"SysReq");
		addMember(l,318,"Break");
		addMember(l,319,"Menu");
		addMember(l,323,"Mouse0");
		addMember(l,324,"Mouse1");
		addMember(l,325,"Mouse2");
		addMember(l,326,"Mouse3");
		addMember(l,327,"Mouse4");
		addMember(l,328,"Mouse5");
		addMember(l,329,"Mouse6");
		addMember(l,330,"JoystickButton0");
		addMember(l,331,"JoystickButton1");
		addMember(l,332,"JoystickButton2");
		addMember(l,333,"JoystickButton3");
		addMember(l,334,"JoystickButton4");
		addMember(l,335,"JoystickButton5");
		addMember(l,336,"JoystickButton6");
		addMember(l,337,"JoystickButton7");
		addMember(l,338,"JoystickButton8");
		addMember(l,339,"JoystickButton9");
		addMember(l,340,"JoystickButton10");
		addMember(l,341,"JoystickButton11");
		addMember(l,342,"JoystickButton12");
		addMember(l,343,"JoystickButton13");
		addMember(l,344,"JoystickButton14");
		addMember(l,345,"JoystickButton15");
		addMember(l,346,"JoystickButton16");
		addMember(l,347,"JoystickButton17");
		addMember(l,348,"JoystickButton18");
		addMember(l,349,"JoystickButton19");
		addMember(l,350,"Joystick1Button0");
		addMember(l,351,"Joystick1Button1");
		addMember(l,352,"Joystick1Button2");
		addMember(l,353,"Joystick1Button3");
		addMember(l,354,"Joystick1Button4");
		addMember(l,355,"Joystick1Button5");
		addMember(l,356,"Joystick1Button6");
		addMember(l,357,"Joystick1Button7");
		addMember(l,358,"Joystick1Button8");
		addMember(l,359,"Joystick1Button9");
		addMember(l,360,"Joystick1Button10");
		addMember(l,361,"Joystick1Button11");
		addMember(l,362,"Joystick1Button12");
		addMember(l,363,"Joystick1Button13");
		addMember(l,364,"Joystick1Button14");
		addMember(l,365,"Joystick1Button15");
		addMember(l,366,"Joystick1Button16");
		addMember(l,367,"Joystick1Button17");
		addMember(l,368,"Joystick1Button18");
		addMember(l,369,"Joystick1Button19");
		addMember(l,370,"Joystick2Button0");
		addMember(l,371,"Joystick2Button1");
		addMember(l,372,"Joystick2Button2");
		addMember(l,373,"Joystick2Button3");
		addMember(l,374,"Joystick2Button4");
		addMember(l,375,"Joystick2Button5");
		addMember(l,376,"Joystick2Button6");
		addMember(l,377,"Joystick2Button7");
		addMember(l,378,"Joystick2Button8");
		addMember(l,379,"Joystick2Button9");
		addMember(l,380,"Joystick2Button10");
		addMember(l,381,"Joystick2Button11");
		addMember(l,382,"Joystick2Button12");
		addMember(l,383,"Joystick2Button13");
		addMember(l,384,"Joystick2Button14");
		addMember(l,385,"Joystick2Button15");
		addMember(l,386,"Joystick2Button16");
		addMember(l,387,"Joystick2Button17");
		addMember(l,388,"Joystick2Button18");
		addMember(l,389,"Joystick2Button19");
		addMember(l,390,"Joystick3Button0");
		addMember(l,391,"Joystick3Button1");
		addMember(l,392,"Joystick3Button2");
		addMember(l,393,"Joystick3Button3");
		addMember(l,394,"Joystick3Button4");
		addMember(l,395,"Joystick3Button5");
		addMember(l,396,"Joystick3Button6");
		addMember(l,397,"Joystick3Button7");
		addMember(l,398,"Joystick3Button8");
		addMember(l,399,"Joystick3Button9");
		addMember(l,400,"Joystick3Button10");
		addMember(l,401,"Joystick3Button11");
		addMember(l,402,"Joystick3Button12");
		addMember(l,403,"Joystick3Button13");
		addMember(l,404,"Joystick3Button14");
		addMember(l,405,"Joystick3Button15");
		addMember(l,406,"Joystick3Button16");
		addMember(l,407,"Joystick3Button17");
		addMember(l,408,"Joystick3Button18");
		addMember(l,409,"Joystick3Button19");
		addMember(l,410,"Joystick4Button0");
		addMember(l,411,"Joystick4Button1");
		addMember(l,412,"Joystick4Button2");
		addMember(l,413,"Joystick4Button3");
		addMember(l,414,"Joystick4Button4");
		addMember(l,415,"Joystick4Button5");
		addMember(l,416,"Joystick4Button6");
		addMember(l,417,"Joystick4Button7");
		addMember(l,418,"Joystick4Button8");
		addMember(l,419,"Joystick4Button9");
		addMember(l,420,"Joystick4Button10");
		addMember(l,421,"Joystick4Button11");
		addMember(l,422,"Joystick4Button12");
		addMember(l,423,"Joystick4Button13");
		addMember(l,424,"Joystick4Button14");
		addMember(l,425,"Joystick4Button15");
		addMember(l,426,"Joystick4Button16");
		addMember(l,427,"Joystick4Button17");
		addMember(l,428,"Joystick4Button18");
		addMember(l,429,"Joystick4Button19");
		addMember(l,430,"Joystick5Button0");
		addMember(l,431,"Joystick5Button1");
		addMember(l,432,"Joystick5Button2");
		addMember(l,433,"Joystick5Button3");
		addMember(l,434,"Joystick5Button4");
		addMember(l,435,"Joystick5Button5");
		addMember(l,436,"Joystick5Button6");
		addMember(l,437,"Joystick5Button7");
		addMember(l,438,"Joystick5Button8");
		addMember(l,439,"Joystick5Button9");
		addMember(l,440,"Joystick5Button10");
		addMember(l,441,"Joystick5Button11");
		addMember(l,442,"Joystick5Button12");
		addMember(l,443,"Joystick5Button13");
		addMember(l,444,"Joystick5Button14");
		addMember(l,445,"Joystick5Button15");
		addMember(l,446,"Joystick5Button16");
		addMember(l,447,"Joystick5Button17");
		addMember(l,448,"Joystick5Button18");
		addMember(l,449,"Joystick5Button19");
		addMember(l,450,"Joystick6Button0");
		addMember(l,451,"Joystick6Button1");
		addMember(l,452,"Joystick6Button2");
		addMember(l,453,"Joystick6Button3");
		addMember(l,454,"Joystick6Button4");
		addMember(l,455,"Joystick6Button5");
		addMember(l,456,"Joystick6Button6");
		addMember(l,457,"Joystick6Button7");
		addMember(l,458,"Joystick6Button8");
		addMember(l,459,"Joystick6Button9");
		addMember(l,460,"Joystick6Button10");
		addMember(l,461,"Joystick6Button11");
		addMember(l,462,"Joystick6Button12");
		addMember(l,463,"Joystick6Button13");
		addMember(l,464,"Joystick6Button14");
		addMember(l,465,"Joystick6Button15");
		addMember(l,466,"Joystick6Button16");
		addMember(l,467,"Joystick6Button17");
		addMember(l,468,"Joystick6Button18");
		addMember(l,469,"Joystick6Button19");
		addMember(l,470,"Joystick7Button0");
		addMember(l,471,"Joystick7Button1");
		addMember(l,472,"Joystick7Button2");
		addMember(l,473,"Joystick7Button3");
		addMember(l,474,"Joystick7Button4");
		addMember(l,475,"Joystick7Button5");
		addMember(l,476,"Joystick7Button6");
		addMember(l,477,"Joystick7Button7");
		addMember(l,478,"Joystick7Button8");
		addMember(l,479,"Joystick7Button9");
		addMember(l,480,"Joystick7Button10");
		addMember(l,481,"Joystick7Button11");
		addMember(l,482,"Joystick7Button12");
		addMember(l,483,"Joystick7Button13");
		addMember(l,484,"Joystick7Button14");
		addMember(l,485,"Joystick7Button15");
		addMember(l,486,"Joystick7Button16");
		addMember(l,487,"Joystick7Button17");
		addMember(l,488,"Joystick7Button18");
		addMember(l,489,"Joystick7Button19");
		addMember(l,490,"Joystick8Button0");
		addMember(l,491,"Joystick8Button1");
		addMember(l,492,"Joystick8Button2");
		addMember(l,493,"Joystick8Button3");
		addMember(l,494,"Joystick8Button4");
		addMember(l,495,"Joystick8Button5");
		addMember(l,496,"Joystick8Button6");
		addMember(l,497,"Joystick8Button7");
		addMember(l,498,"Joystick8Button8");
		addMember(l,499,"Joystick8Button9");
		addMember(l,500,"Joystick8Button10");
		addMember(l,501,"Joystick8Button11");
		addMember(l,502,"Joystick8Button12");
		addMember(l,503,"Joystick8Button13");
		addMember(l,504,"Joystick8Button14");
		addMember(l,505,"Joystick8Button15");
		addMember(l,506,"Joystick8Button16");
		addMember(l,507,"Joystick8Button17");
		addMember(l,508,"Joystick8Button18");
		addMember(l,509,"Joystick8Button19");
		LuaDLL.lua_pop(l, 1);
	}
}
