using System;
using SadConsole;
using Console = SadConsole.Console;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Linq.Expressions;

namespace basicRoguelike
{
    
    class GameLoop
    {
        public const int Width = 80;
        public const int Height = 25;
        private static SadConsole.Entities.Entity player;
        private static TileBase[] _tiles;
        private const int _roomWidth = 10;
        private const int _roomHeight = 20;
        
        [STAThread]
        static void Main(string[] args)
        {
            //Setup engine and create main window
            SadConsole.Game.Create(Width, Height);

            //Hook the start event so we can add consoles to the system
            SadConsole.Game.OnInitialize = Init;

            //Hook the update event that happens each frame so we can trap keys and respond
            SadConsole.Game.OnUpdate = Update;

            //Start the game
            SadConsole.Game.Instance.Run();

            //code here will not run until the game window closes

            SadConsole.Game.Instance.Dispose();
        }

        private static void Update(GameTime time)
        {
            // called each logic update
            //as an example, use f5 to make game full screen

            if (SadConsole.Global.KeyboardState.IsKeyReleased(Microsoft.Xna.Framework.Input.Keys.F5))
            {
                SadConsole.Settings.ToggleFullScreen();
            }
            // move up
            if (SadConsole.Global.KeyboardState.IsKeyPressed(Microsoft.Xna.Framework.Input.Keys.Up))
            {
                player.Position += new Point(0, -1);
            }
            // move down
            if (SadConsole.Global.KeyboardState.IsKeyPressed(Microsoft.Xna.Framework.Input.Keys.Down))
            {
                player.Position += new Point(0, 1);
            }
            // move left
            if (SadConsole.Global.KeyboardState.IsKeyPressed(Microsoft.Xna.Framework.Input.Keys.Left))
            {
                player.Position += new Point(-1, 0);
            }
            // move right
            if (SadConsole.Global.KeyboardState.IsKeyPressed(Microsoft.Xna.Framework.Input.Keys.Right))
            {
                player.Position += new Point(1, 0);
            }

        }

        private static void Init()
        {
            // any custom loading and prep. using sample console for now
            //Build walls and floors:
            CreateWalls();
            CreateFloors();


            Console startingConsole = new ScrollingConsole(Width, Height, Global.FontDefault, new Rectangle(0,0,Width,Height), _tiles);
           
            startingConsole.Fill(new Rectangle(3, 3, 27, 5), null, Color.Black, 0, SpriteEffects.None);
            startingConsole.Print(6, 5, "Hello from sadconsole", ColorAnsi.CyanBright);

            //set our new console as the thing to render and process

            SadConsole.Global.CurrentScreen = startingConsole;

            CreatePlayer();

            //add the player entity to the console so it will display on screen

            startingConsole.Children.Add(player);
        }

        private static void CreatePlayer()
        {
            player = new SadConsole.Entities.Entity(1, 1);
            player.Animation.CurrentFrame[0].Glyph = '@';
            player.Animation.CurrentFrame[0].Foreground = Color.HotPink;
            player.Position = new Point(20, 10);
        }

        private static void CreateFloors()
        {
            for(int x = 0; x< _roomWidth; x++)
            {
                for (int y = 0; y < _roomHeight; y++)
                {
                    //calcualtes index in the array based on y of tile, width of map and x of tile
                    _tiles[y * Width + x] = new TileFloor();
                }
            }
        }

        private static void CreateWalls()
        {
            _tiles = new TileBase[Width * Height];
            for (int i = 0; i < _tiles.Length; i++)
            {
                _tiles[i] = new TileWall();
            }
        }
    }
}
