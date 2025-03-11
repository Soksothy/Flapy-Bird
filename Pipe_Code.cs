using System.Collections;
                        using System.Collections.Generic;
                        using UnityEngine;
                        
                        public class Pipe_Code : MonoBehaviour
                        {
                            public float moveSpeed = 5f;
                            private float deadZone = -15;
                            private bool scored = false;
                        
                            void Update()
                            {
                                transform.position = transform.position + (Vector3.left * moveSpeed * Time.deltaTime);
                        
                                if (transform.position.x < deadZone)
                                {
                                    // Add score when pipe is destroyed
                                    if (!scored && ScoreManager.instance != null)
                                    {
                                        scored = true;
                                        ScoreManager.instance.AddScore();
                                        Debug.Log("Score added when pipe destroyed");
                                    }
                                    Destroy(gameObject);
                                }
                            }
                        
                            // Keep this method in case you want to add a score trigger later
                            private void OnTriggerEnter2D(Collider2D other)
                            {
                                if (other.CompareTag("Bird") && !scored)
                                {
                                    scored = true;
                                    ScoreManager.instance.AddScore();
                                }
                            }
                        }