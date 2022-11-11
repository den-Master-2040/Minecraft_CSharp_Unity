using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class Chunk : MonoBehaviour
{
    public MeshRenderer meshRenderer;
    public MeshFilter meshFilter;


    int vertexIndex = 0;
    List<Vector3> vertices = new List<Vector3>();
    List<int> triangles = new List<int>();
    List<Vector2> uvs = new List<Vector2>();

    bool[,,] voxelMap = new bool[VoxelData.ChunkWidth, VoxelData.ChunkHeight, VoxelData.ChunkWidth];
    
    void Start()
    {
        PopulateVoxelMap();
        CreateMeshData(); 
        CreateMesh();
    }
    void PopulateVoxelMap()
    {
        for (int y = 0; y < VoxelData.ChunkHeight; y++)
        {
            for (int x = 0; x < VoxelData.ChunkHeight; x++)
            {
                for (int z = 0; z < VoxelData.ChunkHeight; z++)
                {
                    voxelMap[x, y, x] = true;
                }
            }
        }
    }

    void CreateMeshData()
    {
        for (int y = 0; y < VoxelData.ChunkHeight; y++)
        {
            for (int x = 0; x < VoxelData.ChunkHeight; x++)
            {
                for (int z = 0; z < VoxelData.ChunkHeight; z++)
                {
                    AddVoxelDataToChunk(new Vector3(x, y, z));
                }
            }
        }
    }

    bool CheckVoxel(Vector3 pos)
    {
         
    }

    void AddVoxelDataToChunk(Vector3 pos)
    {
        for (int p = 0; p < 6; p++)
            for (int i = 0; i < 6; i++)
            {
                int triangleIndex = VoxelData.voxelTris[p, i];
                vertices.Add(VoxelData.voxelVerts[triangleIndex] + pos);
                triangles.Add(vertexIndex);

                uvs.Add(VoxelData.voxelUvs[i]);

                vertexIndex++;
            }
    }

    void CreateMesh()
    {

        Mesh mesh = new Mesh();
        mesh.vertices = vertices.ToArray();
        mesh.triangles = triangles.ToArray();

        mesh.uv = uvs.ToArray();

        mesh.RecalculateNormals();
        meshFilter.mesh = mesh;

    }
}
