Messenger.options = {
    extraClasses: 'messenger-fixed messenger-on-top messenger-on-center',
    theme: 'flat'
};

messager = {
    showInfo: function showInfo(msg) {
        Messenger().post({
            message: msg,
            type: 'info',
            hideAfter: 3,
            showCloseButton: true
        });
    },
    showSuccess: function showWarning(msg) {
        Messenger().post({
            message: msg,
            type: 'success',
            hideAfter: 3,
            showCloseButton: true
        });
    },
    showError: function showError(msg) {
        Messenger().post({
            message: msg,
            type: 'error',
            hideAfter: 5,
            showCloseButton: true
        });
    }
};


