var levelSuivant : String;
 
function OnMouseUp() { 
     if (levelSuivant == "quitter")
         Application.Quit();
     else if (levelSuivant == "jouer")
         Application.LoadLevel(levelSuivant);
}