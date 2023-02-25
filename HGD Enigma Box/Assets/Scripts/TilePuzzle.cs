using UnityEngine;

public class TilePuzzle : MonoBehaviour
{
    [SerializeField] private Transform emptySpace = null;
    private Camera _camera;
    [SerializeField] private TilesScript[] tiles;
    private int emptySpaceIndex = 14;

    void Start()
    {
        _camera = Camera.main;
        Shuffle();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);
            if (hit) {
                if(Vector2.Distance(emptySpace.position, hit.transform.position) < 2) {
                    Vector2 lastEmptySpacePosition = emptySpace.position;
                    TilesScript thisTile = hit.transform.GetComponent<TilesScript>();
                    emptySpace.position = thisTile.targetPosition;
                    thisTile.targetPosition = lastEmptySpacePosition;
                    int tileInd = findInd(thisTile);
                    tiles[emptySpaceIndex] = tiles[tileInd];
                    tiles[tileInd] = null;
                    emptySpaceIndex = tileInd;

                }
            }
        }
    }

    public void Shuffle() {
        int inversions;
        do {
        for (int i = 0; i <= 13; i++) {
            var lastPos = tiles[i].targetPosition;
            int randInd = Random.Range(0, 13);
            tiles[i].targetPosition = tiles[randInd].targetPosition;
            tiles[randInd].targetPosition = lastPos;
            var tile = tiles[i];
            tiles[i] = tiles[randInd];
            tiles[randInd] = tile;
        }
        inversions = getInversions();
        } while(inversions % 2 != 0);
    }

    public int findInd(TilesScript ts) {
        for (int i = 0; i < tiles.Length; i++) {
            if (tiles[i] != null) {
                if (tiles[i] == ts) {
                    return i;
                }
            }
        }
        return -1;
    }

    int getInversions() {
        int inversionSum = 0;
        for (int i = 0; i < tiles.Length; i++) {
            int thisTileInversion = 0;
            for (int j = i; j < tiles.Length; j++) {
                if (tiles[j] != null) {
                    if (tiles[i].num > tiles[j].num) {
                        thisTileInversion++;
                    }
                }
            }
            inversionSum += thisTileInversion;
        }
        return inversionSum;
    }
}
