using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundGenerator : MonoBehaviour
{
    
    int[,] ground = new int[15, 15];

    [SerializeField]
    private GameObject[] tiles = null;
    [SerializeField]
    private GameObject[] resourceGOs = null;
    [SerializeField]
    private GameObject homeGO = null;

    private int food = 2;
    private int stone = 3;
    private int wood = 4;
    private int home = 5;

    private int groundDepth = 1;
    private int resourceDepth = 0;
    private int houseDepth = -2;
    private int workerDepth = -1;

    private int[] houseCoords;
    /*
     0,1,2
     3,4,5
     6,7,8
     */

    // Start is called before the first frame update
    void Start()
    {
        houseCoords  = new int[]{ ground.GetLength(0) / 2, ground.GetLength(1) / 2 }; 
        for (int i = 1; i < ground.GetLength(0) - 1; i++)
        {
            for (int j = 1; j < ground.GetLength(1) - 1; j++)
            {
                ground[i, j] = 1;
                if (isEdge(i,j))
                    continue;
                generateResource(i,j);
            }
        }

        createGround();
        createHome();
        createResources();
        
        Destroy(gameObject);
    }

    bool isEdge(int x, int y) {
        return x == 1 || x == ground.GetLength(0) - 2 || y == 1 || y == ground.GetLength(1) - 2;
    }

    void generateResource(int x, int y) {
        
        if (Random.value < 0.10f)
        {
            ground[x, y] = wood;
        }
        if (Random.value < 0.10f)
        {
            ground[x, y] = stone;
        }
        if (Random.value < 0.10f)
        {
            ground[x, y] = food;
        }
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
                    spawn(tiles[6], i, j, groundDepth);
                }
                else if (ground[i + 1, j] == 0 && ground[i, j - 1] == 0)
                {
                    spawn(tiles[8], i, j, groundDepth);
                }
                else if (ground[i + 1, j] == 0 && ground[i, j + 1] == 0)
                {
                    spawn(tiles[2], i, j, groundDepth);
                }
                else if (ground[i - 1, j] == 0 && ground[i, j + 1] == 0)
                {
                    spawn(tiles[0], i, j, groundDepth);
                }
                else if (ground[i + 1, j] == 0)
                {
                    spawn(tiles[5], i, j, groundDepth);
                }
                else if (ground[i - 1, j] == 0)
                {
                    spawn(tiles[3], i, j, groundDepth);
                }
                else if (ground[i, j + 1] == 0)
                {
                    spawn(tiles[1], i, j, groundDepth);
                }
                else if (ground[i, j - 1] == 0)
                {
                    spawn(tiles[7], i, j, groundDepth);
                }
                else
                {
                    spawn(tiles[4], i, j, groundDepth);
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
                if ((i >= houseCoords[0] - 1 && i <= houseCoords[0] + 1) && (j >= houseCoords[1] - 1 && j <= houseCoords[1] + 1))
                    continue;

                if (ground[i, j] == wood)
                {
                    spawn(resourceGOs[0], i, j, resourceDepth);
                }
                if (ground[i, j] == stone)
                {
                    spawn(resourceGOs[1], i, j, resourceDepth);
                }
                if (ground[i, j] == food)
                {
                    spawn(resourceGOs[2], i, j, resourceDepth); 
                }
            }
        }
    }

    private void createHome() {
        ground[ground.GetLength(0) / 2, ground.GetLength(1) / 2] = home;
        GameObject go = spawn(homeGO, houseCoords[0], houseCoords[1], houseDepth);
        go.GetComponent<City>().AddCollector();
    }
    private GameObject spawn(GameObject go, int x, int y, int z) {
        return Instantiate<GameObject>(go, new Vector3(x, y, z), Quaternion.identity);
    }
}