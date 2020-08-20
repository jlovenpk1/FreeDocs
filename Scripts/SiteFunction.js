
function LoginCheck(name) {
    const Wrong = "Данный логин уже существует!";
    const Good = "Логин не занят!";
    console.log("test");
    var result = $.ajax({
        url: 'LoginCheck/Registration',
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        data: { name: name.value },
        success: function (data) {
            if (data == Wrong) { $('#_loginStatus').append(data) } else
                if (data == Good) { $('#_loginStatus').append(data) }
        }
    });

}

function MailCheck(mail) {
    const Wrong = "Почта уже используется";
    const Good = "Почта свободна";
    var result = $.ajax({
        url: 'MailCheck/Registration',
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        data: { mail: mail.value },
        success: function (data) {
            if (data == Wrong) { $('#_mailStatus').append(data); } else
                if (data == Good) { $('#_mailStatus').append(data); }
        }
    });
}