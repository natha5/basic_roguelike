using System;
using Microsoft.Xna.Framework;

namespace basicRoguelike
{
    // TileFloor is based on TileBase
    // Floor tiles to be used in maps

    public class TileFloor : TileBase
    {
        // Default constructor
        // Floors allow movement and line of sight
        // dark grey foreground and transparent background
        // represented by the . symbol

        public TileFloor(bool blocksMovement=false, bool blocksLOS=false) : base(Color.DarkGray, Color.Transparent, '.', blocksMovement, blocksLOS)
        {
            Name = "Floor";
        }
    }
}
