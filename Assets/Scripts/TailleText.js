#pragma strict

var tailleEntrer : float = 70;
var tailleSortie : float = 50;
//var decalageOffsetJouer : float = 50;
//var decalageOffsetQuitter : float = 35;
var decalageOffset : float = 35;
 
function OnMouseEnter() {
    guiText.fontSize = tailleEntrer;
    guiText.pixelOffset.x -= decalageOffset;
    guiText.color = Color.white;
    /*
    if (guiText.text == "jouer"){
        guiText.pixelOffset.x -= decalageOffsetJouer;
    }
    else
        guiText.pixelOffset.x -= decalageOffsetQuitter;
	*/
}
 
function OnMouseExit() {
    guiText.fontSize = tailleSortie;
    guiText.pixelOffset.x += decalageOffset;
    guiText.color = Color.black;
	/*
    if (guiText.text == "jouer"){
        guiText.pixelOffset.x += decalageOffsetJouer;
    }
    else
        guiText.pixelOffset.x += decalageOffsetQuitter;
	*/
}