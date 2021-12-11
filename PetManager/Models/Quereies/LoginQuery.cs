using Microsoft.AspNetCore.Identity;
using PetManager.Authentication;
using PetManager.DTOs.InputDTOs;

namespace PetManager.Models.Quereies
{
    public class LoginQuery : AbstractQuery<string>
    {
        private readonly CoreDbContext db;
        private User user;
        private UserCredentailsDTO userCredential;
        private string _token;
        private readonly IJwtAuth jwtAuth;
        public LoginQuery(UserCredentailsDTO _userCredential , IJwtAuth jwtAuth)
        {
            this.jwtAuth = jwtAuth;
            db = new CoreDbContext();
            userCredential = _userCredential;
            user = null;
        }


        public override void RunQuery()
        {
            user = db.Users.Where(user => user.Email == userCredential.UserName).SingleOrDefault();
            if (user != null)
            {
               // var hashedPassword = new PasswordHasher<object?>().HashPassword(null, userCredential.Password);
                var result = new PasswordHasher<object?>().VerifyHashedPassword(null, user.Password, userCredential.Password);
                
               // var hash = SecurePasswordHasher.Hash(userCredential.Password);
              //  var result = SecurePasswordHasher.Verify(userCredential.Password,user.Password);
                if (result == PasswordVerificationResult.Success)
                {
                    
                    var token = jwtAuth.Authentication(user.Email, user.Password);
                 
                   if(token != null) _token = token;
                }

            }




        }

        public override string GetResult()
        {
            return _token;
        }
    }
}
