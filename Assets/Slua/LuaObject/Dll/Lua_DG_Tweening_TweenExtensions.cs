using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_DG_Tweening_TweenExtensions : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Complete_s(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==1){
				DG.Tweening.Tween a1;
				checkType(l,1,out a1);
				DG.Tweening.TweenExtensions.Complete(a1);
				pushValue(l,true);
				return 1;
			}
			else if(argc==2){
				DG.Tweening.Tween a1;
				checkType(l,1,out a1);
				System.Boolean a2;
				checkType(l,2,out a2);
				DG.Tweening.TweenExtensions.Complete(a1,a2);
				pushValue(l,true);
				return 1;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Flip_s(IntPtr l) {
		try {
			DG.Tweening.Tween a1;
			checkType(l,1,out a1);
			DG.Tweening.TweenExtensions.Flip(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int ForceInit_s(IntPtr l) {
		try {
			DG.Tweening.Tween a1;
			checkType(l,1,out a1);
			DG.Tweening.TweenExtensions.ForceInit(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Goto_s(IntPtr l) {
		try {
			DG.Tweening.Tween a1;
			checkType(l,1,out a1);
			System.Single a2;
			checkType(l,2,out a2);
			System.Boolean a3;
			checkType(l,3,out a3);
			DG.Tweening.TweenExtensions.Goto(a1,a2,a3);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Kill_s(IntPtr l) {
		try {
			DG.Tweening.Tween a1;
			checkType(l,1,out a1);
			System.Boolean a2;
			checkType(l,2,out a2);
			DG.Tweening.TweenExtensions.Kill(a1,a2);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int PlayBackwards_s(IntPtr l) {
		try {
			DG.Tweening.Tween a1;
			checkType(l,1,out a1);
			DG.Tweening.TweenExtensions.PlayBackwards(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int PlayForward_s(IntPtr l) {
		try {
			DG.Tweening.Tween a1;
			checkType(l,1,out a1);
			DG.Tweening.TweenExtensions.PlayForward(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Restart_s(IntPtr l) {
		try {
			DG.Tweening.Tween a1;
			checkType(l,1,out a1);
			System.Boolean a2;
			checkType(l,2,out a2);
			DG.Tweening.TweenExtensions.Restart(a1,a2);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Rewind_s(IntPtr l) {
		try {
			DG.Tweening.Tween a1;
			checkType(l,1,out a1);
			System.Boolean a2;
			checkType(l,2,out a2);
			DG.Tweening.TweenExtensions.Rewind(a1,a2);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int SmoothRewind_s(IntPtr l) {
		try {
			DG.Tweening.Tween a1;
			checkType(l,1,out a1);
			DG.Tweening.TweenExtensions.SmoothRewind(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int TogglePause_s(IntPtr l) {
		try {
			DG.Tweening.Tween a1;
			checkType(l,1,out a1);
			DG.Tweening.TweenExtensions.TogglePause(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int GotoWaypoint_s(IntPtr l) {
		try {
			DG.Tweening.Tween a1;
			checkType(l,1,out a1);
			System.Int32 a2;
			checkType(l,2,out a2);
			System.Boolean a3;
			checkType(l,3,out a3);
			DG.Tweening.TweenExtensions.GotoWaypoint(a1,a2,a3);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int WaitForCompletion_s(IntPtr l) {
		try {
			DG.Tweening.Tween a1;
			checkType(l,1,out a1);
			var ret=DG.Tweening.TweenExtensions.WaitForCompletion(a1);
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int WaitForRewind_s(IntPtr l) {
		try {
			DG.Tweening.Tween a1;
			checkType(l,1,out a1);
			var ret=DG.Tweening.TweenExtensions.WaitForRewind(a1);
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int WaitForKill_s(IntPtr l) {
		try {
			DG.Tweening.Tween a1;
			checkType(l,1,out a1);
			var ret=DG.Tweening.TweenExtensions.WaitForKill(a1);
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int WaitForElapsedLoops_s(IntPtr l) {
		try {
			DG.Tweening.Tween a1;
			checkType(l,1,out a1);
			System.Int32 a2;
			checkType(l,2,out a2);
			var ret=DG.Tweening.TweenExtensions.WaitForElapsedLoops(a1,a2);
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int WaitForPosition_s(IntPtr l) {
		try {
			DG.Tweening.Tween a1;
			checkType(l,1,out a1);
			System.Single a2;
			checkType(l,2,out a2);
			var ret=DG.Tweening.TweenExtensions.WaitForPosition(a1,a2);
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int WaitForStart_s(IntPtr l) {
		try {
			DG.Tweening.Tween a1;
			checkType(l,1,out a1);
			var ret=DG.Tweening.TweenExtensions.WaitForStart(a1);
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int CompletedLoops_s(IntPtr l) {
		try {
			DG.Tweening.Tween a1;
			checkType(l,1,out a1);
			var ret=DG.Tweening.TweenExtensions.CompletedLoops(a1);
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Delay_s(IntPtr l) {
		try {
			DG.Tweening.Tween a1;
			checkType(l,1,out a1);
			var ret=DG.Tweening.TweenExtensions.Delay(a1);
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Duration_s(IntPtr l) {
		try {
			DG.Tweening.Tween a1;
			checkType(l,1,out a1);
			System.Boolean a2;
			checkType(l,2,out a2);
			var ret=DG.Tweening.TweenExtensions.Duration(a1,a2);
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Elapsed_s(IntPtr l) {
		try {
			DG.Tweening.Tween a1;
			checkType(l,1,out a1);
			System.Boolean a2;
			checkType(l,2,out a2);
			var ret=DG.Tweening.TweenExtensions.Elapsed(a1,a2);
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int ElapsedPercentage_s(IntPtr l) {
		try {
			DG.Tweening.Tween a1;
			checkType(l,1,out a1);
			System.Boolean a2;
			checkType(l,2,out a2);
			var ret=DG.Tweening.TweenExtensions.ElapsedPercentage(a1,a2);
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int ElapsedDirectionalPercentage_s(IntPtr l) {
		try {
			DG.Tweening.Tween a1;
			checkType(l,1,out a1);
			var ret=DG.Tweening.TweenExtensions.ElapsedDirectionalPercentage(a1);
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int IsActive_s(IntPtr l) {
		try {
			DG.Tweening.Tween a1;
			checkType(l,1,out a1);
			var ret=DG.Tweening.TweenExtensions.IsActive(a1);
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int IsBackwards_s(IntPtr l) {
		try {
			DG.Tweening.Tween a1;
			checkType(l,1,out a1);
			var ret=DG.Tweening.TweenExtensions.IsBackwards(a1);
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int IsComplete_s(IntPtr l) {
		try {
			DG.Tweening.Tween a1;
			checkType(l,1,out a1);
			var ret=DG.Tweening.TweenExtensions.IsComplete(a1);
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int IsInitialized_s(IntPtr l) {
		try {
			DG.Tweening.Tween a1;
			checkType(l,1,out a1);
			var ret=DG.Tweening.TweenExtensions.IsInitialized(a1);
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int IsPlaying_s(IntPtr l) {
		try {
			DG.Tweening.Tween a1;
			checkType(l,1,out a1);
			var ret=DG.Tweening.TweenExtensions.IsPlaying(a1);
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Loops_s(IntPtr l) {
		try {
			DG.Tweening.Tween a1;
			checkType(l,1,out a1);
			var ret=DG.Tweening.TweenExtensions.Loops(a1);
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int PathGetPoint_s(IntPtr l) {
		try {
			DG.Tweening.Tween a1;
			checkType(l,1,out a1);
			System.Single a2;
			checkType(l,2,out a2);
			var ret=DG.Tweening.TweenExtensions.PathGetPoint(a1,a2);
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int PathGetDrawPoints_s(IntPtr l) {
		try {
			DG.Tweening.Tween a1;
			checkType(l,1,out a1);
			System.Int32 a2;
			checkType(l,2,out a2);
			var ret=DG.Tweening.TweenExtensions.PathGetDrawPoints(a1,a2);
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int PathLength_s(IntPtr l) {
		try {
			DG.Tweening.Tween a1;
			checkType(l,1,out a1);
			var ret=DG.Tweening.TweenExtensions.PathLength(a1);
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"DG.Tweening.TweenExtensions");
		addMember(l,Complete_s);
		addMember(l,Flip_s);
		addMember(l,ForceInit_s);
		addMember(l,Goto_s);
		addMember(l,Kill_s);
		addMember(l,PlayBackwards_s);
		addMember(l,PlayForward_s);
		addMember(l,Restart_s);
		addMember(l,Rewind_s);
		addMember(l,SmoothRewind_s);
		addMember(l,TogglePause_s);
		addMember(l,GotoWaypoint_s);
		addMember(l,WaitForCompletion_s);
		addMember(l,WaitForRewind_s);
		addMember(l,WaitForKill_s);
		addMember(l,WaitForElapsedLoops_s);
		addMember(l,WaitForPosition_s);
		addMember(l,WaitForStart_s);
		addMember(l,CompletedLoops_s);
		addMember(l,Delay_s);
		addMember(l,Duration_s);
		addMember(l,Elapsed_s);
		addMember(l,ElapsedPercentage_s);
		addMember(l,ElapsedDirectionalPercentage_s);
		addMember(l,IsActive_s);
		addMember(l,IsBackwards_s);
		addMember(l,IsComplete_s);
		addMember(l,IsInitialized_s);
		addMember(l,IsPlaying_s);
		addMember(l,Loops_s);
		addMember(l,PathGetPoint_s);
		addMember(l,PathGetDrawPoints_s);
		addMember(l,PathLength_s);
		createTypeMetatable(l,null, typeof(DG.Tweening.TweenExtensions));
	}
}
