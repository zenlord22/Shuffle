# Go Fish Card Game

This is a simple implementation of the card game Go Fish in C#. The program simulates a single-player game where the player draws cards and checks for pairs. If no pairs are found, the player draws another card and the deck is shuffled.

## Features

- Initializes a standard 52-card deck.
- Draws initial 5 cards for the player.
- Checks the player's hand for pairs.
- If no pairs are found, the player draws a card and the deck is shuffled.
- When a pair is found, the two cards are placed at the bottom of the deck.

## Requirements

- .NET 8
- C# 12.0

## How to Run

1. Clone the repository or download the source code.
2. Open the project in Visual Studio.
3. Build the solution to restore dependencies.
4. Run the program.

## Code Overview

### Main Program

The main program initializes the deck, draws initial cards for the player, and enters a loop where it checks for pairs and draws cards if no pairs are found.
