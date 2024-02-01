using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using GameTypes;

namespace Graphics
{
    //Game display
    public class GraphicsDisplay : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Texture2D _pixelTexture;
        //used to optimize redraws to only when state has changed.
        private bool _updateDisplay = true;
        readonly Func<int, GameAction, GameState> _inputHandler;
        EntitySelector EntitySelector { get; set; }
        public GraphicsDisplay(Func<int, GameAction, GameState> inputHandler)
        {
            _inputHandler = inputHandler;
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            _spriteBatch = new(GraphicsDevice);
            EntitySelector = new EntitySelector(this);
            Components.Add(EntitySelector);
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
            if(EntitySelector.Entities.Count == 0)
                return;

            var input = Keyboard.GetState();
            if (input.IsKeyDown(Keys.W))
                _inputHandler(EntitySelector.SelectedId, );
                

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            //If state has changed since last draw, redraw everything
            if(_updateDisplay)
            {
                GraphicsDevice.Clear(Color.CornflowerBlue);
                //Acquire lock because draw loop is on different thread from entity updater.
                lock (EntitySelector.Entities)
                {
                    //drawing code here
                    _spriteBatch.Begin();
                    foreach (Entity entity in EntitySelector.Entities)
                    {
                        var (r, g, b) = entity.Color;
                        _spriteBatch.Draw(_pixelTexture, entity.Pos, null, new Color(r, g, b), 0, Vector2.Zero, Vector2.One * 50, SpriteEffects.None, 0);
                    }
                    _spriteBatch.End();
                    _updateDisplay = false;
                }
            }
            base.Draw(gameTime);
        }
        //Update entity display
        public void SetEntities(IEnumerable<Entity> entities)
        {
            //Acquire lock to avoid conflict with Draw
            lock(EntitySelector.Entities)
            {
                EntitySelector.Entities = new(entities);
                _updateDisplay = true;
            }
        }
    }
}
