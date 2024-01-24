// For more information see https://aka.ms/fsharp-console-apps
printfn "Hello from F#"

type Entity = {
    id: int
}

type GameState = {
    Entities: Entity list
}

//TODO: async wait for user library to set input
let takeInput (state: GameState) =
    state
//TODO: one step of game simulation
let updateState (state: GameState) =
    state
//TODO: determine if game is over
let concluded (state: GameState) =
    false

//game loop is sequence of states
let gameLoop (initialState: GameState) takeInput =
    seq {
        let mutable state = initialState
        while concluded state |> not do
            state <- takeInput state
                        <| updateState
            yield state
    }