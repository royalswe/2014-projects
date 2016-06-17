"use strict";

var makePerson = function(persArr) {
   
   if( Object.prototype.toString.call( persArr ) != '[object Array]' ) {
      throw new Error('Det här är inte en array');
   }


   var name = persArr.map(function (names) {return names.name})
   .sort(function (a, b){ 
      return a.localeCompare(b);
   }).join(", ");
   
   
   var age = persArr.map(function (ages) { return ages.age});
   
   
   var sum = age.reduce(function(a, b) { return a + b });
   var avg = Math.round(sum / age.length);



   return{
      names: name,
      minAge: Math.min.apply(Math, age),
      maxAge: Math.max.apply(Math, age),
      averageAge: avg,
   };

};

var data = [{name: "John Häggerud", age: 37}, {name: "Johan Leitet", age: 36}, {name: "Mats Loock", age: 46}];
var result = makePerson(data);
console.log(result);


