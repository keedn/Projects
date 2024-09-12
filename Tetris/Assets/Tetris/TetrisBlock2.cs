using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;


public class TetrisBlock2 : MonoBehaviour
{
    private float previousTime;
    public float fallTime = 0.8f;

    public static int height = 20;
    public static int width = 10;

    public int Level => Level;
    public int Lines => Lines;
    
    public Vector3 rotationPoint;
    public static Transform[,] grid = new Transform[width, height];
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.position += new Vector3(-1, 0, 0);
            if(!ValidMove())
            {
                transform.position -= new Vector3(-1, 0, 0);
            }
           
        }

        else if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.position += new Vector3(1, 0, 0);
            if(!ValidMove())
            {
                transform.position -= new Vector3(1, 0, 0);
            }
        }

        if(Time.time - previousTime > (Input.GetKey(KeyCode.DownArrow) ? fallTime / 10 : fallTime))
        {
            transform.position += new Vector3(0, -1, 0);
            previousTime = Time.time;
            if(!ValidMove())
            {
                transform.position -= new Vector3(0, -1, 0);
                AddtoGrid();
                CheckforLines();
                this.enabled = false;
                FindObjectOfType<SpawnTetromino>().NewTertromino();
            }
        }
        else if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            transform.RotateAround(transform.TransformPoint(rotationPoint), new Vector3(0, 0, 1), 90);
            if(!ValidMove())
            {
                transform.RotateAround(transform.TransformPoint(rotationPoint), new Vector3(0, 0, 1), -90);
            }
        }

        if (CheckGameOver())
            {
              
                FindObjectOfType<SpawnTetromino>().enabled = false;
             
            }

    }
     void AddtoGrid()
     {
        foreach(Transform children in transform)
        {
            int roundedX = Mathf.RoundToInt(children.transform.position.x);
            int roundedY = Mathf.RoundToInt(children.transform.position.y);
            grid[roundedX, roundedY] = children;
        }
        
     }
public bool GameOver = false;
      public bool CheckGameOver()
    {
        for (int x = 0; x < width; x++)
        {
            if (grid[x, height - 1] != null)
            {
                Debug.Log("Game Over");
                GameOver = true;
                return true;
                
            }
        }

        return false;
    } 
    
    void CheckforLines()
    {
        int linesClearedThisMove = 0;
        for (int i = height - 1; i >= 0; i--)
        {
            if (HasLine(i))
            {
                DeleteLine(i);
                RowDown(i);
                linesClearedThisMove++;
            }
        }
        if (linesClearedThisMove > 0)
        {
            ScoreManager.instance.AddScore(linesClearedThisMove);
        }

    }

    bool HasLine(int i)
    {
        for (int j = 0; j < width; j++)
        {
            if(grid[j, i] == null)
            {
                return false;
            }
        }
        return true;
    }
    
    public int lineCount=0;
    void DeleteLine(int i)
    {
        
        for (int j = 0; j < width; j++)//deletes the line and moves the blocks down j is the x axis and i is the y axis 
        {
           
            Destroy(grid[j, i].gameObject);
            grid[j, i] = null;
        }
        Debug.Log("Line deleted: " + i + " | Current line count: " + lineCount);
    }

    void RowDown(int i)
    {
        for (int y = i; y < height; y++)
        {
            for (int j = 0; j < width; j++)
            {
                if(grid[j, y] != null)
                {
                    grid[j, y - 1] = grid[j, y];
                    grid[j, y] = null;
                    grid[j, y - 1].transform.position -= new Vector3(0, 1, 0);
                }
            }
        }
    }
    bool ValidMove()
    {
        foreach(Transform children in transform)
        {
            int roundedX = Mathf.RoundToInt(children.transform.position.x);
            int roundedY = Mathf.RoundToInt(children.transform.position.y);

            if(roundedX < 0 || roundedX >= width || roundedY < 0 || roundedY >= height)
            {
                return false;
            }
            if(grid[roundedX, roundedY] != null)
            {
                return false;
            }
        }
        return true;
    }
  
}
