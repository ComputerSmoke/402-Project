using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended.Input.InputListeners;
using GameTypes;
using Microsoft.Xna.Framework.Content;

namespace Graphics
{
    internal class EntitySelector : GameComponent
    {
        int selectedId;
        readonly GraphicsDisplay _game;
        public EntitySelector(GraphicsDisplay display) : base(display) {
            _game = display;
        }

        public override void Update(GameTime gameTime)
        {
            var input = Keyboard.GetState();
            if (input.IsKeyDown(Keys.Right))
                 selectedId = MaxCapped(selectedId + 1, _game.Entities);
            else if (input.IsKeyDown(Keys.Right))
                selectedId = MaxCapped(selectedId - 1, _game.Entities);
        }
        //Get entity id which is strictly less than cap
        static int MaxCapped(int cap, List<Entity> entities)
        {
            int max = -1;
            foreach (Entity entity in entities)
            {
                if(entity.id < cap && entity.id > max)
                    max = entity.id;
            }
            return max;
        }
        
    }
}
