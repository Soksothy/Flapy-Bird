// In Assets/Pipe.cs - Rename to PipeSpawner
                using System.Collections;
                using System.Collections.Generic;
                using UnityEngine;
                
                public class PipeSpawner : MonoBehaviour
                {
                    public GameObject pipe;
                    public float spawnRate = 2;
                    public float heightOffset = 5;
                    public float pipeSpeed = 5f; // Add this to control pipe speed
                
                    private float timer = 0;
                
                    void Start()
                    {
                        SpawnPipe();
                    }
                
                    void Update()
                    {
                        if (timer < spawnRate)
                        {
                            timer += Time.deltaTime;
                        }
                        else
                        {
                            SpawnPipe();
                            timer = 0;
                        }
                    }
                
                    void SpawnPipe()
                    {
                        float lowestPoint = transform.position.y - heightOffset;
                        float highestPoint = transform.position.y + heightOffset;
                
                        Vector3 spawnPosition = new Vector3(
                            transform.position.x,
                            Random.Range(lowestPoint, highestPoint),
                            transform.position.z
                        );
                
                        GameObject newPipe = Instantiate(pipe, spawnPosition, transform.rotation);
                        
                        // Ensure the pipe has the correct script and speed
                        Pipe_Code pipeCode = newPipe.GetComponent<Pipe_Code>();
                        if (pipeCode != null)
                        {
                            pipeCode.moveSpeed = pipeSpeed;
                        }
                        
                        Debug.Log("Pipe spawned with speed: " + pipeSpeed);
                    }
                }