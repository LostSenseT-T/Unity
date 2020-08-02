using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkPlacer : MonoBehaviour
{
    public Transform Player;
    public Chunk[] ChunkPrefabs;
    public Chunk FirstChunk;    
    private List<Chunk> spawnedChunks = new List<Chunk>();
    void Start()
    {
        //spawn first chunk
        spawnedChunks.Add(FirstChunk);
    }

    void Update()
    {
        //spawn next chunk
        if(Player.position.y>spawnedChunks[spawnedChunks.Count-1].Begin.position.y)
        {
            SpawnChunk();
        }
    }

    private void SpawnChunk()
    {
        //generate chunk
        Chunk newChunk = Instantiate(ChunkPrefabs[Random.Range(0, ChunkPrefabs.Length)]);
        newChunk.transform.position =spawnedChunks[spawnedChunks.Count-1].End.position - newChunk.Begin.localPosition;
        spawnedChunks.Add(newChunk);

    }
}
 