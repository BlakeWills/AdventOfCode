module DayTwo

type Shape =
    | Rock
    | Paper
    | Scissors

    member this.Score = 
        match this with
        | Rock -> 1
        | Paper -> 2
        | Scissors -> 3

let getShape (c:string) =
    match c.Trim() with
    | "A" | "X" -> Rock
    | "B" | "Y" -> Paper
    | "C" | "Z" -> Scissors
    | x -> failwith $"Unknown shape {x}"

type Result = 
    | Win
    | Draw
    | Lose

    member this.TotalScore =
        match this with 
        | Win -> 6
        | Draw -> 3
        | Lose -> 0

// rock beats scissors, scissors beats paper, paper beats rock
let getResult me opp =
    match me, opp with
    | Rock, Scissors -> Win
    | Scissors, Rock -> Lose
    | Scissors, Paper -> Win
    | Paper, Scissors -> Lose
    | Paper, Rock -> Win
    | Rock, Paper -> Lose
    | _ -> Draw


let run = 
    let path = Helpers.getDataPath "02.txt"
    let file = System.IO.File.ReadAllText(path)

    let rounds = file.Trim().Split "\n"
        
    let getRoundScore (roundStr:string) = 
        let parts = roundStr.Split(' ')
        let oppShape = getShape parts.[0]
        let myShape = getShape parts.[1]
        let r = getResult myShape oppShape
        r.TotalScore + myShape.Score

    let sc = 
        rounds
        |> Seq.fold (fun s x -> s + getRoundScore x) 0

    printfn $"Total score is {sc}"
    