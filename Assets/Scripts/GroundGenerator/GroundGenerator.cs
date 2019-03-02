using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundGenerator : MonoBehaviour
{

    int[,] ground = new int[10, 10];

    [SerializeField]
    GameObject[] tiles;
    [SerializeField]
    GameObject[] resourceGOs;

    private int food = 2;
    private int stone = 3;
    private int wood = 4;
    /*
     0,1,2
     3,4,5
     6,7,8
     */

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 1; i < ground.GetLength(0) - 1; i++)
        {
            for (int j = 1; j < ground.GetLength(1) - 1; j++)
            {
                ground[i, j] = 1;
                if (Random.value < 0.10f)
                {
                    ground[i, j] = 2;
                }
                if (Random.value < 0.10f)
                {
                    ground[i, j] = 3;
                }
                if (Random.value < 0.10f)
                {
                    ground[i, j] = 4;
                }
            }
        }

        createGround();
        createResources();
    }

    void createGround()
    {
        for (int i = 1; i < ground.GetLength(0) - 1; i++)
        {
            for (int j = 1; j < ground.GetLength(1) - 1; j++)
            {
                if (ground[i, j] == 0)
                    continue;

                if (ground[i - 1, j] == 0 && ground[i, j - 1] == 0)
                {
                    Instantiate<GameObject>(tiles[6], new Vector3(i, j, -1), Quaternion.identity);
                }
                else if (ground[i + 1, j] == 0 && ground[i, j - 1] == 0)
                {
                    Instantiate<GameObject>(tiles[8], new Vector3(i, j, -1), Quaternion.identity);
                }
                else if (ground[i + 1, j] == 0 && ground[i, j + 1] == 0)
                {
                    Instantiate<GameObject>(tiles[2], new Vector3(i, j, -1), Quaternion.identity);
                }
                else if (ground[i - 1, j] == 0 && ground[i, j + 1] == 0)
                {
                    Instantiate<GameObject>(tiles[0], new Vector3(i, j, -1), Quaternion.identity);
                }
                else if (ground[i + 1, j] == 0)
                {
                    Instantiate<GameObject>(tiles[5], new Vector3(i, j, -1), Quaternion.identity);
                }
                else if (ground[i - 1, j] == 0)
                {
                    Instantiate<GameObject>(tiles[3], new Vector3(i, j, -1), Quaternion.identity);
                }
                else if (ground[i, j + 1] == 0)
                {
                    Instantiate<GameObject>(tiles[1], new Vector3(i, j, -1), Quaternion.identity);
                }
                else if (ground[i, j - 1] == 0)
                {
                    Instantiate<GameObject>(tiles[7], new Vector3(i, j, -1), Quaternion.identity);
                }
                else
                {
                    Instantiate<GameObject>(tiles[4], new Vector3(i, j, -1), Quaternion.identity);
                }
            }
        }
    }

    void createResources()
    {
        for (int i = 1; i < ground.GetLength(0) - 1; i++)
        {
            for (int j = 1; j < ground.GetLength(1) - 1; j++)
            {
                if (ground[i, j] == wood)
                {
                    Instantiate<GameObject>(resourceGOs[0]);
                }
                if (ground[i, j] == stone)
                {
                    Instantiate<GameObject>(resourceGOs[1]);
                }
                if (ground[i, j] == food)
                {
                    Instantiate<GameObject>(resourceGOs[2]);
                }
            }
        }
    }
}