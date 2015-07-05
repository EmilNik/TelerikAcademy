(function() {
	var categories = [];
	
	//product
	var product = (function(){
		var product = {},
			typeGender = {
				male: 'male',
				female: 'female',
				other: 'unisex'
				};
		
		//validation		
		function validateName(name){
			if (typeof name != 'string') {
				throw new Error('Product name must be a string');
			}
			
			if (name.length < 3 || name.length > 10) {
				throw new Error('Product name must be between 3 and 10 symbols long!');
			}
		};
		
		function validatePrice(price){
			if (isNaN(price) || price < 0) {
				throw new Error('Invalid price!');
			}
		};
		
		function validateBrand(brand){
			if (typeof brand != 'string') {
                throw new Error('Brand must be a string!');
            }

            if (brand.length < 2 || brand.length > 10) {
                throw new Error('Product brand must be between 2 and 10 symbols long!');
            }
		};
		
		function validateGender(gender) {
            if (!typeGender[gender]) {
                throw new Error('Product gender type must be Men, Women or Unisex');
            }
        }
		
		function validateProduct(name, price, brand, gender) {
			validateName(name);
			validatePrice(price);
			validateBrand(brand);
			validateGender(gender);
		};
		
		//init
		product.init = function(name, price, brand, gender) {
			validateProduct(name, price, brand, gender);
			
			this.name = name;
			this.price = price;
			this.brand = brand;
			this.gender = typeGender[gender];
			
			return this;
		};
		
		product.getInfo = function () {
			var result = 'Info: ' + this.name + ' ' + this.price + ' ' + this.brand + ' ' + this.gender;
            return result;
        };
		
		return product;
	}());
	
	//shampoo
	var shampoo = (function(parent) {
		var shampoo = Object.create(product),
			usageTypes = {
                everyday: 'everyday',
                medical: 'medical'
            };
			
		//validation
		function validateQuantity(quantity){
			if (isNaN(quantity) || quantity < 0) {
                throw new Error('Shampoo quantity must be a possitive number');
            }
		};
		
		function validateUsageType(usage){
			 if (!usageTypes[usage]) {
                throw new Error('Shampoo usage type must be EveryDay or Medical');
            }
		};
		
		function validateShampoo(quantity, usage){
			validateQuantity(quantity);
			validateUsageType(usage);
		}
		
		//init
		shampoo.init = function(name, price, brand, gender, quantity, usage) {
			var shampooPrice = price * quantity;
			
			validateShampoo(quantity, usage);
			
			parent.init.call(this, name, shampooPrice, brand, gender);
			this.quantity = quantity;
			this.usage = usageTypes[usage];
			
			return this;
		};
		
		shampoo.getInfo = function(){
			var result = parent.getInfo.call(this) + ' ' + this.milliliters + ' ' + this.usage;
			return result;
		};
		
		return shampoo;
	}(product));
	
	//toothpaste
	var toothpaste = (function(parent){
		var toothpaste = Object.create(product);
		
		function validateIngredients(ingredients) {
            if (!Array.isArray(ingredients)) {
                throw new Error('Toothpaste ingredients must be a string!');
            }

            ingredients.forEach(function (ingr) {
                if (typeof ingr !== 'string') {
                    throw new Error('Toothpaste\'s ingredient name must be a string!');
                }

                if (ingr.length < 4 || ingr.length > 12) {
                    throw new Error('Ingredients must be between 4  and 12 symbols long!');
                }
            });
        }
		
		toothpaste.init = function(name, price, brand, gender, ingredients) {
			validateIngredients(ingredients);
			
			parent.init.call(this, name, price, brand, gender);
			this.ingredients = ingredients.join(', ');
			
			return this;
		};
		
		toothpaste.getInfo = function () {
            var result = parent.getInfo.call(this) + ' ' + this.ingredients;
			return result;
        };
		
		return toothpaste;
	}(product));
	
	//category
	var category = (function(){
		var category = {},
            products = [];
			
		//validation
		function validateCategoryName(name) {
            if (typeof name != 'string') {
                throw new Error('Category name must be a string!');
            }

            if (name.length < 2 || name.length > 15) {
                throw new Error('Category name must be between 2  and  15 symbols long!');
            }
        };

        function checkIfCategoryExists(categoryName) {
            var isCategoryExists = categories.some(function (category) {
                return category.name == categoryName;
            });

            return isCategoryExists;
        };

        function getProductByName(name) {
            var productAsArray = products.filter(function (prod) {
                return prod.name == name;
            });

            return productAsArray[0];
        };
		
		//init
		category.init = function(name) {
			validateCategoryName(name);

            if (!checkIfCategoryExists(name)) {
                categories.push({ name: name });
            }

            this.name = name;
            products = [];

        	return this;
		};
		
		category.add = function(product) {
			products.push(product);
		};
		
		category.remove = function(productName) {
			var product,
				index;

            product = getProductByName(productName);
            index = products.indexOf(product);

            if (index > -1) {
                products.splice(index, 1);
            }
		};
		
		return category;
	}());
	
	//shopping cart
	var shoppingCart = (function(){
		var shoppingCart = {},
            products = [];
		
		function getProductByName(name) {
            var productAsArray = products.filter(function (prod) {
                return prod.name == name;
            });

            return productAsArray[0];
        }
		
		shoppingCart.add = function() {
			products.push(product);
            return this;
		};
		
		shoppingCart.remove = function(productName) {
			var product,
				index;

                product = getProductByName(productName);
                index = products.indexOf(product);

                if (index > -1) {
                    products.splice(index, 1);
                }
		};
		
		shoppingCart.calculateTotalPrice = function() {
			var totalPrice = products.reduce(function (sum, prod) {
                return sum + prod.price;
            }, 0);

            return totalPrice;
		};
		
		return shoppingCart;
	}());
}());