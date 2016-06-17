"use strict";

var ROYAL = ROYAL || {};

ROYAL.runRssFeed = function(RssUrl) {

    var RssFeed = function() {

        this.url = RssUrl;
        this.galleryWindow = document.getElementById("window" + ROYAL.counter);
        
        this.interval();
    };
    
    RssFeed.prototype.interval = function() {
    var that = this;
    this.init();
    setInterval(function() {
        that.init();
    }, 1000);
    };
    
    RssFeed.prototype.init = function() {
        var that = this;
        var xhr = new XMLHttpRequest();

        xhr.onreadystatechange = function() {
            if (xhr.readyState === 4 && xhr.status === 200) {
                

                    that.galleryWindow.innerHTML = xhr.responseText;
                    
                if(document.querySelector(".loadingImg")){
                    document.querySelector(".loadingImg").remove();
                }
                
            }
            else {
                console.log("status: " + xhr.status);
            }
        };
        xhr.open("GET", this.url, true);
        xhr.send(null);
    };

    new RssFeed();
};