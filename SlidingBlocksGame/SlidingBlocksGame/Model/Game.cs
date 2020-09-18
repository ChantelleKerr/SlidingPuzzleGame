using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using Xamarin.Forms;

namespace SlidingBlocksGame.Model
{
    public class Game
    {
        string prevDir = "";
        int shuffleAmount = 10;

        public Game() { }

        // Return the position from the given row and column
        public int CheckTile(int row, int col)
        {
            int position = 10;
            if(row == 0 && col == 0)
            {
                position = 0;
            } 
            else if(row == 0 && col == 1)
            {
                position = 1;
            }
            else if (row == 0 && col == 2)
            {
                position = 2;
            }
            else if (row == 1 && col == 0)
            {
                position = 3;
            }
            else if (row == 1 && col == 1)
            {
                position = 4;
            }
            else if (row == 1 && col == 2)
            {
                position = 5;
            }
            else if (row == 2 && col == 0)
            {
                position = 6;
            }
            else if (row == 2 && col == 1)
            {
                position = 7;
            }
            else if (row == 2 && col == 2)
            {
                position = 8;
            }
            return position;
        }

        // Switches position between an empty tile and the swiped tile
        public void MoveTile(int row, int col)
        {
            int curPos = CheckTile(row, col);
            foreach (var i in Tile.tileset)
            {
                if (i.isEmpty)
                {
                    i.image = Tile.tileset[curPos].image; // The empty tile now has the image of the swiped tile
                    Tile.tileset[curPos].image = ""; // The swiped tile is now empty
                    i.isEmpty = false;
                    Tile.tileset[curPos].isEmpty = true;
                    break;
                }
            }
        }

        // Check if the tiles are in the correct position
        public bool CheckWin()
        {
            List<bool> winningTiles = new List<bool>();
            winningTiles.Clear();
            bool win = false;
            foreach(var tile in Tile.tileset)
            {
                if(tile.winPosition == 0 && tile.image == "")
                {
                    win = true;
                }
                else if(tile.winPosition == 1 && tile.image == "Assets/Graphics/one.png")
                {
                    win = true;
                }
                else if (tile.winPosition == 2 && tile.image == "Assets/Graphics/two.png")
                {
                    win = true;
                }
                else if (tile.winPosition == 3 && tile.image == "Assets/Graphics/three.png")
                {
                    win = true;
                }
                else if (tile.winPosition == 4 && tile.image == "Assets/Graphics/four.png")
                {
                    win = true;
                }
                else if (tile.winPosition == 5 && tile.image == "Assets/Graphics/five.png")
                {
                    win = true;
                }
                else if (tile.winPosition == 6 && tile.image == "Assets/Graphics/six.png")
                {
                    win = true;
                }
                else if (tile.winPosition == 7 && tile.image == "Assets/Graphics/seven.png")
                {
                    win = true;
                }
                else if (tile.winPosition == 8 && tile.image == "Assets/Graphics/eight.png")
                {
                    win = true;
                }
                else
                {
                    win = false;
                }

                if(win == true)
                {
                    winningTiles.Add(win);
                } 
            }
            if(winningTiles.Count == 9)
            {
                win = true;
            }
            else
            {
                win = false;
            }
            return win;
        }

        // Shuffles the tiles 
        public void Reset()
        {
            for (int i = 0; i < shuffleAmount; i++)
            {
                int emptyPos = 0;
                int newPos = 0;
                bool foundEmpty = false;
                List<int> direction = new List<int>(); // Left = 0, Right = 1, Up = 2, Down = 3

                while (!foundEmpty)
                {
                    direction.Clear();

                    //Find the empty tile position
                    for (int x = 0; x < Tile.tileset.Count; x++)
                    {
                        if (Tile.tileset[x].isEmpty)
                        {
                            emptyPos = x;
                            break;
                        }
                    }

                    // Add the directions of the tiles that can be moved into the empty tile
                    if (emptyPos == 0)
                    {
                        direction.Add(0);
                        direction.Add(3);
                    }
                    else if (emptyPos == 1)
                    {
                        direction.Add(0);
                        direction.Add(1);
                        direction.Add(3);
                    }
                    else if (emptyPos == 2)
                    {
                        direction.Add(1);
                        direction.Add(3);
                    }

                    else if (emptyPos == 3)
                    {
                        direction.Add(0);
                        direction.Add(2);
                        direction.Add(3);
                    }
                    else if (emptyPos == 4)
                    {
                        direction.Add(0);
                        direction.Add(1);
                        direction.Add(2);
                        direction.Add(3);
                    }
                    else if (emptyPos == 5)
                    {
                        direction.Add(1);
                        direction.Add(2);
                        direction.Add(3);
                    }
                    else if (emptyPos == 6)
                    {
                        direction.Add(0);
                        direction.Add(2);
                    }
                    else if (emptyPos == 7)
                    {
                        direction.Add(0);
                        direction.Add(1);
                        direction.Add(2);
                    }
                    else if (emptyPos == 8)
                    {
                        direction.Add(1);
                        direction.Add(2);
                    }

                    Random randomPos = new Random();
                    int moveDirection = randomPos.Next(0, direction.Count); // Choose a random direction from the list
                    bool isValid = false;
                    newPos = emptyPos;
                    if (direction[moveDirection] == 0)
                    {
                        // Check if the tile hasn't been moved in the previous move
                        if (prevDir != "Right")
                        {
                            newPos += 1;
                            prevDir = "Left";
                            isValid = true;
                        }
                    }
                    else if (direction[moveDirection] == 1)
                    {
                        if (prevDir != "Left")
                        {
                            newPos -= 1;
                            prevDir = "Right";
                            isValid = true;
                        }
                    }
                    else if (direction[moveDirection] == 2)
                    {
                        if (prevDir != "Up")
                        {
                            newPos -= 3;
                            prevDir = "Down";
                            isValid = true;
                        }
                    }
                    else if (direction[moveDirection] == 3)
                    {
                        if (prevDir != "Down")
                        {
                            newPos += 3;
                            prevDir = "Up";
                            isValid = true;
                        }
                    }
                    // If a tile can be moved
                    if (isValid)
                    {
                        MoveTile(Tile.tileset[newPos].row, Tile.tileset[newPos].col);
                        foundEmpty = true;
                    }
                }
            }
        }
    }
}
