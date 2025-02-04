using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TimeTravelGrid : SGrid
{
    public int gridOffset = 100; //C: The X distance between the present and past grid

    /* C: The Magitech grid is a 6 by 3 grid. The left 9 STiles represent the present,
    and the right 9 STiles represent the past. The past tile will have an islandID
    exactly 9 more than its corresponding present tile. Note that in strings, the past tiles
    will be reprsented with the characters A-I so they can retain a length of 1. *THIS HAS NOT BEEN PROPERLY IMPLEMENTED YET

    A Magitech grid might look like this

    1 2 3   A B C
    4 5 6   D E F
    7 8 9   G H I

    */

    public override void CollectSTile(int islandId)
    {
        foreach (STile s in grid)
        {
            if (s.islandId == islandId || s.islandId - 9 == islandId)
            {
                CollectStile(s);
            }
        }
    }

    public override int GetNumTilesCollected()
    {
        int numCollected = 0;
        foreach (STile tile in stiles)
        {
            if (tile.isTileCollected)
            {
                numCollected++;
            }
        }
        return numCollected / 2;
    }

    public override int GetTotalNumTiles()
    {
        return width * height / 2;
    }
}
