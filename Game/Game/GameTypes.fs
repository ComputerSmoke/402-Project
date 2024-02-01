namespace GameTypes

open Microsoft.Xna.Framework

type Entity = {
    Id: int
    Pos: Vector2
    Color: Color
} 
type GameState = {
    Step: int
    Entities: Entity list
}

type GameAction = 
    | Idle
    | Move of Vector2
    
type ActionBinding = int * GameAction