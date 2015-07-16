(function() {
	var vehicle = (function() {
		var vehicle = {};
		
		vehicle.init = function (brand) {
			this.brand = brand;
			return this;
		};
		
		vehicle.move = function() {
			return this.brand + ' is moving...';
		};
		
		return vehicle;
	}());
	
	var car = (function(parent) {
		var car = Object.create(parent);
		
		Object.defineProperty(car, 'wheels', {
			get: function () {
				return this._wheels;
			},
			set: function (value) {
				if (value > 4) {
					throw new Error('some other car must have less than 5 wheels for some reason!');
				}
				
				this._wheels = value;
			}
		});
		
		car.init = function(brand, wheels){
			parent.init.call(this, brand);
			this.wheels = wheels;
			return this;
		};
		
		car.move = function(){
			return parent.move.call(this) + ' with ' + this.wheels + ' wheels.';
		};
		
		return car;
	}(vehicle));
	
	var someVehicle = Object.create(vehicle).init('Mercedes');
	
	var someCar = Object.create(car).init('Audi', 4);
	//var someOtherCar = Object.create(car).init('Audi', 8);
		
	console.log(someVehicle);
	console.log(someCar.move());
	//console.log(someOtherCar);
}());