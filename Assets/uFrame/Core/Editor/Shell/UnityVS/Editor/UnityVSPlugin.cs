using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Invert.Core;
using Invert.Core.GraphDesigner;
using Invert.Data;
using Invert.IOC;
using UnityEditor;
using UnityEngine;

namespace Assets.uFrameComplete.uFrame.Editor.DiagramPlugins.UnityVS
{
    public class UnityVSPlugin : DiagramPlugin //, ICompileEvents
    {
        public override bool EnabledByDefault
        {
            get { return false; }
        }

        public override void Initialize(UFrameContainer container)
        {
            
        }

        //public void PreCompile(IGraphConfiguration configuration, IDataRecord[] compilingRecords)
        //{
            
        //}

        //public void FileGenerated(CodeFileGenerator generator)
        //{
           
        //}

        //public void PostCompile(IGraphConfiguration configuration, IDataRecord[] compilingRecords)
        //{
        //    EditorApplication.ExecuteMenuItem("Visual Studio Tools/Generate Project Files");
        //}

        public void FileSkipped(CodeFileGenerator codeFileGenerator)
        {
            
        }
    }
}
