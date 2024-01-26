﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Graphics
{
    public class GraphicsDisplay : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private List<DisplayEntity> _entities;
        private Texture2D _pixelTexture;
        public GraphicsDisplay()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            _spriteBatch = new(GraphicsDevice);
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _pixelTexture = Content.Load<Texture2D>("pixel");
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // No update logic for our graphics display, that's handled in Game project.

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            //Acquire lock because draw loop is on different thread from entity updater.
            lock (_entities)
            {
                //drawing code here
                _spriteBatch.Begin();
                foreach (DisplayEntity entity in _entities)
                {
                    _spriteBatch.Draw(_pixelTexture, entity.Position, null, entity.Color, 0, Vector2.Zero, entity.Size, SpriteEffects.None, 0);
                }
                _spriteBatch.End();
            }
            base.Draw(gameTime);
        }
        public void SetEntities(IEnumerable<DisplayEntity> entities)
        {
            lock(_entities)
            {
                _entities = new(entities);
            }
        }
    }
}