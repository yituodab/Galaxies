﻿using ClientGalaxias.Client.Render;
using Galasias.Core.World.Items;
using Galaxias.Core.World;
using Galaxias.Core.World.Entities;
using Galaxias.Core.World.Tiles;
using Galaxias.Util;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using SharpDX.Direct3D11;

namespace ClientGalaxias.Client;
public class InteractionManager
{
    private AbstractWorld world;
    public InteractionManager(AbstractWorld world)
    {
        this.world = world;
    }

    public void Update(Main.GalaxiasClient galaxias, Camera camera)
    {
        if (galaxias.IsActive)
        {
            var state = Mouse.GetState();
            if (state.LeftButton == ButtonState.Pressed)
            {
                Vector2 p = camera.ScreenToWorldSpace(state.Position);
                int x = Utils.Floor(p.X / 8);
                int y = Utils.Floor(-p.Y / 8);
                var tileState = world.GetTileState(TileLayer.Main, x, y);
                if (tileState.GetTile() != AllTiles.Air && tileState.GetTile().OnBreak(world, x, y, tileState))
                {
                    world.SetTileState(TileLayer.Main, x, y, AllTiles.Air.GetDefaultState());
                }

            }
            else if (state.RightButton == ButtonState.Pressed)
            {
                Vector2 p = camera.ScreenToWorldSpace(state.Position);
                int x = Utils.Floor(p.X / 8);
                int y = Utils.Floor(-p.Y / 8);
                Player player = galaxias.GetPlayer();
                player.HitX = x;
                player.HitY = y;
                var tileState = world.GetTileState(TileLayer.Main, x, y);
                if(player.GetItemOnHand().GetItem() is TileItem){
                    player.GetItemOnHand().GetItem().UseOn(galaxias.GetWorld(), player, tileState, x, y);
                }
                else player.GetItemOnHand().GetItem().Use(galaxias.GetWorld(), player, player.GetItemOnHand());
            }

        }
    }
}
