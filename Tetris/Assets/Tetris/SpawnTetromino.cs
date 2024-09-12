using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using UnityEngine;

public class SpawnTetromino : MonoBehaviour
{
    public GameObject[] Tetrominoes;
    public int nextTetrominoIndex;
    public Transform PreviewNextTetrominoesPosition;
   
    // Start is called before the first frame update
   
    void Start()
    {
        nextTetrominoIndex = GetRandomTetrominoIndex();
        DisplayNextTetromino();
        NewTertromino();
    }

    // Update is called once per frame
    public void NewTertromino()
{
    Instantiate(Tetrominoes[nextTetrominoIndex], transform.position, Quaternion.identity);

    nextTetrominoIndex = GetRandomTetrominoIndex();
    DisplayNextTetromino();
}

    int GetRandomTetrominoIndex()
    {
         return Random.Range(0, Tetrominoes.Length);
    }
    private GameObject currentPreviewTetromino;
  void DisplayNextTetromino()
    {
        // Destroy the existing preview if it exists
        if (currentPreviewTetromino != null)
        {
            Destroy(currentPreviewTetromino);
        }

        // Instantiate the next Tetromino at the preview position
        currentPreviewTetromino = Instantiate(Tetrominoes[nextTetrominoIndex], PreviewNextTetrominoesPosition.position, Quaternion.identity);
        currentPreviewTetromino.layer = LayerMask.NameToLayer("Preview");

        // Center and scale down the preview
        currentPreviewTetromino.transform.position = new Vector3(PreviewNextTetrominoesPosition.position.x, PreviewNextTetrominoesPosition.position.y, 0);
        currentPreviewTetromino.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f); // Adjust the scale as needed

        // Set the order in layer
        SpriteRenderer[] spriteRenderers = currentPreviewTetromino.GetComponentsInChildren<SpriteRenderer>();
        if (spriteRenderers != null)
        {
            foreach (SpriteRenderer renderer in spriteRenderers)
            {
                renderer.sortingOrder = 5;
            }
        }
        else
        {
            Debug.LogError("No SpriteRenderer found on the preview Tetromino");
        }
    }
}
