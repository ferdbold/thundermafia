#pragma strict

var tailleEntrer : float = 45;
var tailleSortie : float = 100;
 
function OnMouseEnter() {
    guiText.fontSize = tailleEntrer;
}
 
function OnMouseExit() {
    guiText.fontSize = tailleSortie;
}