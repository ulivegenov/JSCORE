const storage = function(){
    const appKey = 'kid_Hk_kYryQB';
    const appSecret = '27895e8d22154241b84a4e63a79e8adb';

    const getData = function(key){
        return localStorage.getItem(key + appKey);
    };

    const saveData = function(key, value){
        localStorage.setItem(key + appKey, JSON.stringify(value));
    };

    /* <-- userController's call */
    const saveUser = function(data){
        saveData('userInfo', data);
        saveData('authToken', data._kmd.authtoken); 
    };

    const deleteUser = function(){
        localStorage.removeItem('userInfo' + appKey);
        localStorage.removeItem('authToken' + appKey);
    };

    return{
        appKey,
        appSecret,
        getData,
        saveUser,
        deleteUser
    }
}();
