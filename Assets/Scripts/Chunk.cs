using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chunk
{
<<<<<<< HEAD

    public ChunkCoord coord;

    MeshRenderer meshRenderer;
    MeshFilter meshFilter;
    GameObject chunkObject;
=======
    public ChunkCoord coord;

    GameObject chunkObject;
    MeshRenderer meshRenderer;
    MeshFilter meshFilter;


>>>>>>> e8bf3279b9737f1834339b8245598ebf98b48f68

    int vertexIndex = 0;
    List<Vector3> vertices = new List<Vector3>();
    List<int> triangles = new List<int>();
    List<Vector2> uvs = new List<Vector2>();

    byte[,,] voxelMap = new byte[VoxelData.ChunkWidth, VoxelData.ChunkHeight, VoxelData.ChunkWidth];

    World world;

<<<<<<< HEAD
    public Chunk(ChunkCoord _coord, World _world)
    {

        coord = _coord;
        chunkObject = new GameObject();
        chunkObject.transform.position = new Vector3(coord.x * VoxelData.ChunkWidth, 0f, coord.z * VoxelData.ChunkWidth);

        meshRenderer = chunkObject.AddComponent<MeshRenderer>();
        meshFilter = chunkObject.AddComponent<MeshFilter>();
        world = _world;

        chunkObject.transform.SetParent(world.transform);
        meshRenderer.material = world.material;

        chunkObject.name = coord.x + ", " + coord.z;
=======


    public Chunk(ChunkCoord chunkCoord, World _world)
    {
        coord = chunkCoord;
        world = _world;

        chunkObject = new GameObject();
        meshFilter = chunkObject.AddComponent<MeshFilter>();
        meshRenderer = chunkObject.AddComponent<MeshRenderer>();

        meshRenderer.material = world.material;
        chunkObject.transform.SetParent(world.transform);
        chunkObject.transform.position = new Vector3(coord.x * VoxelData.ChunkWidth, 0f, coord.z * VoxelData.ChunkWidth);
        chunkObject.name = "Chunk" + coord.x + ", " + coord.z;
>>>>>>> e8bf3279b9737f1834339b8245598ebf98b48f68

        PopulateVoxelMap();
        CreateMeshData();
        CreateMesh();
<<<<<<< HEAD

=======
    }

    void PopulateVoxelMap()
    {
        for (int y = 0; y < VoxelData.ChunkHeight; y++)
        {
            for (int x = 0; x < VoxelData.ChunkWidth; x++)
            {
                for (int z = 0; z < VoxelData.ChunkWidth; z++)
                {
                    voxelMap[x, y, z] = world.GetVoxel(new Vector3(x, y, z) + position);
                }
            }
        }
>>>>>>> e8bf3279b9737f1834339b8245598ebf98b48f68
    }

    public bool isActive
    {

        get { return chunkObject.activeSelf; }
        set { chunkObject.SetActive(value); }

    }

    Vector3 position
    {

        get { return chunkObject.transform.position; }

    }

    bool IsVoxelInChunk(int x, int y, int z)
    {

        if (x < 0 || x > VoxelData.ChunkWidth - 1 || y < 0 || y > VoxelData.ChunkHeight - 1 || z < 0 || z > VoxelData.ChunkWidth - 1)
            return false;
        else return true;

    }

    public void PopulateVoxelMap()
    {

        for (int y = 0; y < VoxelData.ChunkHeight; y++)
        {
            for (int x = 0; x < VoxelData.ChunkWidth; x++)
            {
                for (int z = 0; z < VoxelData.ChunkWidth; z++)
                {

                    voxelMap[x, y, z] = world.GetVoxel(new Vector3(x, y, z) + position);

                }
            }
        }

    }

    public void CreateMeshData()
    {

        for (int y = 0; y < VoxelData.ChunkHeight; y++)
        {
            for (int x = 0; x < VoxelData.ChunkWidth; x++)
            {
                for (int z = 0; z < VoxelData.ChunkWidth; z++)
                {

                    AddVoxelDataToChunk(new Vector3(x, y, z));

                }
            }
        }

    }

    public byte GetVoxelFromMap(Vector3 pos)
    {

        pos -= position;

        return voxelMap[(int)pos.x, (int)pos.y, (int)pos.z];

    }

    public bool isAcitve
    {
        get { return chunkObject.activeSelf; }
        set { chunkObject.SetActive(value); }
    }

    public Vector3 position
    {
        get { return chunkObject.transform.position; }
    }

    bool isVoxelChunk(int x, int y, int z)
    {
        if (x < 0 || x > VoxelData.ChunkWidth - 1 || y < 0 || y > VoxelData.ChunkHeight - 1 || z < 0 || z > VoxelData.ChunkWidth - 1)
            return false;
        else
            return true;
    }

    bool CheckVoxel(Vector3 pos)
    {

        int x = Mathf.FloorToInt(pos.x);
        int y = Mathf.FloorToInt(pos.y);
        int z = Mathf.FloorToInt(pos.z);

<<<<<<< HEAD
        // If position is outside of this chunk...
        if (!IsVoxelInChunk(x, y, z))
            return world.blocktypes[world.GetVoxel(pos + position)].isSolid;
=======
        if (!isVoxelChunk(x, y, z))
            return false ;
>>>>>>> e8bf3279b9737f1834339b8245598ebf98b48f68

        return world.blocktypes[voxelMap[x, y, z]].isSolid;

    }

    void AddVoxelDataToChunk(Vector3 pos)
    {

        for (int p = 0; p < 6; p++)
        {

            if (!CheckVoxel(pos + VoxelData.faceChecks[p]))
            {

                byte blockID = voxelMap[(int)pos.x, (int)pos.y, (int)pos.z];

                vertices.Add(pos + VoxelData.voxelVerts[VoxelData.voxelTris[p, 0]]);
                vertices.Add(pos + VoxelData.voxelVerts[VoxelData.voxelTris[p, 1]]);
                vertices.Add(pos + VoxelData.voxelVerts[VoxelData.voxelTris[p, 2]]);
                vertices.Add(pos + VoxelData.voxelVerts[VoxelData.voxelTris[p, 3]]);

                AddTexture(world.blocktypes[blockID].GetTextureID(p));

                triangles.Add(vertexIndex);
                triangles.Add(vertexIndex + 1);
                triangles.Add(vertexIndex + 2);
                triangles.Add(vertexIndex + 2);
                triangles.Add(vertexIndex + 1);
                triangles.Add(vertexIndex + 3);
                vertexIndex += 4;

            }
        }

    }

    public void CreateMesh()
    {

        Mesh mesh = new Mesh();
        mesh.vertices = vertices.ToArray();
        mesh.triangles = triangles.ToArray();
        mesh.uv = uvs.ToArray();

        mesh.RecalculateNormals();

        meshFilter.mesh = mesh;

    }

    void AddTexture(int textureID)
    {

        float y = textureID / VoxelData.TextureAtlasSizeInBlocks;
        float x = textureID - (y * VoxelData.TextureAtlasSizeInBlocks);

        x *= VoxelData.NormalizedBlockTextureSize;
        y *= VoxelData.NormalizedBlockTextureSize;

        y = 1f - y - VoxelData.NormalizedBlockTextureSize;

        uvs.Add(new Vector2(x, y));
        uvs.Add(new Vector2(x, y + VoxelData.NormalizedBlockTextureSize));
        uvs.Add(new Vector2(x + VoxelData.NormalizedBlockTextureSize, y));
        uvs.Add(new Vector2(x + VoxelData.NormalizedBlockTextureSize, y + VoxelData.NormalizedBlockTextureSize));


    }

<<<<<<< HEAD
}
=======
}

public class ChunkCoord
{
    public int x;
    public int z;

    public ChunkCoord(int _x, int _z)
    {
        x = _x;
        z = _z;
    }
}
>>>>>>> e8bf3279b9737f1834339b8245598ebf98b48f68
