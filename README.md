# WordSquare

## Premise
WordSquare is a 2-player turn-based word game played on two separate 5x5 square grids, one for each player. The objective of the game is to score the most points by forming valid English words with adjacent letters on the grid.

## Objective
In WordSquare, the objective is to score the most points by forming valid English words with adjacent letters on each player's individual grid.

## Turns and Actions
On the first turn, the first player chooses any letter and places it in any empty cell on their grid. The first turn consists of only this one action. For all other turns, each player takes two actions:

-  Place the letter chosen by the opponent on the previous turn in any empty cell on their grid.
-  Choose any letter and place it on their grid in any empty cell.
Players do not see their opponent's grid, and only learn the letter chosen by the opponent in the previous turn, but not its placement.

## Game End
The game ends when both players' grids are completely filled.

## Scoring
In WordSquare, points are awarded for each unique word formed by connecting adjacent letters horizontally or vertically on a player's grid. Points are based on the length of the word:

- 3-letter word: 3 points
- 4-letter word: 4 points
- 5-letter word: 5 points

Only words that are valid English words found in a pre-existing dictionary are eligible for points. The maximum score achievable is 50 points.

We hope you enjoy playing WordSquare!