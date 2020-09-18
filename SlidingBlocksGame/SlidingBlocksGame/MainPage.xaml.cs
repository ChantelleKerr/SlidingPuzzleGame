using SlidingBlocksGame.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SlidingBlocksGame
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        Game game;
        public MainPage()
        {
            InitializeComponent();
            game = new Game();
            game.Reset();
            UpdateUI();
        }

        private async void SwipeGestureRecognizer_Swiped(object sender, SwipedEventArgs e)
        {
            Image myImage = (Image)sender;
            int col = Grid.GetColumn(myImage);
            int row = Grid.GetRow(myImage);
            int posCur = game.CheckTile(row, col);

            switch (e.Direction)
            {
                case SwipeDirection.Left:
                    if(Tile.tileset[posCur - 1].isEmpty)
                    {
                        game.MoveTile(row, col);
                    }
                    break;
                case SwipeDirection.Right:
                    if (Tile.tileset[posCur + 1].isEmpty)
                    {
                        game.MoveTile(row, col);
                    }
                    break;
                case SwipeDirection.Up:
                    if (Tile.tileset[posCur - 3].isEmpty)
                    {
                        game.MoveTile(row, col);
                    }
                    break;
                case SwipeDirection.Down:
                    if (Tile.tileset[posCur + 3].isEmpty)
                    {
                        game.MoveTile(row, col);
                    }
                    break;
            }
            bool win = game.CheckWin();
            UpdateUI();
            if (win == true)
            {
                DisplayWin();
            }
        }

        public async void DisplayWin()
        {
            await DisplayAlert("You Win", "You are a winner!!", "OK");
            UpdateUI();
        }
        // Update Images to new positions
        public void UpdateUI()
        {
            Image[] imageLocation = { TopLeft, TopMiddle, TopRight, MiddleLeft, MiddleMiddle,
                MiddleRight, BottomLeft, BottomMiddle, BottomRight };
            
            for(int i = 0; i < Tile.tileset.Count; i++)
            {
                imageLocation[i].Source = Tile.tileset[i].image;
            }
        }

        private void ResetButton_Clicked(object sender, EventArgs e)
        {
            game.Reset();
            UpdateUI();
        }
    }
}
