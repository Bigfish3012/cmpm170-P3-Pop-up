# cmpm 170 prototype 3 - Eliminate pop-ups

Unity Editor version: 6000.2.7f2

---

TODO:
1. Make the pop pus windows has random size and colors
---

--- 
Image
- https://www.goodfon.com/minimalism/wallpaper-bsod-bsod-blue-screen-death.html

---

sounds
- Windows XP Error: https://www.myinstants.com/en/instant/windows-xp-error/
- Windows 10 Error Sound: https://www.myinstants.com/en/instant/windows-10-error-sound-69419/
- Windows 11 error sound: https://www.myinstants.com/en/instant/windows-11-error-sound-46671/
- Windows 2000 error: https://www.myinstants.com/en/instant/windows-2000-error-70582/
- Game Over Link: https://www.myinstants.com/en/instant/game-over-link/

---

## Scripts Overview

### Game Scripts
- **PopupWindow.cs** - Manages individual pop-up window behavior. Handles close button functionality, plays error sounds when created, and adds score when closed.
- **PopupManager.cs** - Controls pop-up spawning system. Generates pop-ups at random positions with increasing frequency (decreasing spawn intervals), and ensures pop-ups stay within screen bounds.
- **AudioManager.cs** - Singleton audio manager that plays random error sounds from a collection when pop-ups are created.
- **Score.cs** - Score management system. Tracks current score, updates UI display, and saves high score and last score to PlayerPrefs.
- **CountdownTimer.cs** - Game timer that counts down from 60 seconds. When time reaches zero, loads the game over scene.

### Scene Scripts
- **MainMenu.cs** - Handles main menu functionality, allows players to start the game.
- **GameOver.cs** - Manages game over screen. Displays high score and last score from PlayerPrefs, provides restart and home button functionality.
---