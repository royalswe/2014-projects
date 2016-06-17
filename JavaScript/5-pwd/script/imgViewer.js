"use strict";

var ROYAL = ROYAL || {};

ROYAL.runImgViewer = function() {

    var ImgViewer = function(){

        this.url = "http://homepage.lnu.se/staff/tstjo/labbyServer/imgviewer/";
        this.imageArr = [];
        this.galleryWindow = document.getElementById("window" + ROYAL.counter);
        
        this.init();
    };

        ImgViewer.prototype.init = function(){
            
            var that = this;

            var xhr = new XMLHttpRequest();

            xhr.onreadystatechange = function() {
                if (xhr.readyState === 4 && xhr.status === 200) {
                    that.imageArr = JSON.parse(xhr.responseText);

                    that.renderImages();
                    
                    document.querySelector(".loadingImg").remove();
                }
                else {
                    console.log("status: " + xhr.status);
                }
            };

            xhr.open("GET", this.url, true);
            xhr.send(null);
        };

        
        ImgViewer.prototype.renderImages = function(){
            var that = this;
            
            this.imageArr.forEach(function(newImage) {
                var img = document.createElement("img");
                var a = document.createElement("a");
                a.classList.add("imgContainer");
                a.setAttribute("href", "#");
                img.src = newImage.thumbURL;
                a.appendChild(img);

                a.onclick = function() {
                    var bigImg = document.createElement("img");
                    bigImg.src = newImage.URL;
                    new ROYAL.NewWindow(newImage.thumbURL, "Gallery");

                    document.querySelector("#popup" + ROYAL.counter).style.width = newImage.width + "px";
                    document.querySelector("#popup" + ROYAL.counter).style.height = newImage.height + "px";
                    document.querySelector("#window" + ROYAL.counter).style.width = newImage.width + "px";
                    document.querySelector("#window" + ROYAL.counter).style.height = newImage.height + "px";
                    document.querySelector("#window" + ROYAL.counter).appendChild(bigImg);
                    
                    document.getElementById("window" + ROYAL.counter).classList.remove("popupBody");
                    
                    document.querySelector(".loadingImg").remove();
                    //document.querySelector("#content").style.background = "url(" + newImage.URL + ")";
                };

                that.galleryWindow.appendChild(a);
            });
        };

    new ImgViewer();
};