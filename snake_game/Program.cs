using snake_game;

// Create 2 player & game
Player p1 = new Player("1");
Player p2 = new Player("2");

Game game = new Game(p1, p2);

// Launch game
game.LoopGame();