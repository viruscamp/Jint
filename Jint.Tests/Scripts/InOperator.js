// Arrays
var trees = new Array("redwood", "bay", "cedar", "oak", "maple");
assert(true, 0 in trees);
assert(true, 3 in trees);
assert(false, 6 in trees);
assert(false, "bay" in trees);  // returns false (you must specify the index number, not the value at that index)
assert(true, "length" in trees);  // returns true (length is an Array property)

// Predefined objects
assert(true, "PI" in Math);  

// Custom objects
var mycar = { make: "Honda", model: "Accord", year: 1998 };
assert(true, "make" in mycar);
assert(true, "model" in mycar);

var color1 = new String("green");
assert(true, "length" in color1);  

var color2 = "coral";
var error = false;
try {
    "length" in color2;   // generates an error (color is not a String object)
    error = true;
}
catch (e) {
}

assert(false, error);

