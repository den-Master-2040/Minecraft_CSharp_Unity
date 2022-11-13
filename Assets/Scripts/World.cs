using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World : MonoBehaviour
{
    public Material material;
    public BlockType[] blocktypes;

    Chunk[,] chunks = new Chunk[VoxelData.WorldSizeInChunks, VoxelData.WorldSizeInChunks];

    private void Start()
    {
        GenerateWorld();

    }

    void GenerateWorld()
    {
        for(int x = 0; x < VoxelData.WorldSizeInChunks; x++)
            for (int z = 0; z < VoxelData.WorldSizeInChunks; z++)
            {
                CreateNewChunk(x, z);
            }
    }
    //1-stone
    //0 - bedrock
    //2 - grass
    public byte GetVoxel(Vector3 pos)
    {
        if (pos.y < 1)
            return 0;
        else if (pos.y == VoxelData.ChunkHeight - 1)
            return 2;
        else return 1;
    }
    
    void CreateNewChunk(int x, int z)
    {
        chunks[x, z] = new Chunk(new ChunkCoord(x, z), this);
    }

    bool isChunkInWorld(ChunkCoord coord)
    {
        if (coord.x > 0 && coord.x < VoxelData.WorldSizeInChunks - 1 && 
            coord.z > 0 && coord.z < VoxelData.WorldSizeInChunks - 1)
            return true;
        else
            return false;
    }

    bool IsVoxelInWorld (Vector3 pos)
    {
        if (pos.x > 0 && pos.x < VoxelData.WorldSizeInChunks - 1 && 
            pos.y > 0 && pos.y < VoxelData.ChunkHeight - 1 &&
            pos.z > 0 && pos.z < VoxelData.WorldSizeInChunks - 1)
            return true;
        else
            return false;
    }
}

[System.Serializable]
public class BlockType
{
    public string blockName;
    public bool isSolid;

    [Header("Texture Values")]
    public int backFaceTexture;
    public int frontFaceTexture;
    public int topFaceTexture;
    public int bottomFaceTexture;
    public int rightFaceTexture;
    public int leftFaceTexture;

    public int GetTextureID(int faceIndex)
    {
        switch (faceIndex)
        {
            case 0:
                return backFaceTexture;
            case 1:
                return frontFaceTexture;
            case 2:
                return topFaceTexture;
            case 3:
                return bottomFaceTexture;
            case 4:
                return rightFaceTexture;
            case 5:
                return leftFaceTexture;
            default:
                Debug.Log("Error int GetTextureID; invalid face index");
                return 0;

        }
    }
}
