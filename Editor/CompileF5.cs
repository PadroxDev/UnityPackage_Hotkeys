using UnityEditor;
using UnityEditor.Compilation;

namespace Antoine.Hotkeys {
    public static class CompileProject {
        [MenuItem("Tools/Compile _F5")]
        public static void CompileF5() {
            CompilationPipeline.RequestScriptCompilation(RequestScriptCompilationOptions.CleanBuildCache);;
        }
    }
}
