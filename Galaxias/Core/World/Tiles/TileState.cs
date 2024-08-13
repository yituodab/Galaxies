﻿using Galaxias.Core.World.Entities;
using System;

namespace Galaxias.Core.World.Tiles;
public class TileState
{
    private readonly Tile tile;

    public TileState(Tile tile)
    {
        this.tile = tile;
    }

    public Tile GetTile()
    {
        return tile;
    }
    public int GetLight()
    {
        return tile.GetLight(this);
    }

    public void OnUse(AbstractWorld world, int x, int y, TileState tileState, Player player)
    {
        tile.OnUse(world, x, y, tileState, player);
    }
}
