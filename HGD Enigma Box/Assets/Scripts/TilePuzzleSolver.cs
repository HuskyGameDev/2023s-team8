using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilePuzzleSolver : MonoBehaviour {
    public GameManager gameManager;
    // Start is called before the first frame update
    void Start() { }

    // Update is called once per frame
    void Update() { }
    public void finished(){
        gameManager.pogressMade();
    }
}

// class SlidingPuzzleSolver {
//     static int[] dx = { -1, 0, 1, 0 };
//     static int[] dy = { 0, 1, 0, -1 };

//     static int Heuristic(int[,] puzzle, int[,] goal) {
//         int h = 0;
//         for (int i = 0; i < puzzle.GetLength(0); i++) {
//             for (int j = 0; j < puzzle.GetLength(1); j++) {
//                 if (puzzle[i, j] != 0 && puzzle[i, j] != goal[i, j]) {
//                     h++;
//                 }
//             }
//         }
//         return h;
//     }

//     static bool IsGoalState(int[,] puzzle, int[,] goal) {
//         for (int i = 0; i < puzzle.GetLength(0); i++) {
//             for (int j = 0; j < puzzle.GetLength(1); j++) {
//                 if (puzzle[i, j] != goal[i, j]) {
//                     return false;
//                 }
//             }
//         }
//         return true;
//     }

//     static bool IsValidMove(int[,] puzzle, int x, int y) {
//         return x >= 0 && x < puzzle.GetLength(0) && y >= 0 && y < puzzle.GetLength(1);
//     }

//     static void Swap(ref int a, ref int b) {
//         int tmp = a;
//         a = b;
//         b = tmp;
//     }

//     static int[,] ClonePuzzle(int[,] puzzle) {
//         int[,] clone = new int[puzzle.GetLength(0), puzzle.GetLength(1)];
//         for (int i = 0; i < puzzle.GetLength(0); i++) {
//             for (int j = 0; j < puzzle.GetLength(1); j++) {
//                 clone[i, j] = puzzle[i, j];
//             }
//         }
//         return clone;
//     }

//     static List<int[,]> GetSuccessors(int[,] puzzle) {
//         List<int[,]> successors = new List<int[,]>();
//         int x = 0;
//         int y = 0;
//         for (int i = 0; i < puzzle.GetLength(0); i++) {
//             for (int j = 0; j < puzzle.GetLength(1); j++) {
//                 if (puzzle[i, j] == 0) {
//                     x = i;
//                     y = j;
//                 }
//             }
//         }
//         for (int i = 0; i < 4; i++) {
//             int nx = x + dx[i];
//             int ny = y + dy[i];
//             if (IsValidMove(puzzle, nx, ny)) {
//                 int[,] successor = ClonePuzzle(puzzle);
//                 Swap(ref successor[x, y], ref successor[nx, ny]);
//                 successors.Add(successor);
//             }
//         }
//         return successors;
//     }

//     static int[,] Solve(int[,] puzzle, int[,] goal) {
//         int[,] result = null;
//         HashSet<int[,]> closed = new HashSet<int[,]>();
//         Dictionary<int[,], int> g = new Dictionary<int[,], int>();
//         Dictionary<int[,], int> f = new Dictionary<int[,], int>();
//         Dictionary<int[,], int[,]> parent = new Dictionary<int[,], int[,]>();
//         PriorityQueue<int[,]> open = new PriorityQueue<int[,]>(new PuzzleComparer(f));

//         g[puzzle] = 0;
//         f[puzzle]
//     }
// }