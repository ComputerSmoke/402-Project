open GameTypes
open InputHandlers
open OutputHandlers


//TODO: one step of game simulation
let updateState (actions: (Entity * Action) list) (state: GameState) =
    state
//TODO: determine if game is over
let concluded (state: GameState) =
    false    

let newGame (initialState: GameState) outputHandler =
    let mutable state = initialState
    let inputCallback (actions: (Entity * Action) list) =
        state <- updateState actions state
        outputHandler state
        state
    inputCallback

let gameUpdater = newGame {Entities=[]} graphicsOutput
//code using game as library would call this
let takeTurn (actions: (Entity * Action) list) =
    gameUpdater actions