//Assign all the possible JavaScript literals to different variables.
//Try typeof on all variables you created.
//Create null, undefined variables and try typeof on them.

var literals = {
    string: 'string',
    int: 69,
    float: 3.14,
    array: [1, 'two', 3.14],
    nullVariable: null,
    undefinedVariable: undefined
}

var variables = [literals.string, literals.int, literals.float, literals.array, literals.nullVariable, literals.undefinedVariable]

for (var i = 0; i < variables.length; i+=1) {
    console.log(typeof(variables[i]));
}