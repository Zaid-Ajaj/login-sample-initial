module App

open Elmish
open Feliz

type State =
  { Login: Login.State }

type Msg =
    | LoginMsg of Login.Msg

let init() =
    let loginState, loginCmd = Login.init()
    { Login = loginState }, Cmd.map LoginMsg loginCmd

let update (msg: Msg) (state: State) =
    match msg with
    | LoginMsg loginMsg ->
        let loginState, loginCmd = Login.update loginMsg state.Login
        { state with Login = loginState }, Cmd.map LoginMsg loginCmd

let render (state: State) (dispatch: Msg -> unit) =
  Login.render state.Login (LoginMsg >> dispatch)