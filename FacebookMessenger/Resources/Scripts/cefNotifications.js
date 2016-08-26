


window.Notification.prototype = {
    vibrate: {},
    icon: null,
    body : null,
    sound : null,
    sticky : false,
    renotify : false,
    noscreen : true,

    onclick : function() {},
    onerror : function() {},
    permission : "default",

    show : function() {},
    close : function() {}

}

window.Notification.prototype.requestPermission = function() {
    
}

