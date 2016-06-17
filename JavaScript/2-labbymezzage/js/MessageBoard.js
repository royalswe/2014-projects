"use strict";

var MessageBoard = {

    messages: [],


    init: function() {

        var submit = document.getElementById("submit");
        var textarea = document.getElementById("textarea");


        textarea.addEventListener("keypress", function(e) {
            if (!e) {
                e = window.event;
            }
            if (e.keyCode == 13 && !e.shiftKey) {
                e.preventDefault();
                MessageBoard.createMessage();
            }
        });

        submit.addEventListener("click", MessageBoard.createMessage, false);

    },


    createMessage: function() {
        var newMessage = document.getElementById("textarea").value;
        //Check if textarea is empty
        if (newMessage === "") {
            return false;
        }

        var mess = new Message(newMessage, new Date());

        MessageBoard.messages.push(mess);
        document.getElementById('textarea').value = "";

        MessageBoard.renderMessages();

    },

    renderMessages: function() {
        // Counter
        document.getElementById("count").innerHTML = "Antal meddelanden: " + MessageBoard.messages.length;

        document.getElementById("newText").innerHTML = "";
        for (var i = 0; i < MessageBoard.messages.length; i++) {
            MessageBoard.renderMessage(i);
        }
    },

    renderMessage: function(messageID) {
        var newText = document.getElementById("newText");
        var div = document.createElement("div");

        //Show text
        var text = document.createElement("p");
        text.innerHTML = MessageBoard.messages[messageID].getHTMLText();

        //Show time
        var time = document.createElement("p");
        time.innerHTML = MessageBoard.messages[messageID].getDate().toLocaleTimeString("sv-SE");


        div.className = "div";
        text.className = "pText";
        time.className = "pTime";

        //create delete button
        var del = document.createElement("img");
        var adel = document.createElement("a");
        adel.setAttribute("href", "#");
        adel.setAttribute("class", "delete");
        del.setAttribute("src", "img/delete.png");
        del.setAttribute("alt", "Ta bort meddelande knapp");
        del.appendChild(adel);


        //create date button
        var clock = document.createElement("img");
        var aclock = document.createElement("a");
        aclock.setAttribute("href", "#");
        aclock.setAttribute("class", "clock");
        clock.setAttribute("src", "img/Clock.png");
        clock.setAttribute("alt", "Visa datum knapp");
        clock.appendChild(aclock);


        newText.appendChild(div);
        div.appendChild(aclock);
        div.appendChild(adel);
        adel.appendChild(del);
        aclock.appendChild(clock);
        div.appendChild(text);
        div.appendChild(time);


        adel.addEventListener("click", function() {
            //Delete message and render message again
            if (confirm("Vill du verkligen radera meddelandet?") === true) {
                MessageBoard.messages.splice(messageID, 1);
                MessageBoard.renderMessages();
            }
        });

        aclock.addEventListener("click", function() {
            alert("Inlägget skapades den " + MessageBoard.messages[messageID].getDateText());
        });


    },

};

window.onload = MessageBoard.init;
