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
using System.Numerics;

namespace Graphics
{
    internal class EntitySelector : GameComponent
    {
        public int SelectedId { get; private set; }
        List<Entity> _entities = new();
        public List<Entity> Entities
        {
            get
            {
                return _entities;
            }
            set
            {
                _entities = value;
                //Make sure selectedId points to a valid entity if list is nonempty
                if (_entities.Count == 0 || _entities.Find(entity => entity.id == SelectedId) != null)
                    return;
                SelectedId = MinCapped(SelectedId, _entities);
            }
        }
        public EntitySelector(Game game) : base(game) {}

        public override void Update(GameTime gameTime)
        {
            if (Entities.Count == 0)
                return;
            var input = Keyboard.GetState();
            if (input.IsKeyDown(Keys.Right))
                IncrementSelected();
            else if (input.IsKeyDown(Keys.Left))
                DeincrementSelected();
        }
        void IncrementSelected()
        {
            int maxId = MaxId(Entities);
            if (maxId <= SelectedId)
                SelectedId = MinId(Entities);
            else
                SelectedId = MinCapped(SelectedId, Entities);
        }
        void DeincrementSelected()
        {
            int minId = MinId(Entities);
            if (minId >= SelectedId)
                SelectedId = MinId(Entities);
            else
                SelectedId = MaxCapped(SelectedId, Entities);
        }
        static int MaxId(List<Entity> entities)
        {
            int max = entities[0].id;
            foreach(Entity entity in entities)
                max = Math.Max(max, entity.id);
            return max;
        }
        static int MinId(List<Entity> entities)
        {
            int min = entities[0].id;
            foreach (Entity entity in entities)
                min = Math.Min(min, entity.id);
            return min;
        }
        //Get entity id which is strictly less than cap
        static int MaxCapped(int cap, List<Entity> entities)
        {
            int max = cap;
            foreach (Entity entity in entities)
            {
                if(max == cap || entity.id < cap && entity.id > max)
                    max = entity.id;
            }
            return max;
        }
        static int MinCapped(int cap, List<Entity> entities)
        {
            int min = cap;
            foreach (Entity entity in entities)
            {
                if (min == cap || entity.id > cap && entity.id < min)
                    min = entity.id;
            }
            return min;
        }
    }
}
