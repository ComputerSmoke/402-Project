module InputHandlers

open GameTypes

//We need a type for actions, and input bindings should then be a list of pairs entity, action
type 

//no input changes
let identityInput (state: GameState) =
    state
    
//async wait for user library to set input
let libraryInputHandler (state: GameState) =
    async {
        
    }