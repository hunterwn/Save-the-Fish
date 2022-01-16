     using System.Collections;
     using System.Collections.Generic;
     using UnityEngine;
     using UnityEditor;
     using System;
     using UnityEditor.SceneManagement;
     using System.Linq;
     
     public static class SetPolygonCollider3D
     {
         [MenuItem("Tools/Update Polygon Colliders %t", false, -1)]
         static void UpdatePolygonColliders()
         {
             Transform transform = Selection.activeTransform;
             if(transform == null)
             {
                 Debug.LogWarning("No valid GameObject selected!");
                 return;
             }
     
             EditorSceneManager.MarkSceneDirty(transform.gameObject.scene);
     
             MeshFilter[] meshFilters = transform.GetComponentsInChildren<MeshFilter>();
             
             foreach(MeshFilter meshFilter in meshFilters)
             {
                 if(meshFilter.GetComponent<PolygonCollider2D>() != null)
                 {
                     UpdatePolygonCollider2D(meshFilter);
                 }
             }
         }
     
         static void UpdatePolygonCollider2D(MeshFilter meshFilter)
         {
             if(meshFilter.sharedMesh == null)
             {
                 Debug.LogWarning(meshFilter.gameObject.name + " has no Mesh set on its MeshFilter component!");
                 return;
             }
     
             PolygonCollider2D polygonCollider2D = meshFilter.GetComponent<PolygonCollider2D>();
             polygonCollider2D.pathCount = 1;
     
             List<Vector3> vertices =  new List<Vector3>();
             meshFilter.sharedMesh.GetVertices(vertices);
     
             var boundaryPath = EdgeHelpers.GetEdges(meshFilter.sharedMesh.triangles).FindBoundary().SortEdges();
     
             Vector3[] yourVectors = new Vector3[boundaryPath.Count];
             for(int i = 0; i < boundaryPath.Count; i++)
             {
                 yourVectors[i] = vertices[ boundaryPath[i].v1 ];
             }
             List<Vector2> newColliderVertices = new List<Vector2>();
     
             for(int i=0; i < yourVectors.Length; i++)
             {
                 newColliderVertices.Add(new Vector2(yourVectors[i].x, yourVectors[i].y));
             }
     
             Vector2[] newPoints = newColliderVertices.Distinct().ToArray();
     
             EditorUtility.SetDirty(polygonCollider2D);
     
             polygonCollider2D.SetPath(0, newPoints);
             Debug.Log(meshFilter.gameObject.name + " PolygonCollider2D updated.");
         }
     }
     
     public static class EdgeHelpers
     {
         public struct Edge
         {
             public int v1;
             public int v2;
             public int triangleIndex;
             public Edge(int aV1, int aV2, int aIndex)
             {
                 v1 = aV1;
                 v2 = aV2;
                 triangleIndex = aIndex;
             }
         }
     
         public static List<Edge> GetEdges(int[] aIndices)
         {
             List<Edge> result = new List<Edge>();
             for (int i = 0; i < aIndices.Length; i += 3)
             {
                 int v1 = aIndices[i];
                 int v2 = aIndices[i + 1];
                 int v3 = aIndices[i + 2];
                 result.Add(new Edge(v1, v2, i));
                 result.Add(new Edge(v2, v3, i));
                 result.Add(new Edge(v3, v1, i));
             }
             return result;
         }
     
         public static List<Edge> FindBoundary(this List<Edge> aEdges)
         {
             List<Edge> result = new List<Edge>(aEdges);
             for (int i = result.Count-1; i > 0; i--)
             {
                 for (int n = i - 1; n >= 0; n--)
                 {
                     if (result[i].v1 == result[n].v2 && result[i].v2 == result[n].v1)
                     {
                         // shared edge so remove both
                         result.RemoveAt(i);
                         result.RemoveAt(n);
                         i--;
                         break;
                     }
                 }
             }
             return result;
         }
         public static List<Edge> SortEdges(this List<Edge> aEdges)
         {
             List<Edge> result = new List<Edge>(aEdges);
             for (int i = 0; i < result.Count-2; i++)
             {
                 Edge E = result[i];
                 for(int n = i+1; n < result.Count; n++)
                 {
                     Edge a = result[n];
                     if (E.v2 == a.v1)
                     {
                         // in this case they are already in order so just continoue with the next one
                         if (n == i+1)
                             break;
                         // if we found a match, swap them with the next one after "i"
                         result[n] = result[i + 1];
                         result[i + 1] = a;
                         break;
                     }
                 }
             }
             return result;
         }
     }