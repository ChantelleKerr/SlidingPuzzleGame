using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Xamarin.Forms.Xaml;

namespace SlidingBlocksGame.Model
{
    public class Tile
    {
        public int row, col;
        public string image;
        public bool isEmpty;
        public int winPosition;

        public Tile() { }
        public Tile(int _winPos, int _row, int _col, string _image, bool _isEmpty)
        {
            this.winPosition = _winPos;
            this.row = _row;
            this.col = _col;
            this.image = _image;
            this.isEmpty = _isEmpty;
        }

        public static List<Tile> tileset = new List<Tile>()
        {
            new Tile(0, 0, 0,"",true),
            new Tile(1, 0, 1,"Assets/Graphics/one.png", false),
            new Tile(2, 0, 2,"Assets/Graphics/two.png", false),

            new Tile(3, 1, 0,"Assets/Graphics/three.png", false),
            new Tile(4, 1, 1,"Assets/Graphics/four.png", false),
            new Tile(5, 1, 2,"Assets/Graphics/five.png", false),

            new Tile(6, 2, 0,"Assets/Graphics/six.png", false),
            new Tile(7, 2, 1,"Assets/Graphics/seven.png", false),
            new Tile(8, 2, 2,"Assets/Graphics/eight.png", false)
        };
    }
}
