﻿using System;
using SadConsole;
using Console = SadConsole.Console;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Runtime.Remoting.Metadata.W3cXsd2001;

namespace basicRoguelike
{
    
    class GameLoop
    {
        public const int Width = 80;
        public const int Height = 25;
        private static SadConsole.Entities.Entity player;
        
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
        }

        private static void Init()
        {
            // any custom loading and prep. using sample console for now

            Console startingConsole = new Console(Width, Height);
            //startingConsole.FillWithRandomGarbage();
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
    }
}