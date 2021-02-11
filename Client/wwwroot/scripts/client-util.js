function SetLocalStorage(key, value) {
    localStorage.setItem(key, value);
}

function GetLocalStorage(key) {
    localStorage.getItem(key);
}

function SetSessionStorage(key, value) {
    sessionStorage.setItem(key, value);
}

function GetSessionStorage(key) {
    sessionStorage.getItem(key);
}

function refresh() {
    window.location.href = window.location.href;
}