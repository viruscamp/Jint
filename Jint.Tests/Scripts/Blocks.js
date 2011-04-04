{ 
    { 
        { 
            var i; 
            i = 1; 
            return i; 
        }
    }
}

assert(1, i);

{ 
    var i = 1; 
} 
{ 
    i = i + 1; 
} 
{ 
    return i; 
}

assert(2, i);

var t = 10;

(function(){

    assert(t,null);

    t = 20;
    
    if (0) {
        var t = 10;
    }

})();

assert(t,10);