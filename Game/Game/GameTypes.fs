namespace GameTypes

type Direction =
    | Up
    | Down
    | Left
    | Right

type Pos = {
    X: int
    Y: int
}

type Texture = 
    | Hero
    | Wall

type Entity = {
    Id: int
    Position: Pos
    Texture: Texture
} 

type GameState = {
    Step: int
    //This should never be empty
    Entities: Entity list
}

type GameAction = 
    | Idle
    | Move of Direction
    
type ActionBinding = int * GameAction