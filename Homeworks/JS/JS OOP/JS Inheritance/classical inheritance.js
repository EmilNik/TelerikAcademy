(function () {
	var Animal  = (function () {
		function Animal (name, age) {
			this.name = name;
			this.age = age;
			}
		
		Animal.prototype.toString =  function() {
				return this.name + ' ' + this.age;
		};
		
		return Animal;
	}());
	
	var Cat = (function (parent) {
		function Cat (name, age, sleep) {
			parent.call(this, name, age);
			this.sleep = sleep;
		};
		
		Cat.prototype.toString = function () {
				return parent.prototype.toString.call(this) + ' ' + this.sleep;
		};
		
		return Cat;
	}(Animal));
	
	var someCat = new Cat('Pesho', 5, 'zZzZzZ...');
	
	console.log(someCat);
	console.log(someCat.toString());
}());