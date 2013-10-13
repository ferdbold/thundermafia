static var score : int = 100000000;

var scoreWidth : int = score.ToString.Length * 3;

function Start () {
	// Récupérer le score
	guiText.text = score.ToString();
	// Centrer le score
	guiText.pixelOffset.x -= scoreWidth;
}
