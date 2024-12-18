function generateRandomString(length) {
    const chars = 'ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789';
    let result = '';
    for (let i = 0; i < length; i++) {
        result += chars.charAt(Math.floor(Math.random() * chars.length));
    }
    return result;
}


function validatePassword(password) {
    // Biểu thức chính quy kiểm tra mật khẩu
    const regex = /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$/;

    // Kiểm tra mật khẩu với regex
    if (regex.test(password)) {
        return true; // Mật khẩu hợp lệ
    } else {
        return false; // Mật khẩu không hợp lệ
    }
}