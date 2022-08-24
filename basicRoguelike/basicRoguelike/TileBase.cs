using System;
using Microsoft.Xna.Framework;
using SadConsole;

namespace basicRoguelike
{
    //abstract base class representing the most basic form of all tiles used

    public abstract class TileBase : Cell
    {
        //movement and line of sight flags
        protected bool IsBlockingMove;
        protected bool IsBlockingLOS;

        //Tiles name
        protected string Name;

        //each tilebase has a forground and background colour and glyph
        //IsBlockingMove and IsBlockingLOs are optional, default false

        //Default constructor
        public TileBase(Color foreground, Color background, int glyph, bool blockingMove=false, bool blockingLOS=false, String name="") : base(foreground, background, glyph)
        {
            IsBlockingMove = blockingMove;
            IsBlockingLOS = blockingLOS;
            Name = name;
        }
    }
}
