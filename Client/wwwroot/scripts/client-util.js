function SetLocalStorage(key, value) {
    localStorage.setItem(key, value);
}

function GetLocalStorage(key) {
    return localStorage.getItem(key);
}

function SetSessionStorage(key, value) {
    sessionStorage.setItem(key, value);
}

function GetSessionStorage(key) {
    return sessionStorage.getItem(key);
}

function refresh() {
    window.location.href = window.location.href;
}