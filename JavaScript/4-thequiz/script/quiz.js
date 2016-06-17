"use strict";

var quiz = {


  question: null,
  input: document.getElementById("input"),
  guessArr: [],
  guess: 0,

  init: function() {

    // If mouse click
    document.getElementById("send").addEventListener("click", function() {
      quiz.post(quiz.input.value, quiz.question.nextURL);
    });

    // If press enter
    quiz.input.addEventListener("keydown", function(e) {
      if (e.keyCode === 13) {
        e.preventDefault();
        quiz.post(quiz.input.value, quiz.question.nextURL);
      }
    });

    quiz.questions("http://vhost3.lnu.se:20080/question/1");
  },

  questions: function(url) {
    var xhr = new XMLHttpRequest();
    xhr.onreadystatechange = function() {
      if (xhr.readyState === 4 && xhr.status === 200) {
        quiz.question = JSON.parse(xhr.responseText);

        // Print out question
        document.getElementById("questions").innerHTML = quiz.question.question;
      }
      else { console.log("Läsfel, status: " + xhr.status); }

    };

    xhr.open("GET", url, true);
    xhr.send(null);


  },

  post: function(input, url) {

    var xhrPost = new XMLHttpRequest();
    xhrPost.onreadystatechange = function() {
      if (xhrPost.readyState === 4) {
        var answer = JSON.parse(xhrPost.responseText);


        // Clear the input field
        quiz.input.value = "";
        var message = document.getElementById("message");

        if (answer.message === "Correct answer!") {

          if (answer.nextURL !== undefined) {
            message.innerHTML = answer.message;
            quiz.guessArr.push(quiz.guess);
            quiz.guess = 0;
            quiz.questions(answer.nextURL);
          }
          else {
            // Game over
            message.innerHTML = "Antal gissningar";
            quiz.guessArr.push(quiz.guess);
            
            for (var i = 0; i < quiz.guessArr.length; i++) {
              var p = document.createElement("p");
              message.appendChild(p);
              p.innerHTML = "fråga " + [i + 1] + ": " + quiz.guessArr[i];
            }
          }

        }
        else if (answer.message === "Wrong answer! :(") {
          message.innerHTML = answer.message;
          quiz.guess += 1;
        }
      }

    };

    xhrPost.open('POST', url, true);
    xhrPost.setRequestHeader('Content-Type', 'application/json');

    var data = {
      "answer": input
    };
    console.log(data);

    // send the collected data as JSON
    xhrPost.send(JSON.stringify(data));

  }

};

window.onload = quiz.init;
