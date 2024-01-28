module GameTypes

open System.Numerics

type Entity = {
    Pos: Vector2
} 
type GameState = internal {
    Step: int
    Entities: Entity list
}

type Direction = Up | Down | Left | Right

type Action = 
    | Move of Direction