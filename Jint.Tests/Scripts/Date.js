d = new Date(2001, 1, 2); // Feb 2 2001
assert(2001, d.getFullYear());
assert(1, d.getMonth()); // February
assert(2, d.getDate());

d = new Date(0);
// assert(1970, d.getFullYear()); // the result can differ as the getFullYear is timezone specific (in France its 1970, in PST it's 1969)
// assert(0, d.getMonth());
// assert(1, d.getDate());

var now = new Date();

assert(now.toDateString(), new Date(Date.parse(now.toDateString())).toDateString());
assert(now.toTimeString(), new Date(Date.parse(now.toTimeString())).toTimeString());
assert(now.toString(), new Date(Date.parse(now.toString())).toString());


var d = new Date(1970, 0, 1, 0, 0, 1);
// assert(-3599000, Number(d)); // same isue: 28801000 in PST
assert(1000, Number(new Date(1000)));

assert(0, Date.UTC(1970, 0, 1));
assert(1000, Date.UTC(1970, 0, 1, 0, 0, 1));
assert(1135987200000, Date.UTC(2006, 0, 0));

assert(0, new Date(Date.UTC(0, 0, 0)).getUTCHours());
// assert(1, new Date(Date.UTC(0, 0, 0)).getHours()); // PST:16

assert(31, new Date(Date.UTC(2006, 0, 0)).getUTCDate());

