#if UNITY_IOS
using System.IO;
using UnityEditor.Callbacks;
using UnityEditor;
using UnityEditor.iOS.Xcode;

public class BuildPostProcessor {
    [PostProcessBuild] 
    public static void OnPostprocessBuild(BuildTarget buildTarget, string buildPath) {
        if (buildTarget == BuildTarget.iOS) {

            /*
             * pbxProject
             */
            string pbxProjectPath = buildPath + "/Unity-iPhone.xcodeproj/project.pbxproj";
            PBXProject pbxProject = new PBXProject();
            pbxProject.ReadFromFile(pbxProjectPath);

            //Disabling Bitcode on all targets because it's deprecated since Xcode 14 and game won't build with it enabled

            //Project
            string target = pbxProject.ProjectGuid();
            pbxProject.SetBuildProperty(target, "ENABLE_BITCODE", "NO");
            
            pbxProject.WriteToFile(pbxProjectPath);
        }
    }
}
#endif

