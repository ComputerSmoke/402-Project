open GameTypes
open InputHandlers
open OutputHandlers


//TODO: one step of game simulation
let updateState (state: GameState) =
    state
//TODO: determine if game is over
let concluded (state: GameState) =
    false    

let playGame (initialState: GameState) takeInput handleOutput =
    async {
        let mutable state = initialState
        while concluded state |> not do
            let! stateAfterInput = takeInput state |> Async.AwaitTask
            state <- updateState stateAfterInput
            handleOutput state
        return state
    }

//Run the game 
let finalState = 
    playGame {Entities=[]} libraryInputHandler libraryOutputHandler 
    |> Async.RunSynchronously