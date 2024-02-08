module Draw

open GameTypes
open Microsoft.Xna.Framework.Graphics
open Microsoft.Xna.Framework.Content
open Microsoft.Xna.Framework
open GameLogic

let textureNames =
    Map [Hero, "hero"; Wall, "wall"]
   
//Load each texture once when first demanded
let mutable textures: Map<GameTypes.Texture, Texture2D> = Map []
let getTexture (content:ContentManager) texture =
    match Map.tryFind texture textures with
    | Some t -> t
    | None ->
        let name = textureNames[texture]
        let texture2D = content.Load<Texture2D>(name)
        textures <- Map.add texture texture2D textures
        texture2D

let draw (entities : Entity list) (content: ContentManager) (spriteBatch: SpriteBatch) =
        spriteBatch.Begin()
        List.iter (fun entity ->
            let texture = getTexture content entity.Texture
            spriteBatch.Draw(
                texture,
                Vector2((float32 entity.Position.X) / (float32 ScreenSize), (float32 entity.Position.Y) / (float32 ScreenSize)),
                new Rectangle(Point.Zero, new Point(texture.Width, texture.Height)),
                Color.White,
                0f,
                Vector2.Zero,
                Vector2.One * 4f,
                SpriteEffects.None,
                0f
            )
        ) entities
        spriteBatch.End()
