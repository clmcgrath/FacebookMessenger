﻿[Constructor(DOMString title, optional NotificationOptions options)]
interface Notification : EventTarget {
    static readonly attribute NotificationPermission permission;
    static void requestPermission(optional NotificationPermissionCallback callback);

    attribute EventHandler onclick;
    attribute EventHandler onshow;
    attribute EventHandler onerror;
    attribute EventHandler onclose;

    readonly attribute DOMString title;
    readonly attribute NotificationDirection dir;
    readonly attribute DOMString lang;
    readonly attribute DOMString body;
    readonly attribute DOMString tag;
    readonly attribute DOMString icon;

    void close();
};

dictionary NotificationOptions {
    NotificationDirection dir = "auto";
    DOMString lang = "";
    DOMString body;
    DOMString tag;
    DOMString icon;
};

enum NotificationPermission {
    "default",
    "denied",
    "granted"
};

callback NotificationPermissionCallback = void (NotificationPermission permission);

enum NotificationDirection {
    "auto",
    "ltr",
    "rtl"
};