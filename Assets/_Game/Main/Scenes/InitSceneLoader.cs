using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using uFrame.IOC;
using uFrame.Kernel;
using uFrame.MVVM;
using uFrame.Serialization;
using UnityEngine;


public class InitSceneLoader : InitSceneLoaderBase {
    
    protected override IEnumerator LoadScene(InitScene scene, Action<float, string> progressDelegate) {
        yield break;
    }
    
    protected override IEnumerator UnloadScene(InitScene scene, Action<float, string> progressDelegate) {
        yield break;
    }
}
