"use strict";


window.onload = function(){
    ROYAL.Desktop();
    ROYAL.GalleryButton();
    ROYAL.RssButton();
    ROYAL.MemoryButton();
};

var ROYAL = ROYAL || {};

ROYAL = (function() {
    
    var counter = 0;  
    var windowIndex = 0;
    var topPX = 0;
    var leftPX = 0;

    function Desktop(){
        var wrapper = document.getElementById("wrapper");
        var footer = document.createElement("footer");
        var content = document.createElement("div");
        
        wrapper.appendChild(content);
        content.appendChild(footer);
        
        footer.id = "mainFooter";
        content.id = "content";
        
        //this.desktopWidth = this.content.clientWidth;
        //this.desktopHeight = this.content.clientHeight;
    }
    
    function GalleryButton(){
        var galleryImg = document.createElement("img");
        var galleryButton = document.createElement("a");
        galleryButton.setAttribute("href", "#");
        galleryImg.setAttribute("src", "pics/gallery.png");
        
        var bottom = document.getElementById("mainFooter");
        galleryButton.appendChild(galleryImg);
        bottom.appendChild(galleryButton);
        
        galleryButton.onclick = function(){
            $("head").append('<script type="text/javascript" src="script/imgViewer.js"></script>');
            new NewWindow("pics/gallery.png", "Gallery");
            new ROYAL.runImgViewer();
        };
    }
    
    function RssButton(){
        var rssImg = document.createElement("img");
        var rssButton = document.createElement("a");
        rssButton.setAttribute("href", "#");
        rssImg.setAttribute("src", "pics/rss.png");
        
        var bottom = document.getElementById("mainFooter");
        rssButton.appendChild(rssImg);
        bottom.appendChild(rssButton);
        
        rssButton.onclick = function(){
            $("head").append('<script type="text/javascript" src="script/rssFeed.js"></script>');
            new NewWindow("pics/rss.png", "Rss Feed");
            new ROYAL.runRssFeed("http://homepage.lnu.se/staff/tstjo/labbyServer/rssproxy/?url=" + escape("http://www.dn.se/m/rss/senaste-nytt"));
        };
    }
    
    function MemoryButton(){
        var memoryImg = document.createElement("img");
        var memoryButton = document.createElement("a");
        memoryButton.setAttribute("href", "#");
        memoryImg.setAttribute("src", "pics/memory.png");
        
        var bottom = document.getElementById("mainFooter");
        memoryButton.appendChild(memoryImg);
        bottom.appendChild(memoryButton);
        
        memoryButton.onclick = function(){
        	$("head").append('<script type="text/javascript" src="script/memory.js"></script>');
            $("head").append('<script type="text/javascript" src="script/random.js"></script>');
            new NewWindow("pics/memory.png", "Memory");
            new ROYAL.runMemory();
        };
    }
    
    function NewWindow(headerIcon, headerName){
        var popup = document.createElement("div");
        var popupBody = document.createElement("div");
        var popupHeader = document.createElement("header");
        var popupFooter = document.createElement("footer");
        var closeImg = document.createElement("img");
        var loadingImg = document.createElement("img");
        var icon = document.createElement("img");
        var iconName = document.createElement("p");
        var closeButton = document.createElement("a");
        var content = document.getElementById("content");
        
        ROYAL.counter +=1;
        
        
        topPX += 60;
        leftPX += 30;
        
        var Zindex = ROYAL.counter + ROYAL.windowIndex;
        
        popup.setAttribute(
        "style", "z-index:"+Zindex+"; top: "+topPX+"px; left: "+leftPX+"px;");
        
        closeButton.setAttribute("href", "#");
        closeImg.setAttribute("src", "pics/close.gif");
        loadingImg.setAttribute("src", "pics/loader.gif");
        icon.setAttribute("src", headerIcon);
        
        closeImg.className = "closeImg";
        loadingImg.className = "loadingImg";
        popup.className = "popupWindow";
        popupBody.id = "window" + ROYAL.counter;
        popup.id = "popup" + ROYAL.counter;
        popupHeader.id = "headerID";
        popupBody.className = "popupBody";
        popupHeader.className = "popupHeader";
        popupFooter.className = "popupFooter";
        iconName.innerHTML = headerName;
        
        
        closeButton.appendChild(closeImg);
        popupHeader.appendChild(closeButton);
        popupHeader.appendChild(icon);
        popupHeader.appendChild(iconName);
        popup.appendChild(popupHeader);
        popup.appendChild(popupBody);
        popupFooter.appendChild(loadingImg);
        popup.appendChild(popupFooter);
        content.appendChild(popup);
        
        popup.onclick = function(){
            ROYAL.windowIndex += 1;
            popup.style.zIndex = ROYAL.counter + ROYAL.windowIndex;
        };
        
        closeButton.onclick = function(){
            topPX -= 60;
            leftPX -= 30;
            content.removeChild(popup);
        };
    
        
    }

    
    return{
        Desktop: Desktop,
        GalleryButton: GalleryButton,
        RssButton: RssButton,
        MemoryButton: MemoryButton,
        NewWindow: NewWindow,
        counter: counter,
        windowIndex: windowIndex,
    };
    
}());