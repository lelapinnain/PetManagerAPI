
using Microsoft.AspNetCore.Identity;
using PetManager.Authentication;
using PetManager.DTOs.InputDTOs;

namespace PetManager.Models.NonQueries
{
    public class RegisterUserQuery : AbstractNonQuery<String>
    {
        private readonly CoreDbContext db;
       
        private UserCredentailsDTO userCredential;
        private String response;


        public RegisterUserQuery(UserCredentailsDTO _userCredential)
        {
            userCredential = _userCredential;
            db = new CoreDbContext();
            
        }
        public override void RunQuery()
        {
            var user = db.Users.Where(u=> u.Email == userCredential.Email).FirstOrDefault();
            if(user == null)
            {
                try
                {
                    var hash = new PasswordHasher<object?>().HashPassword(null, userCredential.Password);
                    User NewUser = new User()
                    {
                        Email = userCredential.Email,
                        FirstName = userCredential.FirstName,
                        LastName = userCredential.LastName,
                        Password = hash,

                    };
                    db.Add(NewUser);
                    db.SaveChanges();
                    response = "ok";
                }
                catch (Exception ex)
                {

                   response = ex.Message;
                }
               
               
            }
            else
            {
                response = "User Already Exists";
            }
            
           
        }
        public override string GetResult()
        {
            return response;
        }
    }
}
