(function () {
	var canvas = document.getElementById("canvas"),
		ctx = canvas.getContext('2d');
	
	//left side
	ctx.beginPath();
	
	ctx.moveTo(100, 0);
	ctx.lineTo(150, 50);
	ctx.lineTo(150, 500);
	ctx.lineTo(100, 450);
	ctx.lineTo(100, 0);
	
	ctx.fillStyle = "rgba(00, 00, 00, 0.7)";
	ctx.fill();
	
	//top side
	ctx.beginPath();
	
	ctx.moveTo(150, 50);
	ctx.lineTo(800, 50);
	ctx.lineTo(750, 0);
	ctx.lineTo(100, 0);
	
	ctx.fillStyle = "rgba(0, 0, 0, 0.2)";
	ctx.fill();
	
	//front body
	ctx.beginPath();
	
	ctx.moveTo(150, 50);
	ctx.lineTo(150, 500);
	ctx.lineTo(800, 500);
	ctx.lineTo(800, 50);
	
	ctx.fillStyle = "rgba(0, 0, 5, 0.5)";
	ctx.fill();
	
	//main shadow
	ctx.beginPath();
	
	ctx.moveTo(800, 500);
	ctx.lineTo(425, 700);
	ctx.lineTo(0, 700);
	ctx.lineTo(0, 575);
	ctx.lineTo(150, 500);
	
	ctx.fillStyle = "rgba(0, 2, 5, 0.1)";
	ctx.fill();
	
	//left shadow
	ctx.beginPath()
	
	ctx.moveTo(100, 450);
	
	ctx.lineTo(150, 500);
	ctx.lineTo(0, 575);
	ctx.lineTo(0, 499);
	ctx.lineTo(100, 450);
	
	ctx.fillStyle = "rgba(0, 2, 5, 0.2)";
	ctx.fill();
	
	//smile
	ctx.beginPath();
	ctx.arc(450, 300, 150, 0, 2 * Math.PI);
	ctx.strokeStyle = 'black';
	ctx.lineWidth = 3;
	ctx.stroke();
	ctx.closePath();
	
	ctx.beginPath();
	ctx.arc(450, 300, 150, 0, 2 * Math.PI);
	ctx.fillStyle = 'yellow';
	ctx.fill();
	ctx.closePath();
	
	ctx.beginPath();
	ctx.arc(395, 245, 25, 0, 2 * Math.PI);
	ctx.fillStyle = 'black';
	ctx.fill();
	ctx.closePath();
	
	ctx.beginPath();
	ctx.arc(495, 245, 25, 0, 2 * Math.PI);
	ctx.fillStyle = 'black';
	ctx.fill();
	ctx.closePath();
	
	ctx.beginPath();
	ctx.moveTo(395, 345);
	ctx.quadraticCurveTo(445, 445, 495, 345);
	ctx.fillStyle = 'black';
	ctx.fill();
	ctx.closePath();
	
	//text
	ctx.font = 'italic 65px Consolas';
	ctx.strokeText("Marto & Emo Ltd.", 200, 100);
}());