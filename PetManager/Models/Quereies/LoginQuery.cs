using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PetManager.Authentication;
using PetManager.DTOs.InputDTOs;

namespace PetManager.Models.Quereies
{
    public class LoginQuery : AbstractQuery<string>
    {
        private readonly CoreDbContext db;
        private User? user;
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


        public async override Task<string> RunQuery()
        {
            user = await db.Users.Where(user => user.Email == userCredential.Email).SingleOrDefaultAsync();
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
            return ("");




        }

        public  override string GetResult()
        {
            return _token;
        }
        public User CustomerInfo()
        {
            return user;
        }
    }
}
