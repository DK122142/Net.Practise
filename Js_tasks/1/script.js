(function(){
    window.setInterval(function(){
        document.getElementById("clock").innerHTML = new Date().toLocaleString();
    }, 1000);
})();