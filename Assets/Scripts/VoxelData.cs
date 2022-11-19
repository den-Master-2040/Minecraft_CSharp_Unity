using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class VoxelData
{
<<<<<<< HEAD

    public static readonly int ChunkWidth = 5;
    public static readonly int ChunkHeight = 15;
    public static readonly int WorldSizeInChunks = 50;
    public static readonly int ViewDistanceInChunks = 8;
    public static int WorldSizeInBlocks
=======
    public readonly static int ChunkWidth = 5;
    public readonly static int ChunkHeight = 15;
    public readonly static int WorldSizeInChunks = 4;

    public static int WorldSizeInVoxel
    {
        get { return WorldSizeInChunks * ChunkWidth; }
    }

    public static readonly int TextureAtlasSizeInBlock = 4;

    public static float NormalizedBlockTextureSize
>>>>>>> e8bf3279b9737f1834339b8245598ebf98b48f68
    {

        get { return WorldSizeInChunks * ChunkWidth; }

    }

    public static readonly int TextureAtlasSizeInBlocks = 4;
    public static float NormalizedBlockTextureSize
    {

        get { return 1f / (float)TextureAtlasSizeInBlocks; }

    }

    public static readonly Vector3[] voxelVerts = new Vector3[8] {

        new Vector3(0.0f, 0.0f, 0.0f),
        new Vector3(1.0f, 0.0f, 0.0f),
        new Vector3(1.0f, 1.0f, 0.0f),
        new Vector3(0.0f, 1.0f, 0.0f),
        new Vector3(0.0f, 0.0f, 1.0f),
        new Vector3(1.0f, 0.0f, 1.0f),
        new Vector3(1.0f, 1.0f, 1.0f),
        new Vector3(0.0f, 1.0f, 1.0f),

    };

<<<<<<< HEAD
    public static readonly Vector3[] faceChecks = new Vector3[6] {

=======

    /*Rendered*/
    public static readonly Vector3[] faceChunks = new Vector3[6]
    {
>>>>>>> e8bf3279b9737f1834339b8245598ebf98b48f68
        new Vector3(0.0f, 0.0f, -1.0f),
        new Vector3(0.0f, 0.0f, 1.0f),
        new Vector3(0.0f, 1.0f, 0.0f),
        new Vector3(0.0f, -1.0f, 0.0f),
        new Vector3(-1.0f, 0.0f, 0.0f),
        new Vector3(1.0f, 0.0f, 0.0f)

    };

    public static readonly int[,] voxelTris = new int[6, 4] {

        // Back, Front, Top, Bottom, Left, Right

		// 0 1 2 2 1 3
		{0, 3, 1, 2}, // Back Face
		{5, 6, 4, 7}, // Front Face
		{3, 7, 2, 6}, // Top Face
		{1, 5, 0, 4}, // Bottom Face
		{4, 7, 0, 3}, // Left Face
		{1, 2, 5, 6} // Right Face

	};

    public static readonly Vector2[] voxelUvs = new Vector2[4] {

        new Vector2 (0.0f, 0.0f),
        new Vector2 (0.0f, 1.0f),
        new Vector2 (1.0f, 0.0f),
        new Vector2 (1.0f, 1.0f)

    };

<<<<<<< HEAD
=======
    /*Textures*/
    public static readonly Vector2[] voxelUvs = new Vector2[4]{
        new Vector2(0.0f, 0.0f),
        new Vector2(0.0f, 1.0f),
        new Vector2(1.0f, 0.0f),
        new Vector2(1.0f, 1.0f),
    };
>>>>>>> e8bf3279b9737f1834339b8245598ebf98b48f68

}