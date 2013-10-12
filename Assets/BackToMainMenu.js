
function OnMouseEnter() {
    guiText.color = Color.yellow;
}

function OnMouseExit() {
    guiText.color = Color.white;
}


function OnMouseUp() { 
     if (guiText.text == "back to main menu")
         Application.LoadLevel("MenuPrincipal");
}