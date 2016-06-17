"use strict";

var rows = 5;
var columns = 4;

var Memory = {

    //Memoryt
    memoryCards: [],
    //Array för att spara tillfälliga kort
    cardValues: [],
    counter: 0,
    tilesFlipped: 0,
    //Timern
    c: 0,
    t: 0,
    
    init: function(){
        
        Memory.memoryCards = new RandomGenerator.getPictureArray(rows, columns);
        console.log(Memory.memoryCards);
        
        if((rows * columns) % 2 !== 0){
            alert('Det är inte ett jämnt antal brickor');
        }
        
        window.addEventListener("load", Memory.newBoard());
        
        //Starta timern
        Memory.timedCount();
        },

        timedCount: function(){
            document.getElementById("clock").value = Memory.c;
            Memory.c = Memory.c + 1;
            Memory.t = setTimeout(function(){ Memory.timedCount() }, 1000);
        },
        
        newBoard: function(){
            var table = document.createElement('table');
            var counter = document.createElement('div');
            counter.id = 'counter';
            counter.className = "count";
            var memoryboard = document.getElementById("memoryBoard");
            memoryboard.appendChild(counter);
            memoryboard.appendChild(table);

            var cardId = 0;
            
            for(var row = 0; row < rows; row++){
            
                var tr = document.createElement('tr');
                table.appendChild(tr);
                
                    for(var col = 0; col < columns; col++){
                        var td = document.createElement('td');
                        
                        
                        var img = document.createElement("img");
                        img.setAttribute("src", "pics/0.png");
                        img.id = cardId;
                            
                        var a = document.createElement("a");
                        a.setAttribute("href", "#");
                        
                        a.appendChild(img);
                        td.appendChild(a);
                        tr.appendChild(td);
                        td.className = "icons";
                        
                        Memory.flipTile(cardId, a);
                        cardId += 1;
                    }
            }
            
        },
        
    flipTile: function(id, tile){
        
        tile.addEventListener("click", function(){
            
            var img = tile.getElementsByTagName("img")[0];

                // Om bilden är redan uppvänd går det inte att klicka på den
            if(img.getAttribute("src") !== "pics/0.png"){
                return false;
            }
            //Lägger klickade kortet i arrayen
            Memory.cardValues.push(tile);
              
            if(Memory.cardValues.length <= 2) {
                img.setAttribute("src", "pics/" + Memory.memoryCards[id] + ".png");
            }
              
            if (Memory.cardValues.length === 2){
                setTimeout(function(){
                    Memory.flipBack(Memory.cardValues);
                }, 700);
            }
        });
        
    },
        
    flipBack: function(card){
        Memory.counter +=1;
        document.getElementById('counter').innerHTML = Memory.counter + ' klick';
        //kolla om korten är samma
        if (card[0].getElementsByTagName("img")[0].getAttribute("src") === card[1].getElementsByTagName("img")[0].getAttribute("src")){
            Memory.cardValues = [];
            Memory.tilesFlipped += 2;
    		// Kolla om alla korten är uppvända
    		if(Memory.tilesFlipped === Memory.memoryCards.length){
    			alert("Grattis du klarade det på " + Memory.counter + " försök.. Klicka ok för att spela igen");
    			window.location.reload();
    		}
            }else{
                // Startbilden visas igen, arrayens innehåll töms
                card[0].getElementsByTagName("img")[0].setAttribute("src", "pics/0.png");
                card[1].getElementsByTagName("img")[0].setAttribute("src", "pics/0.png");
    
                Memory.cardValues = [];
            }
                
    },
        
        
};

window.onload = Memory.init;
    

