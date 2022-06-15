
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
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
        public async override Task<string> RunQuery()
        {
            var user = await db.Users.Where(u=> u.Email == userCredential.Email).FirstOrDefaultAsync();
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
                   await db.SaveChangesAsync();
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
            return response;
            
           
        }
        public override string GetResult()
        {
            return response;
        }
    }
}
