(function () {
	var canvas = document.getElementById('canvas'),
		ctx = canvas.getContext('2d');
	
	ctx.strokeStyle = '#28d1fa';
	ctx.lineWidth = 17;
	ctx.lineCap = 'round';
	ctx.shadowBlur = 15;
	ctx.shadowColor = '#28d1fa';
		
	function degToRad(degree) {
		var factor = Math.PI/180;
		return degree * factor;
	}
	
	function drawArc(radius, timeVariable) {
		ctx.beginPath();
		ctx.arc(250, 250, radius, degToRad(270), degToRad((timeVariable) - 90));
		ctx.stroke();
	}
	
	function renderTime() {
		var now = new Date(),
			today = now.toDateString(),
			time = now.toLocaleTimeString(),
			hours = now.getHours(),
			minutes = now.getMinutes(),
			seconds = now.getSeconds(),
			milliseconds = now.getMilliseconds(),
			newSecond = seconds + (milliseconds / 1000)
			
		//background
		var gradient = ctx.createRadialGradient(250, 250, 5, 250, 250, 300);
		gradient.addColorStop(0, '#09303a');
		gradient.addColorStop(1, 'black');
		ctx.fillStyle = gradient;
		ctx.fillRect(0, 0, 500, 500);
		
		//hours
		drawArc(200, hours * 15);
		
		//minutes
		drawArc(170, minutes * 6);
		
		//seconds
		drawArc(140, newSecond * 6);
		
		//date
		ctx.font = '25px Arial';
		ctx.fillStyle = '28d1fa';
		ctx.fillText(today, 150, 250);
		
		//time
		ctx.font = '25px Arial';
		ctx.fillStyle = '28d1fa';
		ctx.fillText(time, 175, 280);
	}
	
	setInterval(renderTime, 50);
}());