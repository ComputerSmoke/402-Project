module Textures

open GameTypes
open Microsoft.Xna.Framework.Graphics
open Microsoft.Xna.Framework.Content


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