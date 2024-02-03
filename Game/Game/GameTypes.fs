namespace GameTypes

open Microsoft.Xna.Framework

type Direction =
    Up
    | Down
    | Left
    | Right

type Texture = 
    Hero
    | Wall

type Entity = {
    Id: int
    Position: Vector2
    Texture: Texture
} 
type GameState = {
    Step: int
    Entities: Entity list
}

type GameAction = 
    | Idle
    | Move of Direction
    
type ActionBinding = int * GameAction