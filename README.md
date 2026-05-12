# 🎮 Hangman Game - C#

An interactive console-based Hangman game built in C# with multiple difficulty levels, visual ASCII art, and session statistics tracking.

## ✨ Features

- 🎨 **Visual Hangman Display** - ASCII art with emoji progression showing hangman stages
- 🎯 **Three Difficulty Levels** - Easy (30 words), Medium (30 words), Hard (40+ words)
- 📊 **Session Statistics** - Track wins, losses, and win rate
- 💬 **Interactive Menu System** - User-friendly interface with clear navigation
- 📝 **Input Validation** - FluentValidation for secure input handling
- ⌨️ **Real-time Feedback** - Clear messages for correct/incorrect guesses
- 💾 **Persistent Word Pool** - 100+ words loaded from word.json
- 🎮 **Smooth UX** - Proper delays and clear screen management

## 🚀 Getting Started

### Prerequisites
- .NET Framework or .NET Core installed
- FluentValidation NuGet package

### Installation

1. Clone the repository:
```bash
git clone https://github.com/OscarJerez/Hangman.git
cd Hangman
```

2. Restore dependencies:
```bash
dotnet restore
```

3. Build the project:
```bash
dotnet build
```

4. Run the game:
```bash
dotnet run
```

## 🎮 How to Play

1. **Launch the game** - The main menu will appear
2. **Select difficulty** - Choose between Easy, Medium, or Hard
3. **Guess letters** - Enter one letter at a time
4. **Win condition** - Guess all letters before running out of tries
5. **Lose condition** - Run out of tries (6 wrong guesses)

### Controls
- Type a **single letter** to make a guess
- Type **'exit'** to quit the current game and return to menu
- View **statistics** to see your win/loss record

## 📊 Game Modes

| Difficulty | Words | Length | Best For |
|-----------|-------|--------|----------|
| 🟢 Easy   | 30    | 3-5 letters | Beginners |
| 🟡 Medium | 30    | 6-10 letters | Intermediate |
| 🔴 Hard   | 40+   | 10+ letters | Experts |

## 📁 Project Structure

```
Hangman/
├── Program.cs              # Main entry point & menu system
├── Game Class.cs           # Core game logic & hangman display
├── GameStats.cs            # Session statistics tracking
├── Storage Class.cs        # Word loading & management
├── Validation.cs           # Input validation using FluentValidation
├── IStorage Interface.cs   # Storage interface contract
├── word.json               # 100+ words by difficulty
└── Hangman.csproj         # Project configuration
```

## 🏗️ Architecture

### Key Classes

**Game.cs**
- Manages game state (guessed letters, tries remaining)
- Handles guess logic and win/loss detection
- Displays hangman ASCII art progression

**GameStats.cs**
- Tracks games played, won, and lost
- Calculates win rate percentage
- Updates in real-time during session

**JsonStorage.cs**
- Loads words from word.json file
- Supports difficulty-based word selection
- Returns random word for each game

**UserInputValidator.cs**
- Validates single letter input
- Uses FluentValidation for robust error handling
- Ensures only valid alphabetic characters

## 🎨 Visual Display

The game displays a visual hangman that progresses through 7 stages:

```
Stage 0 (Empty)  → Stage 1 (Head) → Stage 2 (Body) → Stage 3 (Left Arm)
     ↓                ↓                ↓                ↓
Stage 4 (Right Arm) → Stage 5 (Left Leg) → Stage 6 (Right Leg - Game Over!)
```

Each stage uses emoji faces to show emotion as the game progresses! 😊 → 😟 → 😖

## 📈 Word Pool (100+ Words)

### Easy Words (30)
apple, banana, cat, dog, fish, horse, house, key, light, moon, pen, rain, star, sun, tiger, tree, water, bird, block, chair, cloud, cup, door, egg, fire, fork, glass, grass, hat, heart

### Medium Words (30)
account, advantage, album, alligator, antelope, avocado, beetle, bicycle, blender, boomerang, buffalo, cactus, camel, camera, canopy, canvas, carousel, carpet, carrot, catalogue, catapult, cavern, celery, cellphone, cemetery, champagne, channel, cheapskate, checkmate, cheetah

### Hard Words (40+)
abstraction, accelerate, accomplishment, accountability, achievement, acknowledge, acquisition, adventure, advertisement, aerial, aerodynamic, aesthetic, affiliation, affordability, affirmative, aggressive, aggregation, anthropology, anticipation, apocalypse, apologize, appetite, applicant, application, appraisal, appreciate, apprehension, apprentice, appropriate, approximately, architecture, and more...

## 🎯 Game Statistics

Your progress is tracked during the session:

- **Total Games Played** - Count of all games started
- **Games Won** - Successfully guessed words
- **Games Lost** - Failed to guess before tries ran out
- **Win Rate** - Percentage of games won (calculated real-time)

Statistics are displayed on the main menu and dedicated stats screen.

## 🛠️ Dependencies

- **FluentValidation** - Input validation
- **.NET Standard / .NET Core** - Runtime

## 📝 Sample Game Session

```
╔════════════════════════════════════════╗
║         🎮 HANGMAN GAME 🎮        ║
╚════════════════════════════════════════╝

  1. Play (Easy)
  2. Play (Medium)
  3. Play (Hard)
  4. View Statistics
  5. Exit

  📊 Stats: 5W / 2L | Win Rate: 71.4%

Choose an option: 1

  ┌────────────────────┐
  │                    │
  │                    │
  │                    │
  │                    │
  │                    │
  │
─────────────────────────

  Word: _ _ _ _ _
  Guessed letters: None
  Tries left: 6

Enter your guess (or 'exit' to quit): a

✅ Great! 'a' is in the word!
```

## 🐛 Known Issues

None at this time. Please report any issues on the GitHub issues page.

## 🚀 Future Enhancements

- [ ] Add hint system (reveal random letter)
- [ ] Multiplayer mode
- [ ] Persistent score across sessions (file-based)
- [ ] Categories for words
- [ ] Leaderboard
- [ ] GUI version using WPF or WinForms
- [ ] Custom word import

## 📄 License

This project is open source and available under the MIT License.

## 👨‍💻 Author

**Oscar Jerez**

---

**Enjoy the game! 🎉 Try to beat your high score!**
