module Draw

open GameTypes
open InputOutput
open Microsoft.Xna.Framework.Graphics
open Microsoft.Xna.Framework.Content
open Microsoft.Xna.Framework


let textureNames =
    Map [Hero, "hero"; Wall, "wall"]
   
//Load each texture once when first demanded
let mutable textures:Map<GameTypes.Texture, Texture2D> = Map []
let getTexture (content:ContentManager) texture =
    match Map.tryFind texture textures with
    | Some t -> t
    | None ->
        let name = textureNames[texture]
        let texture2D = content.Load<Texture2D>(name)
        textures <- Map.add texture texture2D textures
        texture2D

let draw (content:ContentManager) (spriteBatch:SpriteBatch) =
        spriteBatch.Begin()
        List.iter (fun entity ->
            let texture = getTexture content entity.Texture
            spriteBatch.Draw(
                texture,
                entity.Position,
                new Rectangle(Point.Zero, new Point(texture.Width, texture.Height)),
                Color.White,
                0f,
                Vector2.Zero,
                Vector2.One * 4f,
                SpriteEffects.None,
                0f
            )
        ) game.Entities
        spriteBatch.End()
