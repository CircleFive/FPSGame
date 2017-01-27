//using UnityEngine;
//using System.Collections;
////using UnityEditor;

//public class OpMeshGenerator : MonoBehaviour
//{

//    public int divisionX = 200;
//    public int divisionY = 200;
//    public float sizeX = 10f;
//    public float sizeY = 10f;
//    public float opCupCoef = 6f;
//    public string saveAsAnAssetInPath = "Assets/OpMesh.asset";

//    Vector3 Op(float x, float y)
//    {
//        float z = (
//            opCupCoef * Mathf.Exp(
//                -(
//                    Mathf.Pow(2f / 3f * Mathf.Abs(x) - 1f, 2f)
//                    + Mathf.Pow(2f / 3f * y, 2f)
//                )
//                - 1f / 3f * Mathf.Pow(2f / 3f * y + .5f, 3f)
//            )
//            + 2f / 3f * Mathf.Exp(
//                -Mathf.Pow(2.818f, 11f) * Mathf.Pow(
//                    Mathf.Pow(Mathf.Abs(2f / 3f * x) - 1f, 2f)
//                    + Mathf.Pow(2f / 3f * y, 2f)
//                , 2f)
//            )
//            - Mathf.Pow(2f / 3f * x, 4f)
//        ) / 8f;
//        return new Vector3(x, y, -z);
//    }

//    Mesh CreateMesh()
//    {
//        int countX = divisionX + 1;
//        int countY = divisionY + 1;
//        var vertices = new Vector3[countX * countY];
//        var uv = new Vector2[countX * countY];
//        int k = 0;
//        for (int i = 0; i <= divisionY; i++)
//        {
//            for (int j = 0; j <= divisionX; j++)
//            {
//                float u = (float)j / divisionX;
//                float v = (float)i / divisionY;
//                float x = (u - .5f) * sizeX;
//                float y = (v - .5f) * sizeY;
//                vertices[k] = Op(x, y);
//                uv[k++].Set(u, v);
//            }
//        }

//        var triangles = new int[6 * divisionX * divisionY];
//        int l = 0, kTL = 0, kTR = 1, kBL = countX, kBR = countX + 1;
//        for (int i = 0; i < divisionY; i++)
//        {
//            for (int j = 0; j < divisionX; j++)
//            {
//                triangles[l++] = kTL;
//                triangles[l++] = kBL++;
//                triangles[l++] = kBR;
//                triangles[l++] = kTR++;
//                triangles[l++] = kTL++;
//                triangles[l++] = kBR++;
//            }
//            kTL++; kTR++; kBL++; kBR++;
//        }

//        var mesh = new Mesh();
//        mesh.name = "OpMesh";
//        mesh.vertices = vertices;
//        mesh.uv = uv;
//        mesh.triangles = triangles;

//        return mesh;
//    }

//    void Start()
//    {
//        var mesh = CreateMesh();
//        if (saveAsAnAssetInPath != "")
//        {
//            AssetDatabase.CreateAsset(mesh, saveAsAnAssetInPath);
//            AssetDatabase.SaveAssets();
//        }

//        // ここから削除可 ↓↓↓↓↓
//        var filter = GetComponent<MeshFilter>();
//        if (filter == null) filter = gameObject.AddComponent<MeshFilter>();
//        filter.sharedMesh = mesh;

//        var renderer = GetComponent<MeshRenderer>();
//        if (renderer == null)
//        {
//            renderer = gameObject.AddComponent<MeshRenderer>();
//        }
//        if (renderer.material == null)
//        {
//            renderer.material = Resources.Load("Default-Material", typeof(Material)) as Material;
//        }
//        CreateLight("Key Light", 60f, 100f, 1f, 1f, 1f);
//        CreateLight("Fill Light", 30f, -100f, 1f, .8f, .6f);
//        // ここまで削除可 ↑↑↑↑↑
//    }

//    // ここから削除可 ↓↓↓↓↓
//    void CreateLight(string name, float rx, float ry, float r, float g, float b)
//    {
//        var obj = new GameObject();
//        obj.name = name;
//        var light = obj.AddComponent<Light>();
//        var euler = new Vector3(rx, ry, 0f);
//        var pos = transform.position + Op(0f, 0f);
//        light.type = LightType.Directional;
//        light.transform.localRotation = Quaternion.Euler(euler);
//        light.transform.position = pos + Quaternion.Euler(-euler) * Vector3.forward * 10f;
//        light.color = new Color(r, g, b);
//        light.intensity = 1f;
//        light.bounceIntensity = 0f;
//        light.shadows = LightShadows.Soft;
//    }
//    // ここまで削除可 ↑↑↑↑↑

//}