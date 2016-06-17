"use strict";

var ROYAL = ROYAL || {};

ROYAL.runMemory = function(){
    

var Memory = function(){

    //Memoryt
    this.memoryCards = [];
    //Array för att spara tillfälliga kort
    this.cardValues = [];
    this.counter = 0;
    this.tilesFlipped = 0;
    this.rows = 4;
    this.columns = 4;
    
    this.init();
};
    Memory.prototype.init = function(){
        
        this.memoryCards = new RandomGenerator.getPictureArray(this.rows, this.columns);
        console.log(this.memoryCards);
        
        if((this.rows * this.columns) % 2 !== 0){
            alert('Det är inte ett jämnt antal brickor');
        }
        
        this.newBoard();
        document.querySelector(".loadingImg").remove();
        };

        
        Memory.prototype.newBoard = function(){
            var table = document.createElement('table');
            var memoryboard = document.getElementById("window" + ROYAL.counter);
            memoryboard.appendChild(table);
            
            var cardId = 0;
            
            for(var row = 0; row < this.rows; row++){
            
                var tr = document.createElement('tr');
                table.appendChild(tr);
                
                    for(var col = 0; col < this.columns; col++){
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
                        
                        this.flipTile(cardId, a);
                        cardId += 1;
                    }
            }
            
        };
    Memory.prototype.flipTile = function(id, tile){
        var that = this;
        tile.addEventListener("click", function(){
            
            var img = tile.getElementsByTagName("img")[0];

                // Om bilden är redan uppvänd går det inte att klicka på den
            if(img.getAttribute("src") !== "pics/0.png"){
                return false;
            }
            //Lägger klickade kortet i arrayen
            that.cardValues.push(tile);
              
            if(that.cardValues.length <= 2) {
                img.setAttribute("src", "pics/" + that.memoryCards[id] + ".png");
            }
              
            if (that.cardValues.length === 2){
                setTimeout(function(){
                    that.flipBack(that.cardValues);
                }, 700);
            }
        });
        
    };
                

    Memory.prototype.flipBack = function(card){
        var that = this;
        this.counter +=1;
        //kolla om korten är samma
        if (card[0].getElementsByTagName("img")[0].getAttribute("src") === card[1].getElementsByTagName("img")[0].getAttribute("src")){
            that.cardValues = [];
            that.tilesFlipped += 2;
    		// Kolla om alla korten är uppvända
    		if(that.tilesFlipped === that.memoryCards.length){
    			alert("Grattis du klarade det på " + that.counter + " försök.");
    		}
            }else{
                // Startbilden visas igen, arrayens innehåll töms
                card[0].getElementsByTagName("img")[0].setAttribute("src", "pics/0.png");
                card[1].getElementsByTagName("img")[0].setAttribute("src", "pics/0.png");
    
                that.cardValues = [];
            }
                
    };
    
    return new Memory();

};

