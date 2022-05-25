using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeController : MonoBehaviour {
    public GameObject tile = null;
    public float uncoverRadius = 1;
    
    private List<Vector2> hiddenTiles = new List<Vector2>();
    private Dictionary<Vector2, GameObject> furnitureMap = new Dictionary<Vector2, GameObject>();
    private Dictionary<Vector2, Quaternion> furnitureRotationMap = new Dictionary<Vector2, Quaternion>();
    private Vector2 tileDims = new Vector2(0, 0);

    Vector3 GetTilePosition(Vector2 pos) {
        Vector3 basePosition = gameObject.transform.position;

        return new Vector3(basePosition.x + pos.y * tileDims.x, basePosition.y, basePosition.z - pos.x * tileDims.y);
    } 

    List<Vector2> GetTilesToUncover(Vector2 pos) {
        List<Vector2> tilesToUncover = new List<Vector2>();

        foreach(Vector2 hiddenPos in hiddenTiles) {
            if(Vector2.Distance(pos, hiddenPos) <= uncoverRadius) {
                tilesToUncover.Add(hiddenPos);
            }
        }

        foreach(Vector2 hiddenPos in tilesToUncover) {
            hiddenTiles.Remove(hiddenPos);
        }

        return tilesToUncover;
    }

    void InstantiateTile(Vector2 pos) {
        GameObject startTile = Instantiate(tile, GetTilePosition(pos), gameObject.transform.rotation);
        startTile.GetComponent<TileController>().pos = pos;
    }

    void InitializeTiles() {
        Vector3 tileSize = tile.GetComponent<Renderer>().bounds.size;
        tileDims = new Vector2(tileSize.x, tileSize.z);

        string[] rawLayout = new string[]{
            "x.....Sx",
            "......x.",
            ".bxx..x.",
            "...x..x.",
            "...xxxxx",
            "...x...x",
            ".xxxxo.c",
            ".x.x....",
            ".x.f....",
            ".x......",
            "xxx....x"
        };


        for(int i = 0; i < rawLayout.Length; i++) {
            for(int j = 0; j < rawLayout[i].Length; j++) {
                Vector2 vec = new Vector2(j, i);
                if(rawLayout[i][j] == 'x') {
                    hiddenTiles.Add(vec);
                } else if(rawLayout[i][j] == 'S') {
                    InstantiateTile(vec);
                } else if(rawLayout[i][j] == 'b') {
                    hiddenTiles.Add(vec);
                    furnitureMap.Add(vec, Resources.Load<GameObject>("Cursed_Bed"));
                    furnitureRotationMap.Add(vec, Quaternion.Euler(15, 0, -45));
                } else if(rawLayout[i][j] == 'c') {
                    hiddenTiles.Add(vec);
                    furnitureMap.Add(vec, Resources.Load<GameObject>("Cursed_Chair"));
                    furnitureRotationMap.Add(vec, Quaternion.Euler(-120, 170, 200));
                } else if(rawLayout[i][j] == 'o') {
                    hiddenTiles.Add(vec);
                    furnitureMap.Add(vec, Resources.Load<GameObject>("Cursed_Cooker"));
                    furnitureRotationMap.Add(vec, Quaternion.Euler(305, 295, 300));
                } else if(rawLayout[i][j] == 'f') {
                    hiddenTiles.Add(vec);
                    furnitureMap.Add(vec, Resources.Load<GameObject>("Cursed_Couch"));
                    furnitureRotationMap.Add(vec, Quaternion.Euler(285, 350, 10));
                }
            }
        }
    }

    public void UncoverTiles(Vector2 pos) {
        List<Vector2> tilesToUncover = GetTilesToUncover(pos);
        foreach(Vector2 tilePos in tilesToUncover) {
            GameObject furniture;
            if(!furnitureMap.TryGetValue(tilePos, out furniture)) {
                InstantiateTile(tilePos);
            } else {
                // Instantiate(furniture, GetTilePosition(tilePos), furnitureRotationMap[tilePos]);
                Instantiate(furniture, GetTilePosition(tilePos), Quaternion.Euler(0, 0, 0));
                Debug.Log(furniture.transform.rotation);
                furniture.transform.LookAt(new Vector3(10, 100, 10));
                Debug.Log(furniture.transform.rotation);
            }
        }
    }
    

    // Start is called before the first frame update
    void Start() {
        InitializeTiles();
    }

    // Update is called once per frame
    void Update() {
        
    }
}
