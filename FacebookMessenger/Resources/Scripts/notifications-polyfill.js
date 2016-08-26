/*
 * window.Notification polyfill
 * @author Chris McGrath (http://emiliocobos.net)
 */

/* try prefixed */
if (!window.Notification) {
    window.Notification = (function () {
        return window.Notification || window.webkitNotification || window.mozNotification || window.oNotification || window.msNotification;
    })()
}

/* request pemission: */
if (window.Notification.permission === 'default') {
    window.Notification.requestPermission(/* function(permission) {} */);
}

/* If not standard (webkit first implementation) */
if (!window.Notification && window.webkitNotifications) {
    window.webkitNotifications.requestPermission();
    if (window.webkitNotifications.checkPermission() === 0) {
        window.Notification = (function () {
            var notifications_cache = {};
            return function (title, options) {
                var notification,
				tagNotifications,
				tagNotification;
                options = options || {};

                notification = window.webkitNotifications.createNotification(options.iconUrl || options.icon, title, options.body || '');

                if (options.onshow) {
                    notification.ondisplay = options.onshow;
                }

                if (options.onclick) {
                    notification.onclick = options.onclick;
                }

                if (options.onclose) {
                    notification.onclose = options.onclose;
                }

                if (options.onerror) {
                    notification.onerror = options.onerror;
                }

                if (options.tag) {
                    tagNotifications = notifications_cache[options.tag] = notifications_cache[options.tag] || [];
                    while (tagNotification = tagNotifications.shift()) {
                        tagNotification.close();
                    }
                    notifications_cache[options.tag].push(notification);
                }

                return notification;
            }
            window.Notification.requestPermission = function (cb) {
                return window.webkitNotifications.requestPermission(cb);
            }
        })()
    }
}