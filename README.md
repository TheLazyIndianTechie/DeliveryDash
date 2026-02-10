# 🚗 DeliveryDash

A fast-paced 2D top-down delivery driving game built with Unity. Race through the city streets, pick up packages, and deliver them to customers while collecting speed boosts to beat the clock!

## 🎮 Gameplay

In DeliveryDash, you play as a delivery driver navigating through a bustling city. Your mission is simple:

1. **Pick up packages** scattered around the map
2. **Deliver them to customers** waiting at their locations
3. **Collect boost power-ups** to increase your speed
4. **Avoid collisions** - crashing will remove your speed boost!

## 🕹️ Controls

DeliveryDash supports both arrow keys and WASD controls for maximum comfort:

| Action         | Primary Key | Alternative |
|----------------|-------------|-------------|
| **Move Forward**  | ↑ (Up Arrow)    | W           |
| **Move Backward** | ↓ (Down Arrow)  | S           |
| **Steer Left**    | ← (Left Arrow)  | A           |
| **Steer Right**   | → (Right Arrow) | D           |

## ⚡ Game Mechanics

### Package Delivery
- Drive over a **Package** (yellow) to pick it up
- A particle effect indicates you're carrying a package
- You can only carry **one package at a time**
- Drive to a **Customer** (green) location to complete the delivery

### Speed Boost
- Collect **Boost** power-ups scattered around the map
- Boosts increase your speed from **5** to **10** units
- A "BOOST" text indicator appears when boosted
- **Caution**: Colliding with any obstacle removes your boost!

### Speed Values
| State    | Speed |
|----------|-------|
| Normal   | 5     |
| Boosted  | 10    |
| Steer Speed | 200° |

## 📁 Project Structure

```
DeliveryDash/
├── Assets/
│   ├── Art/                  # Game artwork and sprites
│   │   ├── Background Tiles/ # Tilemap backgrounds
│   │   ├── Houses/           # Building sprites
│   │   ├── Props & Stuff/    # Environmental objects
│   │   ├── Road Pieces/      # Road tile sprites
│   │   └── Vehicle/          # Player vehicle sprites
│   ├── Prefabs/              # Reusable game objects
│   │   ├── Boost.prefab      # Speed boost power-up
│   │   ├── Customer.prefab   # Delivery destination
│   │   └── Package.prefab    # Pickup item
│   ├── Scenes/
│   │   └── Main.unity        # Main game scene
│   ├── Scripts/
│   │   ├── Driver.cs         # Player movement & boost logic
│   │   └── Delivery.cs       # Package pickup & delivery logic
│   └── Tests/
│       └── DriverTests.cs    # Unit tests for Driver class
├── CHANGELOG.md              # Version history
└── README.md                 # This file
```

## 🏷️ Tags Used

The game uses Unity tags to identify different game objects:

| Tag       | Description                          |
|-----------|--------------------------------------|
| `Package` | Pickup items for delivery            |
| `Customer`| Delivery destination points          |
| `Boost`   | Speed boost power-ups                |

## 🛠️ Technical Requirements

- **Unity Version**: 6000.3.7f1 (Unity 6)
- **Render Pipeline**: 2D (URP compatible)
- **Input System**: Unity Input System (new)
- **Text Rendering**: TextMesh Pro

## 🚀 Getting Started

### Prerequisites
- Unity Hub installed
- Unity 6000.3.7f1 or compatible version

### Installation

1. Clone the repository:
   ```bash
   git clone https://github.com/yourusername/DeliveryDash.git
   ```

2. Open Unity Hub and click **Add** → **Add project from disk**

3. Navigate to the cloned `DeliveryDash` folder and select it

4. Open the project with Unity 6000.3.7f1

5. Open `Assets/Scenes/Main.unity` and press **Play**!

## 🧪 Running Tests

The project includes unit tests for the Driver class:

1. Open Unity
2. Go to **Window** → **General** → **Test Runner**
3. Select **Edit Mode** tab
4. Click **Run All** to execute the tests

See `UNIT_TESTS_SUMMARY.md` for detailed test documentation.

## 🎨 Art Assets

This project uses art assets from [GameDev.tv](https://www.gamedev.tv/). See `Assets/Art/GameDev.tv Asset License Agreement.txt` for licensing details.

## 📝 Changelog

See [CHANGELOG.md](CHANGELOG.md) for version history and updates.

## 🤝 Contributing

1. Fork the repository
2. Create a feature branch (`git checkout -b feature/amazing-feature`)
3. Commit your changes (`git commit -m 'Add some amazing feature'`)
4. Push to the branch (`git push origin feature/amazing-feature`)
5. Open a Pull Request

## 📄 License

This project is for educational purposes. Art assets are subject to the GameDev.tv Asset License Agreement.

---

**Happy Delivering! 🚗💨📦**
