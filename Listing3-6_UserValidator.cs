public class UserValidator {
    private Cryptographer cryptographer;

// 乍看這個 method 只是用來處理：配對成功就回傳 true, 失敗回傳 false
    public bool checkPassword (string userName, string password) {
        User user = UserGateway.findByName (userName);
        if (user != User.Null) {
            string codedPhrase = user.getPhraseEncodeByPassword ();
            string phrase = cryptographer.decrypt (codedPhrase, password);
            if ("Valid Password".Equals (phrase)) {
                Session.initialize(); // 這邊就是會有副作用了
                return true;
            }            
        }

        return false;
    }
}

// 但其實，這是初始化使用的 method
// 改法，將 method name 改為，checkPasswordAndInitializeSession