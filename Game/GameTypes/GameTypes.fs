namespace GameTypes

open System.Numerics

type Entity = {
    id: int
    Pos: Vector2
    Color: int * int * int
} 
type GameState = {
    Step: int
    Entities: Entity list
}

type GameAction = 
    | Move of Vector2
    
type ActionBinding = int * GameAction