static var score : String = "100000000";

var scoreWidth : int = score.Length * 3;

function Start () {

	// Récupérer le score
	guiText.text = score;
	// Centrer le score
	guiText.pixelOffset.x -= scoreWidth;
}
