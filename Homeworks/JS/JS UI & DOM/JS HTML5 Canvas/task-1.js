(function () {
	var canvas = document.getElementById("canvas"),
		ctx = canvas.getContext('2d');
		
		//face
		ctx.save();
		//main circle
		ctx.beginPath();
		ctx.scale(1, 0.85);
		ctx.arc(250, 500, 140, 0, 2 * Math.PI);
		ctx.fillStyle = "#90cad7";
		ctx.strokeStyle = "#22545f";
		ctx.lineWidth = 5;
		ctx.fill();
		ctx.stroke();
		ctx.closePath();
		ctx.restore();
		
		//mouth
		ctx.save();
		ctx.beginPath();
		ctx.rotate(Math.PI / 180 * 10);
		ctx.scale(1, 0.4);
		ctx.arc(310, 1110, 50, 0, 2 * Math.PI);
		ctx.fillStyle = "#90cad7";
		ctx.strokeStyle = "#22545f";
		ctx.lineWidth = 6;
		ctx.fill();
		ctx.stroke();
		ctx.closePath();
		ctx.restore();
		
		//nose
		ctx.save();
		ctx.beginPath();
		ctx.lineWidth = 4;
		ctx.strokeStyle = "#22545f";
		ctx.moveTo(225, 440);
		ctx.lineTo(195, 440);
		ctx.stroke();
		ctx.closePath();
		
		ctx.beginPath();
		ctx.moveTo(195, 440);
		ctx.lineTo(220, 390);
		ctx.stroke();
		ctx.closePath();
		ctx.restore();
		
		//eyes
		//right
		ctx.save();
		ctx.beginPath();
		ctx.scale(1, 0.6);
		ctx.lineWidth = 4;
		ctx.strokeStyle = "#22545f";
		ctx.arc(180, 640, 20, 0, 2 * Math.PI);
		ctx.stroke();
		ctx.closePath();
		ctx.restore();
		
		ctx.save();
		ctx.beginPath();
		ctx.scale(0.6, 1);
		ctx.arc(290, 383, 11, 0, 2 * Math.PI);
		ctx.fillStyle = "#22545f";
		ctx.fill();
		ctx.closePath();
		ctx.restore();
		
		//left
		ctx.save();
		ctx.beginPath();
		ctx.scale(1, 0.6);
		ctx.lineWidth = 4;
		ctx.strokeStyle = "#22545f";
		ctx.arc(268, 640, 20, 0, 2 * Math.PI);
		ctx.stroke();
		ctx.closePath();
		ctx.restore();
		
		ctx.save();
		ctx.beginPath();
		ctx.scale(0.6, 1);
		ctx.arc(437, 383, 11, 0, 2 * Math.PI);
		ctx.fillStyle = "#22545f";
		ctx.fill();
		ctx.closePath();
		ctx.restore();
		
		//hat
		//bottom
		ctx.save();
		ctx.beginPath();
		ctx.scale(1, 0.2);
		ctx.arc(245, 1600, 140, 0, 2 * Math.PI);
		ctx.fillStyle = "#396693";
		ctx.fill();
		ctx.strokeStyle = "#262626";
		ctx.lineWidth = 6;
		ctx.stroke();
		ctx.closePath();
		ctx.restore();
		
		//cilinder bottom
		ctx.save();
		ctx.beginPath();
		ctx.scale(1, 0.2);
		ctx.arc(255, 1500, 90, 0, Math.PI);
		ctx.strokeStyle = "#262626";
		ctx.lineWidth = 6;
		ctx.stroke();
		ctx.closePath();
		ctx.restore();
		
		//cilinder
		ctx.save();
		ctx.beginPath();
		ctx.rect(165, 120, 180, 180);
		ctx.fillStyle = "#396693";
		ctx.fill();
		ctx.closePath();
		ctx.restore();
		
		ctx.save();
		ctx.beginPath();
		ctx.moveTo(165, 300);
		ctx.lineTo(165, 120);
		ctx.moveTo(345, 120);
		ctx.lineTo(345, 300);
		ctx.moveTo(165, 300);
		ctx.lineWidth = 5;
		ctx.strokeStyle = "#262626";
		ctx.stroke();
		ctx.closePath();
		ctx.restore();
		
		//cilinder top
		ctx.save();
		ctx.beginPath();
		ctx.scale(1, 0.2);
		ctx.arc(255, 600, 90, 0, 2 * Math.PI);
		ctx.fillStyle = "#396693";
		ctx.fill();
		ctx.strokeStyle = "#262626";
		ctx.lineWidth = 6;
		ctx.stroke();
		ctx.closePath();
		ctx.restore();
}());