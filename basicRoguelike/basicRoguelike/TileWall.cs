using System;
using Microsoft.Xna.Framework;


namespace basicRoguelike
{
    //TileWall based on TileBase
    public class TileWall : TileBase
    {
        //Default constructor
        //Walls are set to block movement and line of sight
        //grey foreground and transparent background
        //represetned by # symbol

        public TileWall(bool blocksMovement=true, bool blocksLOS=true) : base(Color.LightGray, Color.Transparent, '#', blocksMovement, blocksLOS)
        {
            Name = "Wall";
        }
    }
}
