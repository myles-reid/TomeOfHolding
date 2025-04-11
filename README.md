# 📘 Tome of Holding API

Tome of Holding is a .NET Core API built for managing tabletop RPG campaigns, players, characters, and more. Whether you're a Game Master or a Player, this API helps keep your game world organized.

---

## 📦 Project Overview

This API supports:

- Creating and managing **Players**
- Building **Character Sheets**
- Creating **Characters** and associating them with Players
- Managing **Campaigns** with Players and Characters
- Basic CRUD operations for all entities

---

## 🔌 API Usage Examples

## Creating a Player

```json
{
  "name": "Lena Stormbringer",
  "availableDays": ["Friday", "Saturday"],
  "role": "Player",
  "campaignIDs": [1, 2],
  "characterIDs": [3, 4]
}
```
## Creating a Character Sheet
``` json
{
  "strength": 16,
  "dexterity": 14,
  "constitution": 13,
  "intelligence": 10,
  "wisdom": 12,
  "charisma": 18,
  "currency": 50,
  "spells": ["Eldritch Blast", "Mage Armor"]
}
```
## Creating a Character
``` json
{
  "characterSheetId": 1,
  "playerId": 2,
  "name": "Thalor the Wise",
  "class": "Wizard",
  "role": "Support",
  "level": 5,
  "race": "Elf",
  "description": "An ancient elf with a vast knowledge of magic."
}

```
## Creating a Campaign
``` json
{
  "title": "The Shadow of Varnak",
  "gm_ID": 1,
  "description": "An epic journey into a cursed land ruled by darkness.",
  "playerIds": [1, 2],
  "characterIds": [3, 4]
}
```

## 🚧 Future Enhancements

- Authentication & Authorization
- Game session scheduling
- In-app inventory & spell tracking
- Campaign activity logs

Feel free to fork, open pull requests, or suggest features! If you find bugs or have enhancement ideas, open an issue.
