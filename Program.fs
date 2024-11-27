// Define the Coach record
type Coach = {
    Name: string
    FormerPlayer: bool
}

// Define the Stats record
type Stats = {
    Wins: int
    Losses: int
}

// Define the Team record
type Team = {
    Name: string
    Coach: Coach
    Stats: Stats
}

// Create a list of 5 Teams
let teams = [
    { Name = "Atlanta Hawks"; 
      Coach = { Name = "Quin Snyder"; FormerPlayer = true }; 
      Stats = { Wins = 7; Losses = 11 } }
    { Name = "Boston Celtics"; 
      Coach = { Name = "Joe Mazzulla"; FormerPlayer = true }; 
      Stats = { Wins = 15; Losses = 3 } }
    { Name = "Brooklyn nets"; 
      Coach = { Name = "Jordi Fernandez"; FormerPlayer = false }; 
      Stats = { Wins = 8; Losses = 10 } }
    { Name = "Charlotte hornets"; 
      Coach = { Name = "Charles Lee"; FormerPlayer = false }; 
      Stats = { Wins = 6; Losses = 11 } }
    { Name = "Chicago Bulls"; 
      Coach = { Name = "Billy Donovan"; FormerPlayer = true }; 
      Stats = { Wins = 8; Losses = 11 } }
]

// Filtering the list of successful teams
let successfulTeams = 
    teams 
    |> List.filter (fun team -> team.Stats.Wins > team.Stats.Losses)

// Mapping to calculate success percentage
let successPercentages = 
    teams 
    |> List.map (fun team -> 
        let totalGames = float (team.Stats.Wins + team.Stats.Losses)
        let successRate = (float team.Stats.Wins / totalGames) * 100.0
        (team.Name, successRate))

// Output results
printfn "Successful Teams:"
successfulTeams |> List.iter (fun team -> printfn "- %s" team.Name)

printfn "\nTeam Success Percentages:"
successPercentages 
|> List.iter (fun (teamName, percentage) -> printfn "%s: %.2f%%" teamName percentage)