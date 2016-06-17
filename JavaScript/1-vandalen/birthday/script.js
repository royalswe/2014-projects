"use strict";

window.onload = function(){

	
	var birthday = function(date){
	
		if(Date.parse(date)){	
			var oneDay = 24 * 60 * 60 * 1000; // hours*minutes*seconds*milliseconds
		
			var inputDate = new Date(date);
			var today = new Date();
			
			//set time to 00:00:00
			today.setHours(0,0,0);
			//Set current year or the next year if you already had birthday this year
			inputDate.setFullYear(today.getFullYear());
			if (today > inputDate) {
			  inputDate.setFullYear(today.getFullYear() + 1);
			}
		
			var days = Math.round(Math.abs((inputDate.getTime() - today.getTime()) / (oneDay)));
			         
				return days;
		}
		else{
			throw new Error("Fel datum format");
		}

	};
	// ------------------------------------------------------------------------------


	// Kod för att hantera utskrift och inmatning. Denna ska du inte behöva förändra
	var p = document.querySelector("#value"); // Referens till DOM-noden med id="#value"
	var input = document.querySelector("#string");
	var submit = document.querySelector("#send");

	// Vi kopplar en eventhanterare till formulärets skickaknapp som kör en anonym funktion.
	submit.addEventListener("click", function(e){
		e.preventDefault(); // Hindra formuläret från att skickas till servern. Vi hanterar allt på klienten.

		p.classList.remove( "error");

		try {
			var answer = birthday(input.value); // Läser in texten från textrutan och skickar till funktionen "convertString"
			var message;
			switch (answer){
				case 0: message = "Grattis på födelsedagen!";
					break;
				case 1: message = "Du fyller år imorgon!";
					break;
				default: message = "Du fyller år om " + answer + " dagar";
					break;
			}

			p.innerHTML = message;
		} catch (error){
			p.classList.add( "error"); // Växla CSS-klass, IE10+
			p.innerHTML = error.message;
		}
	
	});



};