using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Antoine.Hotkeys {
    public static class AlignToGround {
        
        [MenuItem("Tools/Align To Ground _END")]
        public static void AlignToGroundEND() {
            var selectedObjects = Selection.gameObjects;
            var groundedObjects = new List<Object>();
            
            foreach (var obj in selectedObjects) {
                bool success = AlignObjectToGround(obj);

                if (success) {
                    groundedObjects.Add(obj);
                }
            }

            if (groundedObjects.Count > 0) {
                Undo.RecordObjects(groundedObjects.ToArray(), "Align To Ground");
            }
        }
        
        public static bool AlignObjectToGround(GameObject obj) {
            if (obj == null) return false;

            var ray = new Ray(obj.transform.position, Vector3.down);
            if (Physics.Raycast(ray, out RaycastHit hit)) {
                obj.transform.position = hit.point;
                return true;
            }

            return false;
        }
    }
}