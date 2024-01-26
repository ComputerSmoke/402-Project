module InputHandlers

open GameTypes


//no input changes
let identityInput (state: GameState) =
    state
    
//async wait for user library to set input
let libraryInputHandler (state: GameState) =
    async {
        
    }