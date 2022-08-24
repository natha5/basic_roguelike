using System;
using SadConsole;
using Console = SadConsole.Console;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace basicRoguelike
{
    
    class Program
    {
        public const int Width = 80;
        public const int Height = 25;
        
        [STAThread]
        static void Main(string[] args)
        {
            //Setup engine and create main window
            SadConsole.Game.Create(Width, Height);

            //Hook the start event so we can add consoles to the system
            SadConsole.Game.OnUpdate = Update;

            //Start the game
            SadConsole.Game.Instance.Run();

            //code here will not run until the game window closes

            SadConsole.Game.Instance.Dispose;
        }

        private static void Update(GameTime time)
        {
            // called each logic update
            //as an example, use f5 to make game full screen

            if (SadConsole.Global.KeyboardState.IsKeyReleased(Microsoft.Xna.Framework.Input.Keys.F5))
            {
                SadConsole.Settings.ToggleFullScreen();
            }
        }

        
    }
}
